using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;


namespace JustTestAssignment.Configuration
{
    public class ConfigReader
    {
        IConfiguration _config;

        public ConfigReader()
        {
            _config=new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        }
       
 
      
        public string GetRegisterURL()
        {

            var registrationUrl = _config["url"];
            if (registrationUrl != null && registrationUrl.Length!=0) return registrationUrl;
            else throw new Exception("registrationUrl not found in App.config");
             
        }
    }
}
