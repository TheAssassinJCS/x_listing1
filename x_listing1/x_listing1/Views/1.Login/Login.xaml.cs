using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //The Variables used in the login Page
        App appinit;
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

        //To login to the app in the first place use these codes = email = c1 and the password = c1a

        //Links the app.cs class to the login page, Gets called when the application starts up
        public void SetAppLink(App a)
        {
            appinit = a;
        }

        //When the login GET STARTED buttton is clicked
        private void loginGetStartedBtn_Clicked(object sender, EventArgs e)
        {
            //Uses local variables to link the inputted text
            var email = loginEmail.Text;
            var password = loginPassword.Text;
            var bussiness = bussinessPicker.SelectedItem as string;

            //This will be the check if the password entered is not the main password for the app. this will also give access
            // to all the application features on the app and nothing will be hidden.
            if (email == _mainEmail && password == _mainPass)
            {
                loginEmail.Text = "";
                loginPassword.Text = "";
                var mainPg = new MainPage();
                if(appinit.GetCloudComsList() == null)
                {
                    DisplayAlert("Cloud Clients", "It's a null", "OK");
                }
                mainPg.SetCloudClients(appinit.GetCloudClientList(), appinit, appinit.GetCloudComsList());
                Navigation.PushAsync(mainPg);
            }

            // login btn. check if the email and password is corresponding to that which is saved on the cloud 
            // if not then go to the create new account page.
            // NOTE :: HAVE TO ADD :: when email does not correspond to any saved emails then an error has to be given to the user 
            //saying that an incorrect email or password has been given or that the email or password or bussiness cannot be empty
        }

    }
}