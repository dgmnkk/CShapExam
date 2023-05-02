using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace C_Exam
{
    internal class EUDictionary
    {
        public Dictionary<string, List<string>> dict;
        
        public EUDictionary()
        {
            dict = new Dictionary<string, List<string>>();
        }
        public EUDictionary(Dictionary<string, List<string>> dict)
        {
            this.dict = dict;
        }
        public void AddNewWord(string word, List<string> traslate)
        {
            dict.Add(word, traslate);
        }
        public void RemoveWord(string word)
        {
            dict.Remove(word);
        }
        public void ChangeTranslate(string word)
        {
            Console.WriteLine("Enter translate you want to change: ");
            string toChange = Console.ReadLine();
            Console.WriteLine("Enter new translate: ");
            string tmpTranslate = Console.ReadLine();
            dict[word].Remove(toChange);
            dict[word].Add(tmpTranslate);
        }
        public void Traslate(string word)
        {
            Console.WriteLine(word+ ":");
            foreach(var items in dict[word])
            {
                Console.WriteLine(items);
            }
        }
        public void Print()
        {
            var keys = dict.Keys;
            foreach (string key in keys)
            {
                Console.WriteLine(key+ ":");
                foreach (var items in dict[key])
                {
                    Console.WriteLine(items);
                }
            }
        } 
        public void SaveInFile()
        {
            string FileName = "English-UkrainianDictionary.json";
            try
            {
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All), 
                };
                string SerializedList = JsonSerializer.Serialize(dict, options);
                
                File.WriteAllText(FileName, SerializedList);

                Console.WriteLine($"Done! Look at file {FileName}");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }

    }
}
