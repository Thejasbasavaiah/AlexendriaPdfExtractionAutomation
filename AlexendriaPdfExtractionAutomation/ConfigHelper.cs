using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;



namespace AlexendriaPdfExtractionAutomation
{
    public static class ConfigHelper
    {

        public static string GetRootLocation()
        {
            try
            {
                return GetAppConfigValue("RootDirectory", "Path");
            }
            catch (System.Exception e)
            {
                //_logger.LogError(e);
                return default(string);
            }
        }



      
        public static string GetAppConfigValue(string sectionName, string propertyName)
        {
            try
            {
                var currentFolder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(currentFolder)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var configuration = builder.Build();
                var configurationSection = configuration.GetSection(sectionName).GetSection(propertyName);
                return configurationSection.Value;
            }
            catch (System.Exception e)
            {
                //_logger.LogError(e);
                return default(string);
            }
        }

        public static string GetAlexandriaUrl()
        {
            try
            {
                return GetAppConfigValue("DocumentPDFExtractionApi", "BaseUrl");
            }
            catch (System.Exception e)
            {
                //_logger.LogError(e);
                return default(string);
            }
        }
        public static string GetAlexandriaKey()
        {
            try
            {
                return GetAppConfigValue("DocumentPDFExtractionApi", "x-api-key");
            }
            catch (System.Exception e)
            {
                //_logger.LogError(e);
                return default(string);
            }
        }
    }
}


