using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03___StaticText
{
    /*
     * Вручную подготовьте текстовый файл с фрагментом текста. 
     * Напишите программу, которая выводит статистику по файлу - количество символов, строк и слов в тексте.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Test\TestText.txt"; //Путь к файлу
            string dataTex = "";
            ReadTxtFiles(path, ref dataTex);

            string[] strArrWord = dataTex.Split();

            int numRow = dataTex.Split('\n').Length;
            //(path.Length>0)?(File.ReadAllLines(path).Length):(0); 
            //numRow += dataTex.Split('\r').Length; 

            int numWord = 0;
            int numChar = 0;
            foreach (var str in strArrWord)
            {
                if (str.Length > 0)
                {
                    numWord++;
                }
                numChar += str.Length;
            }



            Console.WriteLine("Количество символов в тексте:  {0}", numChar);
            Console.WriteLine("Количество строк в тексте:  {0}", numRow);
            Console.WriteLine("Количество слов в тексте:  {0}", numWord);
            Console.ReadKey();
        }

        static void ReadTxtFiles(string filePath, ref string data)
        {
            data = "";
            if (filePath.Length == 0)
            {
                return;
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                data = sr.ReadToEnd();
            }
        }
    }
}
