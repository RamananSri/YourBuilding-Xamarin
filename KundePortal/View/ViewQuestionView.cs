using System;

using Xamarin.Forms;

namespace KundePortal.View
{
    public class ViewQuestionView : ContentPage
    {
        public ViewQuestionView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

