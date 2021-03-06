using System;
using System.Collections.Generic;
using System.Data;
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
                    string query = @"select * from Employee_payroll";

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
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Gendre = Convert.ToChar(dr.GetString(4));
                            employeeModel.BasicPay = Convert.ToDouble(dr.GetDecimal(2));
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.TaxablePay = (float)dr.GetSqlSingle(9);
                            employeeModel.NetPay = (float)dr.GetSqlSingle(10);
                            employeeModel.IncomeTax = (float)dr.GetSqlSingle(11);
                            employeeModel.StartDate = dr.GetDateTime(3);

                            Console.WriteLine(employeeModel.EmployeeID + " , " + employeeModel.EmployeeName + " , " + employeeModel.Address + " , " + employeeModel.Gendre + " , " + employeeModel.Department + " , " + employeeModel.NetPay + " , " + employeeModel.StartDate + " , " + employeeModel.PhoneNumber
                                                + " , " + employeeModel.BasicPay + " , " + employeeModel.Address + " , " + employeeModel.Deductions + " , " + employeeModel.TaxablePay + " , " + employeeModel.IncomeTax);
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
        public double UpdateEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"update Employee_payroll set BasicPay=3000000 where EmployeeName='Reddy';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        query = @"Select BasicPay from Employee_payroll where EmployeeName='Reddy';";
                        cmd = new SqlCommand(query, connection);
                        object res = cmd.ExecuteScalar();
                        connection.Close();
                        employeeModel.BasicPay = (double)(decimal)res;
                        return (employeeModel.BasicPay);
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public int getEmployeeDataWithGivenRange()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select count(EmployeeName) from Employee_payroll where StartDate between cast('2015-01-01' as date) and CAST('2019-12-12' as date)";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public int getAggrigateSumSalary()
        {
            try
            {
                int sum = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select sum(BasicPay) from  Employee_payroll GROUP BY Gender;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            sum = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return sum;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getAvragSalary()
        {
            try
            {
                int avg = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select avg(BasicPay) from  Employee_payroll GROUP BY Gender;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            avg = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return avg;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMinSalary()
        {
            try
            {
                int min = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select min(BasicPay) from  Employee_payroll GROUP BY Gender;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            min = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return min;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMaxSalary()
        {
            try
            {
                int max = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select max(BasicPay) from  Employee_payroll GROUP BY Gender;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            max = (int)Convert.ToDouble(sqlDataReader.GetDecimal(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return max;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Gets the maximum salary.
        public int getCountSalary()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select count(BasicPay) from  Employee_payroll GROUP BY Gender;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool InsertEmployee(EmployeeModel empModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("payrollProcedure", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@EmployeeID", empModel.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", empModel.EmployeeName);
                    command.Parameters.AddWithValue("@BasicPay", empModel.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                    command.Parameters.AddWithValue("@Gender", empModel.Gendre);
                    command.Parameters.AddWithValue("@PhoneNumber", empModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", empModel.Address);
                    command.Parameters.AddWithValue("@Department", empModel.Department);
                    command.Parameters.AddWithValue("@Deductions", empModel.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", empModel.TaxablePay);
                    command.Parameters.AddWithValue("@NetPay", empModel.NetPay);
                    command.Parameters.AddWithValue("@IncomeTax", empModel.IncomeTax);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool addEmployeeToPayroll(EmployeeModel empModel)
        {
            try
            {
                SqlCommand command = new SqlCommand("payrollProcedure", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@EmployeeID", empModel.EmployeeID);
                command.Parameters.AddWithValue("@EmployeeName", empModel.EmployeeName);
                command.Parameters.AddWithValue("@BasicPay", empModel.BasicPay);
                command.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                command.Parameters.AddWithValue("@Gender", empModel.Gendre);
                command.Parameters.AddWithValue("@PhoneNumber", empModel.PhoneNumber);
                command.Parameters.AddWithValue("@Address", empModel.Address);
                command.Parameters.AddWithValue("@Department", empModel.Department);
                command.Parameters.AddWithValue("@Deductions", empModel.Deductions);
                command.Parameters.AddWithValue("@TaxablePay", empModel.TaxablePay);
                command.Parameters.AddWithValue("@NetPay", empModel.NetPay);
                command.Parameters.AddWithValue("@IncomeTax", empModel.IncomeTax);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();

                int employee_id = empModel.EmployeeID;
                double deductions = empModel.BasicPay * 0.2;
                double taxable_pay = empModel.BasicPay - deductions;
                double Incometax = taxable_pay * 0.1;
                double net_pay = empModel.BasicPay - Incometax;
                SqlCommand sqlCommand = new SqlCommand("PayrollDeatilProcedure", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@EmployeeId", (empModel.EmployeeID));
                sqlCommand.Parameters.AddWithValue("@Deductions", (empModel.BasicPay * 0.2));
                sqlCommand.Parameters.AddWithValue("@TaxablePay", (empModel.BasicPay - deductions));
                sqlCommand.Parameters.AddWithValue("@NetPay", (taxable_pay * 0.1));
                sqlCommand.Parameters.AddWithValue("@IncomeTax", (empModel.BasicPay - Incometax));
                this.connection.Open();
                var result = sqlCommand.ExecuteNonQuery();
                this.connection.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                this.connection.Close();
            }
        }
        public bool DeleteEmployeeUsingID(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("payrollProcedure", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", model.EmployeeID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand command1 = new SqlCommand("payrollProcedure", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@EmployeeId", model.EmployeeID);
                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);

            }
        }
        public double updateEmployeeSalary(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmpPayroll", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                }
                return employeeModel.BasicPay;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}