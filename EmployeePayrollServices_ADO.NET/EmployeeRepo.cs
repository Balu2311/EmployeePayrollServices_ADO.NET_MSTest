using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServices_ADO.NET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool EstablishConnection()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    Console.WriteLine("Database_Connected_Successfully....");
                    connection.Close();
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Database_NOT_Connected!!!");
                return false;
            }
        }
        public int GetAllRecords()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select * from Employee_Payroll";

                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            count++;
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = Convert.ToDouble(dr.GetDecimal(2));
                            employeeModel.start_date = dr.GetDateTime(3);
                            employeeModel.gendre = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Deduction = dr.GetDouble(8);
                            employeeModel.TaxablePay = (float)dr.GetSqlSingle(9);
                            //employeeModel.NetPay = (float)dr.GetSqlSingle(10);
                            employeeModel.IncomeTax = (float)dr.GetSqlSingle(11);

                            Console.WriteLine(employeeModel.EmployeeID + " , " + employeeModel.EmployeeName + " , " + employeeModel.Address + " , " + employeeModel.gendre + " , " + employeeModel.Department + " , " + employeeModel.NetPay + " , " + employeeModel.start_date + " , " + employeeModel.PhoneNumber
                                                + " , " + employeeModel.BasicPay + " , " + employeeModel.Address + " , " + employeeModel.Deduction + " , " + employeeModel.TaxablePay + " , " + employeeModel.IncomeTax);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Table is Empty....");
                    }
                    dr.Close();
                    this.connection.Close();
                }
                return count;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
