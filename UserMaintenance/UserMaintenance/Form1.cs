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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        public BindingList<User> users = new BindingList<User>();
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
            
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.Write;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                foreach(User u in users)
                { sw.WriteLine(u.ID + "; " + u.FullName);
                     
                    }

                sw.Close();

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User u2 = (User)listBox1.SelectedItem;

            var u = from s in users
                     where s.ID == u2.ID
                     select s;

            users.Remove(u.FirstOrDefault());
                    
                
            

        }
    }
}
