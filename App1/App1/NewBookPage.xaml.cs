using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookPage : ContentPage
	{
		public NewBookPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };

            using(SQLite.SQLiteConnection Conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                Conn.CreateTable<Book>();
                var noOfRows = Conn.Insert(book);

                if(noOfRows > 0)
                    DisplayAlert("Success", "Event succesfully handled", "Great!");
                else
                    DisplayAlert("Failed", "Event succesfully handled", "Try Again!");
            }
            
        }
    }
}