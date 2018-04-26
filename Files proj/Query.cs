using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_proj
{
    class Query
    {
        //splitted unprocessed query
        public string[] intialQuery { get; set; }
        //selected columns
        public List<string> colNames;
        public string tableName;
        public Queue<string> postFixString;

        public void OnCreate(string userInput)
        {
            intialQuery = userInput.Split(new[] { "from" }, StringSplitOptions.None);
            colNames = new List<string>(get_columns_name());
            tableName = get_table_name();
            postFixString = stack_postfix();
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

                return after_from_string;
            }
        }
        public string get_table_name()
        {
            string after_from_string = intialQuery[1];

            if (!after_from_string.ToString().Contains("where"))
            {
                string table_name = after_from_string;
                table_name = table_name.Replace(" ", "");

                return table_name;
            }
            else
            {
                string[] s = after_from_string.Split(new[] { "where" }, StringSplitOptions.None);
                string table_name = s[0];
                table_name = table_name.Replace(" ", "");

                return table_name;
            }
        }
        public List<string> get_columns_name()
        {
            string[] s_2 = intialQuery[0].Split(',');

            string[] s_3 = s_2[0].ToString().Split(new[] { "select" }, StringSplitOptions.None);
            string b = s_3[1];

            List<string> columns_name = new List<string>();
            for (int i = 0; i < s_2.Length; i++)
            {
                if (i == 0)
                {
                    b = b.ToString().Replace(" ", "");
                    columns_name.Add(b);
                }
                else
                {
                    s_2[i] = s_2[i].Replace(" ", "");
                    columns_name.Add(s_2[i]);
                }
            }

            return columns_name;
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

        public  Queue<string> stack_postfix()
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

            return new Queue<string>(postfix_arr);

        }


    }
}