using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HealthPortalWebServices
{
    public class UserManagementService: IUserManagementService
    {
        private static string connectionString = "server=localhost;user=root;database=hpdb;port=3306;password=master;";
        private UInt64 maxUserID;
        private MySqlConnection connection;
        
        // Default Constructor
        public UserManagementService()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                maxUserID = Utilities.getMaxUserID(connection);
                if (maxUserID == 0)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Exposed Methods
        public short isValidUserCredentials(string username, string password)
        {
            UInt64 uid = 0;
            return Utilities.isValidUserCredentials(ref uid, username, password, connection);
        }
        public Dictionary<string, object> getCompleteUserDetails(string username, string password)
        {
            Dictionary<string, object> details = new Dictionary<string, object>();
            try
            {
                UInt64 uid = 0;
                short userType = Utilities.isValidUserCredentials(ref uid, username, password, connection);
                switch (userType)
                {
                    case 0: // Hospital Administrator
                        details["user_type"] = 0;
                        getAdminDetails(uid, details);
                        break;
                    case 1: // Doctor
                        details["user_type"] = 1;
                        getDoctorDetails(uid, details);
                        break;
                    case 2: // Patient
                        details["user_type"] = 2;
                        getPatientDetails(uid, details);
                        break;
                    default:
                        details["status"] = "Invalid username/password!";
                        break;
                };
                return details;
            }
            catch (Exception ex)
            {
                details["status"] = ex.Message;
                Utilities.logException(ex);
                return details;
            }
        }
        public string addPatient(Dictionary<string, string> patientDetails)
        {
            try
            {
                patientDetails["uid"] = "" + maxUserID++;
                bool result = false;
                Users.Patient patient = new Users.Patient(patientDetails, out result);
                MySqlTransaction transaction = null;
                if (result == true)
                {
                    transaction = connection.BeginTransaction();


                    if (addUserCredentials(patient, 2) == false)        // Add user credentials
                        transaction.Rollback();
                    else if (addGenericUserProfile(patient) == false)   // Add generic user profile
                        transaction.Rollback();
                    else if (addPatient(patient) == false)              // Add patient specific details
                        transaction.Rollback();
                    else
                    {
                        transaction.Commit();
                        return "OK";
                    }
                }
                
                return "FAILED";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return "FAILED!";
            }
        }
        public string addDoctor(Dictionary<string, string> doctorDetails, string adminUsername, string adminPassword)
        {
            UInt64 uid = 0;
            if (Utilities.isValidUserCredentials(ref uid, adminUsername, adminPassword, connection) != 0)
                return "INVALID ADMIN CREDENTIALS";

            try
            {
                doctorDetails["uid"] = "" + maxUserID++;
                bool result = false;
                Users.Doctor doctor = new Users.Doctor(doctorDetails, out result);
                MySqlTransaction transaction = null;
                if (result == true)
                {
                    transaction = connection.BeginTransaction();


                    if (addUserCredentials(doctor, 1) == false)        // Add user credentials
                        transaction.Rollback();
                    else if (addGenericUserProfile(doctor) == false)   // Add generic user profile
                        transaction.Rollback();
                    else if (addDoctor(doctor) == false)              // Add doctor specific details
                        transaction.Rollback();
                    else
                    {
                        transaction.Commit();
                        return "OK";
                    }
                }

                return "FAILED";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return "FAILED!";
            }
        }

        // Helper Methods
        private bool addUserCredentials(Users.User user, short userType)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAddUserCredentialQuery(user, userType);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return command.ExecuteNonQuery() == 0;
            }
            catch (Exception ex)
            {
                return Utilities.logException(ex);
            }
        }
        private bool addGenericUserProfile(Users.User user)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAddGenericUserProfileQuery(user);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return command.ExecuteNonQuery() == 0;
            }
            catch (Exception ex)
            {
                return Utilities.logException(ex);
            }
        }
        private bool addPatient(Users.Patient patient)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAddPatientQuery(patient);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return command.ExecuteNonQuery() == 0;
            }
            catch (Exception ex)
            {
                return Utilities.logException(ex);
            }
        }
        private bool addDoctor(Users.Doctor doctor)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAddDoctorQuery(doctor);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return command.ExecuteNonQuery() == 0;
            }
            catch (Exception ex)
            {
                return Utilities.logException(ex);
            }
        }

        private bool getGenericUserDetails(UInt64 uid, Dictionary<string, object> details)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadGenericUserProfileQuery(uid);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader != null && reader.Read())
                {
                    details["full_name"] = reader.GetString("full_name");
                    details["dob"] = reader.GetUInt64("dob");
                    details["email"] = reader.GetString("email");
                    details["home_address"] = reader.GetString("home_address");
                    details["contact_number"] = reader.GetString("contact_number");
                    details["gender"] = reader.GetInt16("gender");
                    return true;
                }
                else
                {
                    details["status"] = "No data found against given user id: " + uid;
                    return false;
                }
            }
            catch (Exception ex)
            {
                details["status"] = ex.Message;
                Utilities.logException(ex);
                return false;
            }
        }
        private bool getAdminDetails(UInt64 uid, Dictionary<string, object> details)
        {
            return getGenericUserDetails(uid, details);
            // Implement admin specific code here
        }
        private bool getDoctorDetails(UInt64 uid, Dictionary<string, object> details)
        {
            return getGenericUserDetails(uid, details);
            // Implement doctor specific code here
        }
        private bool getPatientDetails(UInt64 uid, Dictionary<string, object> details)
        {
            return getGenericUserDetails(uid, details);
            // Implement patient specific code here
        }
    }
}
