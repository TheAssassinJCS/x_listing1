using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using x_listing1.Modals;

namespace x_listing1.CloudClients
{
    public class CloudUsers
    {
        ObservableCollection<UserModal> users = new ObservableCollection<UserModal>
        {
            new UserModal { uid=0, userName="Admin", userSurname="", userEmail="c1", userAddress="On Earth, In a town", 
                            userImage="profimg", userCellNumber=0123456789, userPassword="c1a", userBussiness="BHR", isAdmin=true}
        };

        public ObservableCollection<UserModal> GetUsersList() { return users; }

        public UserModal GetUser(string email)
        {
            UserModal u = new UserModal();
            for(int i=0 ; i<users.Count; i++)
            {
                if (users[i].userEmail == email)
                {
                    u = users[i];
                }
            }
            return u;
        }

        public void AddUsersToList(UserModal u) { users.Add(u); }

        public void RemoveUsersFromList(UserModal u) { users.Remove(u); }
    }
}
