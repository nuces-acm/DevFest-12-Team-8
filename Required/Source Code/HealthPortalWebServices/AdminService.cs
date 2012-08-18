using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HealthPortalWebServices
{
    public class AdminService: IAdminService
    {
        // Data Members
        private static string connectionString = "server=localhost;user=root;database=hpdb;port=3306;password=master;";
        private UInt64 maxDepartmentID;
        private MySqlConnection connection;


        // Default Constructor
        public AdminService()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                maxDepartmentID = Utilities.getMaxDepartmentID(connection);
                if (maxDepartmentID == 0)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Exposed Methods
        public string addDepartment(UInt32 hospitalID, string departmentName, string adminUsername, string adminPassword)
        {
            UInt64 uid = 0;
            if(Utilities.isValidUserCredentials(ref uid, adminUsername, adminPassword, connection) != 0)
                return "INVALID ADMIN USERNAME OR PASSWORD";


            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAddDepartmentQuery(hospitalID, maxDepartmentID++, departmentName);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                if (command.ExecuteNonQuery() == 0)
                    return "OK";
                else
                    return "FAILED";
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return "FAILED";
            }
        }
        public string assignDoctorToDepartment(UInt64 departmentID, UInt64 doctorID, string adminUsername, string adminPassword)
        {
            UInt64 uid = 0;
            if (Utilities.isValidUserCredentials(ref uid, adminUsername, adminPassword, connection) != 0)
                return "INVALID ADMIN USERNAME OR PASSWORD";


            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getAssignDepartmentToDoctorQuery(departmentID, doctorID);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                if (command.ExecuteNonQuery() == 0)
                    return "OK";
                else
                    return "FAILED";
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return "FAILED";
            }
        }
        public List<Hospital> getListOfHospitals()
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadAllHospitalsQuery();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                Hospital hospital = null;
                MySqlDataReader reader = command.ExecuteReader();
                List<Hospital> hospitalsList = new List<Hospital>();
                while (reader.Read())
                {
                    hospital = new Hospital();
                    hospital.ID = reader.GetUInt32("hid");
                    hospital.Name = reader.GetString("hospital_name");
                    hospitalsList.Add(hospital);
                }
                reader.Close();
                return hospitalsList;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return null;
            }
        }
        public List<Department> getListOfDepartments(UInt32 hospitalID)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = QueryBuilder.getReadAllDepartmentsQuery(hospitalID);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                Department department = null;
                MySqlDataReader reader = command.ExecuteReader();
                List<Department> deptList = new List<Department>();
                while (reader.Read())
                {
                    department = new Department();
                    department.ID = reader.GetUInt32("did");
                    department.Name = reader.GetString("department_name");
                    deptList.Add(department);
                }
                reader.Close();
                return deptList;
            }
            catch (Exception ex)
            {
                Utilities.logException(ex);
                return null;
            }
        }
    }
}
