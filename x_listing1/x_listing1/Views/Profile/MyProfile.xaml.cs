using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfile : ContentPage
    {
        UserModal loggedInUser;
        public MyProfile()
        {
            InitializeComponent();
        }
        public void SetProfDetails(UserModal u)
        {
            loggedInUser = u;
            profileImg.Source = u.userImage;
            profileTitle.Text = u.userName + " " + u.userSurname;
            profileName.Text = u.userName + " " + u.userSurname;
            profileEmail.Text = u.userEmail;
            profileLocation.Text = u.userAddress;
            profileCellNo.Text = u.userCellNumber.ToString();
            if(u.userBussiness == "BHR")
            {
                profileBussiness.Text = "Bethlehem Hydro Rubber (BHR)";
            }
        }
    }
}