using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Products.Entity;
using Products.Exceptions;
using Products.BL;
using System.Windows.Forms;

namespace WPFProductUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowAllProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductBL objProdBL = new ProductBL();
            List<Product> prodList = objProdBL.ShowAllProducts();
            dataGrid.ItemsSource = prodList;
        }

        private void Btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            string prodName = txt_ProdName.Text;
            ProductBL objProdBL = new ProductBL();
            List<Product> prodList = objProdBL.SearchProductByName(prodName);
            dataGrid.ItemsSource = prodList;
        }

        private void Btn_SearchByID_Click(object sender, RoutedEventArgs e)
        {
            int prodID = Int32.Parse(txt_ProdID.Text);
            ProductBL objProdBL = new ProductBL();
            Product prod = objProdBL.SearchProductByID(prodID);
            Product[] arrProd = new Product[] { prod };
            dataGrid.ItemsSource = arrProd;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Product p1 = new Product();

            p1.ProductID = Int32.Parse(txt_ProdID.Text);
            p1.ProdName = txt_ProdName.Text;
            p1.ProdCategory = txt_Category.Text;
            p1.Price = Int32.Parse(txt_Price.Text);
            p1.Qty = Int32.Parse(txt_Qty.Text);

            ProductBL prodBL = new ProductBL(p1);
            bool flag = prodBL.AddProduct();
            if(flag)
            {
                System.Windows.Forms.MessageBox.Show("Record Added..!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Record Not Added..!");
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int prodID = Int32.Parse(txt_ProdID.Text);
            ProductBL objProdBL = new ProductBL();
            bool flag = objProdBL.DeleteRecord(prodID);

            if(flag)
            {
                System.Windows.Forms.MessageBox.Show("Record Deleted..!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Record Not Found..!");
            }
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            Product p1 = new Product();

            p1.ProductID = Int32.Parse(txt_ProdID.Text);
            p1.ProdName = txt_ProdName.Text;
            p1.ProdCategory = txt_Category.Text;
            p1.Price = Int32.Parse(txt_Price.Text);
            p1.Qty = Int32.Parse(txt_Qty.Text);

            ProductBL prodBL = new ProductBL(p1);
            bool flag = prodBL.UpdateRecord(p1.ProductID);
            if(flag)
            {
                System.Windows.Forms.MessageBox.Show("Record Updated..!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Unable To Update Record..!");
            }
        }
    }
}
