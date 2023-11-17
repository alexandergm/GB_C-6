using System;

public class Calculator
{
    private static bool DoubleTryParse(string input, out double result)
    {
        return double.TryParse(input, out result);
    }

    private static void CheckNonNegative(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Число не может быть отрицательным.");
        }
    }

    public static double Add(string operand1, string operand2)
    {
        double num1, num2;

        if (DoubleTryParse(operand1, out num1) && DoubleTryParse(operand2, out num2))
        {
            return num1 + num2;
        }
        else
        {
            throw new ArgumentException("Неверный формат входных данных.");
        }
    }

    public static double Subtract(string operand1, string operand2)
    {
        double num1, num2;

        if (DoubleTryParse(operand1, out num1) && DoubleTryParse(operand2, out num2))
        {
            double result = num1 - num2;
            CheckNonNegative(result); 
            return result;
        }
        else
        {
            throw new ArgumentException("Неверный формат входных данных.");
        }
    }

    public static double Multiply(string operand1, string operand2)
    {
        double num1, num2;

        if (DoubleTryParse(operand1, out num1) && DoubleTryParse(operand2, out num2))
        {
            return num1 * num2;
        }
        else
        {
            throw new ArgumentException("Неверный формат входных данных.");
        }
    }

    public static double Divide(string operand1, string operand2)
    {
        double num1, num2;

        if (DoubleTryParse(operand1, out num1) && DoubleTryParse(operand2, out num2))
        {
            if (num2 != 0)
            {
                double result = num1 / num2;
                CheckNonNegative(result); 
                return result;
            }
            else
            {
                throw new ArgumentException("Деление на ноль.");
            }
        }
        else
        {
            throw new ArgumentException("Неверный формат входных данных.");
        }
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в калькулятор!");

        while (true)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Выход");

            Console.Write("Введите номер операции: ");
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("До свидания!");
                break;
            }

            Console.Write("Введите первое число: ");
            string operand1 = Console.ReadLine();

            Console.Write("Введите второе число: ");
            string operand2 = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Результат: {Calculator.Add(operand1, operand2)}");
                        break;
                    case "2":
                        Console.WriteLine($"Результат: {Calculator.Subtract(operand1, operand2)}");
                        break;
                    case "3":
                        Console.WriteLine($"Результат: {Calculator.Multiply(operand1, operand2)}");
                        break;
                    case "4":
                        Console.WriteLine($"Результат: {Calculator.Divide(operand1, operand2)}");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор операции. Попробуйте еще раз.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
