namespace Arena;

public class Mage : Fighter
{
    private const int FireballManaCost = 25;
    private const int FireballDamageMultiplier = 2;
    private const int MinMana = 0;

    private int _maxMana;
    private int _mana;

    public Mage(string name, int health, int damage, int armor, int maxMana)
        : base(name, health, damage, armor)
    {
        if (maxMana < MinMana)
            maxMana = MinMana;
        
        _maxMana = maxMana;
        _mana = _maxMana;
    }
    
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Имеет запас маны: {_maxMana}, тратит её на “Огненный шар”");
    }

    protected override int CalculateDamage()
    {
        bool canCast = _mana >= FireballManaCost;

        if (canCast)
        {
            _mana -= _maxMana;
            int fireballDamage = Damage * FireballDamageMultiplier;
            
            Console.WriteLine($"{Name} кастует «Огненный шар»! Урон: {Damage} → {fireballDamage}. Мана: {_mana}/{_maxMana}");
            
            return fireballDamage;
        }
        
        return base.CalculateDamage();
    }

    public override Fighter CreateCopy()
    {
        return new Mage(Name, MaxHealth, Damage, Armor, _maxMana);
    }
}