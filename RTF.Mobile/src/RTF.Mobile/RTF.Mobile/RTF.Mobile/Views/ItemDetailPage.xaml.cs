﻿using RTF.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RTF.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}