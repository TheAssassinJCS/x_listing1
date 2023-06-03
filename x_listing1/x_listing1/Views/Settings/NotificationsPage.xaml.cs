using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        UserModal usr;
        public NotificationsPage(UserModal u)
        {
            InitializeComponent();
            usr = u;
            notificationNewClientSwitch.IsToggled = u.notificationNewClient;
            notificationNewCommentSwitch.IsToggled = u.notificationNewComment;
            notificationLoginSwitch.IsToggled = u.notificationLogin;
        }

        private void NotificationCancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void NotificationSaveBtn_Clicked(object sender, EventArgs e)
        {
            usr.notificationNewClient = notificationNewClientSwitch.IsToggled;
            usr.notificationNewComment = notificationNewCommentSwitch.IsToggled;
            usr.notificationLogin = notificationLoginSwitch.IsToggled;
            Navigation.PopAsync();
        }


        private void NotificationAllSoundsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            var state = notificationAllSoundsSwitch.IsToggled;
            notificationNewClientSwitch.IsToggled = state;
            notificationNewCommentSwitch.IsToggled = state;
            notificationLoginSwitch.IsToggled = state;
        }
    }
}