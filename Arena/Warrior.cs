namespace Arena;

public class Warrior : Fighter
{
    private const int MinCritChancePercent = 0;
    private const int MaxCritChancePercent = 100;
    private const int DefaultCritChancePercent = 25;
    private const int CritMultiplier = 2;
    
    private readonly int _critChancePercent;

    public Warrior(string name, int health, int damage, int armor, int critChancePercent) 
        : base(name, health, damage, armor)
    {
        if (critChancePercent < MinCritChancePercent)
            critChancePercent = MinCritChancePercent;
        if (critChancePercent > MaxCritChancePercent)
            critChancePercent = MaxCritChancePercent;
        
        _critChancePercent = critChancePercent;
    }
    
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Имеет шанс крита {_critChancePercent}% ");
    }
    
    public override Fighter CreateCopy()
    {
        return new Warrior(Name, MaxHealth, Damage, Armor, _critChancePercent);
    }
    
    protected override int CalculateDamage()
    {
        bool isCrit = UserUtils.TryGetRandomChance(_critChancePercent);

        if (isCrit == true)
        {
            int critDamage = Damage * CritMultiplier;
            Console.WriteLine($"{Name} проводит КРИТ-удар! Урон: {Damage}");
            
            return critDamage;
        }
        
        return Damage;
    }
}