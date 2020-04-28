using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _modeValue;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }


            return _connectionString;

        }

        public static string GetModeValue()
        {
            if (string.IsNullOrEmpty(_modeValue))
            {
                _modeValue = ConfigurationManager.AppSettings["Mode"].ToString();
            }


            return _modeValue;

        }
    }
}
