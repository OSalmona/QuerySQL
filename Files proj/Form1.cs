using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if(query.isFunction)
            {
                List<List<string>> results = op.select();

                ResultGredView.ColumnCount = results.Count;
                ResultGredView.RowCount = results[0].Count;

                for(int i=0;i< results.Count;i++)
                {
                    for(int j=0;j< results[i].Count;j++)
                    {
                        ResultGredView.Rows[j].Cells[i].Value = results[i][j];
                    }
                }
            }
            else
            {
                
            }
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