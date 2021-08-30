using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServices_ADO.NET
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public char Gendre { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public Single TaxablePay { get; set; }
        public Single NetPay { get; set; }
        public Single IncomeTax { get; set; }

    }
}
