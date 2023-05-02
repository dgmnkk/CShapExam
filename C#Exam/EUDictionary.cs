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
        public Dictionary<string, string> dict;
        
        public EUDictionary()
        {
            dict = new Dictionary<string, string>();
        }
        public EUDictionary(Dictionary<string, string> dict)
        {
            this.dict = dict;
        }
        public void AddNewWord(string word, string traslate)
        {
            dict.Add(word, traslate);
        }
        public void RemoveWord(string word)
        {
            dict.Remove(word);
        }
        public void ChangeTranslate(string word)
        {
            Console.WriteLine("Enter new translate: ");
            string tmpTranslate = Console.ReadLine();
            dict[word] = tmpTranslate;
        }
        public void Traslate(string word)
        {
            dict.TryGetValue(word, out var traslate);
            Console.WriteLine(word + "-"+ traslate);
        }
        public void Print()
        {
            var keys = dict.Keys;
            foreach (string key in keys)
            {
                Console.WriteLine(key + "-" + dict[key]);
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
