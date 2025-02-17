﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankBusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace FullStackBankProject
{
    public partial class Form1 : Form
    {
        //public Form1(string UserName)
        //{
        //    InitializeComponent();

        //    labINameUser.Text = UserName.ToUpper();

        //}        


        public static Panel myPanel; // تغيير الاسم عشان ميحصلش تضارب

        public Form1()
        {
            InitializeComponent();
            myPanel = mainPanel; // دلوقتي بقى اسمه مختلف عن اللي في `Designer.cs`
        }

        public static void loadForm(Form form)
        {
            if (form == null)
                return;

            myPanel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            myPanel.Controls.Add(form);
            myPanel.Tag = form;
            form.Show();
        }


        //public  void loadForm(object form)
        //{
        //    if (this.mainPanel.Controls.Count > 0)
        //    {
        //        this.mainPanel.Controls.RemoveAt(0);
        //    }

        //    Form frm1 = form as Form;
        //    frm1.TopLevel = false;
        //    frm1.Dock = DockStyle.Fill;
        //    this.mainPanel.Controls.Add(frm1);
        //    this.mainPanel.Tag = frm1;
        //    frm1.Show();
        //}

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnlistClients_Click(object sender, EventArgs e)
        {
            loadForm(new ManageClients());
        }

        private void labINameUser_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
