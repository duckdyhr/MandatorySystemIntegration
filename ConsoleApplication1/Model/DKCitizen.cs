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
    public class DKcitizen
    {
        public DKcitizen() { }
        [XmlElement]
        public string firstName { get; set; }
        [XmlElement]
        public string surName { get; set; }
        [XmlElement]
        public string cprNr { get; set; }
        [XmlElement]
        public string Adress1 { get; set; }
        [XmlElement]
        public string Adress2 { get; set; }
        [XmlElement]
        public string postalCode { get; set; }
        [XmlElement]
        public string city { get; set; }
        [XmlElement]
        public string maritalStatus { get; set; } = "Unmarried";
        [XmlElement]
        public string spouseCPR { get; set; }
        [XmlElement]
        public List<string> childrenCPR { get; set; }
        [XmlElement]
        public List<string> parentsCPR { get; set; }
        [XmlElement]
        public string doctorCVR { get; set; }
    }
}