using DemoLib; using DemoLib.Models; using DemoLib.Presenters; using DemoUIComponents; using MySqlX.XDevAPI; using System; using System.Data; using System.Windows.Forms;  namespace Demo {     public partial class ClientInfo : Form     {         DemoLib.Client client_ = new DemoLib.Client();         public ClientPresenter presenter_;         public ClientInfo(ClientPresenter presenter)         {             InitializeComponent();             LoadProducts();             presenter_ = presenter;             Save.Enabled = false;         }

        private void LoadProducts()
        {
            MySQLClientsModel model = new MySQLClientsModel();
            dataGridView1.DataSource = model.GetProduct();
        }




        public void SetClient(DemoLib.Client client)
        {
            client_ = client;
            CompanyNameTextBox.Text = client.Type + " " + client.Name;
            NameClients.Text = client.Director;
            PhoneNumberTextBox.Text = client.PhoneNumber;
            RatingTextBox.Text = client.Rating.ToString();
            DiscountTextBox.Text = client.Discount.ToString();



        }          private void To_Return_Click(object sender, EventArgs e)         {             this.Hide();             ClientControl CL = new ClientControl();             CL.Show();         }          private void Exit_Click_1(object sender, EventArgs e)         {             Application.Exit();         }          private void OpenEditForm_Click(object sender, EventArgs e)         {             if (string.IsNullOrWhiteSpace(CompanyNameTextBox.Text) ||                 string.IsNullOrWhiteSpace(NameClients.Text))             {                 MessageBox.Show("Поля не могут быть пустыми!");                 Save.Enabled = false;             }             else             {                 Save.Enabled = true;             }         }

        private void Save_Click_1(object sender, EventArgs e)
        {
            client_.Name = CompanyNameTextBox.Text.Split(' ')[1];
            client_.Director = NameClients.Text;
            client_.PhoneNumber = PhoneNumberTextBox.Text;

            if (int.TryParse(RatingTextBox.Text, out int rating) && rating >= 1 && rating <= 10)
            {
                client_.Rating = rating;
            }
            else
            {
                MessageBox.Show("Рейтинг должен быть числом от 1 до 10!");
                return;
            }

            presenter_.SaveClient(client_);
            MessageBox.Show("Информация о клиенте успешно сохранена!");
            this.Close();
        }
          private void CalculateDiscount(int orderSum)
        {
            if (orderSum >= 5000)
            {
                client_.Discount = 50;
            }
            else if (orderSum >= 1000)
            {
                client_.Discount = 20;
            }
            else
            {
                client_.Discount = 10;
            }
            DiscountTextBox.Text = client_.Discount.ToString(); // обновление отображения скидки
        }
    } }