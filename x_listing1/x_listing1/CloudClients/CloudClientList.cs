using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using x_listing1.Modals;

namespace x_listing1.CloudClients
{
    public class CloudClientList
    {
        //Create Temp Client Modals
        ObservableCollection<ClientModal> clients = new ObservableCollection<ClientModal>
            {
                new ClientModal
            {
                clientName = "John Taljaard",
                clientEmail = "john.Taljaard@gmail.com",
                clientAddress = "Bethlehem, Panorama, Eufees Str no 15",
                clientAdjustedRating = 3,
                clientCellNo = 0123456789
            },
                new ClientModal
                {
                    clientName = "Alba Brink",
                    clientEmail = "alba.brink@property.co.za",
                    clientAddress = "Bethlehem, Eureka, Hill str no 19",
                    clientAdjustedRating = 1,
                    clientCellNo = 0123456789
                },
                new ClientModal
                {
                    clientName = "Donald Van der westhuizen",
                    clientEmail = "donaldvdWesthuizen@gmail.com",
                    clientAddress = "Bethlhem, Mini Factories no 24",
                    clientAdjustedRating = 4,
                    clientCellNo = 0123456789
                },
                new ClientModal
                {
                    clientName = "1234567890 12345",
                    clientEmail = "donaldvdWesthuizen@gmail.com",
                    clientAddress = "Bethlhem, Mini Factories no 24",
                    clientAdjustedRating = 4,
                    clientCellNo = 0123456789
                }
            };

        public void GetComments(CloudClientComments coms)
        {
            foreach (ClientModal _clientModal in clients)
            {
                _clientModal.comments = coms.GetCommentList(_clientModal.clientName);
            }
        }

        public bool AddClientToList(ClientModal _client)
        {
            clients.Add(_client);
            return true;
        }

        //This will only be accessed from the main Login Access ...
        public bool RemoveClientFromList(ClientModal _client)
        {
            clients.Remove(_client);
            return true;
        }

        public ObservableCollection<ClientModal> GetClients() { return clients; }
    }
}
