using NewLibrary;
using NewLibrary.Enums;
using FluentAssertions;
using System;
using Xunit;
using System.Collections.Generic;

namespace NewLibraryUnitTest
{
    public class LibraryControllerTest
    {
        [Fact]
        public void ParseInput()
        {
            //Arrange
            
            LibraryModel libraryModel = new LibraryModel();
            Library library = new Library(libraryModel);
            LibraryController libraryController = new LibraryController(library, "testfile");


            //Act
            var actual=libraryController.ParseInput("Addd");
            //Assert           
            actual.Should().Be("Please enter a valid command.");
        }
    }
}
