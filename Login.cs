using HotelBooking.service;
using log4net;

namespace HotelBooking
{
    public partial class Login : Form
    {
        private Service service;
        private static readonly ILog Log = LogManager.GetLogger(typeof(Login));

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
                Log.Info("Login successful");
                if(username == "admin")
                {
                    CRUD crud = new CRUD();
                    crud.SetService(service);
                    crud.Show();
                    this.Hide();
                }
                else
                {
                    UserPage userPage = new UserPage();
                    userPage.SetUserId(userId);
                    userPage.SetService(service);
                    userPage.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Login failed");
                Log.Info("Login failed");
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
