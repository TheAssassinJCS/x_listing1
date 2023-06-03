using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1;
using x_listing1.CloudClients;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //The Variables used in the login Page
        App appinit;
        CloudUsers cU;
        private string _password;
        private string _email;
        private string _bussiness;

        private string _mainEmail;
        private string _mainPass;

        //The initialization of the login page
        public Login()
        {
            InitializeComponent();
            _mainEmail = "c1";
            _mainPass = "c1a";
        }

        //To login to the app in the first place use these codes = email = c1 and the password = c1a and choose bhr as well

        //Links the app.cs class to the login page, Gets called when the application starts up
        public void SetAppLink(App a)
        {
            appinit = a;
            cU = a.GetCloudUsersLink();
        }

        //When the login GET STARTED buttton is clicked
        private void loginGetStartedBtn_Clicked(object sender, EventArgs e)
        {
            //Uses local variables to link the inputted text
            var email = loginEmail.Text;
            var password = loginPassword.Text;
            var bussiness = bussinessPicker.SelectedItem as string;

            UserModal user = new UserModal();
            user = cU.GetUser(email);
            if (user == null)
            {
                //No User has been found
                DisplayAlert("Error", "No user found", "OK");
                return;
            }

            if (user.userPassword == password)
            {
                if (user.userBussiness == bussiness)
                {
                    loginEmail.Text = "";
                    loginPassword.Text = "";
                    var mainPg = new MainPage(user);
                    if (appinit.GetCloudComsList() == null)
                    {
                        DisplayAlert("Cloud Clients", "It's a null", "OK");
                        return;
                    }
                    mainPg.SetCloudClients(appinit.GetCloudClientList(), appinit, appinit.GetCloudComsList());
                    mainPg.SetProfileForLoggedInUser();
                    Navigation.PushAsync(mainPg);
                }
                else
                {
                    DisplayAlert("Invalid", "Invalid Bussiness Entered", "OK");
                }
            }
            else
            {
                DisplayAlert("Invalid", "Invalid Password Entered", "OK");
            }



            // login btn. check if the email and password is corresponding to that which is saved on the cloud 
            // if not then go to the create new account page.
            // NOTE :: HAVE TO ADD :: when email does not correspond to any saved emails then an error has to be given to the user 
            //saying that an incorrect email or password has been given or that the email or password or bussiness cannot be empty
        }

    }
}