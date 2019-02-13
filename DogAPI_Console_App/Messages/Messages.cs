using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAPI_Console_App.Messages
{
    public class Messages
    {
        public void Main_Message()
        {
            System.Console.WriteLine("Please enter a 1 for all dogs AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 2 to check if retriever is in the list AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 3 for all retriever sub breeds AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 4 for a random picture of a Golden retriever AND PRESS THE ENTER KEY - \n");
        }

        public void Continue_Or_Quit_Message()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Please indicate with the Y key AND PRESS THE ENTER KEY to continue with another option");
            System.Console.WriteLine("Or     indicate with the N key AND PRESS THE ENTER KEY To Quit");
        }

        public void What_Are_You_Doing()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Please press 1 , 2 , 3 or 4 - Thank You");
        }
    }
}
