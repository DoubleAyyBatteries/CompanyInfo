using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CompanyInfo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private string connectionString =
        @"Data Source=.\AASQLSERVER;Initial Catalog=NORTHWIND;Integrated Security=SSPI";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            var insertWindow = new Insert();
            insertWindow.Activate();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var DeleteWindow = new Delete();
            DeleteWindow.Activate();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var UpdateWindow = new Update();
            UpdateWindow.Activate();
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            var SelectWindow = new Select();
            SelectWindow.Activate();
        }

    }
}
