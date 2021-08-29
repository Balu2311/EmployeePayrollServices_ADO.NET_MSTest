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
        // retrive employee who joined in perticular date range.
        [TestMethod]
        public void GivenEmployeeNames_WhenUpdateSalary_ThenReturnExpectedSalary()
        {
            EmployeeRepo emprepo = new EmployeeRepo();
            int count = emprepo.getEmployeeDataWithGivenRange();
            int expected = 5;
            Assert.AreEqual(expected, count);
        }

        //Givens the employee names when update salary then return expected sum salary.
        [TestMethod]
        public void GivenEmployeeNames_WhenUpdateSalary_ThenReturnExpectedSumSalary()
        {
            int expected = 200000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int sum = emprepo.getAggrigateSumSalary();
            Assert.AreEqual(expected, sum);
        }
        // Givens the employee names when average salary then return expected average salary.
        [TestMethod]
        public void GivenEmployeeNames_WhenAvgSalary_ThenReturnExpectedAvgSalary()
        {
            int expected = 200000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int avg = emprepo.getAvragSalary();
            Assert.AreEqual(expected, avg);
        }
        // Givens the employee names when minimum salary then return expected minimum salary.
        [TestMethod]
        public void GivenEmployeeNames_WhenMinSalary_ThenReturnExpectedMinSalary()
        {
            int expected = 200000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int min = emprepo.getMinSalary();
            Assert.AreEqual(expected, min);
        }
        // Givens the employee names when maximum then return expected maximum salary.
        [TestMethod]
        public void GivenEmployeeNames_WhenMax_ThenReturnExpectedMaxSalary()
        {
            int expected = 200000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int max = emprepo.getMaxSalary();
            Assert.AreEqual(expected, max);
        }
        // Givens the employee names when count by salary then return expected count by salary.
        [TestMethod]
        public void GivenEmployeeNames_WhenCountBySalary_ThenReturnExpectedCountBySalary()
        {
            int expected = 1;
            EmployeeRepo emprepo = new EmployeeRepo();
            int count = emprepo.getCountSalary();
            Assert.AreEqual(expected, count);
        }
    }
}
