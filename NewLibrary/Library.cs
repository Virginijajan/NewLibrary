﻿using NewLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary
{
    public class Library
    {
        public LibraryModel LibraryModel { get;private set; }
        public string Message { get; set; }

        public Library(LibraryModel libraryModel)
        {
            LibraryModel=libraryModel;
        }
        public string AddBook(Book book)
        {
            LibraryModel.Books.Add(book);
            Message = $"The book {book.Name} is added to teh library.";
            return Message;
        }
        public void TakeBook(Book book)
        {
             book.IsAvailable = false;                   
             book.DateBookIsTaken = DateTime.Now;                       
        }
        public string ReturnBook(Book book)
        {
            book.IsAvailable = true;
            var period = book.DateBookIsTaken - DateTime.Now;
            if (period.Days >= 60)
                Message = $"The book {book.Name} is returned. You are late to return the book!";
            else 
                Message = $"The book {book.Name} is returned.";
            return Message;
        }
        public string DeleteBook(string name)
        {         
            var bookList = FindBooksByName(name);
            if (bookList.Count== 0)
                Message = $"The book {name} is not found.";
            else
            {
                var bookToDelete = GetAnAvailableBook(bookList);
                if (bookToDelete == null)
                    Message = $"The book {name} is borrowed and it can't be deleted.";
                else
                {
                    LibraryModel.Books.Remove(bookToDelete);
                    Message = $"The book {name} is deleted.";
                }
            }
            return Message;
        }
        public List<Book> GetList(string paramToFilter="", FilterBy filterBy = FilterBy.All)
        {
            List<Book> books = new List<Book>();
            switch (filterBy)
            {
                case FilterBy.Name:
                    books = LibraryModel.Books.Where(b => b.Name == paramToFilter).Select(b => b).ToList();                 
                    break;
                case FilterBy.Author:
                    books= LibraryModel.Books.Where(b=>b.Author==paramToFilter).Select(b => b).ToList();
                    break;
                case FilterBy.Category:
                    books= LibraryModel.Books.Where(b => b.Category.ToString() == paramToFilter).Select(b => b).ToList();                 
                    break;
                case FilterBy.Language:
                    books = LibraryModel.Books.Where(b => b.Language.ToString() == paramToFilter).Select(b => b).ToList();                 
                    break;
                case FilterBy.ISBN:
                    books = LibraryModel.Books.Where(b => b.ISBN== paramToFilter).Select(b => b).ToList();                  
                    break;
                case FilterBy.Taken:
                    books = LibraryModel.Books.Where(b => b.IsAvailable == false).Select(b => b).ToList();              
                    break;
                case FilterBy.Available:
                    books = LibraryModel.Books.Where(b => b.IsAvailable == true).Select(b => b).ToList();             
                    break;
                default:
                    books= LibraryModel.Books.Select(b => b).ToList();
                    break;
            }
            return books;
        }
        public List<Book> FindBooksByName(string name)
        {
            var books = LibraryModel.Books.Where(b => b.Name == name).Select(b => b).ToList();
            if (books.Count == 0)               
                Message = $"The book {name} is not found.";                    
            return books;
        }
        public Book GetAnAvailableBook(List<Book> books)
        {
            var book= books.Where(b => b.IsAvailable == true).Select(b => b).FirstOrDefault();
            if (book == null)
                Message = $"The book is not available";
            return book;
        }
        public User AddUser(string name)
        {
            User user = FindUser(name);
            if (user == null)
            {
                user = new User(name);
                LibraryModel.Users.Add(user);
            }
            return user;
        }
        public User FindUser(string name)
        {
            var user = LibraryModel.Users.Where(u => u.Name == name).Select(u => u).FirstOrDefault();
            return user;
        }
    }
}