using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Files_proj
{
    class OP
    {
        XmlNodeList list;
        XmlDocument doc;
        string table;
        public OP(string fileName,string table)
        {
            this.table = table;
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
    }
}
