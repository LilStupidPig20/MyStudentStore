﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RTF.Mobile.Utils.Models
{
    public class EditableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
