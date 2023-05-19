using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_listing1.CloudClients;
using Xamarin.Forms;

namespace x_listing1
{
    public partial class MainPage : TabbedPage
    {
        //The variables that are used in the Main Page
        App appInit;
        CloudClientList cl;
        CloudClientComments cComs;

        //The Initialization of the Main Page, done from the app.cs class
        public MainPage()
        {
            InitializeComponent();
        }

        //The links created from the cloud client list and the app.cs classes , done when the app starts.
        public void SetCloudClients(CloudClientList _cl, App a, CloudClientComments cm) 
        {
            cl = _cl;
            appInit = a;
            cComs = cm;
            SetCloudClientsForSearch();
        }

        //This Sets the ClientSearch Page , which is the first tab of the main Page, client List to the cloud's client list.
        public void SetCloudClientsForSearch()
        {
            //Searche is the Binding Context from the Xaml file, because the client search page has been given a name, Searche.
            Searche.SetCloudcList(cl, appInit, cComs);
        }
        
    }
}
