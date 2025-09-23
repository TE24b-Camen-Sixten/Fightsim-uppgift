using System.Data;

while (true)
{
    Console.WriteLine("Tryck \'Enter\' för att starta");
    string start = Console.ReadLine();
    if (start == "")
    {
        namn();
        break;
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
    int roundCounter = 0;
    bool isOn = true;

    Console.WriteLine($"\n{namn1} VS {namn2}\n");
    while (isOn)
    {
        Console.WriteLine("\nTryck \'Enter\'för att starta nästa runda");
        string round = Console.ReadLine();
        if (round == "")
        {
            roundCounter++;
            Console.WriteLine($"\nRunda {roundCounter}");
           
            int dmg = damage();
            HP2 -= dmg;
            if (HP2 <= 0)
            {
                Console.WriteLine($"{namn1} börjar! Han gör {dmg} skada, {namn2} har nu 0 liv kvar");
            }
            else
            {
                Console.WriteLine($"{namn1} börjar! Han gör {dmg} skada, {namn2} har nu {HP2} liv kvar");
            }
            dmg = damage();
            HP1 -= dmg;
            if (HP1 <= 0)
            {
                Console.WriteLine($"{namn2} kör nästa! Han gör {dmg} skada, {namn1} har nu 0 liv kvar");
            }
            else{Console.WriteLine($"{namn2} kör nästa! Han gör {dmg} skada, {namn1} har nu {HP1} liv kvar");}

            if (HP1 <= 0)
            {
                Console.WriteLine($"\nVi har en vinnare! Vinnaren är... \n{namn2}");
                isOn = false;
            }
            else if (HP2 <= 0)
            {
                Console.WriteLine($"\nVi har en vinnare! Vinnaren är... \n{namn1}");
                isOn = false;
            }
        }
    }
    
}

static int damage()
{
    return (Random.Shared.Next(21));
}

Console.ReadLine();