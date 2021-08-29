using System;

namespace EmployeePayrollServices_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome_To_Employee_Payroll_Service_MSTEST");
            EmployeeRepo emprepo = new EmployeeRepo();
            //Console.WriteLine(emprepo.EstablishConnection());
            //Console.WriteLine(emprepo.GetAllRecords());
            //Console.WriteLine(emprepo.UpdateEmployee());
            Console.WriteLine(emprepo.getEmployeeDataWithGivenRange());
        }
    }
}
