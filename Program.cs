using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();
            //słowniki
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Console.Write("Podaj słowo w języku angielskim: ");
                        string key = Console.ReadLine();

                        Console.Write("Podaj tlumaczenie w języku polskim: ");
                        string value = Console.ReadLine();

                        if (translations.ContainsKey(key))
                        {
                            Console.WriteLine("To słowo już istieje");
                        }
                        else
                        {
                            translations.Add(key, value);
                            Console.WriteLine("Tłumaczenie dodano");
                        }

                        break;

                    case "2":
                        Console.Write("Podaj słowo do przetłumaczewnia: ");
                        string searchKey = Console.ReadLine();

                        if(translations.TryGetValue(searchKey, out string translation))
                        {
                            Console.WriteLine($"Tłumaczenia: {translation}");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono tlumaczenie dla podanego słowa");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Lista wszystkich tłumaczeń");
                        foreach(var item in translations)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Podaj słowo do usunięcia: ");
                        string deleteKey = Console.ReadLine();
                        if (translations.Remove(deleteKey))
                        {
                            Console.WriteLine("tłumaczenie usunięnte");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takiego tłumaczenia");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Podaj slowo tłumaczenie którego chcecz zaktualizowac: ");
                        string updateKey = Console.ReadLine();
                        if (translations.ContainsKey(updateKey))
                        {
                            Console.WriteLine("Podaj nowe tłumaczenie");
                            string newValue= Console.ReadLine();
                            translations[updateKey] = newValue;
                            Console.WriteLine("Tłumaczenie zaktualizowane");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takiego tłumaczenia");
                        }
                        break;
                    case "6":
                        Console.WriteLine("koniec programu");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja");
                        break;

                }
            }
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Dodaj nowe tłumaczenie");
            Console.WriteLine("2.Znajdż tlumaczenie");
            Console.WriteLine("3.Wyświetl wszystkie tłumaczenia");
            Console.WriteLine("4.Usuń tłumaczenuia");
            Console.WriteLine("5.Zuktualizuj tłumaczenuia");
            Console.WriteLine("6.Wyjście");
        }
    }
}
