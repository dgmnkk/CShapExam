using System;
using System.Text;
using System.Text.Json;

namespace C_Exam
{
    
    internal class Program
    {
        
        static void Menu(EUDictionary d, List<string>dictionaries)
        {
            int choise = -1;
            do
            {
                Console.WriteLine("1. Add new word\n2. Change translate\n3. Delete word\n4. Translate\n5. Save dictionary in file\n6. Print dictionary\n7. Add new translate\n8. Delete translate\n0. Go back to main menu");
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
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Enter {i + 1} translate: ");
                            strings.Add(Console.ReadLine());
                        }
                        d.AddNewWord(w, strings);
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
                        d.SaveInFile(dictionaries);
                        break;
                    case 6:
                        Console.WriteLine("____Dictionary_____");
                        d.Print();
                        break;
                    case 7:
                        Console.WriteLine("Enter word:");
                        w = Console.ReadLine();
                        Console.WriteLine("Enter new translate: ");
                        t = Console.ReadLine();
                        d.AddNewTranslate(w, t);
                        break;
                    case 8:
                        Console.WriteLine("Enter word:");
                        w = Console.ReadLine();
                        d.RemoveTranslate(w);
                        break;
                }

            } while (choise != 0);
        }

        static void Main(string[] args)
        {
            List<string> dictionaries = new List<string> { "English-UkrainianDictionary.json", "NewDictionary.json"};
            int c = -1;
            string FileName;
            EUDictionary d= new EUDictionary();
            
            do
            {
                Console.Clear();
                Console.WriteLine("_____English-Ukrainian Dictionary_____");
                Console.WriteLine("1. Create new dictionary 2. Download from file 0. Exit");
                c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        d = new EUDictionary();
                        Menu(d, dictionaries);
                        break;

                    case 2:
                        for(int i =0; i < dictionaries.Count; i++)
                        {
                            Console.WriteLine($"{i+1} {dictionaries[i]}");    
                        }
                        Console.WriteLine("What file you want to choose?");
                        int f = Convert.ToInt32(Console.ReadLine());
                        FileName = dictionaries[f - 1];
                        
                        try
                        {
                            string deserializedList = File.ReadAllText(FileName);
                            Dictionary<string, List<string>> tmp = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(deserializedList);
                            d = new EUDictionary(tmp);
                            Menu(d, dictionaries);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        
                        break;
                }
                
            }while(c!= 0);
            
        }
    }
}