using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] strings = { "vegetables", "ONION", "level", "1234567890", "wheat", "sweet-potato" };

        // количество строк без заглавных букв
        int NoUpper = strings.Count(s => Regex.IsMatch(s, "[a-z]"));
        Console.WriteLine($"Количество строк без заглавных букв: {NoUpper}");

        // количество десятибуквенных строк
        int TenChar = strings.Count(s => Regex.IsMatch(s, "^.{10}$"));
        Console.WriteLine($"Количество десятибуквенных строк: {TenChar}");

        // количество пятибуквенных слов
        int FiveLetter = strings.Count(s => Regex.IsMatch(s, "\\b\\w{5}\\b"));
        Console.WriteLine($"Количество пятибуквенных слов: {FiveLetter}");

        //Слова, начинающиеся на W
        List<string> wWords = strings.Where(s => Regex.IsMatch(s, @"\b[Ww]\w*\b")).ToList();
        Console.WriteLine($"Слова, начинающиеся на 'W': {string.Join(", ", wWords)}");

        // все составные слова, включающие дефис
        List<string> defis = strings.Where(s => Regex.IsMatch(s, @"\b\w+-\w+\b")).ToList();
        Console.WriteLine($"Слова с дефисом: {string.Join(", ", defis)}");
    }
}
