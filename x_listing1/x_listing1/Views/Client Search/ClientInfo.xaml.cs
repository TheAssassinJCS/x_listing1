using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientInfo : ContentPage
    {
        ObservableCollection<ClientInfoModal> clientInfoList;
        public ClientInfo(string _name, string _email, int _rating, int _cellNo,
            string _address, ObservableCollection<CommentModal> commentList)
        {
            InitializeComponent();
            clientInfoName.Text = _name;
            clientInfoEmail.Text = _email;
            rtInfoControl.SelectedStarValue = _rating;
            clientInfoCellNo.Text = _cellNo.ToString();
            clientInfoAddress.Text = _address;
            clientInfoList = SetComments(commentList);
            clientInfoUserCommentsListView.ItemsSource = clientInfoList;
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
            Navigation.PushAsync(new NewComment(_clientName, _clientImage));
        }

        private void clientInfoUserCommentsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ClientInfoModal tempInfo = e.Item as ClientInfoModal;
            DisplayAlert(title: tempInfo.commenteruserName, message: tempInfo.userComment, cancel: "OK");
        }
    }
}