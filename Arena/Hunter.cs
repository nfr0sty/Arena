namespace Arena;

public class Hunter : Fighter
{
    private const int DoubleStrikePeriod = 3;
    private const int DoubleStrikeHits = 2;

    private int _attackCounter;
    
    public Hunter(string name, int health, int damage, int armor)
        : base(name, health, damage, armor)
    {
        _attackCounter = 0;
    }
    
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Каждая {DoubleStrikePeriod}-я атака наносит {DoubleStrikeHits} удара подряд");
    }

    public override Fighter CreateCopy()
    {
        return new Hunter(Name, MaxHealth, Damage, Armor);
    }

    public override void Attack(Fighter target)
    {
        _attackCounter++;
        
        bool isDoubleStrike = (_attackCounter % DoubleStrikePeriod) == 0;

        if (isDoubleStrike == true)
        {
            Console.WriteLine($"{Name} проводит ДВОЙНУЮ атаку!");
            
            base.Attack(target);

            if (target.IsAlive == true)
            {
                base.Attack(target);
            }
            else
            {
                Console.WriteLine($"{Name}: второй удар отменён — противник выведен из строя.");
            }
            
            return;
        }
        
        base.Attack(target);
    }
}