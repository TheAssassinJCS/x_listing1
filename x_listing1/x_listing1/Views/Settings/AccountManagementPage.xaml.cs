using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1.Views.Settings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountManagementPage : ContentPage
	{
		ObservableCollection<UserModal> users;
 		public AccountManagementPage ()
		{
			InitializeComponent ();
			users = new ObservableCollection<UserModal>
			{
				new UserModal { uid=0, userName="Jake", userSurname="Simmons", userEmail="jake@gmail.com", userAddress="Bethlehem",
							userImage="profimg", userCellNumber=0123456789, userPassword="1234", userBussiness="BHR", isAdmin=false}
			};
			userAccountsList.ItemsSource = users;
		}

        private async void UserAccountsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			UserModal usr = e.Item as UserModal;
			bool answer = await GetTheInput(usr);
            if(answer)
			{
                _ = DisplayAlert(usr.userFullNames, "This user will be deleted", "OK");
			}

        }

        private async Task<bool> GetTheInput(UserModal u)
        {
            var a = await DisplayAlert(title: u.userName, message: "What do you want to do?", accept: "Delete", cancel: "Cancel");
            return a;
        }

        private void AccManagementCancelBtn_Clicked(object sender, EventArgs e)
        {
			Navigation.PopAsync();
        }
    }
}