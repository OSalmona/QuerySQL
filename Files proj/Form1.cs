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
            Excute.Enabled = false;

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
                    Excute.Enabled = true;


                }
            }

           

        }
        void fillDataGridView()
        {

            List<List<string>> results = op.select();

            ResultGredView.ColumnCount = results.Count;

            int x = 0;
            for (int i = 0; i < results.Count; i++)
                if (x < results[i].Count) x = results[i].Count;

            for(int i=0;i<results.Count;i++)
            {
                int j = 0;
                for (j = results[i].Count; j < x; j++) results[i].Add("");
            }
            
            ResultGredView.RowCount = x;

            for (int j = 0; j < x; j++)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    ResultGredView.Rows[j].Cells[i].Value = results[i][j];
                }
            }
            for (int i = 0; i < ResultGredView.ColumnCount; i++)
            {
                ResultGredView.Columns[i].Name = results[i][0];
            }
            ResultGredView.Rows.Remove(ResultGredView.Rows[0]);

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

        private void button1_Click(object sender, EventArgs e)
        {
            query.OnCreate(Query_Input.Text);
            op = new OP(openFileDialog1.FileName, query);
            fillDataGridView();
        }
    }
}
/* all except in will take the colum name 
 * In take the colum name and list of values */