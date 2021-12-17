using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace EmployeePayrollTest
{
    public class Employee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
        [TestMethod]
        public void AddEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            JObject jObject = new JObject();
            jObject.Add("name", "jhon");
            jObject.Add("salary", "52000");

            request.AddParameter("application/json", jObject, ParameterType.RequestBody);
            
            
            IRestResponse responce = client.Execute(request);

            Assert.AreEqual(responce.StatusCode, System.Net.HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(responce.Content);
            Assert.AreEqual("jhon", dataResponse.name);
            Assert.AreEqual("52000", dataResponse.salary);
            System.Console.WriteLine(responce.Content);
        }
        [TestMethod]
        public void GetAllEmployeeFromJsonServerUsingPostman()
        {
            RestRequest request = new RestRequest("/employees", Method.GET);
            
            IRestResponse responce = client.Execute(request);
            System.Console.WriteLine(responce.Content);
            
        }
        [TestMethod]
        public void UpdateEmployee()
        {
            RestRequest request = new RestRequest("/employees/3", Method.PUT);
            JObject jObject = new JObject();
            jObject.Add("name", "ram");
            jObject.Add("salary", "45000");

            request.AddParameter("application/json", jObject, ParameterType.RequestBody);


            IRestResponse responce = client.Execute(request );

            Assert.AreEqual(responce.StatusCode, System.Net.HttpStatusCode.OK);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(responce.Content);
            Assert.AreEqual("ram", dataResponse.name);
            Assert.AreEqual("45000", dataResponse.salary);
            System.Console.WriteLine(responce.Content);
        }
        [TestMethod]
        public void DeleteEmployeeDataOfJsonServer()
        {
            RestRequest request = new RestRequest("/employees/5", Method.DELETE);
            
            IRestResponse responce = client.Execute(request);

            Assert.AreEqual(responce.StatusCode, System.Net.HttpStatusCode.OK);
            System.Console.WriteLine(responce.Content);
        }
    }
}
