bool named = false;

while (named == false)
{
    Console.WriteLine("Tryck \'Enter\' för att starta");
    string start = Console.ReadLine();
    
    if (start == "")
    {
        namn();
        named = true;
    }
}

static void namn()
{
    Console.WriteLine("Välj namn");
    Console.WriteLine("Spelare 1:");
    string namn1 = Console.ReadLine();
    Console.WriteLine("Spelare 2:");
    string namn2 = Console.ReadLine();

    if (namn2 == namn1)
    {
        Console.WriteLine("\nSpelare 1 och 2 kan inte ha samma namn");
        namn();
    }
    else
    {
        fight(namn1, namn2);
    }
}

static void fight(string namn1, string namn2)
{
    int HP1 = 100;
    int HP2 = 100;
    int roundCounter = 1;
    bool isOn = true;

    Console.WriteLine($"\n{namn1} VS {namn2}\n");
    while (isOn)
    {
        Console.WriteLine($"\nTryck \'Enter\' för att starta runda {roundCounter}");
        string roundStart = Console.ReadLine();
        if (roundStart == "")
        {
            Console.WriteLine($"\nRunda {roundCounter}");
            roundCounter++;
           
            int dmg1 = damage();
            HP2 -= dmg1;
            int dmg2 = damage();
            HP1 -= dmg2;

            if (HP2 <= 0 && HP1 <= 0)
            {
                if (dmg1 > dmg2)
                {
                    Console.WriteLine($"{namn1} börjar! Han gör {dmg1} skada, {namn2} har nu 0 liv kvar");
                    Console.WriteLine($"\nVi har en vinnare! Vinnaren är... {namn1}");
                    isOn = false;
                }
                else if (dmg1 < dmg2)
                {
                    Console.WriteLine($"{namn1} börjar! Han gör {HP2 - 1} skada, {namn2} har nu 1 liv kvar");
                    Console.WriteLine($"{namn2} kör nästa! Han gör {dmg2} skada, {namn1} har nu 0 liv kvar");
                    Console.WriteLine($"\nVi har en vinnare! Vinnaren är... {namn2}");
                    isOn = false;
                }
                else
                {
                    Console.WriteLine($"{namn1} börjar! Han gör {HP2 - 1} skada, {namn2} har nu 1 liv kvar");
                    Console.WriteLine($"{namn2} börjar! Han gör {HP1 - 1} skada, {namn1} har nu 1 liv kvar");
                    Console.WriteLine("Båda är mycket svaga och kan inte längre slåss, matchen slutar oavgjord");
                    isOn = false;
                }
            }
            else if (HP2 <= 0)
            {
                Console.WriteLine($"{namn1} börjar! Han gör {dmg1} skada, {namn2} har nu 0 liv kvar");
                Console.WriteLine($"\nVi har en vinnare! Vinnaren är... {namn1}");
                isOn = false;
            }
            else if (HP1 <= 0)
            {
                Console.WriteLine($"{namn1} börjar! Han gör {dmg1} skada, {namn2} har nu {HP2} liv kvar");
                Console.WriteLine($"{namn2} kör nästa! Han gör {dmg2} skada, {namn1} har nu 0 liv kvar");
                Console.WriteLine($"\nVi har en vinnare! Vinnaren är... {namn2}");
                isOn = false;
            }
            else
            {
                Console.WriteLine($"{namn1} börjar! Han gör {dmg1} skada, {namn2} har nu {HP2} liv kvar");
                Console.WriteLine($"{namn2} kör nästa! Han gör {dmg2} skada, {namn1} har nu {HP1} liv kvar");
            }
        }
    }
}

static int damage()
{
    return (Random.Shared.Next(21));
}

Console.ReadLine();