using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LogicForRecruitment
{
    public class LetterCounter
    {
        private Dictionary<char, int> LettersCounted;
        private String Text;
        public String StrResult;
        public LetterCounter(String text)
        {
            LettersCounted = new Dictionary<char, int>();
            Text = new String(text.ToLower().Replace(" ", "").ToCharArray());

        }

        public Dictionary<char, int> Count()
        {
            for (int i = 0; i < Text.Length; ++i)
            {
                if (!LettersCounted.ContainsKey(Text[i]) && ((int)Text[i] <= 122 && (int)Text[i] >= 97)// a-z
                   || ((int)Text[i] <= 383 && (int)Text[i] >= 192))//diacritic
                    LettersCounted.Add(Text[i], 0);
            }
            foreach (char c in Text)
            {
                if (((int)c <= 122 && (int)c >= 97) || ((int)c <= 383 && (int)c >= 192))
                    LettersCounted[c]++;
            }
            return LettersCounted;
        }
        public void PrintResult()
        {
            foreach (var c in LettersCounted)
                Console.WriteLine("{0} - {1},", c.Key, c.Value);

        }
        public string StringForTest()
        {
            foreach (var c in LettersCounted)
                StrResult += String.Format("{0}-{1},", c.Key, c.Value);

            return StrResult;
        }
    }
}
