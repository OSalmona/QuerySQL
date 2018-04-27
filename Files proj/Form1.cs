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
        }


        private void Excute_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.Title = "Select a XML File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
            }

            query.OnCreate(Query_Input.Text);
            op=new OP(openFileDialog1.FileName,query.intialQuery[1]);

            Query_Input.Text = op.Sum(query.match[0].Groups[0].ToString()).ToString();
          

        }

        void Where()
        {

        }
        
    }
}
/* all except in will take the colum name 
 * In take the colum name and list of values */