using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {   
            base.OnAppearing();

            using (SQLite.SQLiteConnection Conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                Conn.CreateTable<Book>();

                var books = Conn.Table<Book>().ToList();
                booksListView.ItemsSource = books;
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewBookPage());
        }
    }
}
