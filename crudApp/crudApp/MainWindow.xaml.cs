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
using crudApp.data;

namespace crudApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDbContex dbContex;
        Product NewProduct = new Product();

        public MainWindow(ProductDbContex dbContext) //display list of product on start application
        {
            this.dbContex = dbContext;
            InitializeComponent(); //initialize app
            GetProduct(); //get products from database

            AddNewProductGrid.DataContext = NewProduct; //add products to app grid
        }

        //Read action
        private void GetProduct()
        {
            ProductList.ItemsSource = dbContex.products.ToList(); //get products from database
        }

        //Add action
        private void AddProduct(object s, RoutedEventArgs e)
        {
            dbContex.products.Add(NewProduct); //add new to database
            dbContex.SaveChanges(); //save changes
            GetProduct(); //get products from database
            NewProduct = new Product(); 
            AddNewProductGrid.DataContext = NewProduct; //add new grid to table in application
        }
        //Update action

        Product selectedProduct = new Product();
        private void UpdateProductForEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;  //select selected product to edit
            UpdateProductGrid.DataContext = selectedProduct; //display selected product data in form
            
        }
        private void UpdateProduct(object s, RoutedEventArgs e) //update button click
        {
            dbContex.Update(selectedProduct); //update selected product 
            dbContex.SaveChanges();  //save changes to database
            GetProduct(); //get products from database
        }

        //Delete Action
        private void DeleteProduct(object s, RoutedEventArgs e) //update button click
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as Product; //select selected product to edit
            dbContex.products.Remove(productToBeDeleted); //remove product
            dbContex.SaveChanges(); //save changes to database
            GetProduct(); //get products from database
        }

    }
}

