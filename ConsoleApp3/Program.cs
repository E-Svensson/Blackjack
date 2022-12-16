using System;
using System.Linq.Expressions;

namespace Blackuujackuu
{
    public class Program
    {
        public string Delay(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            return " ";
        }
        public string DelayLine(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            Console.WriteLine();
            return " ";
        }
        public string DelayLineWhite(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            return " ";
        }
        public string DelayLineGray(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            return " ";
        }
        public string DelayLineRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            return " ";
        }
        public string DelayLineGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char c in text)
            {
                Console.Write(c); Thread.Sleep(1);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            return " ";
        }
        static void Main(string[] args)
        {
            var Program = new Program();

            bool Spel = false;
            bool Avslut = false;
            bool Regler = false;
            bool Vinnare = false;
            bool Inställningar = false;

            bool DinEssSave = true;
            bool DatornsEssSave = true;

            bool DatorLoop = true;
            bool DinLoop = true;

            bool vinst;
            int vinstantal = 0;
            string vinnarnamn = "Test";
            List<string> vinnare = new List<string>();

            int StartKort = 2;
            int VinnarTal = 21;
            int Kortlekar = 1;

            int DinSumma;
            int DatornsSumma;

            int delay = 1000;

            int Ace = 11;
            int Jack = 10;
            int Queen = 10;
            int King = 10;
            int[] värde = new int[Kortlekar * 52];
            string[] namn = new string[Kortlekar * 52];

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
            for (int k = 0; k < Kortlekar; k++)
            {
                for (int i = 0; i < Färg.Length; i++)
                {
                    for (int j = 0; j < Kort.Length; j++)
                    {
                        värde[(52 * k) + (j + 13 * i)] = Kort[j];
                        namn[(52 * k) + (j + 13 * i)] = $"{FärgStr[i]} {KortStr[j]}";
                    }
                }
            }

            Random slump = new Random();

            // Variabler för dragna kort
            int ID;
            string[] Prefix = { "Du", "Datorn" };
            int ToggleVärde = (0 ^ 1);
            int Toggle = 0;

            // Skapar en lista för alla dragna kort

            List<int> Dragnakort = new List<int>();
            List<int> Dinakort = new List<int>();
            List<int> Datornskort = new List<int>();

            while (!Avslut)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Clear();
                    Program.DelayLine("=== Välkommen till Blackjack! ===");
                    Program.Delay("\n1. "); Program.DelayLineWhite("Spela spelet");
                    Program.Delay("2. "); Program.DelayLineWhite("Spelets regler");
                    Program.Delay("3. "); Program.DelayLineWhite("Inställningar");
                    Program.Delay("4. "); Program.DelayLineWhite("Kolla de senaste vinnarna");
                    Program.Delay("5. "); Program.DelayLineWhite("Avsluta programmet");
                    Program.Delay("\nSkriv här: ");
                    Console.ForegroundColor = ConsoleColor.White; int IntVal = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;

                    switch (IntVal)
                    {
                        case 1:
                            Spel = true;
                            break;
                        case 2:
                            Regler = true;
                            break;
                        case 3:
                            Inställningar = true;
                            break;
                        case 4:
                            Vinnare = true;
                            break;
                        case 5:
                            Avslut = true;
                            break;
                        default:
                            break;
                    }

                    if (Avslut)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    }

                    if (Regler)
                    {
                        Console.Clear();
                        Program.DelayLine("=== Regler: ===");
                        Program.DelayLineWhite("\n- I Blackjack är målet att nå 21 poäng genom att dra kort från en kortlek.");
                        Program.DelayLineWhite("- Man drar automatiskt två kort och får sedan välja om man vill fortsätta dra kort eller inte.");
                        Program.DelayLineWhite("- Hamnar man över 21 poäng förlorar man automatiskt.");
                        Program.DelayLine("\n=== Värden på korten: ===");
                        Program.DelayLineWhite("\n- Ess är värda 11 poäng förutom om du överskrider 21 poäng, då blir esset värt 1 poäng. (Detta kan endast ske ett ess)");
                        Program.DelayLineWhite("- Kungar, drottningar och knäcktar är alla värda 10 poäng.");
                        Program.DelayLineWhite("- Alla kort mellan 2-10 är värda lika mycket poäng som deras siffra.");

                        Program.Delay("\nSkriv här när du har läst klart: ");
                        Console.ForegroundColor = ConsoleColor.White; Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Yellow;
                        Regler = false;
                    }

                    if (Vinnare)
                    {
                        Console.Clear();
                        Program.DelayLine("=== De senaste vinnarna ===");

                        for (int i = 0; i < vinnare.Count; i++)
                        {
                            Program.Delay($"\n{i + 1}. ");
                            Program.DelayLineWhite($"{vinnare[i]}");
                        }

                        Program.Delay("\nSkriv här när du har kollat klart: ");
                        Console.ForegroundColor = ConsoleColor.White; Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Yellow;
                        Vinnare = false;
                    }

                    while (Inställningar)
                    {
                        Console.Clear();
                        Program.DelayLine("=== Inställningar ===");
                        Program.Delay("\n1. Antal dragna kort i början: "); Program.DelayLineWhite($"{StartKort}");
                        Program.Delay("2. Antal Kortlekar: "); Program.DelayLineWhite($"{Kortlekar}");
                        Program.Delay("3. Vinnartal: "); Program.DelayLineWhite($"{VinnarTal}");

                        Program.Delay("\nVill du ändra någon inställning? (j/n): ");
                        Console.ForegroundColor = ConsoleColor.White; string Val = Console.ReadLine().ToLower(); Console.ForegroundColor = ConsoleColor.Yellow;

                        if (Val[0] == 'j')
                        {
                            Program.Delay("\nVilken inställning vill du ändra?: ");
                            Console.ForegroundColor = ConsoleColor.White; IntVal = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;

                            switch (IntVal)
                            {
                                case 1:
                                    Program.Delay("\nSkriv det nya värdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; StartKort = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 2:
                                    Program.Delay("\nSkriv det nya värdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; Kortlekar = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 3:
                                    Program.Delay("\nSkriv det nya värdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; VinnarTal = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Inställningar = false;
                            break;
                        }
                    }

                    while (Spel)
                    {
                        Dragnakort.Clear();
                        Dinakort.Clear();
                        Datornskort.Clear();

                        Console.Clear();
                        Console.WriteLine();

                        for (int i = 0; i < StartKort * 2; i++) // Del 1
                        {
                            Thread.Sleep(delay / 2);

                            ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort

                            while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                            {
                                ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort
                            }

                            Dragnakort.Add(ID); // Bekräftar kortet

                            switch (i) // Gömmer datorns första kort
                            {
                                case 1:
                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"?");
                                    break;
                                default:
                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"{namn[ID]} ({värde[ID]})");
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

                        if (DatornsSumma == VinnarTal)
                        {
                            DinLoop = false;
                            DatorLoop = false;
                        }
                        else if (DatornsSumma > VinnarTal)
                        {
                            Datornskort.Add(-10);

                            DatornsSumma = Datornskort.Sum(); // Summerar

                            Thread.Sleep(delay);

                            Program.DelayLineGray($"\n(Datorn överskred {VinnarTal} så dens ess är nu värd 1 poäng)");

                            DatornsEssSave = false;
                        }
                        else
                        {
                            Program.DelayLineGray($"\n(Du har {DinSumma} poäng)");
                        }

                        while (DinLoop)
                        {
                            switch (DinSumma)
                            {
                                case var value when value < VinnarTal:
                                    Thread.Sleep(delay);

                                    Program.Delay("\nVill du dra ett till kort (j/n)?: ");
                                    Console.ForegroundColor = ConsoleColor.White; string StringVal = Console.ReadLine().ToLower(); Console.ForegroundColor = ConsoleColor.Yellow;

                                    switch (StringVal[0])
                                    {
                                        case 'j':
                                            Thread.Sleep(delay);

                                            ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort

                                            while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                                            {
                                                ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort
                                            }

                                            Dragnakort.Add(ID); // Bekräftar kortet

                                            Program.Delay($"\n- {Prefix[Toggle]} drog: ");
                                            Program.DelayLineWhite($"{namn[ID]} ({värde[ID]})");

                                            Dinakort.Add(värde[ID]); // Spelarens lista

                                            DinSumma = Dinakort.Sum(); // Summerar

                                            if (DinEssSave && DinSumma > VinnarTal && Dinakort.Contains(11))
                                            {
                                                Dinakort.Add(-10);

                                                DinSumma = Dinakort.Sum(); // Summerar

                                                Thread.Sleep(delay);

                                                Program.DelayLineGray($"\n(Du överskred {VinnarTal} så ditt ess är nu värd 1 poäng)");

                                                DinEssSave = false;
                                            }

                                            Thread.Sleep(delay);

                                            Program.DelayLineGray($"\n(Du har nu {DinSumma} poäng)");

                                            break;
                                        default:
                                            DinLoop = false;
                                            break;
                                    }

                                    break;
                                case var value when value > VinnarTal - 1:
                                    DinLoop = false;
                                    DatorLoop = false;
                                    break;
                            }

                        }

                        Toggle ^= ToggleVärde; // Byter tur

                        bool datordrog = false;

                        while (DatorLoop)
                        {
                            switch (DatornsSumma)
                            {
                                case var value when value < VinnarTal - 4:

                                    Thread.Sleep(delay);

                                    ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort

                                    while (Dragnakort.Contains(ID)) // Har kortet redan dragits?
                                    {
                                        ID = slump.Next(0, 52 * Kortlekar); // Slumpar kort
                                    }

                                    Dragnakort.Add(ID); // Bekräftar kortet

                                    if (!datordrog)
                                    {
                                        Console.WriteLine();
                                    }

                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"{namn[ID]} ({värde[ID]})");

                                    Datornskort.Add(värde[ID]); // Datorns lista

                                    DatornsSumma = Datornskort.Sum();

                                    if (DatornsEssSave && DatornsSumma > VinnarTal && Datornskort.Contains(11))
                                    {
                                        Datornskort.Add(-10);

                                        DatornsSumma = Datornskort.Sum(); // Summerar

                                        Thread.Sleep(delay);

                                        Program.DelayLineGray($"\n(Datorn överskred {VinnarTal} så dens ess är nu värd 1 poäng)");

                                        DatornsEssSave = false;
                                    }

                                    datordrog = true;

                                    break;
                                default:

                                    Thread.Sleep(delay);

                                    if (datordrog)
                                    {
                                        Program.DelayLineGray("\n(Datorn drar inga fler kort)");
                                    }
                                    else
                                    {
                                        Program.DelayLineGray("\n(Datorn drar inga kort)");
                                    }

                                    DatorLoop = false;

                                    break;
                            }
                        }

                        Toggle ^= ToggleVärde; // Byter tur

                        if (DatornsSumma == VinnarTal)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick Blackjack så du förlorade! ");
                            Program.DelayLineRed($"(Du fick {DinSumma})");
                            vinst = false;
                        }
                        else if (DinSumma > VinnarTal)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineRed($"Tyvärr, du förlorade eftersom du överskred {VinnarTal}!");
                            vinst = false;
                        }
                        else if (DatornsSumma > VinnarTal && DinSumma <= VinnarTal)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineGreen($"Grattis, du vann!");
                            vinst = true;
                        }
                        else if (DinSumma > DatornsSumma)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineGreen($"Grattis, du vann!");
                            vinst = true;
                        }
                        else if (DinSumma < DatornsSumma)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineRed($"Tyvärr, du förlorade!");
                            vinst = false;
                        }
                        else if (DatornsSumma == DinSumma)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineRed($"Tyvärr, du förlorade eftersom datorn vinner när det blir lika!");
                            vinst = false;
                        }
                        else
                        {
                            Thread.Sleep(delay);
                            Program.DelayLineRed("\nTyvärr, Du Förlorade!");
                            vinst = false;
                        }

                        if (vinst && vinstantal == 0)
                        {
                            Thread.Sleep(delay);

                            Program.Delay("\nSkriv ditt namn och starta din winstreak: ");
                            Console.ForegroundColor = ConsoleColor.White; vinnarnamn = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Yellow;
                            vinstantal++;
                        }
                        else if (vinst && vinstantal > 0)
                        {
                            Thread.Sleep(delay);

                            vinstantal++;
                            Program.Delay("\nDin winstreak är nu: ");
                            Program.DelayLineGreen($"{vinstantal}");

                            Program.Delay("\nVill du fortsätta? (j/n): ");
                            Console.ForegroundColor = ConsoleColor.White; string Val = Console.ReadLine().ToLower(); Console.ForegroundColor = ConsoleColor.Yellow;

                            switch (Val[0])
                            {
                                case 'j':
                                    break;
                                default:
                                    vinst = false;
                                    break;
                            }
                        }
                        else if (!vinst && vinstantal > 0)
                        {
                            Thread.Sleep(delay);

                            Program.Delay("\nDin slutgiltiga winstreak hamnade på: ");
                            Program.DelayLineGreen($"{vinstantal}");
                            vinnare.Add($"{vinnarnamn} ({vinstantal})");
                        }

                        if (!vinst)
                        {
                            Thread.Sleep(delay);

                            Program.Delay("\nVill du köra igen? (j/n): ");
                            Console.ForegroundColor = ConsoleColor.White; string Val = Console.ReadLine().ToLower(); Console.ForegroundColor = ConsoleColor.Yellow;

                            switch (Val[0])
                            {
                                case 'j':
                                    break;
                                default:
                                    Spel = false;
                                    break;
                            }
                        }

                        Console.WriteLine();

                        DinLoop = true;
                        DatorLoop = true;

                        Dragnakort.Clear();
                        Dinakort.Clear();
                        Datornskort.Clear();
                    }

                    Console.WriteLine();

                    Dragnakort.Clear();
                    Dinakort.Clear();
                    Datornskort.Clear();

                    Spel = false;
                    Avslut = false;
                    Inställningar = false;
                    Regler = false;
                    Vinnare = false;

                    DinLoop = true;
                    DatorLoop = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine();
                    Program.DelayLineRed("Felaktig inmatning, försök igen.");
                }
            }
        }
    }
}
