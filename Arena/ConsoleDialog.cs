namespace Arena;

public static class ConsoleDialog
{
    public static int ReadInt(string prompt)
    {
        bool isWork = true;
        int number = 0;

        while (isWork)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) == true)
            {
                Console.WriteLine("Ошибка: Пустой ввод. Введите целое число.\n");
                continue;   
            }

            if (int.TryParse(input, out number) == false)
            {
                Console.WriteLine("Ошибка: Некорректное число. Пример: 10 или -3. Попробуйте снова.\n");
                continue;
            }

            isWork = false;
        }
        
        return number;
    }

    public static int ReadIntInRange(string prompt, int min, int max)
    {
        bool isWork = true;
        int number = 0;

        while (isWork)
        {
            number = ReadInt($"{prompt} от {min} до {max}\n");

            if (number < min || number > max)
            {
                Console.WriteLine($"Ошибка: введите число от {min} до {max}.");
                continue;
            }
            
            isWork = false;
        }

        return number;
    }

    public static void ReadRange(out int min, out int max, string promptMin, string promptMax)
    {
        bool isWork = true;
        min = 0;
        max = 0;
        
        while (isWork)
        {
            min = ReadInt(promptMin);
            max = ReadInt(promptMax);

            if (max < min)
            {
                Console.WriteLine($"Ошибка: максимум ({max}) меньше минимума ({min}). Введите значения заново.\n");
                continue;
            }
            
            isWork = false;
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        bool isWork = true;
        bool result = false;

        while (isWork)
        {
            Console.Write($"{prompt} (y/n): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) == true)
            {
                Console.WriteLine("Ошибка: пустой ввод. Введите 'y' или 'n'. (Допустимые ответы — 'y'/'n', 'yes'/'no' или 'д'/'н', да'/'нет'.) \n");
                continue;
            }
            
            string normalizedInput = input.Trim().ToLowerInvariant();

            if (normalizedInput == "yes" || normalizedInput == "y" || normalizedInput == "да" || normalizedInput == "д")
            {
                result = true;
                isWork = false;
            }
            else if (normalizedInput == "no" || normalizedInput == "n" || normalizedInput == "нет" || normalizedInput == "н")
            {
                result = false;
                isWork = false;
            }
            else
            {
                Console.WriteLine("Ошибка: Допустимые ответы — 'y'/'n', 'yes'/'no' или 'д'/'н', да'/'нет'.\n");
            }
        }
        
        return result;
    }
    
    public static string ReadNonEmptyString(string prompt)
    {
        bool isWork = true;
        string value = string.Empty;

        while (isWork)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) == true)
            {
                Console.WriteLine("Ошибка: пустой ввод. Повторите.\n");
                continue;
            }

            value = input.Trim();
            isWork = false;
        }

        return value;
    }
}