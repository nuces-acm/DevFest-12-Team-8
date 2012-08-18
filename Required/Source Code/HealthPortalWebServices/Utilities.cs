using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using HealthPortalWebServices.Users;

namespace HealthPortalWebServices
{
    public class Utilities
    {
        public static short isValidUserCredentials(ref UInt64 uid, string username, string password, MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadUserCredentialsQuery(username, password);;
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                short result = -1;
                if (reader.Read())
                {
                    result = reader.GetInt16("user_type");
                    uid = reader.GetUInt64("uid");
                }
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return -1;
            }
        }

        public static bool logException(Exception ex)
        {
            Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            return false;
        }
        public static UInt64 getMaxUserID(MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadMaxUserIDQuery();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return (UInt64)command.ExecuteScalar() + 1;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return 0;
            }
        }
        public static UInt64 getMaxDepartmentID(MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadMaxDepartmentIDQuery();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return (UInt64)command.ExecuteScalar() + 1;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return 0;
            }
        }
        public static UInt64 getMaxAppointmentID(MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadMaxAppointmentIDQuery();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return (UInt64)command.ExecuteScalar() + 1;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return 0;
            }
        }

        private static bool extractGenericUserDetails(Dictionary<string, string> userDetails, User user)
        {
            try
            {
                user.ID = UInt64.Parse(userDetails["uid"]);
                user.Username = userDetails["username"];
                user.Password = userDetails["password"];
                user.Name = userDetails["name"];
                user.Email = userDetails["email"];
                user.HomeAddress = userDetails["home_address"];
                user.ContactNumber = userDetails["contact_number"];
                user.DOB = UInt64.Parse(userDetails["dob"]);
                string gender = userDetails["gender"];

                if (gender == "m")
                    user.Gender = GENDER.MALE;
                else if (gender == "f")
                    user.Gender = GENDER.FEMALE;
                else if (gender == "s")
                    user.Gender = GENDER.SHEMALE;
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return Utilities.logException(ex);
            }
        }
        public static bool extractPatientDetails(Dictionary<string, string> patientDetails, Users.Patient patient)
        {
            if (extractGenericUserDetails(patientDetails, patient) == true)
            {
                try
                {
                    string bloodGroup = patientDetails["blood_group"];
                    bloodGroup = bloodGroup.ToLower();

                    if (bloodGroup == "ap")
                        patient.BloodGroup = BLOODGROUP.AP;
                    else if (bloodGroup == "bp")
                        patient.BloodGroup = BLOODGROUP.BP;
                    else if (bloodGroup == "abp")
                        patient.BloodGroup = BLOODGROUP.ABP;
                    else if (bloodGroup == "op")
                        patient.BloodGroup = BLOODGROUP.OP;
                    else if (bloodGroup == "an")
                        patient.BloodGroup = BLOODGROUP.AN;
                    else if (bloodGroup == "bn")
                        patient.BloodGroup = BLOODGROUP.BN;
                    else if (bloodGroup == "abn")
                        patient.BloodGroup = BLOODGROUP.ABN;
                    else if (bloodGroup == "on")
                        patient.BloodGroup = BLOODGROUP.ON;
                    else
                        return false;

                    return true;

                }
                catch (Exception ex)
                {
                    return Utilities.logException(ex);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool extractDoctorDetails(Dictionary<string, string> doctorDetails, Users.Doctor doctor)
        {
            if (extractGenericUserDetails(doctorDetails, doctor) == true)
            {
                try
                {
                    doctor.DepartmentID = UInt32.Parse(doctorDetails["department_id"]);
                    doctor.Qualification = doctorDetails["qualification"];
                    return true;
                }
                catch (Exception ex)
                {
                    return logException(ex);
                }
            }
            else
            {
                return false;
            }
        }

        

    }
}
