using System;
using System.Linq;

public class StringCalculator
{
    public static void Main(string[] args)
    {
        var calculator = new StringCalculator();
        Console.WriteLine(calculator.Add("  "));
    }

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers)) return 0;

        var delimiters = new[] { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf("\n");
            delimiters = new[] { numbers.Substring(2, delimiterIndex - 2) };
            numbers = numbers.Substring(delimiterIndex + 1);
        }

        var parsedNumbers = numbers
            .Split(delimiters, StringSplitOptions.None)
            .Select(token => int.TryParse(token, out int num) ? num : 0)
            .ToList();

        var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
        if (negativeNumbers.Any())
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negativeNumbers)}");

        return parsedNumbers.Sum();
    }
}
