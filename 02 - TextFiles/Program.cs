using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02___TextFiles
{
    /*
     * Программно создайте текстовый файл и запишите в него 10 случайных чисел. 
     * Затем программно откройте созданный файл, рассчитайте сумму чисел в нем, ответ выведите на консоль.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Test",
                sfile = "test.txt",
                fullDirFiles = ((path.Length > 0) ? (path + @"\") : ("")) + sfile;

            int k = 10;
            string[] strArray = new string[k];
            Random random = new Random();

            for (int i = 0; i < k; i++)
            {
                strArray[i] = Convert.ToString(random.Next(0, 100));
            }

            CreateDir(path);
            WriteTxtFiles(fullDirFiles, strArray);
            double Sum = CalcSumData(fullDirFiles, k);

            //Для проверки
            /*
            string[] dataSt = new string[k];
            ReadTxtFiles(fullDirFiles, ref dataSt);
            foreach (var item in dataSt)
            {
                Console.WriteLine(item);
            }
            */

            Console.WriteLine();
            Console.WriteLine("Сумма записанных чесел = {0}", Sum);

            Console.ReadKey();
        }
        static void CreateDir(string path)
        {
            if ((!Directory.Exists(path)) && (path.Length > 0))
            {
                Directory.CreateDirectory(path);
            }
        }
        static void WriteTxtFiles(string filePath, params string[] data)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var str in data)
                {
                    sw.WriteLine(str);
                }
            }
        }
        static void ReadTxtFiles(string filePath, ref string[] data)
        {
            Array.Clear(data, 0, data.Length);
            using (StreamReader sr = new StreamReader(filePath))
            {
                data = sr.ReadToEnd().Split('\n');
            }
        }
        static double CalcSumData(string pathdir, int k)
        {
            double result = 0;
            string[] dataSt = new string[k];
            ReadTxtFiles(pathdir, ref dataSt);
            if (dataSt.Length == 0)
            {
                return result;
            }
            foreach (var st in dataSt)
            {
                if (st != "")
                {
                    result += Convert.ToDouble(st);
                }
            }
            return result;
        }
    }
}
