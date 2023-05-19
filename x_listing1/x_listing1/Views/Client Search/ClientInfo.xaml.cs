using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ClientInfo : ContentPage
    {
        ObservableCollection<ClientInfoModal> clientInfoList;
        CloudClientComments cloudComs;
        ClientModal c;
        public ClientInfo(ClientModal cl, CloudClientComments clCom)
        {
            InitializeComponent();
            clientInfoName.Text = cl.clientName;
            clientInfoEmail.Text = cl.clientEmail;
            rtInfoControl.SelectedStarValue = cl.clientAdjustedRating;
            clientInfoCellNo.Text = cl.clientCellNo.ToString();
            clientInfoAddress.Text = cl.clientAddress;
            clientInfoList = SetComments(cl.comments);
            clientInfoUserCommentsListView.ItemsSource = clientInfoList;
            cloudComs = clCom;
            c = cl;
        }

        public ObservableCollection<ClientInfoModal> SetComments(ObservableCollection<CommentModal> commentList)
        {
            ObservableCollection<ClientInfoModal> tempClInfo = new ObservableCollection<ClientInfoModal>();
            foreach(CommentModal comment in commentList)
            {
                tempClInfo.Add(new ClientInfoModal
                {
                    commenteruserImage = comment.commenterUsrImg,
                    commenteruserName = comment.commenterUsrName,
                    commenteruserRating = comment.commenterUsrRating,
                    userComment = comment.commenterUsrComment
                });
            }
            return tempClInfo;
        }

        private void clientInfoAddCommentbtn_Clicked(object sender, EventArgs e)
        {
            var _clientName = clientInfoName.Text;
            Image _clientImage = clientInfoImage;
            

            // go to the new comment page
            Navigation.PushAsync(new NewComment(_clientName, _clientImage, cloudComs, this));
        }
        public void ReloadComments()
        {
            clientInfoList = SetComments(cloudComs.GetCommentList(c.clientName));
            clientInfoUserCommentsListView.ItemsSource = clientInfoList;
        }
        private void clientInfoUserCommentsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item == null) { return; }
            ClientInfoModal tempInfo = e.Item as ClientInfoModal;
            DisplayAlert(title: tempInfo.commenteruserName, message: tempInfo.userComment, cancel: "OK");
        }
    }
}