using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ORganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new String[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for(int i=0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new String[]
            {
                "Male",
                "Female",
                "Optimus Prime",
            };
            for (int i = 0; i < 3; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
                return _StudentNo;
            }
            catch
            {
                throw new ArgumentNullException("'Student No' cannot be Parse or empty");
            }
        }
        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Invalid Input at 'Contact No'");
                }

                return _ContactNo;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            
        }
        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial + ".";
                }
                else
                {
                    throw new FormatException("Invalid Input at 'FullName'. Please Input Alphabets [a-zA-Z] only");
                }

                return _FullName;
            }
            catch (FormatException e) {
                MessageBox.Show(e.Message);
                return " ";
            }
            
        }
        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                    return _Age;
                }
                else
                {
                    throw new FormatException("Invalid Input at 'Age'. Must input Numerical Value/ Digits");
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationCLass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationCLass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationCLass.SetProgram = cbPrograms.Text;
                StudentInformationCLass.SetGender = cbGender.Text;
                StudentInformationCLass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationCLass.SetAge = Age(txtAge.Text);
                StudentInformationCLass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");
            }
            catch
            {

            }
            finally
            {
                FrmConfirmation frm = new FrmConfirmation();
                frm.ShowDialog();
            }
            
        }
    }

    public class StudentInformationCLass
    {
        public static long SetStudentNo = 0;
        public static long SetContactNo = 0;
        public static int SetAge = 0;
        public static string SetProgram = " ";
        public static string SetGender = " ";
        public static string SetBirthday = " ";
        public static string SetFullName = " ";
    }
}
