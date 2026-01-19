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
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CompanyInfo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Select : Window
    {
        string connectionString =
    "Server=DDALT\\AASQLSERVER;Database=DES;Trusted_Connection=True;TrustServerCertificate=True;";

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public DataTable UsersTable { get; } = new();

        public Select()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            string sql = "SELECT Employees.emp_id, Employees.emp_first_name, Employees.emp_last_name, Departments.dep_name, Salaries.sal_m_curr, Salaries.sal_m_lm, Salaries.sal_m_2m FROM Employees " +
                "INNER JOIN Departments ON (Employees.emp_dep_id = Departments.dep_id) " +
                "INNER JOIN Salaries ON (Employees.emp_id = Salaries.sal_emp_id); ";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using SqlCommand cmd = new(sql, connection);
                connection.Open();

                using SqlDataReader reader = cmd.ExecuteReader();
                UsersTable.Clear();
                UsersTable.Load(reader);

            }
            catch
            {
                Console.WriteLine("Database Connection Error");
            }
        }
    }
}
