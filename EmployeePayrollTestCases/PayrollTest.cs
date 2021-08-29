using EmployeePayrollServices_ADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTestCases
{
    [TestClass]
    public class PayrollTest
    {
        [TestMethod]
        public void CheckConnection()
        {
            EmployeeRepo emprepo = new EmployeeRepo();
            bool expect = emprepo.EstablishConnection();
            bool result = true;
            Assert.AreEqual(result, expect);
        }
        
        //Given Employee Payroll Service DB when Retrive then return Count of employee
        [TestMethod]
        public void GivenPayrollServiceDB_WhenRetrieve_ThenReturnPayrollServiceFromDataBase()
        {
            EmployeeRepo emprepo = new EmployeeRepo();
            int expect = emprepo.GetAllRecords();
            int result = 5;
            Assert.AreEqual(result, expect);
        }
        // Givens the employee name when update salary then return employee payroll from data base.
        [TestMethod]
        public void GivenEmployeeName_WhenUpdateSalary_ThenReturnExpectedSalary()
        {
            int result = 3000000;
            EmployeeRepo emprepo = new EmployeeRepo();
            double expect = emprepo.UpdateEmployee();
            Assert.AreEqual(result, expect);
        }
    }
}
