using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CompanyInfo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Delete : Window
    {
        string connectionString =
    "Server=DDALT\\AASQLSERVER;Database=DES;Trusted_Connection=True;TrustServerCertificate=True;";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public Delete()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Submit_Dep_Click(object sender, RoutedEventArgs e)
        {
            string sql =
            "DELETE FROM Departments " +
            "WHERE dep_id = @DepID;";

            if (string.IsNullOrEmpty(Dep_ID_Input.Text))
            {
                Console.WriteLine("Departments input cannot be empty!");
            }
            else
            {
                int DID = int.Parse(Dep_ID_Input.Text);
                
                Console.WriteLine(DID);
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Departments connected successfully");
                    try
                    {
                        SqlCommand sc = new SqlCommand(sql, connection);
                        sc.Parameters.AddWithValue("@DepID", DID);
                        sc.ExecuteNonQuery();
                        Console.WriteLine("Departments deleted successfully");
                        connection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Departments Invalid Input Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Departments Connection Error");
                }
            }

            this.Close();
        }
        private void Submit_Emp_Click(object sender, RoutedEventArgs e)
        {
            string sql1 =
            "DELETE FROM Salaries " +
            "WHERE sal_emp_id = @EmpID; " +
            "DELETE FROM Employees " +
            "WHERE emp_id = @EmpID; ";
            

            if (string.IsNullOrEmpty(Emp_ID_Input.Text))
            {
                Console.WriteLine("Employee inputs cannot be empty!");
            }
            else
            {
                int EID = int.Parse(Emp_ID_Input.Text);
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Employee connected successfully");
                    try
                    {
                        SqlCommand sc = new SqlCommand(sql1, connection);
                        sc.Parameters.AddWithValue("@EmpID", EID);
                       
                        Console.WriteLine(EID); 

                        sc.ExecuteNonQuery();

                        Console.WriteLine("Employee deleted successfully");

                        connection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Employee Invalid Input Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Employee Connection Error");
                }
            }

            this.Close();
        }
        private void SubmitAll_Click(object sender, RoutedEventArgs e)
        {
            Submit_Dep_Click(sender, e);
            Submit_Emp_Click(sender, e);
            this.Close();
        }
    }
}
