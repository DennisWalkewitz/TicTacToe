using System;


namespace TicTacToe
{
    /// <summary>
    /// This class reads user inputs
    /// </summary>
    public class UserInputReader
    {
        public string GetStringInput(string dialoge)
        {
            Console.WriteLine(dialoge);
            return Console.ReadLine();
        }

        public int[] GetCoordinates(string prompt)
        {
            //Thats is what we want to return
            int[] coordinates = new int[2];

            //We get some user input, store it as string
            string userInput = GetStringInput(prompt);

            //Parse userinput into number 
            int coord;
            if (userInput.Length == 2 && int.TryParse(userInput, out coord))
            {
                if (coord > 10 && coord < 34) //must be between 11 and 33
                {
                    coordinates[0] = (int)char.GetNumericValue(userInput[0])-1;
                    coordinates[1] = (int)char.GetNumericValue(userInput[1])-1;

                    if ((coordinates[0] >= 0 && coordinates[0] <= 2)
                        && (coordinates[1] >= 0 && coordinates[1] <= 2))
                    {
                        return coordinates;
                    }
                    else { Console.WriteLine("Wrong format. Write coordinates in two numbers for XY. Example for X=1 Y=2, write: '12'"); return null; }


                }
                else { Console.WriteLine("Wrong format. Write coordinates in two numbers for XY. Example for X=1 Y=2, write: '12'"); return null; }
            }
            else { Console.WriteLine("Wrong format. Write coordinates in two numbers for XY. Example for X=1 Y=2, write: '12'"); return null; }

        }

    }
}
