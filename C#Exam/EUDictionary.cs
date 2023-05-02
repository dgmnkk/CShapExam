using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Exam
{
    internal class EUDictionary
    {
        public Dictionary<string, object> dict;
        public EUDictionary()
        {
            dict = new Dictionary<string, object>();
        }
        public EUDictionary(Dictionary<string, object> dict)
        {
            this.dict = dict;
        }
        public void AddNewWord(string word, object traslate)
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
    }
}
