using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForRecruitment;

namespace SecondTask
{
    class Program
    {
        /*
         * Napisz prostą aplikacje gdzie użytkownik może wprowadzić tekst, 
         * jako wynik użytkownik ma otrzymać liczbę znaków w ciągu. 
         * (np. ciąg wejściowy jest "Ala ma kota" i wyjścia: 
         * A - 3, l - 1 h - 1, s - 1, c -1, t - 1)
         */
        static void Main(string[] args)
        {
            string text;

            Console.WriteLine("Proszę wpisać ciąg znaków i zatwierdzić enterem aby policzyć wystąpienia liter. \n (Uwzględniane są znaki diakrytyczne, oraz a-z)");

            text = Console.ReadLine();

            LetterCounter Count1 = new LetterCounter(text);
            Count1.Count();
            Count1.PrintResult();

            Console.ReadKey();
        }
    }
}
