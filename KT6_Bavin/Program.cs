using System;
using System.Collections.Generic;

class Program
{
    static int SumValidNumbers(List<string> values)
    {
        int sum = 0;
        int processed = 0;

        foreach (string value in values)
        {
            try
            {
                int number = int.Parse(value);
                sum += number;
            }
            catch (FormatException) when (string.IsNullOrWhiteSpace(value))
            {
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Предупреждение: '{value}' не является числом. {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Критическая ошибка: '{value}' слишком велико. {ex.Message}");
                throw;
            }
            finally
            {
                processed++;
                Console.WriteLine($"Обработано элементов: {processed}");
            }
        }

        return sum;
    }

    static void Main()
    {
        var values = new List<string> { "10", "", "abc", "20" };

        int sum = SumValidNumbers(values);
        Console.WriteLine($"Итоговая сумма: {sum}"); // 30


    }
}
