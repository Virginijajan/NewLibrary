using System;

namespace NewLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "MyLibrary";
            var libraryModel = LibraryData.Load(fileName);
            Library library = new Library(libraryModel);
            bool end = true;
            while (end)
            {             
                var libraryController = new LibraryController(library, fileName);
                Console.WriteLine(libraryController.Commands);
                Console.WriteLine(("").PadRight(50, '-'));
                var command=Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(libraryController.ParseInput(command));
                Console.ForegroundColor = ConsoleColor.White;
                if (command == "q")
                {
                    LibraryData.Save(fileName, libraryModel);
                    end = false;
                }                   
            }
        }
    }
}
