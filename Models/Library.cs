using System;
using System.Collections.Generic;

namespace console_library.Models
{
  class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }

    private List<Book> CheckedOut { get; set; }

    public Library(string location, string name)
    {
      Location = location;
      Name = name; 
      CheckedOut = new List<Book>();
      Books = new List<Book>();
    }

    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i+1}) {Books[i].Title} - {Books[i].Author}");
      }
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }

    public void Checkout(string title)
    {
      Book selectedBook = ValidateBook(title, Books);

      if (selectedBook == null)
      {
        Console.Clear();
        Console.WriteLine(@"Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = false;
        CheckedOut.Add(selectedBook);
        Console.WriteLine($"You've checked out {selectedBook.Title}");
        Books.Remove(selectedBook);
      }
    }

    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > bookList.Count)
      {
        return null;
      }
      return bookList[bookIndex - 1];
    }
  }
}