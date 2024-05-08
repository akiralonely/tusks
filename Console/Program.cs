using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();
        string result = "";

        if (input.All(c => c >= 'a' && c <= 'z'))
        {
            result = ReverseAndMerge(input);
            Console.WriteLine("Строка результата: " + result);
        }
        else
        {
            string invalidChars = new string(input.Where(c => !(c >= 'a' && c <= 'z')).ToArray());
            Console.WriteLine("Ошибка! Входная строка содержит недопустимые символы: " + invalidChars);
        }
    }

    static string ReverseAndMerge(string input)
    {
        int len = input.Length;

        if (len % 2 == 0)
        {
            int mid = len / 2;
            string s1 = ReverseString(input.Substring(0, mid));
            string s2 = ReverseString(input.Substring(mid));
            return s1 + s2;
        }
        else
        {
            string reversed = ReverseString(input);
            return reversed + input;
        }
    }

    static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}