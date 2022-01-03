using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Transactions : Form
    {
        private Customer _customer;
        public Transactions(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            customerText.Text = _customer.CustomerName;
            _customer.CheckingAccount.OverdraftedEvent += CheckingAccount_OverdraftedEvent;
        }

        private void CheckingAccount_OverdraftedEvent(object sender, decimal e)
        {
            errorMessage.Visible = true;
        }

        private void makePurchaseButton_Click(object sender, EventArgs e)
        {
            bool paymentResult = _customer.CheckingAccount.MakePayment("Credit Card Purchase", amountValue.Value, _customer.SavingsAccount);
            amountValue.Value = 0;
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
