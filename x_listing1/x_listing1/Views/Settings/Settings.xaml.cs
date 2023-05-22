using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        UserModal usr;
        public Settings()
        {
            InitializeComponent();
        }

        public void SetUserProfDetails(UserModal u)
        {
            usr = u;
            settingsProfEmail.Text = u.userEmail;
            settingsProfImg.Source = u.userImage;
            settingsProfName.Text = u.userName + " " + u.userSurname;
        }
    }
}