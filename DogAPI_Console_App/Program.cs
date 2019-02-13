using DogAPI_Console_App.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAPI_Console_App
{
    class Program
    {
        public static bool quitNow = false;

        #region API Strings

        private static string allDogs_URL = System.Configuration.ConfigurationManager.AppSettings["All_Dogs_Api_URL"];
        private static string retriever = System.Configuration.ConfigurationManager.AppSettings["Retriever"];
        private static string retrieverSub_breeds_URL = System.Configuration.ConfigurationManager.AppSettings["Retriever__Sub_Breeds_Api_URL"];
        private static string randomGoldenRetrieverPicture_URL = System.Configuration.ConfigurationManager.AppSettings["Retriever_Random_Image_Api_URL"];

        #endregion

        static void Main(string[] args)
        {
            Program.Start_Or_StartAgain();
        }

        private static void Start_Or_StartAgain()
        {
            System.Console.WriteLine("Please enter a 1 for all dogs AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 2 to check if retriever is in the list AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 3 for all retriever sub breeds AND PRESS THE ENTER KEY - \n" +
                                    "Please enter a 4 for a random picture of a Golden retriever AND PRESS THE ENTER KEY - \n");

            Program.Get_User_Choice(Console.ReadLine());
        }

        private static void Get_User_Choice(string command)
        {
            Dog_API dogApi = new Dog_API();
            DogAPI_Console_App.Messages.Messages messages = new DogAPI_Console_App.Messages.Messages();

            switch (command)
            {
                case "1":
                    Console.WriteLine("Here Is Your List of all the dogs\n");

                    dogApi.Get_Dogs(allDogs_URL);

                    messages.Continue_Or_Quit_Message();
                    Program.Continue_Or_Quit(Console.ReadLine());

                    break;

                case "2":
                    Console.WriteLine("Here Is to check if Retriever is in the result set\n");

                    dogApi.Check_If_Breed_Exists(retriever, allDogs_URL);

                    messages.Continue_Or_Quit_Message();
                    Program.Continue_Or_Quit(Console.ReadLine());

                    break;

                case "3":
                    Console.WriteLine("Here are the sub Breeds for retriever\n");

                    dogApi.Get_Dogs(retrieverSub_breeds_URL);

                    messages.Continue_Or_Quit_Message();
                    Program.Continue_Or_Quit(Console.ReadLine());

                    break;

                case "4":
                    Console.WriteLine("Here is a URL for a random picture of a golden retriever\n");

                    string goldenRetriever_ImageURL = dogApi.Get_Random_SubBreedImage_URL(randomGoldenRetrieverPicture_URL);
                    System.Console.WriteLine(goldenRetriever_ImageURL);

                    messages.Continue_Or_Quit_Message();
                    Program.Continue_Or_Quit(Console.ReadLine());

                    break;

                default:
                    Console.WriteLine("Unknown Command " + command);

                    messages.What_Are_You_Doing();
                    messages.Continue_Or_Quit_Message();

                    Program.Continue_Or_Quit(Console.ReadLine());

                    break;
            }
        }

        private static void Continue_Or_Quit(string command)
        {
            DogAPI_Console_App.Messages.Messages messages = new DogAPI_Console_App.Messages.Messages();

            while (!quitNow)
            {
                switch (command)
                {
                    case "y":
                        Console.Clear();
                        Program.Start_Or_StartAgain();
                        break;

                    case "Y":
                        Console.Clear();
                        Program.Start_Or_StartAgain();
                        break;

                    case "n":
                        Console.WriteLine("GOODBYE");
                        quitNow = true;
                        break;

                    case "N":
                        Console.WriteLine("GOODBYE");
                        quitNow = true;
                        break;

                    default:
                        Console.WriteLine("Unknown Command " + command + "\n");
                        messages.Continue_Or_Quit_Message();
                        Program.Continue_Or_Quit(Console.ReadLine());
                        break;
                }
            }
        }
    }
}
