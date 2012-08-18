using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace HealthPortalWebServices.Users
{
    [DataContract]
    public class Patient : User
    {
        [DataMember]
        public BLOODGROUP BloodGroup { get; set; }

        public Patient() { }

        public Patient(Dictionary<string, string> patientDetails, out bool result)
        {
            result = Utilities.extractPatientDetails(patientDetails, this);
        }
    }
}
