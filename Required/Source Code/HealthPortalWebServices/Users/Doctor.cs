using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace HealthPortalWebServices.Users
{
    [DataContract]
    public class Doctor: User
    {
        [DataMember]
        public uint DepartmentID {get;set;}

        [DataMember]
        public string Qualification { get; set; }

        public Doctor() { }

        public Doctor(Dictionary<string, string> doctorDetails, out bool result)
        {
            result = Utilities.extractDoctorDetails(doctorDetails, this);
        }
    }
}
