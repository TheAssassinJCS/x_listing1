﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_listing1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewComment : ContentPage
    {
        public NewComment(string clientName, Image clientImageSource)
        {
            InitializeComponent();
            newCommentClientName.Text = clientName;
            newCommentImage = clientImageSource;
        }
    }
}