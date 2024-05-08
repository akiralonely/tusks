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
            Console.WriteLine("Частота символов в строке результата:");
            foreach (var kvp in frequencyMap)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }

            string biggestVowelSubstring = GetBiggestVowelSubstring(result);
            Console.WriteLine("Самая большая подстрока результирующей строки, которая начинается и заканчивается гласной: " + biggestVowelSubstring);

            ChooseSortingType(result);
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

    static void ChooseSortingType(string input)
    {
        Console.WriteLine("Choose a sorting method (1 = Quick sort, 2 = Tree sort):");
        int sortOption;
        try
        {
            sortOption = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid choice: not an integer number");
            return;
        }

        if (sortOption == 1)
        {
            string sorted = QuickSort(input);
            Console.WriteLine("The sorted string: " + sorted);
        }
        else if (sortOption == 2)
        {
            string sorted = TreeSort(input);
            Console.WriteLine("The sorted string: " + sorted);
        }
        else
        {
            Console.WriteLine("Invalid sort option selected.");
        }

        return;
    }

    static string QuickSort(string input)
    {
        if (input.Length <= 1)
        {
            return input;
        }

        int pivotIndex = input.Length / 2;
        char pivot = input[pivotIndex];

        string left = "";
        string right = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (i == pivotIndex)
            {
                continue;
            }
            if (input[i] < pivot)
            {
                left += input[i];
            }
            else
            {
                right += input[i];
            }
        }

        return QuickSort(left) + pivot + QuickSort(right);
    }

    class Node
    {
        public char Value;
        public Node Left;
        public Node Right;

        public Node(char value)
        {
            Value = value;
        }
    }

    static string TreeSort(string input)
    {
        Node root = null;
        foreach (char c in input)
        {
            root = Insert(root, c);
        }

        List<char> sortedList = new List<char>();
        InOrderTraversal(root, sortedList);

        return new string(sortedList.ToArray());
    }

    static Node Insert(Node node, char value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        else
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    static void InOrderTraversal(Node node, List<char> sortedList)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left, sortedList);
        sortedList.Add(node.Value);
        InOrderTraversal(node.Right, sortedList);
    }
}