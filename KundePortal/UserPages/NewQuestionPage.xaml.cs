using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KundePortal.UserPages
{
    public partial class NewQuestionPage : ContentPage
    {

		public NewQuestionPage()
		{
			InitializeComponent();

		}

        public NewQuestionPage(string selectedCategory)
        {
            InitializeComponent();
            Title = "Nyt spørgsmål";
            CategoryLbl.Text = selectedCategory;
        }
    }
}
