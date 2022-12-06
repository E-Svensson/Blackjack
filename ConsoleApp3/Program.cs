using System;
using System.Linq.Expressions;

namespace ____
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Spel = false;
            bool Avslut = false;
            bool Regler = false;

            bool EssSave = true;

            bool DatorLoop = true;
            bool DinLoop = true;

            int DinSumma = 0;
            int DatornsSumma = 0;

            int delay = 1000;

            int Ace = 11;
            int Jack = 10;
            int Queen = 10;
            int King = 10;
            int[] värde = new int[52];
            string[] namn = new string[52];

            int[] Kort = { Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King };
            string[] KortStr = { "Ess", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Knäckt", "Drottning", "Kung", };

            // Kort[0] = Ess
            // Kort[1] = 2
            // Kort[2] = 3
            // Kort[3] = 4
            // Kort[4] = 5
            // Kort[5] = 6
            // Kort[6] = 7
            // Kort[7] = 8
            // Kort[8] = 9
            // Kort[9] = 10
            // Kort[10] = Knäckt
            // Kort[11] = Drottning
            // Kort[12] = Kung

            int[] Färg = { 0, 1, 2, 3 };
            string[] FärgStr = { "Spader", "Klöver", "Hjärter", "Ruter" };

            // Färg[0] = Spader
            // Färg[1] = Klöver
            // Färg[2] = Hjärter
            // Färg[3] = Ruter

            // Ger alla kort sitt eget värde (ID)
            for (int i = 0; i < Färg.Length; i++)
            {
                for (int j = 0; j < Kort.Length; j++)
                {
                    värde[j + 13 * i] = Kort[j];
                    namn[j + 13 * i] = $"{FärgStr[i]} {KortStr[j]}";
                }
            }

            Random slump = new Random();

            // Variabler för dragna kort
            int DittKortID = 0;
            int DatorKortID = 0;
            int ID = 0;
            string[] Prefix = { "Du", "Datorn" };
            int ToggleVärde = (0 ^ 1);
            int Toggle = 0;

            // Skapar en lista för alla dragna kort

            List<int> Dragnakort = new List<int>();
            List<int> Dinakort = new List<int>();
            List<int> Datornskort = new List<int>();

            int[] DragnaKort = new int[52];
            int[] DinaKort = new int[26];
            int[] DatornsKort = new int[26];

            while (Avslut == false)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nVälkommen till Blackjack!");
                    Console.WriteLine("\n1. Spela spelet");
                    Console.WriteLine("2. Spelets regler");
                    Console.WriteLine("3. Kolla de senaste vinnarna");
                    Console.WriteLine("4. Avsluta programmet");
                    Console.Write("\nSkriv här: "); int IntVal = int.Parse(Console.ReadLine());

                    switch (IntVal)
                    {
                        case 1:
                            Spel = true;
                            break;
                        case 2:
                            Regler = true;
                            break;
                        case 3:
                            break;
                        case 4:
                            Avslut = true;
                            break;
                        default:
                            break;
                    }

                    if (Regler)
                    {
                        Console.Clear();
                        Console.WriteLine("\nRegler:");
                        Console.WriteLine("\n- I Blackjack är målet att nå 21 poäng genom att dra kort från en kortlek.");
                        Console.WriteLine("- Man drar automatiskt två kort och får sedan välja om man vill fortsätta dra kort eller inte.");
                        Console.WriteLine("- Hamnar man över 21 poäng förlorar man automatiskt.");
                        Console.WriteLine("\nÖvriga regler:");
                        Console.WriteLine("\n- Ess är värda 11 men om du överskrider 21 med ett ess på hand blir det esset värt 1. Detta kan endast ske ett ess.");

                        Console.Write("\nSkriv här när du har läst klart: "); Console.ReadLine();
                        Regler = false;
                    }

                    while (Spel)
                    {
                        Console.Clear();
                        Console.WriteLine();

                        for (int i = 0; i < 4; i++) // Del 1
                        {
                            Thread.Sleep(delay);

                            ID = slump.Next(0, 52); // Slumpar kort

                            while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                            {
                                ID = slump.Next(0, 52); // Slumpar kort
                            }

                            Dragnakort.Add(ID); // Bekräftar kortet

                            switch (i) // Gömmer datorns första kort
                            {
                                case 1:
                                    Console.WriteLine($"- {Prefix[Toggle]} drog: ?");
                                    break;
                                default:
                                    Console.WriteLine($"- {Prefix[Toggle]} drog: {namn[ID]} ({värde[ID]})");
                                    break;
                            }

                            switch (Toggle) // Vilken lista ska kortet behöra?
                            {
                                case 0:
                                    Dinakort.Add(värde[ID]); // Spelarens lista
                                    break;
                                case 1:
                                    Datornskort.Add(värde[ID]); // Datorns lista
                                    break;
                            }

                            Toggle ^= ToggleVärde; // Byter tur
                        }

                        DinSumma = Dinakort.Sum(); // Summerar
                        DatornsSumma = Datornskort.Sum(); // Summerar

                        Thread.Sleep(delay);

                        Console.WriteLine($"\n(Du har {DinSumma} poäng)");

                        while (DinLoop)
                        {
                            switch (DinSumma)
                            {
                                case < 21:
                                    Thread.Sleep(delay);

                                    Console.Write("\nVill du dra ett till kort (j/n)?: "); string StringVal = Console.ReadLine().ToLower();

                                    switch (StringVal[0])
                                    {
                                        case 'j':
                                            Thread.Sleep(delay);

                                            ID = slump.Next(0, 52); // Slumpar kort

                                            while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                                            {
                                                ID = slump.Next(0, 52); // Slumpar kort
                                            }

                                            Dragnakort.Add(ID); // Bekräftar kortet

                                            Console.WriteLine($"\n- Du drog: {namn[ID]} ({värde[ID]})");

                                            Dinakort.Add(värde[ID]); // Spelarens lista

                                            DinSumma = Dinakort.Sum(); // Summerar

                                            if (EssSave && DinSumma > 21 && Dinakort.Contains(11))
                                            {
                                                Dinakort.Add(-10);

                                                DinSumma = Dinakort.Sum(); // Summerar

                                                Thread.Sleep(delay);

                                                Console.WriteLine("\n(Du överskred 21 så ditt ess är nu värd 1 poäng)");

                                                EssSave = false;
                                            }

                                            Thread.Sleep(delay);

                                            Console.WriteLine($"\n(Du har nu {DinSumma} poäng)");

                                            break;
                                        default:
                                            DinLoop = false;
                                            break;
                                    }

                                    break;
                                case > 20:
                                    DinLoop = false;
                                    break;
                            }

                        }

                        Toggle ^= ToggleVärde; // Byter tur
                        EssSave = true;

                        bool datordrog = false;

                        while (DatorLoop)
                        {
                            switch (DatornsSumma)
                            {
                                case < 17:
                                    Thread.Sleep(delay);

                                    ID = slump.Next(0, 52); // Slumpar kort

                                    while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                                    {
                                        ID = slump.Next(0, 52); // Slumpar kort
                                    }

                                    Dragnakort.Add(ID); // Bekräftar kortet

                                    Console.WriteLine($"\n- Datorn drog: {namn[ID]} ({värde[ID]})");

                                    Datornskort.Add(värde[ID]); // Datorns lista

                                    DatornsSumma = Datornskort.Sum();

                                    if (EssSave && DatornsSumma > 21 && Datornskort.Contains(11))
                                    {
                                        Datornskort.Add(-10);

                                        DatornsSumma = Datornskort.Sum(); // Summerar

                                        Thread.Sleep(delay);

                                        Console.WriteLine($"\n(Datorn överskred 21 så dens ess är nu värd 1 poäng)");

                                        EssSave = false;
                                    }

                                    datordrog = true;

                                    break;
                                default:
                                    Thread.Sleep(delay);

                                    if (datordrog)
                                    {
                                        Console.WriteLine("\n(Datorn drar inga fler kort)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n(Datorn drar inga kort)");
                                    }

                                    DatorLoop = false;

                                    break;
                            }
                        }

                        Toggle ^= ToggleVärde; // Byter tur

                        Thread.Sleep(delay);
                        Console.WriteLine();

                        if (DatornsSumma == 21)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Du förlorade!\n");
                        }
                        else if (DinSumma > 21)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Tyvärr, du förlorade eftersom du överskred 21!\n");
                        }
                        else if (DatornsSumma > 21 && DinSumma <= 21)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Grattis, du vann!\n");
                        }
                        else if (DinSumma > DatornsSumma)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Grattis, du vann!\n");
                        }
                        else if (DinSumma < DatornsSumma)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Tyvärr, du förlorade!\n");
                        }
                        else if (DatornsSumma == DinSumma)
                        {
                            Console.WriteLine($"Datorn fick {DatornsSumma} och du fick {DinSumma}! Tyvärr, du förlorade eftersom datorn vinner när det blir lika!\n");
                        }
                        else
                        {
                            Console.WriteLine("Tyvärr, Du Förlorade!\n");
                        }

                        Thread.Sleep(delay);

                        Console.Write("Vill du köra igen? (j/n): "); string Val = Console.ReadLine().ToLower();

                        switch (Val[0])
                        {
                            case 'j':
                                break;
                            default:
                                Spel = false;
                                break;
                        }

                        Console.WriteLine();

                        Dragnakort.Clear();
                        Dinakort.Clear();
                        Datornskort.Clear();

                        DinLoop = true;
                        DatorLoop = true;
                    }

                    Console.WriteLine();

                    Dragnakort.Clear();
                    Dinakort.Clear();
                    Datornskort.Clear();

                    DinLoop = true;
                    DatorLoop = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
