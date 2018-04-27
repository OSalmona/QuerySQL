using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_proj
{
   
    public partial class Form1 : Form
    {
        Query query = new Query();

        
        public Form1()
        {
            InitializeComponent();
        }


        private void Excute_Btn_Click(object sender, EventArgs e)
        {
            query.OnCreate(Query_Input.Text);
            if(query.isFunction)
            {
                Query_Input.Text = "";
                foreach (string s in query.postFixString) Query_Input.Text += s + " ";
            }

        }
        void Split()
        {

        }
        void Where()
        {

        }
        void getTable()
        {

        }
        void Sum()
        {

        }
        void avarage()
        {

        }
        void min()
        {

        }
        void max()
        {

        }
        void count()
        {

        }
        void In()
        {

        }
    }
}
/* all except in will take the colum name 
 * In take the colum name and list of values */