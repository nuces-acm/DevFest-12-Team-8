using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthPortalWebServices.Patient
{
    [DataContract]
    public class History
    {
        [DataMember]
        public List<Diagnosis> diagnosis;

        [DataMember]
        public UInt64 AppointmentID { get; set; }
    }
}
