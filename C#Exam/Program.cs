using System;
using System.Text;
using System.Text.Json;

namespace C_Exam
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int choise = -1;
            int c = -1;
            string FileName = "English-UkrainianDictionary.json";
            Console.WriteLine("_____English-Ukrainian Dictionary_____");
            Console.WriteLine("1. Create new dictionary 2. Download from file");
            c = Convert.ToInt32(Console.ReadLine());
            EUDictionary d= new EUDictionary();
            switch (c)
            {
                case 1:
                    d = new EUDictionary();
                    break;
                case 2:
                    string deserializedList = File.ReadAllText(FileName);
                    Dictionary<string, List<string>> tmp = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(deserializedList);
                    d = new EUDictionary(tmp);
                    break;
            }
            do
            {
                Console.WriteLine("1. Add new word\n2. Change word\n3. Delete word\n4. Translate\n5. Save dictionary in file\n6. Print dictionary\n0. Exit");
                choise = Convert.ToInt32(Console.ReadLine());
                string w;
                string t;
                
                switch (choise)
                {
                    case 1:
                        
                        
                        Console.WriteLine("Enter word in English: ");
                        w = Console.ReadLine();
                        Console.WriteLine("How much translates you want to add?");
                        int count = Convert.ToInt32(Console.ReadLine());
                        List<string> strings = new List<string>();
                        for (int i = 0; i < count;i ++)
                        {
                            strings.Add(Console.ReadLine());
                        }
                        d.AddNewWord(w,strings );
                        break;
                    case 2:
                        
                        Console.WriteLine("Change word");
                        Console.WriteLine("Enter word which translate you want to change: ");
                        w = Console.ReadLine();
                        d.ChangeTranslate(w);
                        break; 
                    case 3:
                        
                        Console.WriteLine("Enter word you want to delete: ");
                        w = Console.ReadLine();
                        d.RemoveWord(w);
                        break;
                    case 4:
                        
                        Console.WriteLine("Enter word you want to find translate of: ");
                        w = Console.ReadLine();
                        d.Traslate(w);
                        break;
                    case 5:
                        
                        d.SaveInFile();
                        break;
                    case 6:
                        
                        Console.WriteLine("____Dictionary_____");
                        d.Print();
                        break;
                    default: Console.WriteLine("Try again"); break;
                }

            } while (choise != 0);
        }
    }
}