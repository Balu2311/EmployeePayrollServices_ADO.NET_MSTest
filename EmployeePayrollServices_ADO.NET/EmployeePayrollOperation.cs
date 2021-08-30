using System;
using System.Collections.Generic;
using System.Text;

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

       
        //Adds the employee to payroll.
        public void AddEmployeePayroll(EmployeeModel employeeData)
        {
            modelList.Add(employeeData);

        }
    }
}
