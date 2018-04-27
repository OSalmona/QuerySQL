using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Files_proj
{

    public partial class Form1 : Form
    {
        Query query = new Query();
        OP op;


        public Form1()
        {
            InitializeComponent();
            Query_Input.Enabled = false;
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.Title = "Select a XML File";
        }


        private void Excute_Btn_Click(object sender, EventArgs e)
        {
           if(openFileDialog1.FileName!=null)//regex assurance of the writting query
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    Query_Input.Enabled = true;
                    
                   
                }
            }

           

        }
        void fillDataGridView()
        {
            List<Tuple<string, List<double>>> results = op.select();

            string[] values = new string[results.Count];
            ResultGredView.ColumnCount = results.Count;
            int i = 0;
            foreach (Tuple<string, List<double>> col in results)
            {
                ResultGredView.Columns[i].Name = col.Item1;
                values[i] = col.Item2[0].ToString();
                i++;
            }

            ResultGredView.Rows.Add(values);
        }
        void Where()
        {

        }

        private void Query_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                query.OnCreate(Query_Input.Text);
                op = new OP(openFileDialog1.FileName, query);
                fillDataGridView();
               
            }
            
        }
    }
}
/* all except in will take the colum name 
 * In take the colum name and list of values */