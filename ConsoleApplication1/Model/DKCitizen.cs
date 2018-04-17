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
        string firstName { get; set; }
        string surName { get; set; }
        string cprNr { get; set; }
        string Adress1 { get; set; }
        string Adress2 { get; set; }
        string postalCode { get; set; }
        string city { get; set; }
        string maritalStatus { get; set; }
        string spouseCPR { get; set; }
        List<string> childrenCPR { get; set; }
        List<string> parentsCPR { get; set; }
        string doctorCVR { get; set; }
    }
}
