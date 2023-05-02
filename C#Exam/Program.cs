using System.Text;

namespace C_Exam
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            //int choise = -1;
            //do
            //{
            //    Console.WriteLine("_____English-Ukrainian Dictionary_____");
            //    Console.WriteLine("1. Add new word\n2. Change word\n3. Delete word\n4. Translate\n5. Download dictionary from file\n6. Save dictionary in file\n0. Exit");
            //    choise = Convert.ToInt32(Console.ReadLine());
            //    switch( choise )
            //    {
            //        case 1:
            //            Console.Clear();
            //            Console.WriteLine("Add new word to dictionary");
            //            break;
            //    }

            //} while (choise != 0);

            EUDictionary d = new EUDictionary();
            d.AddNewWord("Hello", "Привіт");
            d.Traslate("Hello");
            d.ChangeTranslate("Hello");
            d.Traslate("Hello");
        }
    }
}