using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;


namespace winformsAndDatabase
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        List<Seller> sellers = new List<Seller>();
        public Form1()
        {
            InitializeComponent();

            var builde = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "ingatlanok"
            };

            connection = new MySqlConnection(builde.ConnectionString); 
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sellers ORDER BY name";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Seller tmp = new Seller();
                tmp.Id = reader.GetInt32("id");
                tmp.Name = reader.GetString("name");
                tmp.Phone = reader.GetString("phone");
                sellers.Add(tmp);
                listBox1.Items.Add(tmp.Name);
            }
            reader.Close();
        }

        class Ad
        {
            public int Area;
            public int Id;
            public int Floors;
            public int Rooms;
            public string Description;
            public string ImageUrl;
            public string LatLong;
            public bool FreeOfCharge;
            public Category Category;
            public Seller Seller;
            public DateTime CreateAt;
            public static List<Ad> LoadFromCsv(string fileName)
            {
                string[] sorok = File.ReadAllLines(fileName, Encoding.UTF8).Skip(1).ToArray();
                List<Ad> ads = new List<Ad>();

                foreach (var item in sorok)
                {
                    Ad ad = new Ad();
                    var columns = item.Split(';');
                    ad.Id = int.Parse(columns[0]);
                    ad.Area = int.Parse(columns[4]);
                    ad.Floors = int.Parse(columns[3]);
                    ad.Rooms = int.Parse(columns[1]);
                    ad.Description = columns[5];
                    ad.ImageUrl = columns[7];
                    ad.LatLong = columns[2];
                    ad.FreeOfCharge = columns[6] == "1";
                    ad.Category = new Category()
                    {
                        Id = int.Parse(columns[12]),
                        Name = columns[13],
                    };
                    ad.Seller = new Seller()
                    {
                        Id = int.Parse(columns[9]),
                        Name = columns[10],
                        Phone = columns[11]
                    };
                    ad.CreateAt = DateTime.Parse(columns[8]);
                    ads.Add(ad);
                }
                return ads;
            }

            public double DistanceTo(string coord)
            {
                double a = double.Parse(coord.Split(',')[0]);
                double b = double.Parse(coord.Split(',')[1]);

                var x = Math.Abs(a - double.Parse(LatLong.Split(',')[0]));
                var y = Math.Abs(b - double.Parse(LatLong.Split(',')[1]));

                return Math.Sqrt(x * x + y * y);

            }
            public override string ToString()
            {
                return ($"\tEladó neve\t: {Seller.Name}\n\tEladó telefonja: {Seller.Phone}\n\tAlapterület\t:{Area}\n\tSzobák száma\n: {Rooms}");
            }

        }

        class Seller
        {
            public int Id;
            public string Name;
            public string Phone;
        }

        class Category
        {
            public int Id;
            public string Name;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            label2.Text = "Eladó neve: " + sellers[index].Name;
            label4.Text = "Telefonszám: " + sellers[index].Phone;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;

            var sellerId = sellers[listBox1.SelectedIndex].Id;
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM realestates WHERE sellerId = @id";
            cmd.Parameters.AddWithValue("@id", sellerId);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            label6.Text = count.ToString();
        }
    }
}
