
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project_text;



namespace Project_text
{
    class Program
    {
        /*
•  Распарсить предложенный документ на:  
o  Предложения 
o  Слова 
o  Знаки препинания 
•  Вывести в другой файл слова в алфавитном порядке, с указанием 
количества использований данного слова. 
•  В ещё один файл вывести с новой строки 
o  самое длинное предложение по количеству символов 
o  самое короткое предложение по количеству слов 
o  самую встречающуюся букву 

 */
        private static void Main(string[] args)

        {

            string line = "=============================================================";

            IFileReader r = new TextReader(@"D:/New/sample.txt");

            List<string> listSentences = new List<string>();      

            IParser<Text> parser = new TextParser();
            
            listSentences = r.Read();

            var file = @"D:/New/sample.txt";
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    var text1 = sr.ReadToEnd();
                    Console.WriteLine(text1);

                    var allwords = text1.Split(new char[] { ' ', '-', '\'', '.', '=', ',', '"', ' ', '!', ';', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    var unique =
                        (from word in allwords select word.ToLower()).Distinct().OrderBy(name => name);
                    foreach (var word in unique)
                    {
                        int cnt = (from word2 in allwords where word2.ToLower() == word select word2).Count();
                        Console.WriteLine("Word: {0} - {1}", word, cnt);

                    }
                    // string input = "Some sequence for test";
                    Console.WriteLine("Word with max length: " + text1.Split(new Char[] { '.', ':', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries).OrderByDescending(s => s.Length).First());
                    Console.WriteLine("Word with min length: " + text1.Split(new Char[] { '.', ':', '!', '?', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(s => s.Length).First());
                    //string text1 = Console.ReadLine();
                    Console.WriteLine(text1.Select(x => new { Symbol = x, Count = text1.Count(y => y == x) }).OrderByDescending(x => x.Count).First().Symbol);
                    Console.WriteLine(text1.GroupBy(c => c).OrderByDescending(g => g.Count()).First().Key);

                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }




var text = parser.Parse(listSentences);



            //1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.

            foreach (var item in text.SortSentences())

            {

                string writePath = @"D:\1.txt";

              //  string text1 = "kjgjhghghj";
                try
                {
                   /* using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                    {
                        text = sr.ReadToEnd();
                    }*/
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item);
                    }

                   /* using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("Дозапись");
                        sw.Write(4.5);
                    }*/
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                 Console.WriteLine(item);

            }

            Console.WriteLine(line);



            


            Console.ReadKey();

        }

    }

}