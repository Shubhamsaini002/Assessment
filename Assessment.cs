// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public static void Main(string[] args)
    {
        StringCalculator st =new StringCalculator();
        Console.WriteLine (st.Add("//;\n1;2"));
    }
     public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }
        string[] delimiters = new[] { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf("\n");
            string customDelimiter = numbers.Substring(2, delimiterIndex - 2);
            delimiters = new[] { customDelimiter };
            numbers = numbers.Substring(delimiterIndex + 1);
        }
        string[] tokens = numbers.Split(delimiters, StringSplitOptions.None);
        List<int> parsedNumbers = new List<int>();
        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int num))
            {
                parsedNumbers.Add(num);
            }
        }
        List<int> negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negativeNumbers)}");
        }

        return parsedNumbers.Sum();
    }
}