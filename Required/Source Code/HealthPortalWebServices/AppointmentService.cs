using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HealthPortalWebServices
{
    public class AppointmentService: IAppointmentService
    {
        private static string connectionString = "server=localhost;user=root;database=hpdb;port=3306;password=master;";
        private UInt64 maxAppointmentID;
        private MySqlConnection connection;
        
        // Default Constructor
        public AppointmentService()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                maxAppointmentID = Utilities.getMaxAppointmentID(connection);
                if (maxAppointmentID == 0)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> GetAppointmentDetails(UInt64 appointmentID, string username, string password)
        {
            Dictionary<string, object> details = new Dictionary<string, object>();

            // Validate information seeker
            UInt64 uid = 0;
            short userType = Utilities.isValidUserCredentials(ref uid, username, password, connection);
            if (userType != 1 && userType != 2) // only doctor or patient himself can check some appointment
            {
                details["status"] = "Invalid username/password";
                return details;
            }

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadAppointmentDetailsQuery(appointmentID);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader == null || !reader.Read())
                {
                    details["status"] = "Invalid appointment ID";
                    return details;
                }

                details["pid"] = reader.GetUInt64("pid");
                details["dept_id"] = reader.GetUInt64("dept_id");
                details["appointment_time"] = reader.GetUInt64("appointment_time");
                details["status"] = reader.GetInt16("status");
                details["status_change_time"] = reader.GetUInt64("status_change_time");
                details["dr_id"] = reader.GetUInt64("dr_id");
                reader.Close();

                return details;
            }
            catch (Exception ex)
            {
                details["status"] = ex.Message;
                Utilities.logException(ex);
                return details;
            }
        }
        public Dictionary<string, object> GetAppointment(string patientUsername, string patientPassword, UInt32 hospitalID, UInt64 departmentID)
        {
            Dictionary<string, object> details = new Dictionary<string, object>();

            // Validate information seeker
            UInt64 uid = 0;
            short userType = Utilities.isValidUserCredentials(ref uid, patientUsername, patientPassword, connection);
            if (userType != 2)  // Only patient can get an appointment
            {
                details["status"] = "Invalid username/password";
                return details;
            }

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadMaxAppointment(departmentID);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                UInt64 maxTime = (UInt64)command.ExecuteScalar();
                DateTime time = DateTime.FromFileTime((long)maxTime);
                time.AddMinutes(15);    // Consider 15 minutes slot per patient
                if (time.Hour > 14)
                {
                    TimeSpan span = new TimeSpan(6, 0, 0);
                    time = time.Subtract(span);
                    do
                    {
                        time.AddDays(1);
                    }while(time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday);
                }

                command = connection.CreateCommand();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                command.CommandText = QueryBuilder.getAddAppointmentQuery(maxAppointmentID++, uid, departmentID, (UInt64)time.ToFileTime());
                
                if (command.ExecuteNonQuery() == 0)
                {
                    details["aid"] = maxAppointmentID - 1;
                    details["pid"] = uid;
                    details["dept_id"] = departmentID;
                    details["appointment_time"] = time.ToFileTime();
                    details["status"] = 0;
                    return details;
                }
                else
                {
                    details["status"] = "FAILED";
                    return details;
                }
            }
            catch (Exception ex)
            {
                details["status"] = ex.Message;
                Utilities.logException(ex);
                return details;
            }
        }

    }
}
