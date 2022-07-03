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

        public MainWindow(ProductDbContex dbContext)
        {
            this.dbContex = dbContext;
            InitializeComponent();
            GetProduct();

            AddNewProductGrid.DataContext = NewProduct;
        }

        //Read action
        private void GetProduct()
        {
            ProductList.ItemsSource = dbContex.products.ToList();
        }

        //Add action
        private void AddProduct(object s, RoutedEventArgs e)
        {
            dbContex.products.Add(NewProduct);
            dbContex.SaveChanges();
            GetProduct();
            NewProduct = new Product();
            AddNewProductGrid.DataContext = NewProduct; 
        }
        //Update action

        Product selectedProduct = new Product();
        private void UpdateProductForEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
            
        }
        private void UpdateProduct(object s, RoutedEventArgs e) //update button click
        {
            dbContex.Update(selectedProduct);
            dbContex.SaveChanges();
            GetProduct();
        }

    }
}

