using System;
using console_library.Models;

namespace console_library
{
    class Program
    {

        static void Main(string[] args)
        {
            Library myLibrary = new Library("location", "myLibrary");
            Book whereTheSidewalkEnds = new Book("Shel Silverstein", "Where the Sidewalk Ends");
            Book bullMountain = new Book("Bull Mountain", "Brian Panowich");
            Book theThingsWeCannotSay = new Book("The Things We Cannot Say", "Kelly Rimmer");
            myLibrary.AddBook(whereTheSidewalkEnds);
            myLibrary.AddBook(bullMountain);
            myLibrary.AddBook(theThingsWeCannotSay);
            Console.WriteLine("Welcome to The Library!");
            Console.WriteLine("Available Books: ");
            myLibrary.PrintBooks();
            Console.WriteLine("\n Select a book number to checkout (Q)uit, or (R)eturn a book");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "q")
            {
                Console.WriteLine("Thanks for visiting!");
            }
            else if (userInput.ToLower() == "r")
            {
                Console.WriteLine("Which book are you returning?");
            }
            else
            {
                myLibrary.Checkout(userInput);
            }
        }
    }
}
