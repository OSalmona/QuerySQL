using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Files_proj
{
    class Query
    {
        //splitted unprocessed query
        //[0]:the selection parameters 
        //[1]:the table Name 
        //[2]:the conditions if existes 
        public string[] intialQuery { get; set; }
        //selected columns
        public List<string> colNames;
        public string tableName;
        public Queue<string> postFixString;
        public bool isFunction;
        MatchCollection match;
        public void OnCreate(string userInput)
        {

            intialQuery = userInput.Split(new[] {"select","where", "from" }, StringSplitOptions.None);
            intialQuery = intialQuery.Where(w => w != "").ToArray();
            selection();
            setTableName();
            postfix();
        }
        //Specify if the query is selecting a col or a function
        //and get out the function name and prameter or the col names
        public void selection()
        {
            string re1 = "(max|min|count|avg|Sum).*?"; //function Name max,min,sum
            string re2 = "\\(.*?(\\*|[a-z][a-z0-9]+).*?\\)";   // Column Name for the function ex: max(colName)
            string re3 = "([a-z][a-z0-9]*)";//column name Name in the selection ex select colname , colname
            Regex r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            match = r.Matches(intialQuery[0]);

            if (match.Count == 0)
            {
                isFunction = false;
                r = new Regex(re3, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                match = r.Matches(intialQuery[0]);
            }
            else
                isFunction = true;

        }

        public void setTableName()
        {
            string after_from_string = intialQuery[1];
            string table_name = after_from_string;
            table_name = table_name.Replace(" ", "");

            tableName=table_name;
        }
        public string after_where_fn()
        {
            string after_from_string = intialQuery[1];
            if (!after_from_string.ToString().Contains("where"))
            {
                return null;
            }
            else
            {

                string[] s = after_from_string.ToString().Split(new[] { "where" }, StringSplitOptions.None);
                after_from_string = s[1];
                after_from_string = after_from_string.Replace(" And ", "&");
                after_from_string = after_from_string.Replace(" OR ", "||");
                return after_from_string;
            }
        }



        public bool Predecessor(string firstOperator, string secondOperator)
        {
            // (           0
            // and or      1 
            // < > = !=    2

            int firstpoint = 0; int secondpoint = 0;

            if (firstOperator == "(") // 
                firstpoint = 0;
            else if (firstOperator =='&'.ToString() || firstOperator == "||")
                firstpoint = 1;
            else if (firstOperator == ">" || firstOperator == "<" || firstOperator == "!=" || firstOperator == "=")
                firstpoint = 2;

            if (secondOperator == "(") // 
                secondpoint = 0;
            else if (secondOperator == '&'.ToString() || secondOperator == "||")
                secondpoint = 1;
            else if (secondOperator == ">" || secondOperator == "<" || secondOperator == "!=" || secondOperator == "=")
                secondpoint = 2;

            return (firstpoint >= secondpoint) ? true : false;

        }

        public  void postfix()
        {
            string infix = after_where_fn();
             infix = infix.Replace(" ", "");

            Stack<string> stack_operator = new Stack<string>();
            StringBuilder postfix = new StringBuilder();

            string arrival;
            bool cont = false;
            //  StringBuilder op = new StringBuilder();
            //  int count_and = 0;
            //  int count_or = 0;

            foreach (char X in infix.ToCharArray())
            {
                string c = X.ToString();
                if (cont) { cont = false; continue; }
                if (char.IsLetterOrDigit(c[0]))
                {
                    postfix.Append(c);
                }
                else if (c == "(")
                    stack_operator.Push(c.ToString());
                else if (c == ")")
                {
                    arrival = stack_operator.Pop().ToString();

                    while (arrival != "(")
                    {
                        postfix.Append(" ");
                        postfix.Append(arrival.ToString());

                        if (stack_operator.Count == 0)
                            break;
                        else
                            arrival = stack_operator.Pop();
                    }
                }
                else
                {
                    if (c == "|") { c = "||"; cont = true; }
                    if (c == "!") { c = "!="; cont = true; }
                    if (stack_operator.Count != 0 && Predecessor(stack_operator.Peek(), c.ToString()))
                    {
                        arrival = stack_operator.Pop();
                        while (Predecessor(arrival, c.ToString()))
                        {
                            postfix.Append(" ");
                            postfix.Append(arrival);

                            if (stack_operator.Count == 0)
                                break;
                            arrival = stack_operator.Pop();
                            if (arrival == "(")
                                break;
                        }
                        stack_operator.Push(c.ToString());
                        postfix.Append(" ");
                    }
                    else
                    {
                       
                        stack_operator.Push(c.ToString());//If Stack is empty or the operator has precedence
                        postfix.Append(" ");
                    }
                }
            }

            while (stack_operator.Count > 0)
            {
                arrival = stack_operator.Pop();
                postfix.Append(" ");
                postfix.Append(arrival);
            }

            postfix.Replace("  ", " ");

            string[] postfix_arr = postfix.ToString().Split(' ');

            postFixString= new Queue<string>(postfix_arr);

        }


    }
}