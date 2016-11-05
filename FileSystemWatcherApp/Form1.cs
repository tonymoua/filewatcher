using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace FileSystemWatcherApp
{
    public partial class Form1 : Form
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;

        public Form1()
        {
            InitializeComponent();
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//stop
        {
            watcher.EnableRaisingEvents = false;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.Enabled = true;

            MessageBox.Show("File System Watcher has stopped!");
        }

        private void button1_Click(object sender, EventArgs e)//start
        {
            Watching.Items.Clear();
            //FileSystemWatcher watcher = new FileSystemWatcher();
            if (!(Directory.Exists(textBox1.Text)))
            {
                MessageBox.Show("Directory does not exist", "Exit", MessageBoxButtons.OK);
                return;
            }
            watcher.Path = textBox1.Text;
            watcher.Filter = comboBox1.Text;

            Watching.Items.Add("Watching...");
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.Size;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
           

            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            button3.Enabled = true;
            //need to handle when user has not path 
            //


        }
        //string result = string.Format("File {0}, {1}, Extension Type: {2}", e.FullPath, e.ChangeType, comboBox1);
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Add event details in listbox.
            this.Invoke((MethodInvoker)(() =>
                Watching.Items.Add(String.Format("{0}|{1}|{2}|{3}", e.FullPath, e.ChangeType, e.Name, DateTime.Now))));

        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
                Watching.Items.Add(String.Format("{0}|{1}|{2}|{3}", e.FullPath, e.OldFullPath, e.Name, DateTime.Now))));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0" + "\nDeveloper: Tony Moua");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == " ")
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0" + "\nDeveloper: Tony Moua");
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileSystemWatcher watcher = new FileSystemWatcher();
            if (!(Directory.Exists(textBox1.Text)))
            {
                MessageBox.Show("Directory does not exist", "Exit", MessageBoxButtons.OK);
                return;
            }
            watcher.Path = textBox1.Text;
            watcher.Filter = comboBox1.Text;

            Watching.Items.Add("Watching...");
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.Size;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;


            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            button3.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;

            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.Enabled = true;

            MessageBox.Show("File System Watcher has stopped!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //FileSystemWatcher watcher = new FileSystemWatcher();
            if (!(Directory.Exists(textBox1.Text)))
            {
                MessageBox.Show("Directory does not exist", "Exit", MessageBoxButtons.OK);
                return;
            }
            watcher.Path = textBox1.Text;
            watcher.Filter = comboBox1.Text;

            Watching.Items.Add("Watching...");
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.Size;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;


            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            button3.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;

            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.Enabled = true;

            MessageBox.Show("File System Watcher has stopped!");
        }

        private void button3_Click(object sender, EventArgs e)//write to database
        {
            if(Watching.Items.Count == 0)
            {
                button3.Enabled = false;
                MessageBox.Show("List is empty. Cannot write to database");
                return;
            }
            using(SQLiteConnection con = new SQLiteConnection(sqlite_conn))
            {
                try 
                {
                    // open the connection:
                    con.Open();
                    if(con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Database created");
                    }
                        
                    //create a new SQL command:
                    sqlite_cmd = con.CreateCommand();

                    sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FileWatchingDB (id integer AUTO_INCREMENT primary key, Extension varchar(100), FileName varchar(100), PATH varchar(250), Event varchar(100), DateTime date);";

                    // Now lets execute the SQL ;D
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                    string value = "";

                    Regex  regex = new Regex(@".{1}[a-z]{3}");

                    for (int i = 0; i < Watching.Items.Count; i++)
                    {
                        if (value != "")
                        {                 
                            value += "|";
                        }
                        value += Watching.Items[i];
                    }
                    // Now you have all the values in comma (,) separated string.

                    string[] arr = value.Split('|');
                    int j = 1;
                    int tempcount = Watching.Items.Count * 4;
                    string[] path = new string[tempcount];
                    string extension ="";
                    string sPatterns = @".{1}[a-z]{3}";
                    int count=0;
                    int x=0;
                    foreach (string s in arr)
                    {
                        path[j] = s;
                        j++;
                    }

                    for (int i = 0; i < Watching.Items.Count; i++)
                    {
                        try
                        {
                            sqlite_cmd.CommandText = "INSERT INTO FileWatchingDB (Extension, PATH,Event,FileName,DateTime) VALUES (@extension, @path, @event, @name, @date);";
                            //sqlite_cmd.Parameters.AddWithValue("@id", i+1);
                            sqlite_cmd.Parameters.AddWithValue("@path", path[count+2]);
                            extension = Path.GetExtension(path[count+2]);
                            sqlite_cmd.Parameters.AddWithValue("@extension", extension );
                            sqlite_cmd.Parameters.AddWithValue("@event", path[count+3]);
                            sqlite_cmd.Parameters.AddWithValue("@name", path[count+4]);
                            sqlite_cmd.Parameters.AddWithValue("@date", path[count+5]);
                            sqlite_cmd.ExecuteNonQuery();
                            count = count +4;
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
            }

            sqlite_conn.Close();
        }

        private void Watching_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Watching.Items.Count == 0)
            {
                button3.Enabled = false;
                MessageBox.Show("List is empty. Cannot write to database");
                return;
            }
            using (SQLiteConnection con = new SQLiteConnection(sqlite_conn))
            {
                try
                {
                    // open the connection:
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Database created");
                    }

                    //create a new SQL command:
                    sqlite_cmd = con.CreateCommand();

                    sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FileWatchingDB (id integer AUTO_INCREMENT primary key, Extension varchar(100), FileName varchar(100), PATH varchar(250), Event varchar(100), DateTime date);";

                    // Now lets execute the SQL ;D
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string value = "";

                Regex regex = new Regex(@".{1}[a-z]{3}");

                for (int i = 0; i < Watching.Items.Count; i++)
                {
                    if (value != "")
                    {
                        value += "|";
                    }
                    value += Watching.Items[i];
                }
                // Now you have all the values in comma (,) separated string.

                string[] arr = value.Split('|');
                int j = 1;
                int tempcount = Watching.Items.Count * 4;
                string[] path = new string[tempcount];
                string extension = "";
                string sPatterns = @".{1}[a-z]{3}";
                int count = 0;
                int x = 0;
                foreach (string s in arr)
                {
                    path[j] = s;
                    //MessageBox.Show("Path: "+path[j]);
                    j++;
                }

                for (int i = 0; i < Watching.Items.Count; i++)
                {
                    try
                    {
                        sqlite_cmd.CommandText = "INSERT INTO FileWatchingDB (Extension, PATH,Event,FileName,DateTime) VALUES (@extension, @path, @event, @name, @date);";
                        sqlite_cmd.Parameters.AddWithValue("@path", path[count + 2]);
                        extension = Path.GetExtension(path[count + 2]);
                        sqlite_cmd.Parameters.AddWithValue("@extension", extension);
                        sqlite_cmd.Parameters.AddWithValue("@event", path[count + 3]);
                        sqlite_cmd.Parameters.AddWithValue("@name", path[count + 4]);
                        sqlite_cmd.Parameters.AddWithValue("@date", path[count + 5]);
                        sqlite_cmd.ExecuteNonQuery();
                        count = count + 4;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            sqlite_conn.Close();
        }

        private void writeToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Watching.Items.Count == 0)
            {
                button3.Enabled = false;
                MessageBox.Show("List is empty. Cannot write to database");
                return;
            }
            using (SQLiteConnection con = new SQLiteConnection(sqlite_conn))
            {
                try
                {
                    // open the connection:
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Database created");
                    }

                    //create a new SQL command:
                    sqlite_cmd = con.CreateCommand();

                    sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FileWatchingDB (id integer AUTO_INCREMENT primary key, Extension varchar(100), FileName varchar(100), PATH varchar(250), Event varchar(100), DateTime date);";

                    // Now lets execute the SQL ;D
                    sqlite_cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string value = "";

                for (int i = 0; i < Watching.Items.Count; i++)
                {
                    if (value != "")
                    {
                        value += "|";
                    }
                    value += Watching.Items[i];
                }

                string[] arr = value.Split('|');
                int j = 1;
                int tempcount = Watching.Items.Count * 4;
                //MessageBox.Show("count"+tempcount);
                string[] path = new string[tempcount];
                string extension = "";
                string sPatterns = @".{1}[a-z]{3}";
                int count = 0;
                int x = 0;
                foreach (string s in arr)
                {
                    path[j] = s;
                    //MessageBox.Show("Path: "+path[j]);
                    j++;
                }

                for (int i = 0; i < Watching.Items.Count; i++)
                {
                    try
                    {
                        sqlite_cmd.CommandText = "INSERT INTO FileWatchingDB (Extension, PATH,Event,FileName,DateTime) VALUES (@extension, @path, @event, @name, @date);";
                        //sqlite_cmd.Parameters.AddWithValue("@id", i+1);
                        sqlite_cmd.Parameters.AddWithValue("@path", path[count + 2]);
                        extension = Path.GetExtension(path[count + 2]);
                        sqlite_cmd.Parameters.AddWithValue("@extension", extension);
                        sqlite_cmd.Parameters.AddWithValue("@event", path[count + 3]);
                        sqlite_cmd.Parameters.AddWithValue("@name", path[count + 4]);
                        sqlite_cmd.Parameters.AddWithValue("@date", path[count + 5]);
                        sqlite_cmd.ExecuteNonQuery();
                        count = count + 4;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
                //string txtSqlQuery  = String.Format("INSERT INTO Book (Id, Title, Language, PublicationDate, Publisher, Edition, OfficialUrl, Description, EBookFormat) VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",book.Id, book.Title, book.Language, book.PublicationDate, book.Publisher, book.Edition, book.OfficialUrl, book.Description, book.EBookFormat);


            }

            sqlite_conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)//Query database
        {
            Form2 secondForm;
            secondForm = new Form2();
            secondForm.ShowDialog();
            
            button4.Enabled = true;


        }

        private void queryDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 secondForm;
            secondForm = new Form2();
            secondForm.ShowDialog();
            button4.Enabled = true;
        }

    }

    
}
