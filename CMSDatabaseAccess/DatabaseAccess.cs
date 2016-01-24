using CMSDatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSDatabaseAccess
{
    public class DatabaseAccess
    {
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    Configuration config = null;
                    string exeConfigPath = this.GetType().Assembly.Location;
                    try
                    {
                        config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                    }
                    catch (Exception ex)
                    {
                        // log to database
                    }

                    if (config != null)
                    {
                        _connectionString = GetAppSetting(config, "CMSConnectionString");
                    }
                }

                return _connectionString;
            }
        }
        private string _connectionString;

        string GetAppSetting(Configuration config, string key)
        {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element != null)
            {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }

        public List<CarModel> GetAllCars()
        {
            var result = new List<CarModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "proc_get_all_cars";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new CarModel()
                    {
                        CarID = (int)reader["CarID"],
                        Brand = reader["Brand"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        VIN_Number = reader["VIN_Number"].ToString(),
                        TermTechnicalResearch = SqlHelper.GetNullableDatetime(reader["TermTechnicalResearch"]),
                        TechLegalization = SqlHelper.GetNullableDatetime(reader["TechLegalization"]),
                        LiftUDT = SqlHelper.GetNullableDatetime(reader["LiftUDT"]),
                        OCPolicy = SqlHelper.GetNullableDatetime(reader["OCPolicy"]),
                        ACPolicy = SqlHelper.GetNullableDatetime(reader["ACPolicy"]),
                    });
                }
            }

            return result;
        }
    }
}
