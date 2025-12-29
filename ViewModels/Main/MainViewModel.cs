using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDIDemo.ViewModels.Main;

namespace WpfDIDemo.ViewModels
{
    public partial class MainViewModel : ObservableObject , IMainViewModel
    {
        public MainViewModel()
        {
            
        }

        [ObservableProperty]
        private string _message;

        [RelayCommand]
        public void SayHello()
        {
            Message = "Hello";
        }
    }
}
