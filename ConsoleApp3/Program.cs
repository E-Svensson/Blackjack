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
            bool Inst??llningar = false;

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
            int[] v??rde = new int[Kortlekar * 52];
            string[] namn = new string[Kortlekar * 52];

            int[] Kort = { Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King };
            string[] KortStr = { "Ess", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Kn??ckt", "Drottning", "Kung", };

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
            // Kort[10] = Kn??ckt
            // Kort[11] = Drottning
            // Kort[12] = Kung

            int[] F??rg = { 0, 1, 2, 3 };
            string[] F??rgStr = { "Spader", "Kl??ver", "Hj??rter", "Ruter" };

            // F??rg[0] = Spader
            // F??rg[1] = Kl??ver
            // F??rg[2] = Hj??rter
            // F??rg[3] = Ruter

            // Ger alla kort sitt eget v??rde (ID)
            for (int k = 0; k < Kortlekar; k++)
            {
                for (int i = 0; i < F??rg.Length; i++)
                {
                    for (int j = 0; j < Kort.Length; j++)
                    {
                        v??rde[(52 * k) + (j + 13 * i)] = Kort[j];
                        namn[(52 * k) + (j + 13 * i)] = $"{F??rgStr[i]} {KortStr[j]}";
                    }
                }
            }

            Random slump = new Random();

            // Variabler f??r dragna kort
            int ID;
            string[] Prefix = { "Du", "Datorn" };
            int ToggleV??rde = (0 ^ 1);
            int Toggle = 0;

            // Skapar en lista f??r alla dragna kort

            List<int> Dragnakort = new List<int>();
            List<int> Dinakort = new List<int>();
            List<int> Datornskort = new List<int>();

            while (!Avslut)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Clear();
                    Program.DelayLine("=== V??lkommen till Blackjack! ===");
                    Program.Delay("\n1. "); Program.DelayLineWhite("Spela spelet");
                    Program.Delay("2. "); Program.DelayLineWhite("Spelets regler");
                    Program.Delay("3. "); Program.DelayLineWhite("Inst??llningar");
                    Program.Delay("4. "); Program.DelayLineWhite("Kolla de senaste vinnarna");
                    Program.Delay("5. "); Program.DelayLineWhite("Avsluta programmet");
                    Program.Delay("\nSkriv h??r: ");
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
                            Inst??llningar = true;
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
                        Program.DelayLineWhite("\n- I Blackjack ??r m??let att n?? 21 po??ng genom att dra kort fr??n en kortlek.");
                        Program.DelayLineWhite("- Man drar automatiskt tv?? kort och f??r sedan v??lja om man vill forts??tta dra kort eller inte.");
                        Program.DelayLineWhite("- Hamnar man ??ver 21 po??ng f??rlorar man automatiskt.");
                        Program.DelayLine("\n=== V??rden p?? korten: ===");
                        Program.DelayLineWhite("\n- Ess ??r v??rda 11 po??ng f??rutom om du ??verskrider 21 po??ng, d?? blir esset v??rt 1 po??ng. (Detta kan endast ske ett ess)");
                        Program.DelayLineWhite("- Kungar, drottningar och kn??cktar ??r alla v??rda 10 po??ng.");
                        Program.DelayLineWhite("- Alla kort mellan 2-10 ??r v??rda lika mycket po??ng som deras siffra.");

                        Program.Delay("\nSkriv h??r n??r du har l??st klart: ");
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

                        Program.Delay("\nSkriv h??r n??r du har kollat klart: ");
                        Console.ForegroundColor = ConsoleColor.White; Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Yellow;
                        Vinnare = false;
                    }

                    while (Inst??llningar)
                    {
                        Console.Clear();
                        Program.DelayLine("=== Inst??llningar ===");
                        Program.Delay("\n1. Antal dragna kort i b??rjan: "); Program.DelayLineWhite($"{StartKort}");
                        Program.Delay("2. Antal Kortlekar: "); Program.DelayLineWhite($"{Kortlekar}");
                        Program.Delay("3. Vinnartal: "); Program.DelayLineWhite($"{VinnarTal}");

                        Program.Delay("\nVill du ??ndra n??gon inst??llning? (j/n): ");
                        Console.ForegroundColor = ConsoleColor.White; string Val = Console.ReadLine().ToLower(); Console.ForegroundColor = ConsoleColor.Yellow;

                        if (Val[0] == 'j')
                        {
                            Program.Delay("\nVilken inst??llning vill du ??ndra?: ");
                            Console.ForegroundColor = ConsoleColor.White; IntVal = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;

                            switch (IntVal)
                            {
                                case 1:
                                    Program.Delay("\nSkriv det nya v??rdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; StartKort = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 2:
                                    Program.Delay("\nSkriv det nya v??rdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; Kortlekar = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 3:
                                    Program.Delay("\nSkriv det nya v??rdet: ");
                                    Console.ForegroundColor = ConsoleColor.White; VinnarTal = int.Parse(Console.ReadLine()); Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Inst??llningar = false;
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

                            Dragnakort.Add(ID); // Bekr??ftar kortet

                            switch (i) // G??mmer datorns f??rsta kort
                            {
                                case 1:
                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"?");
                                    break;
                                default:
                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"{namn[ID]} ({v??rde[ID]})");
                                    break;
                            }

                            switch (Toggle) // Vilken lista ska kortet beh??ra?
                            {
                                case 0:
                                    Dinakort.Add(v??rde[ID]); // Spelarens lista
                                    break;
                                case 1:
                                    Datornskort.Add(v??rde[ID]); // Datorns lista
                                    break;
                            }

                            Toggle ^= ToggleV??rde; // Byter tur
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

                            Program.DelayLineGray($"\n(Datorn ??verskred {VinnarTal} s?? dens ess ??r nu v??rd 1 po??ng)");

                            DatornsEssSave = false;
                        }
                        else
                        {
                            Program.DelayLineGray($"\n(Du har {DinSumma} po??ng)");
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

                                            Dragnakort.Add(ID); // Bekr??ftar kortet

                                            Program.Delay($"\n- {Prefix[Toggle]} drog: ");
                                            Program.DelayLineWhite($"{namn[ID]} ({v??rde[ID]})");

                                            Dinakort.Add(v??rde[ID]); // Spelarens lista

                                            DinSumma = Dinakort.Sum(); // Summerar

                                            if (DinEssSave && DinSumma > VinnarTal && Dinakort.Contains(11))
                                            {
                                                Dinakort.Add(-10);

                                                DinSumma = Dinakort.Sum(); // Summerar

                                                Thread.Sleep(delay);

                                                Program.DelayLineGray($"\n(Du ??verskred {VinnarTal} s?? ditt ess ??r nu v??rd 1 po??ng)");

                                                DinEssSave = false;
                                            }

                                            Thread.Sleep(delay);

                                            Program.DelayLineGray($"\n(Du har nu {DinSumma} po??ng)");

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

                        Toggle ^= ToggleV??rde; // Byter tur

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

                                    Dragnakort.Add(ID); // Bekr??ftar kortet

                                    if (!datordrog)
                                    {
                                        Console.WriteLine();
                                    }

                                    Program.Delay($"- {Prefix[Toggle]} drog: ");
                                    Program.DelayLineWhite($"{namn[ID]} ({v??rde[ID]})");

                                    Datornskort.Add(v??rde[ID]); // Datorns lista

                                    DatornsSumma = Datornskort.Sum();

                                    if (DatornsEssSave && DatornsSumma > VinnarTal && Datornskort.Contains(11))
                                    {
                                        Datornskort.Add(-10);

                                        DatornsSumma = Datornskort.Sum(); // Summerar

                                        Thread.Sleep(delay);

                                        Program.DelayLineGray($"\n(Datorn ??verskred {VinnarTal} s?? dens ess ??r nu v??rd 1 po??ng)");

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

                        Toggle ^= ToggleV??rde; // Byter tur

                        if (DatornsSumma == VinnarTal)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick Blackjack s?? du f??rlorade! ");
                            Program.DelayLineRed($"(Du fick {DinSumma})");
                            vinst = false;
                        }
                        else if (DinSumma > VinnarTal)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineRed($"Tyv??rr, du f??rlorade eftersom du ??verskred {VinnarTal}!");
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
                            Program.DelayLineRed($"Tyv??rr, du f??rlorade!");
                            vinst = false;
                        }
                        else if (DatornsSumma == DinSumma)
                        {
                            Thread.Sleep(delay);
                            Program.Delay($"\nDatorn fick {DatornsSumma} och du fick {DinSumma}! ");
                            Program.DelayLineRed($"Tyv??rr, du f??rlorade eftersom datorn vinner n??r det blir lika!");
                            vinst = false;
                        }
                        else
                        {
                            Thread.Sleep(delay);
                            Program.DelayLineRed("\nTyv??rr, Du F??rlorade!");
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
                            Program.Delay("\nDin winstreak ??r nu: ");
                            Program.DelayLineGreen($"{vinstantal}");

                            Program.Delay("\nVill du forts??tta? (j/n): ");
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

                            Program.Delay("\nDin slutgiltiga winstreak hamnade p??: ");
                            Program.DelayLineGreen($"{vinstantal}");
                            vinnare.Add($"{vinnarnamn} ({vinstantal})");
                        }

                        if (!vinst)
                        {
                            Thread.Sleep(delay);

                            Program.Delay("\nVill du k??ra igen? (j/n): ");
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
                    Inst??llningar = false;
                    Regler = false;
                    Vinnare = false;

                    DinLoop = true;
                    DatorLoop = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine();
                    Program.DelayLineRed("Felaktig inmatning, f??rs??k igen.");
                }
            }
        }
    }
}
