namespace Arena;

public abstract class Fighter
{
    private const int MinHealthValue = 0;
    private const int MinDamageValue = 0;
    private const int MinArmorValue = 0;
    private const int FallbackMaxHealthValue = 1;
    private const int MinEffectiveDamageValue = 0;
    private const int MinHealAmount = 1;
    private const int NoHealValue = 0;
    
    protected Fighter(string name, int health, int damage, int armor)
    {
        if (string.IsNullOrWhiteSpace(name) == true)
            name = "Unnamed";
        
        if (health <= MinHealthValue)
            health = FallbackMaxHealthValue;
        
        if (damage < MinDamageValue)
            damage = MinDamageValue;
        
        if (armor < MinArmorValue)
            armor = MinArmorValue;
        
        Name = name;
        MaxHealth = health;
        Health = MaxHealth;
        Damage = damage;
        Armor = armor;
    }
    
    public string Name { get; private set; }
    public int Health{ get; private set; }
    public int MaxHealth { get; private set; }
    public int Damage{ get; private set; }
    public int Armor{ get; private set; }
    
    public bool IsAlive => Health > MinHealthValue;

    public virtual void ShowStats()
    {
        Console.WriteLine($"~ {Name}, Здоровье: {Health}, Урон: {Damage}, Броня: {Armor}");
    }

    public void ShowCurrentHealth()
    {
        Console.WriteLine($"{Name} - HP: {Health}/{MaxHealth}");
    }

    public virtual void Attack(Fighter target)
    {
        int dealtDamage = CalculateDamage();
        Console.WriteLine($"{Name} атакует и пытается нанести {dealtDamage} урона.");
        target.TakeDamage(dealtDamage);
    }
    
    

    public virtual void TakeDamage(int damage)
    {
        if (damage < MinDamageValue)
        {
            Console.WriteLine($"{Name}: получен отрицательный урон ({damage}). Урон проигнорирован.");
            return;
        }

        int effectiveDamage = damage - Armor;

        if (effectiveDamage < MinEffectiveDamageValue)
            effectiveDamage = MinEffectiveDamageValue;
        
        int newHealth = Health - effectiveDamage;
        
        if (newHealth < MinHealthValue)
            newHealth = MinHealthValue;
        
        Health = newHealth;
        
        if (effectiveDamage == 0)
        {
            Console.WriteLine($"{Name} полностью блокирует удар бронёй {Armor}. Здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            Console.WriteLine($"{Name} получает {effectiveDamage} урона. Здоровье: {Health}/{MaxHealth}");
        }
    }

    protected virtual int CalculateDamage()
    {
        return Damage;
    }

    protected int Heal(int amount)
    {
        if (Health == MaxHealth)
        {
            Console.WriteLine($"{Name} уже в полном здоровье ({Health}/{MaxHealth}). Лечение не требуется.");
            return NoHealValue;
        }

        if (amount < MinHealAmount)
        {
            Console.WriteLine($"{Name}: попытка лечения на {amount} — отклонена. Минимальное лечение: {MinHealAmount}.");
            return NoHealValue;
        }
        
        int missingHealth = MaxHealth - Health;
        int healAmount = amount;
        
        if (healAmount > missingHealth)
        {
            healAmount = missingHealth;
        }
        
        Health += healAmount;
        
        Console.WriteLine($"{Name} лечится на {healAmount}. Текущее здоровье: {Health}/{MaxHealth}");
        
        return healAmount;
    }
    
    public abstract Fighter CreateCopy();
}