using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using x_listing1.Modals;

namespace x_listing1.CloudClients
{
    public class CloudClientComments
    {
        ObservableCollection<CommentModal> comments = new ObservableCollection<CommentModal>
        {
            new CommentModal{commentClientName="John Taljaard", commenterUsrName="Jan Raap", commenterUsrImg="profimg",
                commenterUsrRating=5, commenterUsrComment="He is a dick"},
            new CommentModal{commentClientName="Alba Brink", commenterUsrName="Jan Raap", commenterUsrImg="profimg",
                commenterUsrRating=4, commenterUsrComment="She is nice"},
            new CommentModal{commentClientName="Donald Van der westhuizen", commenterUsrName="Jan Raap", commenterUsrImg="profimg",
                commenterUsrRating=1, commenterUsrComment="This guy does'nt want to pay anyone"},
            new CommentModal{commentClientName="1234567890 12345", commenterUsrName="Jan Raap", commenterUsrImg="profimg",
                commenterUsrRating=4, commenterUsrComment="This is a test"},
            new CommentModal{commentClientName="John Taljaard", commenterUsrName="Mr A", commenterUsrImg="profimg",
                commenterUsrRating=2, commenterUsrComment="Sometimes this guy knows nothing"},
            new CommentModal{commentClientName="Alba Brink", commenterUsrName="Mrs K", commenterUsrImg="profimg",
                commenterUsrRating=3, commenterUsrComment="She always pays."},
            new CommentModal{commentClientName="Alba Brink", commenterUsrName="Mrs L", commenterUsrImg="profimg",
                commenterUsrRating=4, commenterUsrComment="Damn What the hell."}
        };

        public ObservableCollection<CommentModal> GetCommentList(string cName)
        {
            ObservableCollection<CommentModal> tempCommentModal = new ObservableCollection<CommentModal>();
            for (int i = 0; i < comments.Count; i++)
            {
                if (comments[i].commentClientName == cName)
                {
                    tempCommentModal.Add(comments[i]);
                }
            }
            if (tempCommentModal.Count > 0)
            {
                return tempCommentModal;
            }
            else
            {
                Debug.WriteLine("AN ERROR OCCURRED >> PLEASE CHECK WHY DID THE APP NOT GET ANY COMMENTS AT ALL FOR SOME OF THE CLIENTS   ............................THIS IS NEVER SUPPOSED TO SHOW HERE...................................................................................................................................................................................");
                return null;
            }
        }
    }
}
