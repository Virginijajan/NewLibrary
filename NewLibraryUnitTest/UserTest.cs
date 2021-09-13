using NewLibrary;
using NewLibrary.Enums;
using FluentAssertions;
using System;
using Xunit;
using System.Collections.Generic;

namespace NewLibraryUnitTest
{
    public class UserTest
    {
        [Fact]
        public void AddTheBookToListShouldWork()
        {
            //Arrange
            var book = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");

            User user = new User("User");


            //Act
            user.AddTheBookToList(book);
           

            //Assert
            user.Books.Count.Should().Be(1);
            user.Books[0].Name.Should().Be("Name");

        }
        [Fact]
        public void AddTheBookToListShoulFilek()
        {
            //Arrange
            var book = new Book();
            book.AddName("Name");
            book.AddAuthor("Author");
            book.AddCategory("Business");
            book.AddLanguage("English");
            book.AddISBN("1234524444441");

            User user = new User("User");

            //Act
            user.AddTheBookToList(book);
            var actual2 = user.ReturnBook("nnnn");
            var actual=user.ReturnBook("Name");
            var actual1 = user.ReturnBook("Name");

            //Assert
            user.Books.Count.Should().Be(0);
            actual.Should().Be(true);
            actual1.Should().Be(false);
            actual2.Should().Be(false);
        }
    }
}
