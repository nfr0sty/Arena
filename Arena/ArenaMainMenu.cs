namespace Arena;

public class ArenaMainMenu
{
     private const string Title =  "ДОБРО ПОЖАЛОВАТЬ НА АРЕНУ СМЕРТИ!";
     private const string CommandShowBattle = "1";
     private const string CommandExit = "2";
     private const int MinFighterCount = 2;
     private const int FirstNumber = 1;

     private readonly List<Fighter> _fightersPrototypes;

     public ArenaMainMenu(List<Fighter> fightersPrototypes)
     {
          if (fightersPrototypes == null)
               throw new ArgumentNullException(nameof(fightersPrototypes));

          if (fightersPrototypes.Count < MinFighterCount)
               throw new ArgumentException($"Нужно минимум {MinFighterCount} бойца.", nameof(fightersPrototypes));
          
          _fightersPrototypes = fightersPrototypes;
     }
     
     public void Show()
     {
          Console.WriteLine("=== " + Title + " ===");
          Console.WriteLine("Выберите действие: ");
          Console.WriteLine($"{CommandShowBattle} - Посмотреть бой");
          Console.WriteLine($"{CommandExit} - Выход");
     }

     public string ReadCommand()
     {
          string input;
          bool isValid;

          do
          {
               input = ConsoleDialog.ReadNonEmptyString("Ваш выбор: ");
               isValid = input == CommandShowBattle || input == CommandExit;

               if (isValid == false)
               {
                    Console.WriteLine($"Неверный выбор. Введите {CommandShowBattle} или {CommandExit}.\n");
               }

          } while (isValid == false);

          return input;
     }

     public void ShowFighters()
     {
          int number = FirstNumber;

          foreach (Fighter fighter in _fightersPrototypes)
          {
               Console.Write($"{number}.");
               fighter.ShowStats();
               Console.WriteLine($"___________________________________________________________________");
               number++;
          }
     }

     public void SelectTwoFighters(out Fighter first, out Fighter second)
     {
          int maxCount = _fightersPrototypes.Count;

          int firstIndex = ConsoleDialog.ReadIntInRange("Номер первого бойца: ", FirstNumber, maxCount) - FirstNumber;
          int secondIndex = ConsoleDialog.ReadIntInRange("Номер второго бойца: ", FirstNumber, maxCount) - FirstNumber;

          first = _fightersPrototypes[firstIndex].CreateCopy();
          second = _fightersPrototypes[secondIndex].CreateCopy();
     }
}