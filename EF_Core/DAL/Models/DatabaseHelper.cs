using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            string connectionString = builder.Build().GetConnectionString("EventDbCon");
            return connectionString;
        }
    }
}