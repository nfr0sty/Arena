namespace Arena;

public class CreateFighters
{
    public List<Fighter> CreateAll()
    {
        
        List<Fighter> fighters = new List<Fighter>
        {
            CreateGrommash(),
            CreateSylvanas(),
            CreateArthas(),
            CreateJaina(),
            CreateMathiasShaw(),
        };

        return fighters;
    }
    
    private Fighter CreateGrommash()
    {
        const string Name = "Громмаш";
        const int Health = 220;
        const int Damage = 25;
        const int Armor  = 3;
        const int CritChance = 30;

        return new Warrior(Name, Health, Damage, Armor, CritChance);
    }

    private Fighter CreateSylvanas()
    {
        const string Name = "Сильвана";
        const int Health = 210;
        const int Damage = 25;
        const int Armor  = 5;

        return new Hunter(Name, Health, Damage, Armor);
    }

    private Fighter CreateArthas()
    {
        const string Name = "Артас";
        const int Health = 270;
        const int Damage = 20;
        const int Armor  = 5;

        return new Paladin(Name, Health, Damage, Armor);
    }

    private Fighter CreateJaina()
    {
        const string Name = "Джайна";
        const int Health = 270;
        const int Damage = 18;
        const int Armor  = 7;
        const int MaxMana = 70;

        return new Mage(Name, Health, Damage, Armor, MaxMana);
    }

    private Fighter CreateMathiasShaw()
    {
        const string Name = "Матиас Шоу";
        const int Health = 230;
        const int Damage = 22;
        const int Armor  = 8;
        const int DodgeChancePercent = 15;

        return new Rogue(Name, Health, Damage, Armor, DodgeChancePercent);
    }
}