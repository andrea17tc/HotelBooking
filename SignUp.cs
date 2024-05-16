using HotelBooking.service;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class SignUp : Form
    {
        private Service service;
        private Login loginWindow;
        private static readonly ILog Log = LogManager.GetLogger(typeof(SignUp));

        public SignUp(Service s, Login loginWindow)
        {
            service = s;
            this.loginWindow = loginWindow;
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            if (textBoxUsername.Text.Trim() == "")
            {
                labelUsername.Text = "Username cannot be empty";
                labelUsername.ForeColor = Color.Red;
                labelUsername.Font = new Font(labelUsername.Font, FontStyle.Bold);
                valid = false;
            }
            if (textBoxPassword.Text.Trim() == "")
            {
                labelPassword.Text = "Password cannot be empty";
                labelPassword.ForeColor = Color.Red;
                labelPassword.Font = new Font(labelPassword.Font, FontStyle.Bold);
                valid = false;
            }
            if (textBoxFirstName.Text.Trim() == "")
            {
                labelFirstName.Text = "First name cannot be empty";
                labelFirstName.ForeColor = Color.Red;
                labelFirstName.Font = new Font(labelFirstName.Font, FontStyle.Bold);
                valid = false;
            }
            if (textBoxLastName.Text.Trim() == "")
            {
                labelLastName.Text = "Last name cannot be empty";
                labelLastName.ForeColor = Color.Red;
                labelLastName.Font = new Font(labelLastName.Font, FontStyle.Bold);
                valid = false;
            }
            //check if username doesnt have more than 30 characters
            if (textBoxUsername.Text.Length > 30)
            {
                labelUsername.Text = "Username cannot have more than 30 characters";
                labelUsername.ForeColor = Color.Red;
                labelUsername.Font = new Font(labelUsername.Font, FontStyle.Bold);
                valid = false;
            }
            //check if password doesnt have more than 30 characters
            if (textBoxPassword.Text.Length > 30)
            {
                labelPassword.Text = "Password cannot have more than 30 characters";
                labelPassword.ForeColor = Color.Red;
                labelPassword.Font = new Font(labelPassword.Font, FontStyle.Bold);
                valid = false;
            }
            //check if date of birth is selected
            Console.WriteLine(dateTimePicker1.Value);
            if (dateTimePicker1.Value.Date != DateTime.Now.Date)
            {
                //if user doesnt have 18 years old
                if (DateTime.Now.Year - dateTimePicker1.Value.Year < 18)
                {
                    labelDateOfBirth.Text = "You must be at least 18 years old";
                    labelDateOfBirth.ForeColor = Color.Red;
                    labelDateOfBirth.Font = new Font(labelDateOfBirth.Font, FontStyle.Bold);
                    valid = false;
                }
            }

            if(valid)
            {
                string username = textBoxUsername.Text;
                if (service.findByUsername(username))
                {
                    MessageBox.Show("Username already exists");
                    Log.Info("Username already exists");
                    return;
                }
                string password = textBoxPassword.Text;
                string firstName = textBoxFirstName.Text;
                string lastName = textBoxLastName.Text;
                string? dateOfBirth = null;
                if(dateTimePicker1.Value.Date != DateTime.Now.Date)
                    dateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string? address = null;
                if(textBoxAddress.Text.Trim() != "")
                {
                    address = textBoxAddress.Text;
                }
                try
                {
                    service.createUser(username, password, firstName, lastName, dateOfBirth, address);
                    MessageBox.Show("Account created successfully");
                    Log.Info("Account created successfully");
                    loginWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating account");
                    Log.Error("Error creating account", ex);
                    return;
                }
                this.Close();
            }

        }
    }
}
