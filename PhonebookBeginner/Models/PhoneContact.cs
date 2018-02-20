using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookBeginner.Models
{
    public class PhoneContact
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_number")]
        public string Number { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
