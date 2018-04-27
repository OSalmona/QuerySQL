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
        public OP(string fileName,Query query)
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
            for(int i=0;i<list.Count;i++)
            {
                if (list[i].Attributes["name"].Value.ToString() == table) tablepos = i;
            }
            for (int i = 0; i < list.Count; i++)
            {
                string col = list[tablepos].ChildNodes[i].Attributes["name"].Value.ToString(); // store value of "name" attribute into col variable

                if (col == attrName) // check value at col with the wanted col given as parameter called "attrName"
                {
                    return list[tablepos].ChildNodes[i].ChildNodes;    // if true  return number of iterations (position of exact coloumn )
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
                foreach (XmlElement i in col)
                    _sum += double.Parse(i.InnerText);
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
            foreach (XmlElement i in col)
            {
                test = double.Parse(i.InnerText);
                if (test <= _min) _min = test;

            }

            return _min;
        }
        double max(string attrName)
        {
            XmlNodeList col = getCol(attrName);
            double _max = double.MinValue;
            double test = 0;
            foreach (XmlElement i in col)
            {
                test = double.Parse(i.InnerText);
                if (test >= _max) _max = test;

            }
            return _max;
        }
        double count(string attrName)
        {
            int _count = 0;
            XmlNodeList col = getCol(attrName);
            _count = col.Count;

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
            List<int> rows=new List<int>();
            Stack<string> s = new Stack<string>();
            foreach(string i in query.postFixString)
            {

            }

            return rows;

        }
        public List<List<string>> select()
        {
            List<List<string>> l =new List<List<string>>();
            if(query.isFunction)
            {
                string colName,operation;
                double tmp=0;
                
                foreach (Match m in query.match)
                {
                    colName = m.Groups[2].ToString();
                    operation = m.Groups[1].ToString();
                    if (operation == "max")
                    {
                        tmp =  max(colName) ;
                    }
                    else if (operation == "min")
                    {
                        tmp =  min(colName) ;
                    }
                    else if (operation == "avg")
                    {
                        tmp =  Avarage(colName) ;
                    }
                    else if (operation == "count")
                    {
                        tmp =  count(colName) ;
                    }
                    else if (operation == "sum")
                    {
                        tmp =  Sum(colName) ;
                    }
                    l.Add(new List<string>() { colName, tmp.ToString() });
                }
            }
            else
            {
                List<string> colNames = new List<string>();
                if (query.match[0].Groups[0].ToString() == "*")
                {

                }
                else
                {
                    foreach (Match i in query.match)
                    {
                      //  colNames.Add(i.)
                    }
                }
            }
            return l;
        }

    }
}
