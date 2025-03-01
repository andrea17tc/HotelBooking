using HotelBooking.model;
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
    public partial class CRUDOffers : Form
    {
        private Service service;
        private int hotelId;
        public CRUDOffers()
        {
            InitializeComponent();
        }

        public void SetHotelId(int hotelId)
        {
            this.hotelId = hotelId;
        }

        public void SetService(Service service)
        {
            this.service = service;
            CRUDOffers_Load();
        }

        public void CRUDOffers_Load()
        {
            List<Offer> offers = service.FindAllOffersByHotel(hotelId);
            dataGridView1.DataSource = offers;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Hotel"].Visible = false;
            dataGridView1.Columns["HotelId"].Visible = false;
            dataGridView1.Columns["StartDate"].HeaderText = "Start Date";
            dataGridView1.Columns["NoNights"].HeaderText = "Number of Nights";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //set datepicker to the value of selected row from column Start Date
            DateOnly date = (DateOnly)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            dateTimePicker1.Value = new DateTime(date.Year, date.Month, date.Day);
            dateTimePicker1.Update();
            numericUpDown1.Value = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value;
            DateOnly date = new DateOnly(d.Year, d.Month, d.Day);
            int noNights = (int)numericUpDown1.Value;
            service.AddOffer(hotelId,date,noNights);
            CRUDOffers_Load();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value;
            DateOnly date = new DateOnly(d.Year, d.Month, d.Day);
            int noNights = (int)numericUpDown1.Value;
            int id = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
            service.UpdateOffer(id, hotelId, date, noNights);
            CRUDOffers_Load();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
            service.DeleteOffer(id);
            CRUDOffers_Load();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CRUD form = new CRUD();
            form.SetService(service);
            form.Show();
            this.Close();
        }
    }
}
