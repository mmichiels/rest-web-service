using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuscData
{
    [Serializable]
    public class User
    {
        [JsonProperty("Id")]
        public int? Id;
        [JsonProperty("Username")]
        public string Name;
        [JsonProperty("Password")]
        public string Password;
        [JsonProperty("Balance")]
        public double Balance;
    }
}
