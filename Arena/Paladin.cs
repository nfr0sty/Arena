namespace Arena;

public class Paladin : Fighter
{
    private const int MinSpirit = 0;
    private const int MaxSpirit = 100;
    private const int HealWhenFull = 25;
    private const int ZeroDamage = 0;

    private int _spirit;

    public Paladin(string name, int health, int damage, int armor)
        : base(name, health, damage, armor)
    {
        _spirit = MinSpirit;
    }
    
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Копит «Силу духа» от полученного урона. Лечит себя при накоплении максимального значения шкалы «Силу духа»");
    }
    
    public override Fighter CreateCopy()
    {
        return new Paladin(Name, MaxHealth, Damage, Armor);
    }
    
    public override void TakeDamage(int damage)
    {
        int healthBefore = Health;
        
        base.TakeDamage(damage);
        
        int takenHealth = healthBefore - Health;

        if (takenHealth > ZeroDamage)
        {
            _spirit += takenHealth;
            
            if (_spirit > MaxSpirit)
            {
                _spirit = MaxSpirit;
            }
            
            if (_spirit == MaxSpirit && IsAlive == true)
            {
                int healed = Heal(HealWhenFull);
                Console.WriteLine($"{Name} использует Силу духа и лечится на {healed}.");
                _spirit = MinSpirit;
            }
        }
    }
}