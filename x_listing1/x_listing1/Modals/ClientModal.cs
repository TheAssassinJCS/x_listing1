using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using x_listing1.Modals;

namespace x_listing1.Modals
{
    public class ClientModal
    {
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string clientAddress { get; set; }
        public int clientCellNo { get; set; }
        public int clientAdjustedRating { get; set; }
        public ObservableCollection<CommentModal> comments { get; set; }
    }
}
