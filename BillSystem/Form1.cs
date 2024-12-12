using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Read input values from text boxes
                double price = Convert.ToDouble(txtPrice.Text);
                double quantity = Convert.ToDouble(txtQuantity.Text);
                double discountRate = Convert.ToDouble(txtDiscount.Text);

                // Validations
                if (price <= 0)
                    throw new Exception("Price must be greater than 0.");
                if (quantity <= 0)
                    throw new Exception("Quantity must be greater than 0.");
                if (discountRate < 0)
                    throw new Exception("Discount rate cannot be negative.");

                // Calculate values
                double billAmount = price * quantity;
                double discountAmount = billAmount * (discountRate / 100);
                double netBillAmount = billAmount - discountAmount;

                // Display result
                lblNetBill.Text = $" {netBillAmount:C}";
            }
            catch (FormatException)
            {
                MessageBox.Show("maroganna epa mata kiyala .",
                                "Input Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

