using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace HealthPortalWebServices.Users
{
    [DataContract]
    public class User
    {
        /* User Credentials */
        [DataMember]
        public UInt64 ID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        /* Bio-Data */
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string HomeAddress { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public UInt64 DOB { get; set; }

        [DataMember]
        public GENDER Gender { get; set; }
    }
}
