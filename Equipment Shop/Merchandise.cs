using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Shop
{
    class Merchandise
    {
        public string MerchandiseID { get; set; }

        [JsonIgnore]
        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }

        public string ImageURL { get; set; }
    }
}
