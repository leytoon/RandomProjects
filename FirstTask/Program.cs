using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicForRecruitment;
using System.Windows.Forms;

namespace FirstTask
{
    class Program
    {


        
        /* Napisz prostą aplikacje gdzie użytkownik może wskazać dwa pliki tekstowe, 
         * jako wynik powinien dostać różnice pomiędzy tymi plikami 
         * (np. w jednym pliku linia nr 2 jest pusta a w drugim zawiera tekst, 
         * linia 3 zawiera tekst i jest on inny niż w linii 3 z drugiego pliku - 
         * program ma wskazać taką różnice)
        */
        [STAThread]
        static void Main(string[] args) 
        {
            string path1 = @".\T1.txt";
            string path2 =  @".\T2.txt";

            Console.WriteLine("Wybierz plik *.txt");

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Only txt|*.txt;";

            dialog.ShowDialog();
            path1 = dialog.FileName;

            Console.WriteLine("Wybierz plik do porównania *.txt");
           
            dialog.ShowDialog();
            path2 = dialog.FileName;
            
            FileEquality Instance = new FileEquality(path1, path2);
           
            List<String> result = Instance.GetDifferenses();

            foreach(string change in result)
            {
                Console.WriteLine(change);
            }

            Console.ReadKey();

        }
    }
}
