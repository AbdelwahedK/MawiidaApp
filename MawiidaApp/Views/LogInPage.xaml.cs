using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MawiidaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            loginStack.BackgroundColor = System.Drawing.Color.FromArgb(140, 0, 0,0);
            showPass.Toggled += (sender, e) =>
            {
                _ = e.Value ? PassEntry.IsPassword = false : PassEntry.IsPassword = true;
            };
        }

        private void LogIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new AddNewItemPage()));
        }

        private void PassEntry_Focused(object sender, FocusEventArgs e)
        {
            passImg.Source = "lockClr.png";
        }

        private void PassEntry_Unfocused(object sender, FocusEventArgs e)
        {
            passImg.Source = "lock.png";
        }

        private void UserEntry_Focused(object sender, FocusEventArgs e)
        {
            userImg.Source = "userClr.png";
        }

        private void UserEntry_Unfocused(object sender, FocusEventArgs e)
        {
            userImg.Source = "user.png";
        }
    }
}