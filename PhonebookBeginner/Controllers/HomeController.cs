using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonebookBeginner.Data;
using PhonebookBeginner.Models;

namespace PhonebookBeginner.Controllers
{
    public class HomeController : Controller
    {

        private const string API = @"http://www.mocky.io/v2/581335f71000004204abaf83";
        private const string Name = "name";
        private const string NameDesc = "name_desc";
        private const string Number = "number";
        private const string NumberDesc = "number_desc";
        private const string Address = "address";
        private const string AddressDesc = "address_desc";
        


        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = sortOrder == Name ? NameDesc : Name;
            ViewData["PhoneNumberSortParm"] = sortOrder == Number ? NumberDesc : Number;
            ViewData["AddressSortParm"] = sortOrder == Address ? AddressDesc : Address;

            ViewData["CurrentFilter"] = searchString;

            var contacts = await ContactsClient.SendAsync<IEnumerable<PhoneContact>>(API, "contacts", string.Empty);

            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(a => a.Name.ToUpper().Contains(searchString.ToUpper())
                || a.Number.ToUpper().Contains(searchString.ToUpper())
                || a.Address.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case Name:
                    contacts = contacts.OrderBy(a => a.Name);
                    break;
                case Number:
                    contacts = contacts.OrderBy(a => a.Number);
                    break;
                case Address:
                    contacts = contacts.OrderBy(a => a.Address);
                    break;
                case NameDesc:
                    contacts = contacts.OrderByDescending(a => a.Name);
                    break;
                case NumberDesc:
                    contacts = contacts.OrderByDescending(a => a.Number);
                    break;
                case AddressDesc:
                    contacts = contacts.OrderByDescending(a => a.Address);
                    break;
                default:
                    break;
            }

            return View(contacts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
