using System;
using System.Diagnostics;
using x_listing1.CloudClients;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    public partial class App : Application
    {
        //Variables that has the links to all the pages that is used in the application
        Login lg;
        CloudClientList cloudclist;
        CloudClientComments cloudcComms;
        CloudUsers clouduser;
        
        //The Initializing of the app class and the app starts here
        public App()
        {
            InitializeComponent();
            //Creates the login page then Pushes the login Page to the Main Navigation page and then links the app class 
            //To the login page

            clouduser = new CloudUsers();
            lg = new Login();
            MainPage = new NavigationPage(lg);
            SetLoginAppLink();
        }

        protected override void OnStart()
        {
            //Creates the pages on the start of the application
            cloudclist = new CloudClientList();
            cloudcComms = new CloudClientComments();

            //Links the app class to the pages that was created.
            cloudclist.GetComments(cloudcComms);
        }

        public CloudUsers GetCloudUsersLink() { return clouduser; }
        //Get the cloud client list from the app.cs class
        public CloudClientList GetCloudClientList() { return cloudclist; }

        //Gets the cloud client comments list
        public CloudClientComments GetCloudComsList() { return cloudcComms; }

        //Sets the link between the login page and the app.cs class
        public void SetLoginAppLink()
        {
            lg.SetAppLink(this);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
