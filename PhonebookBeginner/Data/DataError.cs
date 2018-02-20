using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookBeginner.Data
{
    public class DataError
    {
        [JsonProperty("error")]
        public String Message { get; set; }
    }
}
