﻿using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullStackBankProject
{
    public partial class GetAllLoginRegister : Form
    {
        public GetAllLoginRegister()
        {
            InitializeComponent();
            _RefreashGetAllLoginRegister();
        }



        private void _RefreashGetAllLoginRegister()
        {
            dgvGetAllLoginRegister.DataSource = clsLoginRegisterBusinessLayer.GetAllLoginRegister();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form1.loadForm(new ManageClients());
        }
    }
}
