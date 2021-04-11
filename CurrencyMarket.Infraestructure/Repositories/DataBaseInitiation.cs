using CurrencyMarket.Core.Interfaces.Repositories;
using CurrencyMarket.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CurrencyMarket.Infraestructure.Repositories
{
    public class DataBaseInitiation : IDataBaseInitiation
    {
        public DefaultDataConfig GetDataConfig()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            string directoryPath = Path.GetDirectoryName(path);
            string filePath = $"{directoryPath}/initData.json";

            if (File.Exists(filePath))
            {
                using (var file = new StreamReader(filePath))
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<DefaultDataConfig>(json);
                }
            }
            return null;
        }
    }
}
