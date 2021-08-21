using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AClass aClass = new AClass();
            aClass.Name = "Hosikawa Gen";
            aClass.Age = 29;

            string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(aClass);

            AClass obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AClass>(jsonText);
            obj.Name = "Hosikawa";
            obj.Age = 29;
  
        }
        public static void WriteName(AClass aClass)
        {
            Console.WriteLine(aClass.Name);
        }
        public class AClass
        { 
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
