using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory
{
    public class NumberFormatException : Exception
    {
        public NumberFormatException(string message) : base(message) { }
    }

    public class StringFormatException : Exception
    {
        public StringFormatException(string message) : base(message) { }
    }

    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string message) : base(message) { }
    }

    public partial class frmAddProduct : Form
    {
        private BindingSource showProductList;

        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;

        private int _Quantity;

        private double _SellPrice;

        string[] ListOfProductCategory;

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new StringFormatException("Product Name is invalid. It should only contain letters.");
            }
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
            {
                throw new NumberFormatException("Quantity is invalid. Please enter a whole number.");
            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!double.TryParse(price, out double result))
            {
                throw new CurrencyFormatException("Selling Price is invalid. Please enter a valid currency value.");
            }
            return result;
        }

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", 
                "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  foreach (string _Category in ListOfProductCategory)
            {
                cbCategory.Items.Add(_Category);
            } */
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;

                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                    _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtProductName.Clear();
                txtQuantity.Clear();
                txtSellPrice.Clear();
                richTxtDescription.Clear();
                cbCategory.SelectedIndex = -1;
                dtPickerMfgDate.Value = DateTime.Now;
                dtPickerExpDate.Value = DateTime.Now;
            }
        }
        /* _ProductName = Product_Name(txtProductName.Text);
         _Category = cbCategory.Text;
         _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
         _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
         _Description = richTxtDescription.Text;
         _Quantity = Quantity(txtQuantity.Text);
         _SellPrice = SellingPrice(txtSellPrice.Text);
         showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
         _ExpDate, _SellPrice, _Quantity, _Description));
         gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         gridViewProductList.DataSource = showProductList; */
    }
}

