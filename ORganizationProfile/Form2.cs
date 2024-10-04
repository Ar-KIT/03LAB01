using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORganizationProfile
{
    public partial class FrmConfirmation : Form
    {
        public FrmConfirmation()
        {
            InitializeComponent();
        }
        private void FrmConfirmation_Load(object sender, EventArgs e)
        {

            lblStudentInfo.Text = StudentInformationCLass.SetStudentNo.ToString();
            lblName.Text = StudentInformationCLass.SetFullName;
            lblProgram.Text = StudentInformationCLass.SetProgram;
            lblBirthday.Text = StudentInformationCLass.SetBirthday;
            lblGender.Text = StudentInformationCLass.SetGender;
            lblContactNo.Text = "+63" + StudentInformationCLass.SetContactNo.ToString();
            lblAge.Text =  StudentInformationCLass.SetAge.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
