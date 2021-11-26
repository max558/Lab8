using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01___Direct
{
    /*
     * Выберите любую папку на своем компьютере, имеющую вложенные директории. 
     * Выведите на консоль ее содержимое и содержимое всех подкаталогов.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\";
            
            DirectoryInfo direct = new DirectoryInfo(path);
            Directories(direct);          

            Console.ReadKey();
        }
        static void FileName(DirectoryInfo dir, string prefix = "")
        {
            FileInfo[] filesArr = dir.GetFiles();
            if (filesArr.Length > 0)
            {
                Console.WriteLine(prefix + "----Файлы----");
                foreach (FileInfo fio in filesArr)
                {                  
                    Console.WriteLine(prefix + fio.Name);
                }
            }
        }

        static void Directories(DirectoryInfo dir, string prefix="")
        {
            foreach (var x in dir.GetDirectories().OrderBy(x => x.Name))
            {
                Console.WriteLine(prefix + x); 
                FileName(x, prefix);
                if (x.GetDirectories().Count() > 0)
                {
                    Directories(x, prefix + "    ");
                }
            }
        }
    }
}
