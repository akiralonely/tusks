using System;
using System.Collections.Generic;
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

            Dictionary<char, int> frequencyMap = CountFrequency(result);
            Console.WriteLine("Частота символов в результирующей строке:");
            foreach (var kvp in frequencyMap)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }

            string biggestVowelSubstring = GetBiggestVowelSubstring(result);
            Console.WriteLine("Самая большая подстрока результирующей строки, которая начинается и заканчивается гласной: " + biggestVowelSubstring);
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

    static Dictionary<char, int> CountFrequency(string input)
    {
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (!frequencyMap.ContainsKey(c))
            {
                frequencyMap.Add(c, 1);
            }
            else
            {
                frequencyMap[c]++;
            }
        }
        return frequencyMap;
    }

    static string GetBiggestVowelSubstring(string input)
    {
        string vowels = "aeiouy";
        int firstIndex = -1;
        int lastIndex = -1;
        for (int i = 0; i < input.Length; i++)
        {
            if (firstIndex == -1 && vowels.Contains(input[i]))
            {
                firstIndex = i;
            }
            if (vowels.Contains(input[i]))
            {
                lastIndex = i;
            }
        }
        if (firstIndex == -1 || lastIndex == -1)
        {
            return "not found";
        }
        return input.Substring(firstIndex, lastIndex - firstIndex + 1);
    }
}