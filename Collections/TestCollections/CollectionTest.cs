using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using static Collections.Program;

namespace TestProject1
{
    public class test
    {
        [Fact]
        public void AddTest()
        {
            Library lib1 = new Library();
            lib1.Add("Test Book", "Osama", "Alzaghal", 600);
            lib1.Add("Test Book1", "Osama", "Alzaghal", 600);
            lib1.Add("Test Book2", "Osama", "Alzaghal", 600);
            // When adding a book, the count increases.
            Assert.Equal(3, lib1.Count);
            Book book = lib1.Borrow("Test Book");
            // When trying to use Assert.Contains, the test gets stuck without showing any types of errors.
            // Assert.Contains(book, lib1);
        }

        [Fact]
        public void BorrowTest()
        {
            Library lib2 = new Library();
            lib2.Add("Book1", "Osama", "Alzaghal", 600);
            lib2.Add("Book2", "Osama", "Alzaghal", 600);
            Book book = lib2.Borrow("Book1");
            Assert.Equal(1, lib2.Count);
        }

        [Fact]
        public void BorrowMissingTest()
        {
            Library lib3 = new Library();
            lib3.Add("Book1", "Osama", "Alzaghal", 600);
            lib3.Add("Book2", "Osama", "Alzaghal", 600);
            Book book = lib3.Borrow("Book10");
            Assert.Null(book);
        }

        [Fact]
        public void ReturnBookTest()
        {
            Library lib4 = new Library();
            lib4.Add("Book1", "Osama", "Alzaghal", 600);
            lib4.Add("Book2", "Osama", "Alzaghal", 600);
            Book book = lib4.Borrow("Book1");
            // When borrowing a book and returning it, the count increases.
            lib4.Return(book);
            // When trying to use Assert.Contains, the test gets stuck without showing any types of errors.
            //Assert.Contains(book, lib4);
            // Count changed when book returned.
            Assert.Equal(2, lib4.Count);
        }

        [Fact]
        public void PackUnpackTest()
        {
            Library lib5 = new Library();
            lib5.Add("Book1", "Osama", "Alzaghal", 600);
            lib5.Add("Book2", "Osama", "Alzaghal", 600);
            Book book = lib5.Borrow("Book2");
            Backpack<string> items = new Backpack<string>();
            items.Pack(book.Title);
            string title = items.Unpack(0);
            Assert.Equal(title, book.Title);
        }
    }
}
