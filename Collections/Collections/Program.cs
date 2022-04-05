using System;
using System.Collections;
using System.Collections.Generic;
namespace Collections
{
    public class Program
    {
        public interface IBag<T> : IEnumerable<T>
        {
            /// <summary>
            /// Add an item to the bag. <c>null</c> items are ignored.
            /// </summary>
            void Pack(T item);
            /// <summary>
            /// Remove the item from the bag at the given index.
            /// </summary>
            /// <returns>The item that was removed.</returns>
            T Unpack(int index);
        }
        /// <summary>
        ///  ILibrary : IReadOnlyCollection<Book>
        /// </summary>
        public interface ILibrary : IReadOnlyCollection<Book>
        {
            // public int Count { get; }
            /// <summary>
            /// Add a Book to the library.
            /// </summary>
            void Add(string title, string firstName, string lastName, int numberOfPages);
            /// <summary>
            /// Remove a Book from the library with the given title.
            /// </summary>
            /// <returns>The Book, or null if not found.</returns>
            Book Borrow(string title);
            /// <summary>
            /// Return a Book to the library.
            /// </summary>
            void Return(Book book);
        }
        public class Book
        {
            public string Title { get; set; }
            public string authorFirstname { get; set; }
            public string authorLastname { get; set; }
            public int numberOfpages { get; set; }
        }
        /// <summary>
        /// Library Class.
        /// </summary>
        public class Library : ILibrary
        {
            private Dictionary<string, Book> libraryBook = new Dictionary<string, Book>();
            public int Count
            {
                get
                {
                    return libraryBook.Count;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
            public IEnumerator<Book> GetEnumerator()
            {
                return (IEnumerator<Book>)GetEnumerator();
            }
            public void printLibrary()
            {
                Dictionary<string, Book>.ValueCollection values = libraryBook.Values;
                Console.WriteLine("*******************************************");
                foreach (Book element in values)
                {

                    Console.WriteLine($"Title: {element.Title},\nFirst Name: {element.authorFirstname},\nLast Name: {element.authorLastname},\nNumber Of Pages: {element.numberOfpages}.\n");
                }
                Console.WriteLine("*******************************************");
            }
            public void Add(string title, string firstName, string lastName, int numberOfPages)
            {
                Book myBook = new Book();
                try
                {
                    myBook.Title = title;
                    myBook.authorFirstname = firstName;
                    myBook.authorLastname = lastName;
                    myBook.numberOfpages = numberOfPages;
                    libraryBook.Add(myBook.Title, myBook);
                }
                catch (ArgumentException e)
                {
                    myBook.Title += $"{libraryBook.Count}";
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"New title has been added with a title of {myBook.Title}\n");
                    libraryBook.Add(myBook.Title, myBook);
                }
            }
            public Book Borrow(string title)
            {
                Book book;
                if (libraryBook.TryGetValue(title, out book))
                {
                    libraryBook.Remove(title);
                    return book;
                }
                else
                {
                    return null;
                }
            }
            public void Return(Book book)
            {
                libraryBook.Add(book.Title, book);
            }
        }
        public class Backpack<T> : IBag<T>
        {
            private List<T> items = new List<T>();
            public IEnumerator<T> GetEnumerator()
            {

                return (IEnumerator<T>)GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {

                return (IEnumerator)GetEnumerator();
            }
            public void Pack(T item)
            {
                if (item != null)
                {
                    items.Add(item);
                    Console.WriteLine($"\nAdded item.\n");
                }
            }
            public T Unpack(int index)
            {
                try
                {
                    T item = items[index];
                    items.RemoveAt(index);
                    Console.WriteLine("Removed item.\n");
                    return item;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nItem index was not found!");
                }
                return default(T);
            }
        }
        static void Main(string[] args)
        {
            // Create new library and add books to it.
            Library lib = new Library();
            lib.Add("C++ Book", "Osama", "Alzaghal", 200);
            lib.Add("C# Book", "Fadi", "Hboubati", 600);
            lib.Add("Java Book", "Bashar", "Refae", 500);
            lib.printLibrary();
            // Borrow book and print the library after.
            Console.WriteLine("The books library after borrowing: ");
            Book x = lib.Borrow("C++ Book");
            lib.printLibrary();
            Console.WriteLine("The books library after returning: ");
            lib.Return(x);
            lib.printLibrary();
            // Borrow a book that does not exist so it will return null. 
            x = lib.Borrow("No Book");
            if(x is null)
                Console.WriteLine("Returned null.");
            x = lib.Borrow("C++ Book");
            Backpack<Book> items = new Backpack<Book>();
            items.Pack(x);
            // After Unpacking the item by it's index, it will return the item.
            if(x == items.Unpack(0))
                Console.WriteLine("Unpacked book.");
            // If we unpack item using index that does not exist, it will prompt the user and return null.
            items.Unpack(0);
        }
    }
}