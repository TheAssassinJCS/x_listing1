using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.CloudClients;
using x_listing1.Modals;
using x_listing1.Views.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        UserModal usr;
        CloudUsers users;
        App aInit;
        MainPage mainP;
        MyProfile profP;

        public Settings()
        {
            InitializeComponent();
        }

        public void SetUserProfDetails(UserModal u, CloudUsers clu, App a, MainPage mp)
        {
            usr = u;
            users = clu;
            aInit = a;
            mainP= mp;
            SetAccManagementPageForAdmin(u.isAdmin);
        }

        public void SetAccManagementPageForAdmin(bool init)
        {
            adminOnlyAccess.IsVisible = init;
        }

        private void NotificationsPageBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotificationsPage(usr));
        }

        private void SecPageBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecurityPage(usr, users, aInit));
        }

        private void AccManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountManagementPage());
        }

        private void HelpPageBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }

        private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (!e.Value)
            {
                mainP.BarBackgroundColor = Color.FromRgb(0, 0, 0);
                mainP.SelectedTabColor = Color.FromRgb(62, 6, 95);
                mainP.UnselectedTabColor = Color.FromRgb(112, 11, 151);
                mainP.setProfileColor(Color.MediumPurple);
                mainP.setSearchColor(Color.MediumOrchid);
                BackgroundColor = Color.MediumPurple;
            }
            else
            {
                mainP.BarBackgroundColor = Color.FromRgb(198, 207, 255);
                mainP.SelectedTabColor = Color.FromRgb(0, 0, 0);
                mainP.UnselectedTabColor = Color.FromRgb(55, 27, 88);
                mainP.setProfileColor(Color.FromHex("#8E8FFA"));
                mainP.setSearchColor(Color.FromHex("#7752FE"));
                BackgroundColor = Color.FromHex("#C2D9FF");
            }
        }

        private void Logout_BtnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}