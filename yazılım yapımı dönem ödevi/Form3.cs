﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yazılım_yapımı_dönem_ödevi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HVCUDKM;Initial Catalog=yazılım yapım;Integrated Security=True");
        private void veriler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *From ogrencigiris",baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["sifre"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        int id = 0;
            
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update ogrencigiris set ad='" + textBox1.Text.ToString() + "',sifre='" + textBox2.Text.ToString() + "'where id =" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler(); 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            veriler();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
