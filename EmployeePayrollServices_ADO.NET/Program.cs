using System;
using System.Collections.Generic;

namespace EmployeePayrollServices_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome_To_Employee_Payroll_Service_MSTEST");
            List<EmployeeModel> modelList = new List<EmployeeModel>();
            modelList.Add(new EmployeeModel() { EmployeeID = 1, EmployeeName = "Nagireddy", BasicPay = 500000, StartDate = new DateTime(2019, 01, 01), Gendre = 'M', PhoneNumber = "7876538963", Department = "IT", Address = "Chennai", Deductions = 3000, TaxablePay = 2500, NetPay = 40000, IncomeTax = 440 });
            modelList.Add(new EmployeeModel() { EmployeeID = 2, EmployeeName = "ishak", BasicPay = 300000, StartDate = new DateTime(2018, 01, 01), Gendre = 'M', PhoneNumber = "8963098076", Department = "DS", Address = "port", Deductions = 3000, TaxablePay = 2500, NetPay = 40600, IncomeTax = 450 });
            modelList.Add(new EmployeeModel() { EmployeeID = 4, EmployeeName = "Dipika", BasicPay = 900000, StartDate = new DateTime(2017, 01, 01), Gendre = 'F', PhoneNumber = "9630124578", Department = "IT", Address = "Lakanow", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 460 });
            modelList.Add(new EmployeeModel() { EmployeeID = 3, EmployeeName = "Maheshwari", BasicPay = 700000, StartDate = new DateTime(2016, 01, 01), Gendre = 'F', PhoneNumber = "6301245789", Department = "HR", Address = "Pidugurala", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 540 });
            modelList.Add(new EmployeeModel() { EmployeeID = 5, EmployeeName = "Ganesh", BasicPay = 100000, StartDate = new DateTime(2015, 01, 01), Gendre = 'M', PhoneNumber = "9630124578", Department = "FI", Address = "ONGL", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 560 });
            modelList.Add(new EmployeeModel() { EmployeeID = 8, EmployeeName = "Aahok", BasicPay = 300000, StartDate = new DateTime(2014, 01, 01), Gendre = 'M', PhoneNumber = "8963012457", Department = "CA", Address = "Pune", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 540 });
            modelList.Add(new EmployeeModel() { EmployeeID = 7, EmployeeName = "Vikash", BasicPay = 450000, StartDate = new DateTime(2015, 01, 01), Gendre = 'M', PhoneNumber = "8912457630", Department = "IT", Address = "Ap", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 430 });
            modelList.Add(new EmployeeModel() { EmployeeID = 9, EmployeeName = "Praveen", BasicPay = 655000, StartDate = new DateTime(2018, 01, 01), Gendre = 'F', PhoneNumber = "9630124578", Department = "DS", Address = "WK", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 550 });
            modelList.Add(new EmployeeModel() { EmployeeID = 10, EmployeeName = "Vivek", BasicPay = 360000, StartDate = new DateTime(2019, 01, 01), Gendre = 'M', PhoneNumber = "9630124578", Department = "HR", Address = "TS", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 590 });
            modelList.Add(new EmployeeModel() { EmployeeID = 11, EmployeeName = "Bhanu", BasicPay = 550000, StartDate = new DateTime(2017, 01, 01), Gendre = 'F', PhoneNumber = "8124579630", Department = "IT", Address = "TN", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 580 });
            modelList.Add(new EmployeeModel() { EmployeeID = 12, EmployeeName = "Anjilireddy", BasicPay = 350000, StartDate = new DateTime(2020, 01, 01), Gendre = 'F', PhoneNumber = "6124578930", Department = "CA", Address = "KDKR", Deductions = 3000, TaxablePay = 2500, NetPay = 40500, IncomeTax = 570 });

            EmployeePayrollOperation employeePayroll = new EmployeePayrollOperation();
            DateTime startTime = DateTime.Now;
            employeePayroll.AddEmployeeToPayroll(modelList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Execution_Time_without_Thread : " + (endTime - startTime));
            EmployeeRepo payrollRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeID = 14,
                EmployeeName = "Devendra",
                BasicPay = 650000,
                StartDate = new DateTime(2018, 01, 01),
                Gendre = 'M',
                PhoneNumber = "6781234590",
                Department = "IT",
                Address = "Pune",
                Deductions = 6000,
                TaxablePay = 3500,
                NetPay = 56000,
                IncomeTax = 1200
            };
            DateTime startTimes = DateTime.Now;
            payrollRepo.addEmployeeToPayroll(employeeModel);
            DateTime endTimes = DateTime.Now;
            Console.WriteLine("Execution_Time_without_Thread : " + (endTimes - startTimes));

            DateTime startTimeWithThread = DateTime.Now;
            employeePayroll.AddEmployeeToPayroll(modelList);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Execution_Time_Using_Thread : " + (startTimeWithThread - endTimeWithThread));
        }
    }
}
