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
        CloudClientList cl;
        CloudClientComments coms;
        ClientSearch clientSearchPage;
        UserModal uM;

        //This is where the page is created, done from the app.cs class
        public AddClient(CloudClientComments cm, CloudClientList c, ClientSearch cs, UserModal u)
        {
            InitializeComponent();
            coms = cm;
            cl = c;
            clientSearchPage = cs;
            uM = u;
        }

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
            string cName = addClientName.Text + " " + addClientSurname.Text;
            string cAddress = addClientCity.Text + ", " + addClientSuburb.Text + ", " + addClientStreet.Text;
            ClientModal clModal = new ClientModal
            {
                clientName = cName,
                clientEmail = addClientEmail.Text,
                clientCellNo = int.Parse(addClientCell.Text),
                clientAddress = cAddress,
                clientAdjustedRating = addClientRating.SelectedStarValue
            };
            CommentModal commsModal = new CommentModal
            {
                commentClientName = cName,
                commenterUsrName = uM.userName,
                commenterUsrImg = uM.userImage,
                commenterUsrComment = addClientComment.Text,
                commenterUsrRating = addClientRating.SelectedStarValue
            };

            bool t = PushNewClient(clModal, commsModal);
            if (t)
            {
                clientSearchPage.SetClientSearchListViewItemsSources();
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Couldn't Create", "Unsuccessfull creation of Comment, Please Try Again.", "OK");
            }
        }

        bool PushNewClient(ClientModal cM, CommentModal cmM)
        {
            if(cM == null || cmM == null)
            {
                return false;
            }
            else
            {
                try
                {
                    cl.AddClientToList(cM);
                    coms.PushNewComment(cmM);
                    cl.GetComments(coms);
                    return true;
                }
                catch (Exception e)
                {
                    DisplayAlert("why?", message: e + " OKAY", "ok");
                    return false;
                }
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