using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;

        private int _Quantity;

        private double _SellPrice;

        string[] ListOfProductCategory;

        public frmAddProduct()
        {
            InitializeComponent();
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
