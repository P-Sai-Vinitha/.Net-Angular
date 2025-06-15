using Contacts_Directory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts_Directory.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        public static List<ContactInfo> contactList = new List<ContactInfo>
        {
            new ContactInfo{ ContactId = 1, FirstName = "John", LastName = "Doe", CompanyName = "ABC Corp", EmailId = "john@abc.com", MobileNo = 9876543210, Designation = "Manager" }
        };

        [Route("/")] // startup route
        [Route("ShowContacts", Name = "ShowContacts")]
        public IActionResult ShowContacts()
        {
            return View(contactList);
        }

        [Route("GetContactById/{id}", Name = "GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var contact = contactList.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        [Route("AddContact", Name = "AddContact")]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contactList.Add(contactInfo);
            return RedirectToRoute("ShowContacts");
        }
    }
}
