using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FileSystemWatcherApp
{
    public partial class Form2 : Form
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;

        public Form2()
        {
            InitializeComponent();
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                using (SQLiteConnection con = new SQLiteConnection(sqlite_conn))
                {
                    try
                    {

                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        //select all files in database
                        sqlite_cmd.CommandText = "SELECT * FROM FileWatchingDB;";
        
                        // Now lets execute the SQL ;D
                        sqlite_cmd.ExecuteNonQuery();
                        listView1.Items.Clear();
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        while (sqlite_datareader.Read())
                        {
                            string extension = (string)sqlite_datareader["Extension"];
                            string fn = (string)sqlite_datareader["FileName"];
                            string type = (string)sqlite_datareader["Event"];

                            listView1.Items.Add(string.Format("{0}--{1}--{2}--", extension, fn, type));
                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }//endif
            else
            {
                using (SQLiteConnection con = new SQLiteConnection(sqlite_conn))
                {
                    try
                    {

                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        //select all files in database
                        sqlite_cmd.CommandText = "SELECT * FROM FileWatchingDB WHERE Extension = @extension;";
                        sqlite_cmd.Parameters.AddWithValue("@extension", textBox1.Text);
                        // Now lets execute the SQL ;D
                        sqlite_cmd.ExecuteNonQuery();
                        listView1.Items.Clear();
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        while (sqlite_datareader.Read())
                        {
                            string extension = (string)sqlite_datareader["Extension"];
                            string fn = (string)sqlite_datareader["FileName"];
                            string type = (string)sqlite_datareader["Event"];

                            listView1.Items.Add(string.Format("{0}--{1}--{2}--", extension, fn, type));
                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }//using
            }//end else
            
            sqlite_conn.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
