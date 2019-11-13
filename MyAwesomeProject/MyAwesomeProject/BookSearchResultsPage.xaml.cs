using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAwesomeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookSearchResultsPage : ContentPage
    {
        private ObservableCollection<Book> BooksOnPage { get; set; }

        private BookService bookService;

        public BookSearchResultsPage(String searchText)
        {
            InitializeComponent();

           // string searchText = Preferences.Get("SearchText","");

            bookService = new BookService();

            BooksOnPage = new ObservableCollection<Book>();

            List<Book> booksFromService = bookService.FindBooks(searchText);

            foreach (Book book in booksFromService)
            {
                BooksOnPage.Add(book);
            }

            booksList.ItemsSource = BooksOnPage;
        }
    }
}