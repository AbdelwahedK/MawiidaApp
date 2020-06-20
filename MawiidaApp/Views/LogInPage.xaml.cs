using FirebaseAuth.ViewModels;
using MawiidaApp.Services;
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
        LoginViewModel viewModel;
        IFirebaseAuthentication auth;
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
            auth = DependencyService.Get<IFirebaseAuthentication>();
            this.BackgroundImage = "background.png";
            loginStack.BackgroundColor = System.Drawing.Color.FromArgb(140, 0, 0,0);
            showPass.Toggled += (sender, e) =>
            {
                _ = e.Value ? PassEntry.IsPassword = false : PassEntry.IsPassword = true;
            };
        }

        async void LogIn_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Username != string.Empty)
            {
                string token = await auth.LoginWithEmailAndPassword(viewModel.Username, viewModel.Password);
                if (token != string.Empty)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    ShowError();
                }
            }
        }

        async private void ShowError()
        {
            await DisplayAlert("هناك خطب ما", "البريد الإلكتروني او كلمة السر خطأ", "حسنا");
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