using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.CloudClients;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClient : ContentPage
    {
        //This is all of the variables used in the page
        App appInit;
        CloudClientList cl;
        
        //This is where the page is created, done from the app.cs class
        public AddClient()
        {
            InitializeComponent();
        }
        
        //This links the app.cs class to this page
        public void SetAppInit(App a) => appInit = a;
        public void SetCloudClientList(CloudClientList c) => cl = c;

        //This fires when the cancel button is clicked
        private async void AddClientCancelBtn_ClickedAsync(object sender, EventArgs e)
        {
            //Firstly it shows a message to the user asking if he wants to Cancel the creation of a new client.
            bool action = await CancelTheClientCreation();
            if (action == false)
            {
                //If the user clicks cancel on the displayed message then just return to the client creation page
                return;
            }
            else if (action == true)
            {
                //If he said ok . Firstly then Clear all the text entries that was entered 
                ClearTextEntries();
                //And then go back to the main Page
                _ = Navigation.PopAsync();
            }

        }

        //This displays the alert to the user asking if the user wants to cancel.
        private async Task<bool> CancelTheClientCreation()
        {
            var a = await DisplayAlert(title:"Cancel Client Creation", message:"Are You Sure?", accept:"OK", cancel:"Cancel");
            return a;
        }

        //Fires when the create btn is clicked
        private void addClientCreateBtn_Clicked(object sender, EventArgs e)
        {
            if (addClientName.Text == "" || addClientSurname.Text == "" || addClientEmail.Text == "" || addClientCell.Text == "" || addClientCity.Text == "" || addClientSuburb.Text == "" || addClientStreet.Text =="")
            {
                DisplayAlert("Cannot Create", "Cannot leave Empty spaces in client Creation.", "OK");
                return;
            }
            //Firstly Create a ClientModal, and add all the details to a spesific local variable from all the entries that were made
            ClientModal client = new ClientModal();
            CommentModal commenter = new CommentModal();
            client.clientName = addClientName.Text +" "+ addClientSurname.Text;
            client.clientEmail = addClientEmail.Text;
            client.clientAddress = addClientCity.Text +" "+ addClientSuburb.Text +" "+ addClientStreet.Text;
            client.clientCellNo = int.Parse(addClientCell.Text);
            client.clientAdjustedRating = addClientRating.SelectedStarValue;
            commenter.commentClientName = addClientName.Text;
            commenter.commenterUsrComment = addClientComment.Text;
            commenter.commenterUsrName = "John Taljaard";
            commenter.commenterUsrRating= addClientRating.SelectedStarValue;
            commenter.commenterUsrImg = "profimg";
            //client.comments = commenter;
            //Create a boolean to check if the addation of the new client was a success or not
            bool a;
            //use try catch. Because this will be an online thing. You cannot Just add a new client to the online list if you are offline.
            try
            {
                a = cl.AddClientToList(client);
            }
            catch (Exception ex)
            {
                //NOTE :: NOTE :: Here we have to either save the client list locally untill the phone is online to update the list manually
                //OR we can just say that the creation failed because there was no connection or some other issue occured
                Debug.WriteLine(ex + " Is what is going wrong with this thing . hehehehe tru and make that we can fix thsi hehehehe bad timing for a joke");
                return;
            }
            //Here we check if the creation was a success. if it was clear all entries and then go back to the main page
            if (a)
            {
                ClearTextEntries();
                Navigation.PopAsync();
            }
            else
            {
                //NOTE:: NOTE:: NOTE ::if it wasn't , i would like to add firstly someting that we can retry the creation
                //After that we can Display the error and go back to the AddClient Screen without clearing all the details of the client.
                _ = DisplayAlert("error", "An error occured while saving!", "OK");
            }
        }

        // Clears all of the entries on the page
        private void ClearTextEntries()
        {
            addClientName.Text = string.Empty;
            addClientSurname.Text = string.Empty;
            addClientCell.Text = string.Empty;
            addClientEmail.Text = string.Empty;
            addClientCity.Text = string.Empty;
            addClientSuburb.Text = string.Empty;
            addClientStreet.Text = string.Empty;
            addClientComment.Text = string.Empty;
            addClientRating.SelectedStarValue = 1;
        }
    }
}