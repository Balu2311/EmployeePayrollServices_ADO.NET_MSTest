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
    }
}
