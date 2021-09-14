using NewLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary
{
    public class LibraryController
    {
        public Library Library { get; private set; }
        public string Commands { get; private set; } = "\nCommands: Add Delete Take Return List Q - to quit";
        public string Message { get; private set; }
        public string FileName { get; private set; }

        string Headline = "\n".PadRight(111, '-') + "\n" + "Name".PadRight(30, ' ') + "Author".PadRight(25, ' ') + "Category".PadRight(12, ' ') + "Language".PadRight(12, ' ') + "Publication date".PadRight(18, ' ') + "ISBN".PadRight(14, ' ') + "\n".PadRight(111, '-') + "\n";

        public LibraryController(Library library, string fileName)
        {
            Library = library;
            FileName = fileName;
        }

        public string ParseInput(string command)
        {
            string message;
            string userName;
            switch (command.ToLower())
            {
                case "add":
                    Book book= CreateABook();                  
                    message= Library.AddBook(book);
                    LibraryData.Save(FileName, Library.LibraryModel);
                    break;
                case "delete":               
                    string bookToDelete = InputAndOutput("Book title: ");
                    message = Library.DeleteBook(bookToDelete);
                    LibraryData.Save(FileName, Library.LibraryModel);
                    break;
                case "take":                 
                    string bookToTakeString = InputAndOutput("Book title: ");
                    userName = InputAndOutput("User name: ");
                    Library.TakeBook(bookToTakeString, userName);
                    message = Library.Message;                   
                    LibraryData.Save(FileName, Library.LibraryModel);                                    
                    break;
                case "return":                   
                    userName = InputAndOutput("User name: ");                                                       
                    string bookToReturn = InputAndOutput("Book title: ");                       
                    message = Library.ReturnBook(bookToReturn, userName);
                    LibraryData.Save(FileName, Library.LibraryModel);                                    
                    break;
                case "list":
                    string msg = "Enter command to filter by (Name Author Category Language ISBN Taken Available) + name: \"Command name\"\n".PadLeft(66, '-')+
                        "\nEnter a command to filter by or any other key to show all: ";                   
                    var commandToFilterString =InputAndOutput(msg);             
                    var books=Library.GetList(commandToFilterString);
                    message = GetABooksTable(books);
                    break;
                case "q":
                    message = "Goodbye!";
                    break;
                default:
                    message = "Please enter a valid command.";
                    break;
            }
            return message;
        }
        public Book CreateABook()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Book book = new Book();
            Console.Write("Name: ");
            while (!book.AddName(Console.ReadLine()))
                Console.WriteLine("The title is not valid.");            
            Console.Write("Author: ");
            while(!book.AddAuthor(Console.ReadLine()))
                Console.WriteLine("The authors name is not valid.");
            Console.Write("Category: ");
            while(!book.AddCategory(Console.ReadLine()))
                Console.WriteLine("The category is not valid");
            Console.Write("Language: ");
            while(!book.AddLanguage(Console.ReadLine()))
                Console.WriteLine("The language is not valid.");
            Console.Write("Publications date(YYYY.MM.DD): ");
            while(!book.AddPublicationDate(Console.ReadLine()))
                Console.WriteLine("The publication date is not valid.");
            Console.Write("ISBN: ");
            while(!book.AddISBN(Console.ReadLine()))
                Console.WriteLine("The ISBN is not valid.");
            Console.ForegroundColor = ConsoleColor.White;
            return book;
        }
        public string InputAndOutput(string output)
        {  
            Console.Write(output);
            string input=Console.ReadLine();
            return input;
        }
        public string GetABooksTable(List<Book>books)
        {
            string table = Headline;
            foreach(Book book in books)
            {
                string name = book.Name;
                if (name.Count() > 30)
                    name = name.Remove(30);
                name = name.PadRight(30, ' ');
                string author = book.Author.PadRight(25, ' ');
                string category = book.Category.ToString().PadRight(12, ' ');
                string language = book.Language.ToString().PadRight(12, ' ');
                string pubDate = book.PublicationDate.ToString("yyyy.MM.dd").PadRight(18, ' ');
                string isbn = book.ISBN.PadRight(14, ' ');
                table += $"{name}{author}{category}{language}{pubDate}{isbn}\n";
            }                      
            return table;
        }
    }
}
