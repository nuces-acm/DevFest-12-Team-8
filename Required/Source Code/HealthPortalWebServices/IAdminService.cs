using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;


namespace HealthPortalWebServices
{
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        string addDepartment(UInt32 hospitalID, string departmentName, string adminUsername, string adminPassword);

        [OperationContract]
        string assignDoctorToDepartment(UInt64 departmentID, UInt64 doctorID, string adminUsername, string adminPassword);

        [OperationContract]
        List<Hospital> getListOfHospitals();

        [OperationContract]
        List<Department> getListOfDepartments(UInt32 hospitalID);
    }

    [DataContract]
    public class Hospital
    {
        [DataMember]
        public UInt32 ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Department
    {
        [DataMember]
        public UInt64 ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
