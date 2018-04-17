using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable()]
    [XmlRoot("itizen")]
    public class EUcitizenCanonical
    {
        public EUcitizenCanonical() { }
        [XmlElement]
        public string euccid { get; set; }
        [XmlElement]
        public string christianName { get; set; }
        [XmlElement]
        public string familyName { get; set; }
        [XmlElement]
        public gender gender { get; set; }
        [XmlElement]
        public string streetAndHouseNo { get; set; }
        [XmlElement]
        public string apartmentNo { get; set; }
        [XmlElement]
        public string county { get; set; }
        [XmlElement]
        public string city { get; set; }
        [XmlElement]
        public string birthCountry { get; set; }
        [XmlElement]
        public string currentCountry { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(euccid);
            sb.Append(", ");
            sb.Append(christianName);
            sb.Append(", ");
            sb.Append(familyName);
            sb.Append(", ");
            sb.Append(gender);
            sb.Append(", ");
            sb.Append(streetAndHouseNo);
            sb.Append(", ");
            sb.Append(apartmentNo);
            sb.Append(", ");
            sb.Append(county);
            sb.Append(", ");
            sb.Append(city);
            sb.Append(", ");
            sb.Append(birthCountry);
            sb.Append(", ");
            sb.Append(currentCountry);
            return sb.ToString();
        }
    }

    public enum gender
    {
        Unidentified,
        Male,
        Female
    }
}
