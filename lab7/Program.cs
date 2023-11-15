using System;

class Calculator
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль неможливе.");
            return 0;
        }
        return a / b;
    }

    public double Modulus(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Операція Modulus з нульовим дільником.");
            return 0;
        }
        return a % b;
    }

    public double Power(double a, double b) => Math.Pow(a, b);
}

class UserInterface
{
    public int GetChoice()
    {
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("1. Додавання");
        Console.WriteLine("2. Віднімання");
        Console.WriteLine("3. Множення");
        Console.WriteLine("4. Ділення");
        Console.WriteLine("5. Modulus (Остача від ділення)");
        Console.WriteLine("6. Power (Піднесення до ступеня)");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
        }

        return choice;
    }

    public double GetOperand(string operandName)
    {
        Console.WriteLine($"Введіть {operandName}:");
        double operand;
        while (!double.TryParse(Console.ReadLine(), out operand))
        {
            Console.WriteLine("Некоректне значення. Введіть число.");
        }

        return operand;
    }

    public void ShowResult(double result)
    {
        Console.WriteLine($"Результат: {result}");
    }
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        UserInterface userInterface = new UserInterface();

        double operand1 = userInterface.GetOperand("перше число");
        double operand2 = userInterface.GetOperand("друге число");
        int choice = userInterface.GetChoice();

        double result = 0;

        switch (choice)
        {
            case 1:
                result = calculator.Add(operand1, operand2);
                break;
            case 2:
                result = calculator.Subtract(operand1, operand2);
                break;
            case 3:
                result = calculator.Multiply(operand1, operand2);
                break;
            case 4:
                result = calculator.Divide(operand1, operand2);
                break;
            case 5:
                result = calculator.Modulus(operand1, operand2);
                break;
            case 6:
                result = calculator.Power(operand1, operand2);
                break;
            default:
                Console.WriteLine("Неправильний вибір операції.");
                break;
        }

        userInterface.ShowResult(result);

        Console.ReadKey();
    }
}
