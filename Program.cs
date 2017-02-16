using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Uge1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Tekstfilen med labyrinten ligger i selve projektmappen (samme sted som filen »Program.cs«).
            FileStream fs = new FileStream("../../labyrint.txt", FileMode.Open, FileAccess.Read);

            string firstLine = String.Empty;
            int numberOfRows, numberOfColumns;

            using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
            {                
                firstLine = streamReader.ReadLine();
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
