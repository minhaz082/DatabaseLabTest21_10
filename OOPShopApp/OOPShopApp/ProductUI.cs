using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPShopApp.BLL;
using OOPShopApp.DAL.DAO;

namespace OOPShopApp
{
    public partial class ProductUI : Form
    {
        public ProductUI()
        {
            InitializeComponent();
        }

        private ProductBll aProductBll = new ProductBll();
        private void saveButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.Code = codeTextBox.Text;
            aProduct.Name = nameTextBox.Text;
            aProduct.Quantity = Convert.ToInt16(quantityTextBox.Text);
            string msg = aProductBll.SaveProduct(aProduct);
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            quantityTextBox.Text = "";
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            int total = 0;
            int length = 0;
            List<Product> productDetailsList = aProductBll.GetAllProduct();
            foreach (var product in productDetailsList)
            {
                ListViewItem anItem = new ListViewItem(product.Code);
                anItem.SubItems.Add(product.Name);
                anItem.SubItems.Add(product.Quantity.ToString());
                productListView.Items.Add(anItem);
                total += product.Quantity;
                totalQuantityTextBox.Text = total.ToString();
                length = product.Name.Length;
            }

        }
    }
}
