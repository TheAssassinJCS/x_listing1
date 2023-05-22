using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using x_listing1.CloudClients;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Serialization;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientSearch : ContentPage
    {
        //All the variables used in the client search page
        App appInit;
        CloudClientList c;
        CloudClientComments cComs;
        ObservableCollection<ClientModal> cModals;
        UserModal usrM;

        //The Initialization of the client search page is done here, Most probably from the initialization of the MainPage
        public ClientSearch()
        {
            InitializeComponent();
        }

        //This sets the cloud client List and app class links . it is done from the mainPage.cs
        public void SetCloudcList(CloudClientList cl, App a, CloudClientComments comm)
        {
            c = cl;
            appInit = a;
            cComs = comm;
            SetClientSearchListViewItemsSources();
        }

        public void SetUserDetails(UserModal u)
        {
            usrM = u;
            clientSearchProfName.Text = u.userName + " " + u.userSurname;
            clientSearchProfImg.Source = u.userImage;
            clientSearchProfEmail.Text = u.userEmail;
        }

        // This uses the Observable List variable that was created and links the cloud list to it. so that it is more accessable to the 
        // User for faster results.
        public void SetClientSearchListViewItemsSources()
        {
            //Gets the clientlist from the WEb and then adds them to a local list
            cModals = c.GetClients();
            //This sets the listview from the xaml file to the observable list created
            clientSearchListView.ItemsSource = cModals;
        }

        //This fires when the text changes on the Searchbar in the searchClient.xaml
        private void clientSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //takes the first letter of the search and makes it capital letters
            // firstly checking if the length is only 1 character and then if it is make it uppercase. else if the 
            // searchtext is longer than 1 character then only take the first character and make it capital.
            var searchText = clientSearchBar.Text;
            if (searchText.Length > 0)
            {
                Char[] str = searchText.ToCharArray();
                string upstr = str[0].ToString();
                upstr = upstr.ToUpper();
                searchText = upstr;
                if (str.Length > 1)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        searchText += str[i];
                    }
                }
            }
            cModals = c.GetClients();
            clientSearchListView.ItemsSource = cModals.Where(s => s.clientName.StartsWith(searchText));
        }

        //This fires when the Add Btn is clicked. It gets the Add client Page , which is already created from the app.cs class when the 
        //Application is started and then just adds it to the layers of pAges that is on the application
        private void btnClientSearchAddClient_Clicked(object sender, EventArgs e)
        {
            //Sends to the add client Page
            Navigation.PushAsync(new AddClient(cComs, c, this));
        }

        //This Fires when one of the clients has been tapped . It opens the Client Info page for a spesific client and then adds all of the 
        //Details for that spesific client to the page.
        private void ClientSearchListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //If an item is selected in the client list then send to the clients info page
            ClientModal client = e.Item as ClientModal;
            if (client != null)
            {
                Navigation.PushAsync(new ClientInfo(client, cComs));
            }
            else
            {
                _ = DisplayAlert("Reference not set", "Client object does not have a reference", "OK");
            }
        }

    }
}