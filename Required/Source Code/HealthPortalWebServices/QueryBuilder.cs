using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthPortalWebServices.Users;

namespace HealthPortalWebServices
{
    public class QueryBuilder
    {
        #region Select Queries
        public static string getReadUserCredentialsQuery(string username, string password)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select * from users  where username=\'").Append(username);
            query.Append("\' and password=\'").Append(password).Append("\'");
            return query.ToString();
        }
        public static string getReadMaxUserIDQuery()
        {
            return "Select Max(uid) from users";
        }
        public static string getReadMaxDepartmentIDQuery()
        {
            return "Select Max(did) from hospital_departments";
        }
        public static string getReadMaxAppointmentIDQuery()
        {
            return "Select Max(aid) from appointments";
        }
        public static string getReadAppointmentDetailsQuery(UInt64 appointmentID)
        {
            return "Select * from appointments where aid=" + appointmentID;
        }
        public static string getReadMaxAppointment(UInt64 departmentID)
        {
            return "Select Max(appointment_time) from appointments where dept_id=" + departmentID + " and status<>2"; // Not canceled
        }
        public static string getReadGenericUserProfileQuery(UInt64 uid)
        {
            return "Select * from generic_user_profiles where uid=" + uid;
        }
        public static string getReadAllHospitalsQuery()
        {
            return "Select * from hospitals";
        }
        public static string getReadAllDepartmentsQuery(UInt32 hospitalID)
        {
            return "Select * from hospital_departments where hid=" + hospitalID;
        }
        #endregion

        #region Add Queries
        public static string getAddUserCredentialQuery(User user, short userType)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into users values(").Append(user.ID);
            query.Append(", \'").Append(user.Username).Append("\', \'").Append(user.Password);
            query.Append("\', ").Append(userType).Append(")");
            return query.ToString();
        }
        public static string getAddGenericUserProfileQuery(User user)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into generic_user_profiles values(").Append(user.ID).Append(", \'");
            query.Append(user.Name).Append("\', ").Append(user.DOB).Append(", \'").Append(user.Email).Append("\', \'");
            query.Append(user.HomeAddress).Append("\', \'").Append(user.ContactNumber).Append("\', ");
            query.Append((int)user.Gender).Append(")");
            return query.ToString();
        }
        public static string getAddPatientQuery(Users.Patient patient)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into patients values(").Append(patient.ID).Append(", ");
            query.Append((int)patient.BloodGroup).Append(")");
            return query.ToString();
        }
        public static string getAddDoctorQuery(Users.Doctor doctor)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into patients values(").Append(doctor.ID).Append(", ");
            query.Append(doctor.DepartmentID).Append(", \'").Append(doctor.Qualification).Append("\')");
            return query.ToString();
        }

        public static string getAddDepartmentQuery(UInt32 hospitalID, UInt64 departmentID, string departmentName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into hospital_departments values(").Append(departmentID).Append(", ");
            query.Append(hospitalID).Append(", \'").Append(departmentName).Append("\')");
            return query.ToString();
        }
        public static string getAssignDepartmentToDoctorQuery(UInt64 departmentID, UInt64 doctorID)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into doctors(dr_id, dept_id) values(").Append(doctorID).Append(", ");
            query.Append(departmentID).Append(")");
            return query.ToString();
        }
        public static string getAddAppointmentQuery(UInt64 appointmentID, UInt64 patientID, UInt64 departmentID, UInt64 time)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into appointments(aid, pid, dept_id, appointment_time, status) values(");
            query.Append(appointmentID).Append(", ").Append(patientID).Append(", ").Append(departmentID);
            query.Append(", ").Append(time).Append(", ").Append(0).Append(")");
            return query.ToString();
        }
        #endregion
    }
}
