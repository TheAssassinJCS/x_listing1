using System;
using System.Collections.Generic;
using System.Text;

namespace x_listing1.Modals
{
    //Constructor of the user
    public class UserModal
    {
        public int uid { get; set; }
        public bool isAdmin { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userFullNames
        {
            get
            {
                return userName + " " + userSurname;
            }
        }

        public string userEmail { get; set; }
        public string userImage { get; set; }
        public int userCellNumber { get; set; }
        public string userAddress {  get; set; }
        public string userBussiness { get; set; }
        public string userPassword { get; set; }

        //The settings for the notification's
        public bool notificationNewClient { get; set; }
        public bool notificationNewComment { get; set; }
        public bool notificationLogin { get; set; }
    }
}
