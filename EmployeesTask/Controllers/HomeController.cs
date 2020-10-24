using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeesTask.Models;
using Newtonsoft.Json;

namespace EmployeesTask.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await LoadAllEmployeesInPartilaView(); // render all employees partial view 
            return View();
        }

        [HttpGet]
        public async Task< PartialViewResult> LoadAllEmployeesInPartilaView()
        {
            string apiUrl = "https://localhost:44380/api/employees"; // call api to get all employees

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var Jsondata = await response.Content.ReadAsStringAsync();
                    var ListOfEmployees = JsonConvert.DeserializeObject<List<Employees>>(Jsondata); // convert json data to list of employees 
                    return PartialView("GetAllEmployees", ListOfEmployees); // then pass that list to partial view  
                }

                return null;
            }
        }


    }
}
