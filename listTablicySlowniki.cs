using System;
using System.Collections.Generic;

enum DyscyplinaSportowa
{
    PilkaNozna,
    Koszykowka,
    Siatkowka,
    Lekkoatletyka,
    Tenis,
    Hokej
}

class Program
{
    static string[] drużyny = new string[10] 
    {
        "Orły Warszawa", "Smoki Kraków", "Wikingowie Gdańsk", 
        "Lwy Poznań", "Diabły Wrocław", "Gladiatorzy Łódź", 
        "Królowie Lublin", "Jastrzębie Rzeszów", "Wilki Bydgoszcz", 
        "Tytani Katowice"
    };

    // Lista przechowująca zawodników
    static List<(string imie, string nazwisko, DyscyplinaSportowa dyscyplina, int wiek, int punkty)> zawodnicy = new List<(string, string, DyscyplinaSportowa, int, int)>
    {
        ("Jan", "Kowalski", DyscyplinaSportowa.PilkaNozna, 25, 20),
        ("Piotr", "Nowak", DyscyplinaSportowa.Koszykowka, 30, 35),
        ("Adam", "Lewandowski", DyscyplinaSportowa.Siatkowka, 22, 15),
        ("Marek", "Wiśniewski", DyscyplinaSportowa.Lekkoatletyka, 28, 40),
        ("Kamil", "Zieliński", DyscyplinaSportowa.Tenis, 26, 25),
        ("Łukasz", "Jankowski", DyscyplinaSportowa.Hokej, 24, 10),
        ("Paweł", "Szymański", DyscyplinaSportowa.PilkaNozna, 27, 12),
        ("Katarzyna", "Mazur", DyscyplinaSportowa.Koszykowka, 29, 18),
        ("Ewa", "Nowak", DyscyplinaSportowa.Siatkowka, 24, 22),
        ("Monika", "Kwiatkowska", DyscyplinaSportowa.Lekkoatletyka, 32, 14),
        ("Tomasz", "Kowalczyk", DyscyplinaSportowa.Tenis, 27, 30),
        ("Andrzej", "Ostrowski", DyscyplinaSportowa.Hokej, 21, 25),
        ("Michał", "Rogowski", DyscyplinaSportowa.PilkaNozna, 23, 28),
        ("Szymon", "Wiśniewski", DyscyplinaSportowa.Koszykowka, 25, 15),
        ("Joanna", "Chmiel", DyscyplinaSportowa.Siatkowka, 22, 18)
    };

    // Słownik drużyn i przypisanych do nich zawodników
    static Dictionary<string, List<(string, string, DyscyplinaSportowa, int, int)>> druzynyZawodnicy = new Dictionary<string, List<(string, string, DyscyplinaSportowa, int, int)>>();

    static void Main(string[] args)
    {
        bool continueProgram = true;
        while (continueProgram)
        {
            WyswietlMenu();
            int choice = PobierzWybor();
            switch (choice)
            {
                case 1:
                    WyswietlDruzyne();
                    break;
                case 2:
                    DodajZawodnikaDoDruzyny();
                    break;
                case 3:
                    UsunZawodnika();
                    break;
                case 4:
                    PokazZawodnikowDyscypliny();
                    break;
                case 5:
                    AktualizujPunkty();
                    break;
                case 6:
                    WyszukajZawodnika();
                    break;
                case 0:
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void WyswietlMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Wyświetl drużynę");
        Console.WriteLine("2 - Dodaj zawodnika do drużyny");
        Console.WriteLine("3 - Usuń zawodnika");
        Console.WriteLine("4 - Wyświetl zawodników danej dyscypliny");
        Console.WriteLine("5 - Aktualizuj punkty zawodnika");
        Console.WriteLine("6 - Wyszukaj zawodnika");
        Console.WriteLine("0 - Zakończ");
        Console.Write("Wybierz opcję: ");
    }

    static int PobierzWybor()
    {
        int wybor;
        while (!int.TryParse(Console.ReadLine(), out wybor) || wybor < 0 || wybor > 6)
        {
            Console.WriteLine("Wybór musi być liczbą z zakresu 0-6.");
        }
        return wybor;
    }

    static void WyswietlDruzyne()
    {
        Console.Write("Podaj nazwę drużyny: ");
        string nazwaDruzyny = Console.ReadLine();

        if (druzynyZawodnicy.ContainsKey(nazwaDruzyny))
        {
            var zawodnicyDruzyny = druzynyZawodnicy[nazwaDruzyny];
            Console.WriteLine($"Zawodnicy drużyny {nazwaDruzyny}:");
            foreach (var zawodnik in zawodnicyDruzyny)
            {
                Console.WriteLine($"{zawodnik.imie} {zawodnik.nazwisko}, Dyscyplina: {zawodnik.dyscyplina}, Wiek: {zawodnik.wiek}, Punkty: {zawodnik.punkty}");
            }
        }
        else
        {
            Console.WriteLine("Drużyna o podanej nazwie nie istnieje.");
        }
    }

    static void DodajZawodnikaDoDruzyny()
    {
        Console.Write("Podaj imię zawodnika: ");
        string imie = Console.ReadLine();
        Console.Write("Podaj nazwisko zawodnika: ");
        string nazwisko = Console.ReadLine();
        Console.Write("Podaj dyscyplinę sportową (1 - Piłka Nożna, 2 - Koszykówka, 3 - Siatkówka, 4 - Lekkoatletyka, 5 - Tenis, 6 - Hokej): ");
        int dyscyplinaChoice = int.Parse(Console.ReadLine());
        DyscyplinaSportowa dyscyplina = (DyscyplinaSportowa)(dyscyplinaChoice - 1);
        Console.Write("Podaj wiek zawodnika: ");
        int wiek = int.Parse(Console.ReadLine());
        Console.Write("Podaj punkty zawodnika: ");
        int punkty = int.Parse(Console.ReadLine());

        var nowyZawodnik = (imie, nazwisko, dyscyplina, wiek, punkty);

        Console.Write("Podaj nazwę drużyny: ");
        string nazwaDruzyny = Console.ReadLine();

        if (!druzynyZawodnicy.ContainsKey(nazwaDruzyny))
        {
            druzynyZawodnicy[nazwaDruzyny] = new List<(string, string, DyscyplinaSportowa, int, int)>();
        }

        druzynyZawodnicy[nazwaDruzyny].Add(nowyZawodnik);
        Console.WriteLine("Zawodnik został dodany do drużyny.");
    }

    static void UsunZawodnika()
    {
        Console.Write("Podaj imię zawodnika do usunięcia: ");
        string imie = Console.ReadLine();
        Console.Write("Podaj nazwisko zawodnika do usunięcia: ");
        string nazwisko = Console.ReadLine();

        foreach (var drużyna in druzynyZawodnicy)
        {
            var zawodnikDoUsuniecia = drużyna.Value.Find(z => z.imie == imie && z.nazwisko == nazwisko);
            if (zawodnikDoUsuniecia != default)
            {
                drużyna.Value.Remove(zawodnikDoUsuniecia);
                Console.WriteLine("Zawodnik został usunięty.");
                return;
            }
        }
        Console.WriteLine("Zawodnik o podanym imieniu i nazwisku nie został znaleziony.");
    }

    static void PokazZawodnikowDyscypliny()
    {
        Console.Write("Podaj numer dyscypliny (1 - Piłka Nożna, 2 - Koszykówka, 3 - Siatkówka, 4 - Lekkoatletyka, 5 - Tenis, 6 - Hokej): ");
        int dyscyplinaChoice = int.Parse(Console.ReadLine());
        DyscyplinaSportowa dyscyplina = (DyscyplinaSportowa)(dyscyplinaChoice - 1);

        Console.WriteLine($"Zawodnicy uprawiający dyscyplinę {dyscyplina}:");
        foreach (var zawodnik in zawodnicy)
        {
            if (zawodnik.dyscyplina == dyscyplina)
            {
                Console.WriteLine($"{zawodnik.imie} {zawodnik.nazwisko}, Wiek: {zawodnik.wiek}, Punkty: {zawodnik.punkty}");
            }
        }
    }

    static void AktualizujPunkty()
    {
        Console.Write("Podaj imię zawodnika: ");
        string imie = Console.ReadLine();
        Console.Write("Podaj nazwisko zawodnika: ");
        string nazwisko = Console.ReadLine();

        foreach (var zawodnik in zawodnicy)
        {
            if (zawodnik.imie == imie && zawodnik.nazwisko == nazwisko)
            {
                Console.Write("Podaj liczbę punktów do dodania: ");
                int punkty = int.Parse(Console.ReadLine());
                zawodnik.punkty += punkty;
                Console.WriteLine("Punkty zostały zaktualizowane.");
                return;
            }
        }
        Console.WriteLine("Zawodnik o podanym imieniu i nazwisku nie został znaleziony.");
    }

    static void WyszukajZawodnika()
    {
        Console.Write("Podaj nazwisko zawodnika: ");
        string nazwisko = Console.ReadLine();

        foreach (var zawodnik in zawodnicy)
        {
            if (zawodnik.nazwisko == nazwisko)
            {
                Console.WriteLine($"Zawodnik znaleziony: {zawodnik.imie} {zawodnik.nazwisko}, Dyscyplina: {zawodnik.dyscyplina}, Wiek: {zawodnik.wiek}, Punkty: {zawodnik.punkty}");
                return;
            }
        }
        Console.WriteLine("Zawodnik o podanym nazwisku nie został znaleziony.");
    }
}
