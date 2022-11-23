using System;

namespace ____
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Avslut = false;
            bool Igen = false;

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

            // Skapar en lista för alla dragna kort
            int[] DragnaKort = new int[52];
            int[] DinaKort = new int[26];
            int[] DatornsKort = new int[26];

            while (Avslut == false)
            {
                if (Igen == true)
                {
                    Console.Write("Vill du köra igen? (j/n): "); char[] val = Console.ReadLine().ToLower().ToCharArray();

                    if (val[0] == 'j')
                    {
                        Igen = false;
                        Array.Clear(DragnaKort);
                        Array.Clear(DinaKort);
                        Array.Clear(DatornsKort);
                    }
                    else
                    {
                        Avslut = true;
                    }
                    Console.WriteLine();
                }

                while (Igen == false)
                {

                    // Drar ditt första kort
                    DittKortID = slump.Next(0, 52);

                    // Lägger till kortet i listan för dragna kort
                    DragnaKort[0] = DittKortID;
                    DinaKort[0] = värde[DittKortID];

                    // Drar datorns första kort
                    DatorKortID = slump.Next(0, 52);

                    // Kollar listan för dragna kort
                    while (DragnaKort.Contains(DatorKortID))
                    {
                        DatorKortID = slump.Next(0, 52);
                    }

                    // Bekräftar Kortet
                    DragnaKort[1] = DatorKortID;
                    DatornsKort[0] = värde[DatorKortID];
                    Console.WriteLine($"- Du drog: {namn[DittKortID]} ({värde[DittKortID]})"); // {DragnaKort[0]}
                    Console.WriteLine($"- Datorn Drog: {namn[DatorKortID]} ({värde[DatorKortID]})\n"); //{namn[DatorKortID]} ({värde[DatorKortID]}) {DragnaKort[1]}

                    // Drar ditt andra kort
                    DittKortID = slump.Next(0, 52);

                    // Kollar listan för dragna kort
                    while (DragnaKort.Contains(DittKortID))
                    {
                        DittKortID = slump.Next(0, 52);
                    }

                    // Bekräftar Korter
                    DragnaKort[2] = DittKortID;
                    DinaKort[1] = värde[DittKortID];

                    // Drar Datorns andra kort
                    DatorKortID = slump.Next(0, 52);

                    // Kollar listan för dragna kort
                    while (DragnaKort.Contains(DatorKortID))
                    {
                        DatorKortID = slump.Next(0, 52);
                    }

                    // Bekräftar Kortet
                    DragnaKort[3] = DatorKortID;
                    DatornsKort[1] = värde[DatorKortID];

                    Console.WriteLine($"- Du drog: {namn[DittKortID]} ({värde[DittKortID]})"); // {DragnaKort[2]}
                    Console.WriteLine($"- Datorn Drog: ?\n"); // {DragnaKort[3]}

                    int DinSumma = DinaKort.Sum();
                    int DatornsSumma = DatornsKort.Sum();
                    bool DatorLoop = true;
                    bool DinLoop = true;
                    int AntalKortDragna = 4;
                    int AntalDatorKort = 2;
                    int AntalDinaKort = 2;

                    if (DatornsSumma == 21)
                    {
                        Console.WriteLine("Datorn fick 21! Du förlorade!\n");
                        Igen = true;
                        break;
                    }

                    while (DatorLoop == true)
                    {
                        switch (DatornsSumma)
                        {
                            case > 21:
                                for (int i = 0; i < DatornsKort.Length; i++)
                                {
                                    if (DatornsKort[i] == 11)
                                    {
                                        DatornsKort[i] = 1;
                                        DatornsSumma = DatornsKort.Sum();
                                        break;
                                    }
                                }
                                if (DatornsSumma > 21)
                                {
                                    DatorLoop = false;
                                }
                                break;
                            case 21:
                                DatorLoop = false;
                                break;
                            case < 17:
                                while (DatornsSumma < 17)
                                {
                                    // Drar datorns nästa  kort
                                    DatorKortID = slump.Next(0, 52);

                                    // Kollar listan med dragna kort
                                    while (DragnaKort.Contains(DatorKortID))
                                    {
                                        DatorKortID = slump.Next(0, 52);
                                    }

                                    // Bekräftar kortet
                                    DragnaKort[AntalKortDragna] = DatorKortID;
                                    DatornsKort[AntalDatorKort] = värde[DatorKortID];

                                    // Summerar
                                    DatornsSumma = DatornsKort.Sum();

                                    AntalKortDragna++;
                                    AntalDatorKort++;
                                }
                                break;
                            default:
                                DatorLoop = false;
                                break;
                        }
                    }

                    Console.WriteLine($"Dina poäng: {DinSumma}\n");

                    while (DinLoop == true)
                    {
                        switch (DinSumma)
                        {
                            case > 21:
                                for (int i = 0; i < DinaKort.Length; i++)
                                {
                                    if (DinaKort[i] == 11)
                                    {
                                        DinaKort[i] = 1;
                                        DinSumma = DinaKort.Sum();
                                        break;
                                    }
                                }
                                if (DinSumma > 21)
                                {
                                    DinLoop = false;
                                }
                                break;
                            case 21:
                                DinLoop = false;
                                break;
                            case < 21:
                                while (DinSumma < 21)
                                {
                                    Console.Write("Vill du dra ett till kort? (j/n): "); char[] val2 = Console.ReadLine().ToLower().ToCharArray();
                                    Console.WriteLine();
                                    if (val2[0] == 'j')
                                    {
                                        // Drar ditt  nästa  kort
                                        DittKortID = slump.Next(0, 52);

                                        // Kollar listan med dragna kort
                                        while (DragnaKort.Contains(DittKortID))
                                        {
                                            DittKortID = slump.Next(0, 52);
                                        }

                                        // Bekräftar kortet
                                        DragnaKort[AntalKortDragna] = DittKortID;
                                        DinaKort[AntalDinaKort] = värde[DittKortID];
                                        Console.WriteLine($"- Du drog: {namn[DittKortID]} ({värde[DittKortID]})\n");

                                        // Summerar
                                        DinSumma = DinaKort.Sum();

                                        if (DinSumma > 21)
                                        {
                                            for (int i = 0; i < DinaKort.Length; i++)
                                            {
                                                if (DinaKort[i] == 11)
                                                {
                                                    DinaKort[i] = 1;
                                                    DinSumma = DinaKort.Sum();
                                                    break;
                                                }
                                            }
                                        }

                                        Console.WriteLine($"Dina poäng: {DinSumma}\n");

                                        AntalKortDragna++;
                                        AntalDinaKort++;

                                    }
                                    else
                                    {
                                        DinLoop = false;
                                        break;
                                    }
                                }
                                break;
                        }
                    }

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

                    Igen = true;
                }
            }
        }
    }
}