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
                throw new Exception();
                return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                throw new Exception();
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                throw new Exception();
                return Convert.ToDouble(price);
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
            foreach (string _Category in ListOfProductCategory)
            {
                cbCategory.Items.Add(_Category);
            }
        }
    }
}
