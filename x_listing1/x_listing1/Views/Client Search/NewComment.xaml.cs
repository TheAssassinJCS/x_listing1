using System;
using System.Collections.Generic;
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
    public partial class NewComment : ContentPage
    {
        CloudClientComments clCL;
        ClientInfo clInfo;
        public NewComment(string clientName, Image clientImageSource, CloudClientComments clCm, ClientInfo cInfo)
        {
            InitializeComponent();
            newCommentClientName.Text = clientName;
            newCommentImage = clientImageSource;
            clCL = clCm;
            clInfo = cInfo;
        }

        private void AddCommentCreateBtn_Clicked(object sender, EventArgs e)
        {
            CommentModal cModal = new CommentModal
            {
                commentClientName = newCommentClientName.Text,
                commenterUsrName = clInfo.GetUserModal().userName,
                commenterUsrImg = clInfo.GetUserModal().userImage,
                commenterUsrComment = addCommentsComment.Text,
                commenterUsrRating = newCommentRatingBar.SelectedStarValue
            };
            bool t = PushNewComm(cModal);
            if (t)
            {
                clInfo.ReloadComments();
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Couldn't Create", "Unsuccessfull creation of Comment, Please Try Again.", "OK");
            }
        }

        private bool PushNewComm(CommentModal cm)
        {
            if (cm == null)
            {
                return false;
            }
            else
            {
                try
                {
                    clCL.PushNewComment(cm);
                    return true;
                }
                catch (Exception ex)
                {
                    DisplayAlert("why?", message: ex + " OKAY", "ok");
                    return false;
                }
            }
        }
    }
}