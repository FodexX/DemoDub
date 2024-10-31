using DemoLib;
using DemoLib.Presenters;
using DemoUIComponents;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Demo
{
    public partial class ClientInfo : Form
    {
        Client client_ = new Client();
        private ClientPresenter presenter_;
        public ClientInfo()
        {
            InitializeComponent();

            Save.Enabled = false;
        }

        public void SetClient(Client client)
        {
            CompanyNameTextBox.Text = client.Type + " " + client.Name;
            NameClients.Text = client.Director;
            PhoneNumberTextBox.Text = client.PhoneNumber;
            RatingTextBox.Text = client.Rating.ToString();
            DiscountTextBox.Text = client.Discount.ToString();
        }

        private void To_Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientControl CL = new ClientControl();
            CL.Show();
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenEditForm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CompanyNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameClients.Text))
            {
                MessageBox.Show("Поля не могут быть пустыми!");
                Save.Enabled = false;
            }
            else
            {
                Save.Enabled = true;
            }
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            client_.Name = CompanyNameTextBox.Text.Split(' ')[1];
            client_.Director = NameClients.Text;
            client_.PhoneNumber = PhoneNumberTextBox.Text;
            client_.Rating = int.Parse(RatingTextBox.Text);
            client_.Discount = int.Parse(DiscountTextBox.Text);

            presenter_.UpdateClient(client_);

            MessageBox.Show("Информация о клиенте успешно сохранена!");

            this.Close();
        }
    }
}