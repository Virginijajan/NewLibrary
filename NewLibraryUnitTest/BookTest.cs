using NewLibrary;
using NewLibrary.Enums;
using FluentAssertions;
using System;
using Xunit;

namespace NewLibraryUnitTest
{
    public class BookTest
    {
        [Fact]
        public void AddName()
        {//Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddName("Pasakos");
            bool returnedResult2 = book.AddName("");
            bool returnedResult3 = book.AddName("Pccccccccccccccccccccccccccccccc" +
                "ccccccccccccccccccccccccccccccccccccccccccccccccc" +
                "cccccccccccccccccccccccccccccccccccccccccc" +
                "ccccccccccccccccccccccccccccccccccccccccccccccc" +
                "cccccccccccccccccccccccccccccccccccccc");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            book.Name.Should().Be("Pasakos");
        }
        [Fact]
        public void AddAuthor()
        {
            //Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddAuthor("Vardenis Pavardenis");
            bool returnedResult2 = book.AddAuthor("");
            bool returnedResult3 = book.AddAuthor("Pccccccccccccccccccccccccccccccc" +
                "ccccccccccccccccccccccccccccccccccccccccccccccccc" +
                "cccccccccccccccccccccccccccccccccccccccccc" +
                "ccccccccccccccccccccccccccccccccccccccccccccccc" +
                "cccccccccccccccccccccccccccccccccccccc");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            book.Author.Should().Be("Vardenis Pavardenis");
        }
        [Fact]
        public void AddCategory()
        {
            //Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddCategory("Other");
            bool returnedResult2 = book.AddCategory("Pasaka");
            bool returnedResult3 = book.AddCategory("");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            book.Category.Should().Be(Categories.Other);
        }
        [Fact]
        public void AddLanguage()
        {
            //Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddLanguage("English");
            bool returnedResult2 = book.AddLanguage("Pasaka");
            bool returnedResult3 = book.AddLanguage("");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            book.Language.Should().Be(Languages.English);
        }
        [Fact]
        public void AddPublicationDate()
        {
            //Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddPublicationDate("2001.01.01");
            bool returnedResult2 = book.AddLanguage("Pmmm");
            bool returnedResult3 = book.AddLanguage("");
            bool returnedResult4 = book.AddPublicationDate("0000.01.01");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            returnedResult4.Should().Be(false);
            book.PublicationDate.Should().Be(new DateTime(2001, 01, 01)) ;
        }
        [Fact]
        public void AddISBN()
        {
            //Arrange
            var book = new Book();

            //Act
            bool returnedResult1 = book.AddISBN("9781491976708");           
            bool returnedResult2 = book.AddISBN("8885m55555555");
            bool returnedResult3 = book.AddISBN("88 2222222222");
            bool returnedResult4 = book.AddISBN("00000101");
            bool returnedResult5 = book.AddISBN("97814919767088");

            //Assert
            returnedResult1.Should().Be(true);
            returnedResult2.Should().Be(false);
            returnedResult3.Should().Be(false);
            returnedResult4.Should().Be(false);
            returnedResult5.Should().Be(false);
            book.ISBN.Should().Be("9781491976708");
        }
    }
}
