using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Uge1
{
    class Program
    {

        public class Timer
        {
            private readonly System.Diagnostics.Stopwatch stopwatch
              = new System.Diagnostics.Stopwatch();
            public Timer() { Play(); }
            public double Check() { return stopwatch.ElapsedMilliseconds / 1000.0; }
            public void Pause() { stopwatch.Stop(); }
            public void Play() { stopwatch.Start(); }
        }

        public static double Opgave1Hjælpemetode(String inputstring, int rows, int columns) {

            double dummy = 1.0;
            string[] labyrinthDimensions = inputstring.Split('x');
            int numberOfRows = Convert.ToInt32(labyrinthDimensions[0]) * rows;
            int numberOfColumns = Convert.ToInt32(labyrinthDimensions[1]) * columns;
            char[,] labyrinthCharacters = new char[numberOfRows, numberOfColumns];
            return dummy;
        
        }

        public static double Opgave1Hovedmetode(String inputstring, int rows, int columns) {

            int n = 10;
            int count = 1000000;
            double dummy = 0.0;
            for (int j = 0; j < n; j++)
            {
                Timer t = new Timer();
                for (int i = 0; i < count; i++)
                    dummy += Opgave1Hjælpemetode(inputstring, rows, columns);
                double time = t.Check() * 1e9 / count;
                Console.WriteLine("{0,6:F1} ns", time);
            }
            return dummy;

        }
        static void Main(string[] args)
        {
            
            // Tekstfilen med labyrinten ligger i selve projektmappen (samme sted som filen »Program.cs«).
            FileStream fs = new FileStream("../../labyrint.txt", FileMode.Open, FileAccess.Read);

            string firstLine = String.Empty;
            int numberOfRows, numberOfColumns;

            using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
            {                
                firstLine = streamReader.ReadLine();                

                // Opgave 1: Tidstagning på konvertering fra tekst til heltal og oprettelse af array:
                Console.WriteLine("Opgave 1:");
                Opgave1Hovedmetode(firstLine, 1, 1);

                // Opgave 2: Tidstagnning når størrelsen på arrayet tidobles:
                Console.WriteLine("Opgave 2:");
                Opgave1Hovedmetode(firstLine, 10, 10);

                // Opgave 3: Tidstagning når størrelsen på arrayet hundrededobles:
                Console.WriteLine("Opgave 3:");
                Opgave1Hovedmetode(firstLine, 100, 100);


                //Omdan den første linje på formen 21x21 til et string-array kun med tallene indsat som strings
                string[] labyrinthDimensions = firstLine.Split('x');
                
                //Forsøg på at omdanne de indlæste tal på formen strings i string-arrayet til rigtige heltal
                if (int.TryParse(labyrinthDimensions[0], out numberOfRows) && int.TryParse(labyrinthDimensions[1], out numberOfColumns))
                {
                    //Hvis konverteringen lykkes, dannes et char-array med de ønskede dimensioner, så det 
                    //kan rumme alle tegnene i labyrinten
                    char[,] labyrinthCharacters = new char[numberOfRows,numberOfColumns];

                    string textLine = String.Empty;
                    
                    int i = 0;
                    while ((textLine = streamReader.ReadLine()) != null)
                    {
                        for (int j = 0; j < textLine.Length; j++)
                        {
                            labyrinthCharacters[i,j] = textLine[j];
                        }
                        i++;
                    }

                    //Udskriver den indlæste labyrint til konsollen
                    for (int k = 0; k < numberOfRows; k++)
                    {
                        for (int m = 0; m < numberOfColumns; m++)
                        {
                            Console.Write(labyrinthCharacters[k,m]);
                        }
                        Console.WriteLine();
                    }                    
                    
                    Console.ReadLine();
                }

                streamReader.Close();
                
            }

            
            
        }
    }
}
