using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace HealthPortalWebServices.Users
{
    [DataContract]
    public class HospitalAdministrator : User
    {
        [DataMember]
        public int HospitalID { get; set; }
    }

    
}
