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
    public partial class WithdrawScreen : Form
    {
        public WithdrawScreen()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form1.loadForm(new ManageTransactions());
        }






        private void ClearAllTbox()
        {
            TboxAccountNumber.Text = "";
            TboxAccountBalance.Text = "";
            TboxClientID.Text = "";
            TboxFirstName.Text = "";
            TboxLastName.Text = "";
            TboxEmail.Text = "";
            TboxPhone.Text = "";
            TboxCity.Text = "";
            TboxCountry.Text = "";
            TboxEntertheWithdrawAmount.Text = "";
            TboxEntertheWithdrawAmount.Visible = false;
            BtnClear.Visible = false;
            BtnWithdraw.Visible = false;
        }

        private void BtnSerach_Click(object sender, EventArgs e)
        {
            clsTransactionsBusinessLayer FullInfoClientAndAccountClient = clsTransactionsBusinessLayer.GetAllInfoClient_Account(TboxAccountNumber.Text);


            if (FullInfoClientAndAccountClient != null)
            {
                TboxAccountBalance.Text = FullInfoClientAndAccountClient.AccountBalance.ToString();
                TboxClientID.Text = FullInfoClientAndAccountClient.ClientID.ToString();
                TboxFirstName.Text = FullInfoClientAndAccountClient.FirstName.ToString();
                TboxLastName.Text = FullInfoClientAndAccountClient.LastName.ToString();
                TboxEmail.Text = FullInfoClientAndAccountClient.Email.ToString();
                TboxPhone.Text = FullInfoClientAndAccountClient.Phone.ToString();
                TboxCity.Text = FullInfoClientAndAccountClient.City.ToString();
                TboxCountry.Text = FullInfoClientAndAccountClient.Country.ToString();
                TboxEntertheWithdrawAmount.Visible = true;
                BtnClear.Visible = true;
                BtnWithdraw.Visible = true;
            }
            else
            {
                MessageBox.Show("Account data retrieval failed. Please enter a valid account number", "Error The account data retrieval process failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            clsAccountBusinessLayer Account = clsAccountBusinessLayer.FindAccountByAccountNumber(TboxAccountNumber.Text);
            if (Account != null)
            {
                int Amount = Convert.ToInt32(TboxEntertheWithdrawAmount.Text);

                if (Amount > 0 && Amount <= Account.AccountBalance)
                {
                    Account.AccountBalance -= Convert.ToInt32(TboxEntertheWithdrawAmount.Text);
                    if (Account.Save())
                    {
                        MessageBox.Show($"The process was completed successfully, and an amount has been deposited {TboxEntertheWithdrawAmount.Text} into the account [ {Account.AccountNumber} ]", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAllTbox();
                    }
                    else
                    {
                        MessageBox.Show($"The process has failed. Please try again correctly.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show($"Error: Please enter a value less than the current account balance, and do not enter a negative value This is the current account balance [ {Account.AccountBalance} ]", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }


        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllTbox();
        }
    }
}
