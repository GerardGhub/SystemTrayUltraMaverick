using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayUltraMaverick.Store_Procedure;

namespace SystemTrayUltraMaverick
{
    public partial class frmMySystemTrayBin : Form
    {
        DataSet dSet = new DataSet();
        myclasses xClass = new myclasses();
        public frmMySystemTrayBin()
        {
            InitializeComponent();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.ShowBalloonTip(1000, "Important notice", "Something important has come up. Click this to know more.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon1.ShowBalloonTip(1000, "Important notice", "Something important has come up. Click this to know more.", ToolTipIcon.Info);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1_Tick(sender, e);
        }


        private void showSubCategoryData()      //method for loading available_menus
        {
            try
            {

                xClass.fillDataGridView(DataGridViewBindingSource, "Sub_Category", dSet);

                lbltotalrecords.Text = DataGridViewBindingSource.RowCount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
 

        }



    }
}
