using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2();
            // Set the Parent Form of the CHild window
            newMDIChild.MdiParent = this;
            // Display the new form
            newMDIChild.Show();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgBox = new OpenFileDialog();

            dlgBox.ShowDialog();
        }
        
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            if(activeChild != null)
            {
                try
                {
                    RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Put the selected text on the Clipboard
                        Clipboard.SetDataObject(theBox.SelectedText);
                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a RichTextBox");
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            if (activeChild != null)
            {
                try
                {
                    RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Create new instance of DataObject interface
                        IDataObject data = Clipboard.GetDataObject();

                        // If the data is text, then set the text of the RichTextBox to the text in the clipboard
                        if (data.GetDataPresent(DataFormats.Text))
                        {
                            theBox.SelectedText = data.GetData(DataFormats.Text).ToString();
                        }
                       
                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a RichTextBox");
                }
            }
        }
    }
}
