namespace my_task
{




    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private bool isAvailable;

        
        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.isAvailable = true;
        }

        // Getter & Setter Methods
        public string GetTitle() { return title; }
        public void SetTitle(string value) { title = value; }

        public string GetAuthor() { return author; }
        public void SetAuthor(string value) { author = value; }

        public string GetIsbn() { return isbn; }
        public void SetIsbn(string value) { isbn = value; }

        public bool GetAvailability() { return isAvailable; }
        public void SetAvailability(bool value) { isAvailable = value; }
    }

    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book != null)
                books.Add(book);
        }

        public bool BorrowBook(string keyword)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if ((books[i].GetTitle().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||       //this line by chat gpt
                     books[i].GetIsbn().Equals(keyword, StringComparison.OrdinalIgnoreCase))
                    && books[i].GetAvailability())
                {
                    books[i].SetAvailability(false);
                    Console.WriteLine($"You borrowed: {books[i].GetTitle()}");
                    return true;
                }
            }
            Console.WriteLine($"Book '{keyword}'Is not available in the library.");
            return false;
        }

        public bool ReturnBook(string keyword)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if ((books[i].GetTitle().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                     books[i].GetIsbn().Equals(keyword, StringComparison.OrdinalIgnoreCase))
                    && !books[i].GetAvailability())
                {
                    books[i].SetAvailability(true);
                    Console.WriteLine($"Book returned: {books[i].GetTitle()}");
                    return true;
                }
            }
            Console.WriteLine($"Book '{keyword}' is not borrowed.");
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
