using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400122
{
    public class Covid_Config
    {
        public string satuan_suhu {  get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima {  get; set; }
    }
    public class CovidConfig
    {
        public Covid_Config config;
        private const string path = "covid_config.json";
        public CovidConfig()
        {
            string jsonString = File.ReadAllText(path);
            config = JsonSerializer.Deserialize<Covid_Config>(jsonString);
        }
        public void UbahSatuan()
        {
            config.satuan_suhu = config.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
        }
    }
}
