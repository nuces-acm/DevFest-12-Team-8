using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthPortalWebServices
{

    [ServiceContract]
    public interface IUserManagementService
    {
        [OperationContract]
        short isValidUserCredentials(string username, string password);

        [OperationContract]
        Dictionary<string, object> getCompleteUserDetails(string username, string password);

        [OperationContract]
        string addPatient(Dictionary<string, string> patientDetails);

        [OperationContract]
        string addDoctor(Dictionary<string, string> doctorDetails, string adminUsername, string adminPassword);
    }
}
