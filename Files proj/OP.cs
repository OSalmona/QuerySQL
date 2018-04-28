using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Files_proj
{
    class OP
    {
        XmlNodeList list;
        XmlDocument doc;
        string table;
        Query query;
        public OP(string fileName, Query query)
        {
            this.query = query;
            this.table = query.intialQuery[1];
            getFile(fileName);
            

        }

        void getFile(string fileName)
        {
            /* get the file ready to use */
            doc = new XmlDocument(); // make an instance from XmlDocument
            doc.Load(fileName);  // load table (xml file name ) 
        }

        XmlNodeList getCol(string attrName)
        {

            list = doc.GetElementsByTagName("table"); // get elements at tag "table" & store them at list variable
                                                      // Note:[0] for first tage table  
                                                      /* Go through the table tag */
            int tablepos = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Attributes["name"].Value.ToString() == table) tablepos = i;
            }
            for (int i = 0; i < list[tablepos].ChildNodes.Count; i++)
            {
                string col = list[tablepos].ChildNodes[i].Attributes["name"].Value.ToString(); // store value of "name" attribute into col variable

                if (col == attrName) // check value at col with the wanted col given as parameter called "attrName"
                {
                    return list[tablepos].ChildNodes[i].ChildNodes;    // if true  return number of iterations (position of exact coloumn )
                }
            }
            return null;
        }
        XmlNodeList getCol()
        {

            list = doc.GetElementsByTagName("table"); // get elements at tag "table" & store them at list variable
                                                      // Note:[0] for first tage table  
                                                      /* Go through the table tag */
            int tablepos = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Attributes["name"].Value.ToString() == table)
                {
                    return list[i].ChildNodes;
                }
            }
            return null;
        }
        public double Sum(string attrName)
        {
            double _sum = 0;
            XmlNodeList col = getCol(attrName);
            if (col != null)
            {
                if(query.intialQuery.Length== 3&&query.selectedRows!=null)
                {
                    foreach (int  i in query.selectedRows)
                        if(getCol(attrName).Count>i) _sum += double.Parse(col[i].InnerText);
                }
                else
                {
                    foreach (XmlElement i in col)
                        _sum += double.Parse(i.InnerText);
                }
            }
            return _sum;
        }
        double Avarage(string attrName)
        {
            double _sum = Sum(attrName);
            double avg = _sum / count(attrName);
            return avg;
        }
        double min(string attrName)
        {
            XmlNodeList col = getCol(attrName);
            double _min = double.MaxValue;
            double test = 0;
            if (query.intialQuery.Length == 3 && query.selectedRows != null)
            {
                foreach (int i in query.selectedRows)
                    if (getCol(attrName).Count > i)
                    {
                        test = double.Parse(col[i].InnerText);
                        if (test <= _min) _min = test;
                    }
            }
            else
            {
                foreach (XmlElement i in col)
                {
                    test = double.Parse(i.InnerText);
                    if (test <= _min) _min = test;
                }
            }

            return _min;
        }
        double max(string attrName)
        {
            XmlNodeList col = getCol(attrName);
            double _max = double.MinValue;
            double test = 0;

            if (query.intialQuery.Length == 3 && query.selectedRows != null)
            {
                foreach (int i in query.selectedRows)
                    if (getCol(attrName).Count > i)
                    {
                        test = double.Parse(col[i].InnerText);
                        if (test >= _max) _max = test;
                    }
            }
            else
            {
                foreach (XmlElement i in col)
                {
                    test = double.Parse(i.InnerText);
                    if (test >= _max) _max = test;
                }
            }
            return _max;
        }
        double count(string attrName)
        {
            int _count = 0;
            if (query.intialQuery.Length == 3 && query.selectedRows != null)
            {
                foreach (int i in query.selectedRows)
                    if (getCol(attrName).Count > i)
                    {
                        _count ++;
                    }
                    else
                        break;
            }
            else
            {
                XmlNodeList col = getCol(attrName);
                _count = col.Count;
            }
            return _count;
        }
        bool In(string attrName, List<string> l)
        {
            XmlNodeList col = getCol(attrName);
            bool resulat = false;
            if (col != null)
            {
                foreach (XmlElement i in col)
                {
                    foreach (string s in l)
                        resulat = (resulat == true || i.InnerText == s) ? true : false;
                }
            }
            return resulat;
        }
        List<int> selectedRows()
        {
            List<int> rows = new List<int>();
            
            for (int i = 0; i < 20; i++)
                if (checkColumn(i)) { rows.Add(i); }
            return rows;

        }
        bool checkColumn(int i)
        {
            Stack<string> s = new Stack<string>();
            foreach (string q in query.postFixString)
            {
                if (q == ">") s.Push((greater(c(s.Pop(), i), c(s.Pop(), i)) ? "T" : "F"));

                else if (q == "<") s.Push((smaller(c(s.Pop(), i), c(s.Pop(), i))?"T":"F"));

                else if (q == "=") s.Push((equal(c(s.Pop(), i), c(s.Pop(), i)) ? "T" : "F"));

                else if (q == "!=") s.Push((notEqual(c(s.Pop(), i), c(s.Pop(), i)) ? "T" : "F"));

                else if (q == "^") s.Push((IN(c(s.Pop(), i), int.Parse((c(s.Pop(), i)).ToString())) ? "T" : "F"));

                else if (q == "!^") s.Push((!IN(c(s.Pop(), i), int.Parse((c(s.Pop(), i)).ToString())) ? "T" : "F"));

                else if (q == "&") s.Push((AND(s.Pop(),s.Pop()) ? "T" : "F"));

                else if (q == "||") s.Push((OR(s.Pop(), s.Pop()) ? "T" : "F"));

                else s.Push(c(q,i).ToString());

            }
            return ((s.Peek() == "T") ? true : false);
        }

        bool greater(double a, double b){ return (a!= double.NaN && b!=double.NaN&&b>a) ? true : false; }
        bool smaller(double a, double b){ return (a!= double.NaN && b!=double.NaN&&b<a) ? true : false; }
        bool equal(double a, double b){ return (a != double.NaN && b != double.NaN&& b == a) ? true : false; }
        bool notEqual(double a, double b){ return (a != double.NaN && b != double.NaN&& b != a) ? true : false; }
        bool equal(string a, string b){ return (a != null && b != null&& b == a ) ? true : false; }
        bool AND(string a, string b) { return ((a == "T") ? true : false)&&((b == "T") ? true : false);}
        bool OR(string a, string b) { return ((a == "T") ? true : false)||((b == "T") ? true : false); }
        bool IN(double a, int b)
        {
            foreach (double i in query.INPrameters[b])
            { if (a == i) return true; }
            return false;
        }
        double c(string d,int i)
        {
            double f;
            if (!double.TryParse(d, out f))
            {
                if(getCol(d).Count>i)
                    f = getCellValue(d, i);
                else return double.NaN;

            }
            return f;
        }
        private double getCellValue(string a, int i)
        {
            XmlNodeList l = getCol(a);
            double d = double.Parse(l[i].InnerText);
            return d;
        }

        public List<List<string>> select()
        {
            query.selectedRows=selectedRows();
            List<List<string>> l = new List<List<string>>();
            if (query.isFunction)
            {
                string colName, operation;
                double tmp = 0;

                foreach (Match m in query.match)
                {
                    colName = m.Groups[2].ToString();
                    operation = m.Groups[1].ToString();
                    if (operation == "max")
                    {
                        tmp = max(colName);
                    }
                    else if (operation == "min")
                    {
                        tmp = min(colName);
                    }
                    else if (operation == "avg")
                    {
                        tmp = Avarage(colName);
                    }
                    else if (operation == "count")
                    {
                        tmp = count(colName);
                    }
                    else if (operation == "sum")
                    {
                        tmp = Sum(colName);
                    }
                    l.Add(new List<string>() { colName, tmp.ToString() });
                }
            }
            else
            {
                if (query.match[0].Groups[0].ToString() == "*")
                {
                    XmlNodeList table = getCol();

                    for (int i = 0; i < table.Count; i++)
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(table[i].Attributes["name"].Value.ToString());
                        for (int j = 0; j < table[i].ChildNodes.Count; j++)
                        {
                            tmp.Add(table[i].ChildNodes[j].InnerText);
                        }
                        l.Add(tmp);
                    }
                }
                else
                {
                    foreach (Match m in query.match)
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(m.Groups[0].ToString());
                        XmlNodeList table = getCol(tmp[0]);
                        foreach (XmlNode i in table)
                        {
                            tmp.Add(i.InnerText);
                        }
                        l.Add(tmp);
                    }
                }
            }
            return l;
        }

        

    }
}