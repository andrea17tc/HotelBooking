using HotelBooking.service;

namespace HotelBooking
{
    public partial class Login : Form
    {
        private Service service;
        public Login(Service s)
        {
            this.service = s;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            int userId = service.login(username, password);
            if (userId != 0)
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(service, this);
            signUp.Show();
            this.Hide();
        }
    }
}
