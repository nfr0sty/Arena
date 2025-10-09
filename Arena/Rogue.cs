namespace Arena;

public class Rogue : Fighter
{
    private const int MinDodgeChancePercent = 0;
    private const int MaxDodgeChancePercent = 100;
    
    private readonly int _dodgeChancePercent;
    
    public Rogue(string name, int health, int damage, int armor, int dodgeChancePercent)
        : base(name, health, damage, armor)
    {
        if (dodgeChancePercent < MinDodgeChancePercent)
            dodgeChancePercent = MinDodgeChancePercent;
        if (dodgeChancePercent > MaxDodgeChancePercent)
            dodgeChancePercent = MaxDodgeChancePercent;

        _dodgeChancePercent = dodgeChancePercent;
    }
    
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Имеет шанс уклониться {_dodgeChancePercent}%");
    }
    
    public override Fighter CreateCopy()
    {
        return new Rogue(Name, MaxHealth, Damage, Armor, _dodgeChancePercent);
    }
    
    public override void TakeDamage(int damage)
    {
        bool isDodge = UserUtils.TryGetRandomChance(_dodgeChancePercent);

        if (isDodge == true)
        {
            Console.WriteLine($"{Name} УКЛОНЯЕТСЯ от удара! Урон не получен.");
            return;
        }

        base.TakeDamage(damage);
    }
}