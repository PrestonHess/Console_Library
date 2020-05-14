using System;
using console_library.Models;

namespace console_library
{
  class Program
  {

    static void Main(string[] args)
    {
      Library myLibrary = new Library("location", "myLibrary");
      bool inLibrary = true;
      Book whereTheSidewalkEnds = new Book("Shel Silverstein", "Where the Sidewalk Ends");
      Book bullMountain = new Book("Bull Mountain", "Brian Panowich");
      Book theThingsWeCannotSay = new Book("The Things We Cannot Say", "Kelly Rimmer");
      myLibrary.AddBook(whereTheSidewalkEnds);
      myLibrary.AddBook(bullMountain);
      myLibrary.AddBook(theThingsWeCannotSay);
      Enum activeMenu = Menus.CheckoutBook;
      while (inLibrary)
      {
        Console.Clear();
        Console.WriteLine("Welcome to The Library!");
        switch (activeMenu)
        {
            case Menus.CheckoutBook:
                Console.WriteLine("Available Books: ");
                myLibrary.PrintBooks();
                Console.WriteLine("\nSelect a book number to checkout (Q)uit, or (R)eturn a book.");
                break;
            case Menus.ReturnBook:
                Console.WriteLine("Checked Out Books: ");
                myLibrary.PrintCheckedOut();
                Console.WriteLine("\nSelect a book number to return.");
                break;
        }
        string selection = Console.ReadLine();
        switch (selection)
        {
            case "R":
                Console.Clear();
                activeMenu = Menus.ReturnBook;
                break;
            case "A":
                Console.Clear();
                activeMenu = Menus.CheckoutBook;
                break;
            case "Q":
                Console.Clear();
                inLibrary = false;
                break;
            default:
                if (activeMenu.Equals(Menus.CheckoutBook))
                {
                    Console.Clear();
                    myLibrary.Checkout(selection);
                }
                else
                {
                    Console.Clear();
                    myLibrary.ReturnBook(selection);
                }
                break;
        }
      }
    }

    public enum Menus
    {
        CheckoutBook,
        ReturnBook
    }
  }
}
