﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiaApp
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da = DataAdapter.dataAd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = AzureCon.ConnectionString;
            DataSet ds = new DataSet();
            
            using(SqlConnection conn = new SqlConnection(connStr)){
                try
                {
                    conn.Open();
                    da.Fill(ds);

                    comboBox1.DataSource = ds.Tables[0].DefaultView;



                    comboBox1.DataSource = ds.Tables[0].DefaultView ;
                        
                        
                
                    comboBox1.DisplayMember = "ID";
                    comboBox1.ValueMember = "Namn";
                    comboBox1.SelectedIndex = -1;
                 
                    
                    DataGridKlassView.DataSource = klasstable;
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Encryption.ToggleConfigEncryption();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                label1.Text = comboBox1.SelectedValue.ToString();
                label2.Text =((DataRowView)comboBox1.SelectedItem)["ClassNamn"].ToString();
            }
            else
            {
                label1.Text = "";
                label2.Text = "";
            }
        }

        private void comboBoxKlasser_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}
