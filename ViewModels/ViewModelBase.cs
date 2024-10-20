using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinalProject.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
