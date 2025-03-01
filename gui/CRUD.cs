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
    public partial class CRUD : Form
    {
        private Service service;
        public CRUD()
        {
            InitializeComponent();
        }

        public void SetService(Service service)
        {
            this.service = service;
            CRUD_Load();
        }

        private void CRUD_Load()
        {
            List<Hotel> hotels = service.FindAllHotels();
            dataGridView1.DataSource = hotels;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Hotel Name";
            dataGridView1.Columns["Location"].HeaderText = "Hotel Location";
            dataGridView1.Columns["Address"].HeaderText = "Hotel Address";
            dataGridView1.Columns["NoRooms"].HeaderText = "Number of Rooms";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxNoRooms.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string location = textBoxLocation.Text;
            string address = textBoxAddress.Text;
            int noRooms = int.Parse(textBoxNoRooms.Text);
            Hotel hotel = new Hotel(name, location, address, noRooms);
            service.AddHotel(hotel);
            CRUD_Load();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            string name = textBoxName.Text;
            string location = textBoxLocation.Text;
            string address = textBoxAddress.Text;
            int noRooms = int.Parse(textBoxNoRooms.Text);
            Hotel hotel = new Hotel(name, location, address, noRooms);
            hotel.Id = id;
            service.UpdateHotel(hotel);
            CRUD_Load();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            service.DeleteHotel(id);
            CRUD_Load();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CRUDOffers form = new CRUDOffers();
            form.SetHotelId(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
            form.SetService(service);
            if (!dataGridView1.IsCurrentCellInEditMode)
            {
                form.Show();
                this.Hide();
            }
            return;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
