namespace Arena;

class Program
{
    private const string ShowBattleCommand = "1";
    private const string ExitCommand = "2";
    
    static void Main(string[] args)
    {
        FightersFactory factory =  new FightersFactory();
        List<Fighter> fighterPrototypes = factory.CreateAll();
        BattleGround battleGround = new BattleGround();
        ArenaMainMenu mainMenu = new ArenaMainMenu(fighterPrototypes);

        bool isWork = true;

        while (isWork)
        {
            mainMenu.Show();
            string command = mainMenu.ReadCommand();

            if (command == ShowBattleCommand)
            {
                Console.Clear();
                Console.WriteLine("Доступные бойцы: \n");
                mainMenu.ShowFighters();
                
                mainMenu.SelectTwoFighters(out Fighter firstFighter, out Fighter secondFighter);
                Console.WriteLine();
                battleGround.Run(firstFighter, secondFighter);
            }
            else if (command == ExitCommand)
            {
                isWork = false;
            }
            
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}