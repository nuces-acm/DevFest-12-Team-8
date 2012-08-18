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
    public interface IAppointmentService
    {
        [OperationContract]
        Dictionary<string, object> GetAppointmentDetails(UInt64 appointmentID, string username, string password);

        [OperationContract]
        Dictionary<string, object> GetAppointment(string patientUsername, string patientPassword, UInt32 hospitalID, UInt64 departmentID);

        /*[OperationContract]
        Dictionary<string, string> GetAppointment(string patientUsername, string patientPassword, UInt32 hospitalID, UInt32 departmentID, UInt64 dateTime);/*/
    }
}
