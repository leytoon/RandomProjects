using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicForRecruitment
{
    public class FileEquality
    {
        string[] Lines1;
        string[] Lines2;
        public FileEquality(string path1, string path2)
        {
            if (File.Exists(path1) && File.Exists(path2))
            {
                Lines1 = File.ReadAllLines(path1);
                Lines2 = File.ReadAllLines(path2);
            }
            else
            {
                Console.WriteLine("Invalid path or one of the files does't exist.\n");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public List<String> GetDifferenses()
        {
            List<String> a = new List<string>();

            string[] shorter;
            string[] longer;

            if (Lines1.Length > Lines2.Length)
            {
                shorter = Lines2;
                longer = Lines1;
            }
            else
            {
                longer = Lines2;
                shorter = Lines1;
            }

            for (int i = 0; i < shorter.Length; ++i)
            {
                int shl = GetShorterStringLength(shorter, longer, i);

                for (int j = 0; j < shl; ++j)
                {
                    if (!Lines1[i].Equals("") && !Lines2[i].Equals("") && Lines1[i].ElementAt(j) != Lines2[i].ElementAt(j))
                    {
                        a.Add(String.Format("{0}=>{1}  at line{2}, at {3}", Lines1[i].ElementAt(j), Lines2[i].ElementAt(j), i, j));
                    }

                    if (j == GetShorterStringLength(shorter, longer, i) - 1)
                    {
                        for (int k = GetShorterStringLength(shorter, longer, i); k < GetLongerStringLength(shorter, longer, i); k++)
                        {
                            if (ReferenceEquals(GetLongerString(shorter, longer, i), Lines1[i]))
                                a.Add(String.Format("{0}=>{1}  at line{2}, at {3}", GetLongerString(shorter, longer, i).ElementAt(k), "Empty", i, j + k));
                            else
                                a.Add(String.Format("{0}=>{1}  at line{2}, at {3}", "Empty", GetLongerString(shorter, longer, i).ElementAt(k), i, j + k));
                        }
                        j = GetLongerStringLength(shorter, longer, i) + 3;
                    }
                }
            }

            for (int i = shorter.Length; i < longer.Length; ++i)
            {
                for (int j = 0; j < longer[i].Length; ++j)
                {
                    a.Add(String.Format("{0}=>{3} at line{1},  at {2}", longer[i].ElementAt(j), i, j, "Empty"));
                }
            }

            return a;
        }

        private int GetLongerStringLength(string[] str1, string[] str2, int i)
        {
            if (str1[i].Length > str2[i].Length)
                return str1[i].Length;
            else
                return str2[i].Length;

        }
        private string GetLongerString(string[] str1, string[] str2, int i)
        {
            if (str1[i].Length > str2[i].Length)
                return str1[i];
            else
                return str2[i];

        }
        private int GetShorterStringLength(string[] str1, string[] str2, int i)
        {
            if (str1[i].Length < str2[i].Length)
                return str1[i].Length;
            else
                return str2[i].Length;

        }
    }
}
