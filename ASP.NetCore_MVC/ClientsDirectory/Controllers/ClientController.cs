using ClientsDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClientsDirectory.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {
        public static List<ClientInfo> clients = new List<ClientInfo>
        {
            new ClientInfo{ ClientId = 1, CompanyName="TechCorp", WebUrl="https://techcorp.com", Email="info@techcorp.com", Category="Software Services", Standard="CMMI3" },
            new ClientInfo{ ClientId = 2, CompanyName="NetSecure", WebUrl="https://netsecure.com", Email="support@netsecure.com", Category="Network_Management", Standard="ISO" }
        };

        [Route("/")] // startup route
        [Route("ShowAll", Name = "ShowAllClients")]
        public IActionResult ShowAllClientDetails()
        {
            return View(clients);
        }

        [Route("Id/{id:int}", Name = "GetById")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);
            return View("ClientDetails", client);
        }

        [Route("Name/{name}", Name = "GetByName")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var client = clients.FirstOrDefault(c => c.CompanyName == name);
            return View("ClientDetails", client);
        }

        [Route("Email/{email}", Name = "GetByEmail")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var client = clients.FirstOrDefault(c => c.Email == email);
            return View("ClientDetails", client);
        }

        [Route("Category/{category}", Name = "GetByCategory")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c => c.Category == category);
            return View("ClientDetails", client);
        }

        [Route("Standard/{standard}", Name = "GetByStandard")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c => c.Standard == standard);
            return View("ClientDetails", client);
        }

        [Route("Add", Name = "AddClient")]
        public IActionResult AddClient()
        {
            ViewBag.Categories = new List<string>
            {
                "Low_Level_Managed_IT_Services",
                "Mid_Level_Managed_IT_Services",
                "High_Level_Managed_IT_Services",
                "On-Demand_IT_Services",
                "Hardware_Support",
                "Software Services",
                "Network_Management"
            };

            ViewBag.Standards = new List<string>
            {
                "CMMI1", "CMMI2", "CMMI3", "CMMI4", "CMMI5", "ISO", "None"
            };
            return View();
        }

        [HttpPost]
        [Route("Save", Name = "SaveClient")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToRoute("ShowAllClients");
        }
    }
}
