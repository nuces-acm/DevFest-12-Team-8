using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthPortalWebServices.Patient
{
    [DataContract]
    public class Diagnosis
    {
        [DataMember]
        public UInt64 DiagnosisID { get; set; }

        [DataMember]
        public string Diagnoses { get; set; }

        [DataMember]
        public List<string> Treatment { get; set; }
    }
}
