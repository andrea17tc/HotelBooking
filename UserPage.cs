using HotelBooking.service;
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
    public partial class UserPage : Form
    {
        private Service service;
        private int userId;
        public UserPage()
        {
            InitializeComponent();
        }

        public void SetService(Service service)
        {
            this.service = service;
            UserPage_Load();
        }

        internal void SetUserId(int userId)
        {
            this.userId = userId;
        }

        private void UserPage_Load()
        {
            throw new NotImplementedException();
        }
    }
}
