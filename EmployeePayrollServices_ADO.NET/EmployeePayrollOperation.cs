using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServices_ADO.NET
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeModel> modelList = new List<EmployeeModel>();
        EmployeeRepo payrollRepo = new EmployeeRepo();
        //Adds the employee to payroll
        public void AddEmployeeToPayroll(List<EmployeeModel> employeelist)
        {
            employeelist.ForEach(employeeData =>
            {
                Console.WriteLine("Employee_Being_added : " + employeeData.EmployeeName);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee_added : " + employeeData.EmployeeName);
            });
            Console.WriteLine(this.modelList.ToString());
        }
        //UC_2 Adding Employee and calculating Execution Time Using Thread.
        public void AddEmployee_UsingThread(List<EmployeeModel> employeelist)
        {
            employeelist.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee_Being_Added : " + employeeData.EmployeeName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee_Added :" + employeeData.EmployeeName);
                });
                thread.Start();
            });
            Console.WriteLine(this.modelList.Count);
        }

        //Adds the employee to payroll.
        public void AddEmployeePayroll(EmployeeModel employeeData)
        {
            modelList.Add(employeeData);

        }
    }
}
