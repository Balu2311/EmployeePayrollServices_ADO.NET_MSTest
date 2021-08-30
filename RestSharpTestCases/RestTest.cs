using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTestCases
{
    [TestClass]
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }

    [TestClass]
    public class RestTest
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }
        // Retrive all employees using rest api.
        [TestMethod]
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(7, dataResponse.Count);

            foreach (Employee e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.id + ",Name: " + e.name + ",Salary" + e.salary);
            }
        }
        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/employee", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("name", "Ganesh");
            jObjectbody.Add("salary", "10000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Ganesh", dataResponse.name);
            Assert.AreEqual("10000", dataResponse.salary);

        }
        //adding multiple employee to the Json Server.
        [TestMethod]
        public void GivenMultipleEmployee_OnPost_ThenShouldReturnEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee { name = "Vinaya", salary = "15000" });
            employeeList.Add(new Employee { name = "Ajaya kumar", salary = "7000" });
            employeeList.Add(new Employee { name = "Powan", salary = "9000" });
            employeeList.Add(new Employee { name = "Swathi", salary = "12000" });
            employeeList.ForEach(employeeData =>
            {
                RestRequest request = new RestRequest("/employee", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("name", employeeData.name);
                jObjectBody.Add("salary", employeeData.salary);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Employee dataResorce = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(employeeData.name, dataResorce.name);
                Assert.AreEqual(employeeData.salary, dataResorce.salary);
                System.Console.WriteLine(response.Content);
            });

            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResorce = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(12, dataResorce.Count);
        }
    }
}
