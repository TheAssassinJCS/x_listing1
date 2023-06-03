using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.CloudClients;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityPage : ContentPage
    {
        UserModal usr;
        CloudUsers clUsr;
        App a;
        public SecurityPage(UserModal u, CloudUsers clu, App _a)
        {
            InitializeComponent();
            usr = u;
            clUsr = clu;
            a = _a;
            if(u.userName == "Admin")
            {
                secDelBtn.IsVisible = false;
            }
            accUserName.Text = "";
            accUserSurname.Text = "";
            accUserEmail.Text = "";
            accUserAddress.Text = "";
            accUserPassword.Text = "";
            accUserName.Placeholder = usr.userName;
            accUserSurname.Placeholder = usr.userSurname;
            accUserEmail.Placeholder = usr.userEmail;
            accUserAddress.Placeholder = usr.userAddress;
            accUserPassword.Placeholder = usr.userPassword;
        }

        private void SecCancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SecDelBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Not allowed", "This function has not been implemented yet.", "OK");
        }

        private void SecSaveBtn_Clicked(object sender, EventArgs e)
        {
            if(usr.userName == "Admin")
            {
                DisplayAlert("Attention", "Cannot change the admin settings!", "OK");
                return;
            }
            bool t = false;
            if(accUserName.Text != "")
            {
                usr.userName = accUserName.Text;
                t = true;
            }
            if(accUserSurname.Text != "")
            {
                usr.userSurname = accUserSurname.Text;
                t = true;
            }
            if(accUserEmail.Text != "")
            {
                usr.userEmail = accUserEmail.Text;
                t = true;
            }
            if(accUserAddress.Text != "")
            {
                usr.userAddress = accUserAddress.Text;
                t = true;
            }
            if (accUserPassword.Text != "")
            {
                usr.userPassword = accUserPassword.Text;
                t = true;
            }
            if(bussinessPicker.SelectedItem != null)
            {
                usr.userBussiness = bussinessPicker.SelectedItem.ToString();
                t = true;
            }
            if (t == true)
            {
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Failed to save new Details or no new details entered, Try again.", "OK");
            }
        }
    }
}