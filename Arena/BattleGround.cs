namespace Arena;

public class BattleGround
{
    private const int InitiativeChoicesCount = 2;
    private const int FirstChoiceIndex = 0;
    private const int TurnDelayMs = 600;

    public void Run(Fighter firstFighter, Fighter secondFighter)
    {
        if (firstFighter == null || secondFighter == null)
        {
            return;
        }
        
        Console.WriteLine($"Начало боя: {firstFighter.Name} vs {secondFighter.Name}");
        firstFighter.ShowStats();
        secondFighter.ShowStats();
        Console.WriteLine();
        
        bool isFirstTurn;

        int roll = UserUtils.GenerateRandomNumber(InitiativeChoicesCount);

        if (roll == FirstChoiceIndex)
        {
            Console.WriteLine($"{firstFighter.Name} атакует первым.");
            isFirstTurn = true;
        }
        else
        {
            Console.WriteLine($"{secondFighter.Name} атакует первым.");
            isFirstTurn = false;
        }

        while (firstFighter.IsAlive == true && secondFighter.IsAlive == true)
        {
            if (isFirstTurn == true)
            {
                firstFighter.Attack(secondFighter);
            }
            else
            {
                secondFighter.Attack(firstFighter);
            }
            
            firstFighter.ShowCurrentHealth();
            secondFighter.ShowCurrentHealth();
            Console.WriteLine();
            
            System.Threading.Thread.Sleep(TurnDelayMs);
            
            if (firstFighter.IsAlive == false || secondFighter.IsAlive == false)
                break;

            isFirstTurn = isFirstTurn == false;
        }

        if (firstFighter.IsAlive == true && secondFighter.IsAlive == false)
        {
            Console.WriteLine($"Победил {firstFighter.Name}!");
            return;
        }

        if (firstFighter.IsAlive == false && secondFighter.IsAlive == true)
        {
            Console.WriteLine($"Победил {secondFighter.Name}!");
            return;
        }
        
        Console.WriteLine("Оба бойца пали одновременно. Ничья.");
    }
}