using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable()]
    [XmlRoot("Citizen")]
    public class EUcitizen
    {
        public string euccid { get; set; }
        public string christianName { get; set; }
        public string familyName { get; set; }
        public string gender { get; set; }
        public string streetAndHouseNo { get; set; }
        public string apartmentNo { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public string birthCountry { get; set; }
        public string currentCountry { get; set; }
    }
}
