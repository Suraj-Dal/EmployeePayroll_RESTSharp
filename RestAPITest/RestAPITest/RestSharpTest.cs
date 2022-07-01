using EmployeePayrollRestAPI;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestAPITest
{
    public class RestSharpTest
    {
        RestClient restClient;
        [Test]
        public void CallGetMethod_ReturnEmployeeDetails()
        {
            restClient = new RestClient("http://localhost:4000");
            RestRequest request = new RestRequest("/employees", Method.Get);
            RestResponse response = restClient.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(4, list.Count);
            foreach (Employee e in list)
            {
                Console.WriteLine("ID: " + e.Id + "\nName: " + e.Name + "\nSalary: " + e.Salary);
            }
        }
    }
}