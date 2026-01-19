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
    public sealed partial class Update : Window
    {
        string connectionString =
    "Server=DDALT\\AASQLSERVER;Database=DES;Trusted_Connection=True;TrustServerCertificate=True;";

        public Update()
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
            "UPDATE Departments " +
            "SET dep_name = @DepName " +
            "WHERE dep_id = @DepID;";

            if (string.IsNullOrEmpty(Dep_ID_Input.Text) || string.IsNullOrEmpty(Dep_Name_Input.Text))
            {
                Console.WriteLine("Departments input cannot be empty!");
            }
            else
            {
                string DNI = Dep_Name_Input.Text;
                int DID = int.Parse(Dep_ID_Input.Text);
                Console.WriteLine(DNI);
                Console.WriteLine(DID);
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Departments connected successfully");
                    try
                    {
                        SqlCommand sc = new SqlCommand(sql, connection);
                        sc.Parameters.AddWithValue("@DepName", DNI);
                        sc.Parameters.AddWithValue("@DepID", DID);
                        sc.ExecuteNonQuery();
                        Console.WriteLine("Departments updated successfully");
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
            "UPDATE Employees " +
            "SET emp_first_name = @EmpFirstName, emp_last_name = @EmpLastName, emp_dep_id = @EmpDepID " +
            "WHERE emp_id = @EmpID; " +
            "UPDATE Salaries " +
            "Set sal_m_curr = @SalCurrM, sal_m_lm = @SalLastM, sal_m_2m = @Sal2M " +
            "WHERE sal_emp_id = @EmpID; ";

            if (string.IsNullOrEmpty(Emp_ID_Input.Text) ||
                string.IsNullOrEmpty(Emp_FName_Input.Text) ||
                string.IsNullOrEmpty(Emp_LName_Input.Text) ||
                string.IsNullOrEmpty(Emp_DepID_Input.Text) ||
                string.IsNullOrEmpty(Emp_Current_Sal_Input.Text) ||
                string.IsNullOrEmpty(Emp_LM_Sal_Input.Text) ||
                string.IsNullOrEmpty(Emp_2M_Sal_Input.Text)
                )
            {
                Console.WriteLine("Employee inputs cannot be empty!");
            }
            else
            {
                int EID = int.Parse(Emp_ID_Input.Text);
                string EFN = Emp_FName_Input.Text;
                string ELN = Emp_LName_Input.Text;
                int EDID = int.Parse(Emp_DepID_Input.Text);
                int CurrSal = int.Parse(Emp_Current_Sal_Input.Text);
                int LastMSal = int.Parse(Emp_LM_Sal_Input.Text);
                int TwoMSal = int.Parse(Emp_2M_Sal_Input.Text);
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Employee connected successfully");
                    try
                    {
                        SqlCommand sc = new SqlCommand(sql1, connection);
                        sc.Parameters.AddWithValue("@EmpID", EID);
                        sc.Parameters.AddWithValue("@EmpFirstName", EFN);
                        sc.Parameters.AddWithValue("@EmpLastName", ELN);
                        sc.Parameters.AddWithValue("@EmpDepID", EDID);
                        sc.Parameters.AddWithValue("@SalCurrM", CurrSal);
                        sc.Parameters.AddWithValue("@SalLastM", LastMSal);
                        sc.Parameters.AddWithValue("@Sal2M", TwoMSal);

                        Console.WriteLine(EID);
                        Console.WriteLine(EFN);
                        Console.WriteLine(ELN);
                        Console.WriteLine(EDID);
                        Console.WriteLine(CurrSal);
                        Console.WriteLine(LastMSal);
                        Console.WriteLine(TwoMSal);

                        sc.ExecuteNonQuery();

                        Console.WriteLine("Employee updated successfully");

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
