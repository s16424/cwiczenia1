using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
namespace Cwiczenia1
{
    public class Student
    {
        public string Nazwisko { get; set; }
        private string _imie;
        //Properties - methods -fields 
        public string imie
        {
            get { return _imie; }
            set
            {
                if (value == null) throw new ArgumentException();
                _imie = value;
            }
        }

    }


    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
                var client = new HttpClient();
                var result = await client.GetAsync(url);

                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Server error");
                    return;
                }
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);

                //kolekcje
                var set = new HashSet<string>();
                var list = new List<string>();
                var elementy = from e in list
                               where e.StartsWith("A")
                               select e;
                var elementy2 = list.Where(s => s.StartsWith("A"));

                var slownik = new Dictionary<string, string>();

                //LINQ - COS JAK SQL W BD


                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }

                Console.WriteLine("koniec!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystapil blad{ ex.ToString()}");
            }
        }
    }
}
