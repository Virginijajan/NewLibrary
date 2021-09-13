using NewLibrary;
using NewLibrary.Enums;
using FluentAssertions;
using System;
using Xunit;
using System.Collections.Generic;

namespace NewLibraryUnitTest
{
    public class LibraryTest
    {
        [Fact]
        public void AddBook()
        {
            
            //Arrange
            var book = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");
          
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);

            //Act
            string message=library.AddBook(book);
            string message1=library.AddBook(book);

            //Assert
            message.Should().Be("The book Name is added to teh library.");
            message1.Should().Be("The book Name is added to teh library.");
            int count = libraryModel.Books.Count;
            count.Should().Be(2);
            string name = libraryModel.Books[0].Name;
            string name1 = libraryModel.Books[1].Name;
            name.Should().Be("Name");
            name1.Should().Be("Name");
        }
        [Fact]
        public void TakeBookShouldWork()
        {
            //Arrange
            var book = new Book();
            var book1 = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");

            book1.AddName("Name");
            book1.AddAuthor("Author");
            book1.AddCategory("Business");
            book1.AddLanguage("English");
            book1.AddISBN("1234524444441");
         
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            User user = new User("user");
            library.AddBook(book);
            library.AddBook(book1);

            //Act
            library.TakeBook("Name","user" );

            //Assert           
            bool isAvailable = libraryModel.Books[0].IsAvailable;
            isAvailable.Should().Be(false);
            isAvailable = libraryModel.Books[1].IsAvailable;
            isAvailable.Should().Be(true);
        }
        
        [Fact]
        public void ReturnBook()
        {
            //Arrange
            var book = new Book();
            var book1 = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");

            book1.AddName("Name");
            book1.AddAuthor("Author");
            book1.AddCategory("Business");
            book1.AddLanguage("English");
            book1.AddISBN("1234524444441");
           
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            User user = new User("user");
            library.AddBook(book);
            library.AddBook(book1);
            library.TakeBook("Name", "user");
            library.TakeBook("Name", "user");

            //Act
            string message=library.ReturnBook("Name", "user");

            //Assert           
            message.Should().Be("The book Name is returned.");           

            bool isAvailable = libraryModel.Books[0].IsAvailable;
            isAvailable.Should().Be(true);
            isAvailable = libraryModel.Books[1].IsAvailable;
            isAvailable.Should().Be(false);

        }
        [Fact]
        public void DeleteBook()
        {
            //Arrange
            var book = new Book();
            var book1 = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");

            book1.AddName("Name1");
            book1.AddAuthor("Author");
            book1.AddCategory("Business");
            book1.AddLanguage("English");
            book1.AddISBN("1234524444441");
           
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            library.AddBook(book);
            library.AddBook(book1);
            User user = new User("user");
            library.TakeBook("Name1", "user");
            
            //Act
            string message = library.DeleteBook("Name");
            string message1 = library.DeleteBook("Name1");

            //Assert           
            message.Should().Be("The book Name is deleted.");
            message1.Should().Be("The book Name1 is borrowed and it can't be deleted.");
            libraryModel.Books.Count.Should().Be(1);            
        }
        [Fact]
        public void GetList()
        {
            //Arrange
            var book = new Book();
            var book1 = new Book();
            book.AddName("Name");
            book.AddAuthor("Author1");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");
            book.AddPublicationDate("2001.01.01");

            book1.AddName("Name1");
            book1.AddAuthor("Author");
            book1.AddCategory("Business");
            book1.AddLanguage("English");
            book1.AddISBN("1234524444441");
            book1.AddPublicationDate("2002.11.21");

            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            User user = new User("user");
            library.AddBook(book);
            library.AddBook(book1);
            library.TakeBook("Name1", "user");

            //Act
            var actual=library.GetList("",FilterBy.All );
            var actual1 = library.GetList("Name1", FilterBy.Name);
            var actual2 = library.GetList("Author", FilterBy.Author);
            var actual3 = library.GetList("Business", FilterBy.Category);
            var actual4 = library.GetList("",FilterBy.Available);
            var actual5 = library.GetList("",FilterBy.Taken);

            //Assert           
            actual.Count.Should().Be(2);
            actual[0].Name.Should().Be("Name");
            actual[0].Author.Should().Be("Author1");
            actual[1].Name.Should().Be("Name1");
            actual[1].Language.Should().Be(Languages.English);
            actual[1].Category.Should().Be(Categories.Business);
            actual[1].PublicationDate.Should().Be(new DateTime(2002,11,21));

            actual1.Count.Should().Be(1);
            actual1[0].Name.Should().Be("Name1");
            actual1[0].Author.Should().Be("Author");
            actual1[0].Language.Should().Be(Languages.English);
            actual1[0].Category.Should().Be(Categories.Business);
            actual1[0].PublicationDate.Should().Be(new DateTime(2002, 11, 21));

            actual2.Count.Should().Be(1);
            actual2[0].Name.Should().Be("Name1");
            actual2[0].Author.Should().Be("Author");
            actual2[0].Language.Should().Be(Languages.English);
            actual2[0].Category.Should().Be(Categories.Business);
            actual2[0].PublicationDate.Should().Be(new DateTime(2002, 11, 21));

            actual3.Count.Should().Be(2);
            actual4.Count.Should().Be(1);
            actual4[0].Name.Should().Be("Name");
            actual5.Count.Should().Be(1);
            actual5[0].Name.Should().Be("Name1");
        }
        [Fact]
        public void FindABook()
        {
            //Arrange
            var book = new Book();
            var book1 = new Book();
            book.AddName("Name");
            book.AddAuthor("Author1");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");
            book.AddPublicationDate("2001.01.01");

            book1.AddName("Name1");
            book1.AddAuthor("Author");
            book1.AddCategory("Business");
            book1.AddLanguage("English");
            book1.AddISBN("1234524444441");
            book1.AddPublicationDate("2002.11.21");
           
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            library.AddBook(book);
            library.AddBook(book1);

            //Act            
            List<Book>actual= library.FindBooksByName("Name");
            List<Book>actual1= library.FindBooksByName("Name2");

            //Assert           
            actual[0].Name.Should().Be("Name");
            actual.Count.Should().Be(1);
            actual1.Count.Should().Be(0);
        }
        [Fact]
        public void AddUser()
        {
            //Arrange  
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            User user = new User("User");

            //Act
            library.AddUser("User");

            //Assert           
            libraryModel.Users.Count.Should().Be(1);
            libraryModel.Users[0].Name.Should().Be("User");
        }
        [Fact]
        public void FindUser()
        {
            //Arrange 
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            User user = new User("User");
            library.AddUser("User");

            //Act
            User actual=library.FindUser("User");

            //Assert           
            actual.Name.Should().Be("User");
        }
    }
}
