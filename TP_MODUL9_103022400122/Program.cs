using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TP_MODUL9_103022400122
{
    public class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();
            cekkondisi(config);

            config.UbahSatuan();

            cekkondisi(config);
        }
        static void cekkondisi(CovidConfig config)
        {
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.config.satuan_suhu}");
            string Suhu = Console.ReadLine();

            double suhu = double.Parse(Suhu.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir kali demam? ");
            int hari = int.Parse(Console.ReadLine());

            bool statusSuhu = false;
            if (config.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                {
                    statusSuhu = true;
                }
            }
            else if (config.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                {
                    statusSuhu = true;
                }
            }
            bool statusHari = hari < config.config.batas_hari_demam;

            Console.WriteLine("Hasil: ");
            if (statusSuhu && statusHari)
            {
                Console.WriteLine(config.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.config.pesan_ditolak);
            }
        }
    }
}
