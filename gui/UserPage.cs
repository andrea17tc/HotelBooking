using HotelBooking.model;
using HotelBooking.service;
using HotelBooking.utils;
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
    public partial class UserPage : Form, IObserver
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
            service.AddObserver(this);
            UserPage_Load();
        }

        public void SetUserId(int userId)
        {
            this.userId = userId;
        }

        private void UserPage_Load()
        {
            List<Offer> offers = service.FindAllAvailableOffers();
            dataGridView1.DataSource = offers;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Hotel"].Visible = false;
            dataGridView1.Columns["HotelId"].Visible = false;
            dataGridView1.Columns["StartDate"].HeaderText = "Start Date";
            dataGridView1.Columns["NoNights"].HeaderText = "Number of Nights";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if the clicked cell is the first cell of the row,the hotel name, the user wants to see all the offers of the hotel
            if (e.ColumnIndex == 1)
            {
                int hotelId = (int)dataGridView1.Rows[e.RowIndex].Cells["HotelId"].Value;
                List<Offer> offers = service.FindAllOffersByHotel(hotelId);
                dataGridView1.DataSource = offers;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Hotel"].Visible = false;
                dataGridView1.Columns["HotelId"].Visible = false;
                dataGridView1.Columns["StartDate"].HeaderText = "Start Date";
                dataGridView1.Columns["NoNights"].HeaderText = "Number of Nights";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int offerId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            service.BookOffer(userId, offerId);
            MessageBox.Show("Offer booked successfully!");
            UserPage_Load();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //close the form and the application
            this.Close();
            Application.Exit();
        }

       public void Update()
        {
            UserPage_Load();
        }
    }
}
