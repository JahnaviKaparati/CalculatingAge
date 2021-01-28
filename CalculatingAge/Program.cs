using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CalculatingAge
{
    [Serializable]
    public class AgeCalcu
    {

        public int Age { get; set; } 
        public AgeCalcu(DateTime dob)
        {
            
            if (DateTime.Now.Year < dob.Year)
                Age--;
            else
                Age = DateTime.Now.Year - dob.Year;


        }
        public void AgeMethod()
        {
            
            Console.WriteLine($"Age is {Age}");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Date Of Birth in dd/mm/yyyy format");
            
            AgeCalcu ac = new AgeCalcu(Convert.ToDateTime(Console.ReadLine()));
            
            FileStream fs = new FileStream(@"age.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs, ac);
            fs.Seek(0, SeekOrigin.Begin);

            AgeCalcu ad = (AgeCalcu)b.Deserialize(fs);
            ad.AgeMethod();
            
            
        }
    }
}
