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
    }
}
