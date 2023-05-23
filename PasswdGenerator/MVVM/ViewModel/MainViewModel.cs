using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswdGenerator.Core;

namespace PasswdGenerator.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand GeneratorViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public GeneratorViewModel GeneratorVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            GeneratorVM = new GeneratorViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            GeneratorViewCommand = new RelayCommand(o =>
            {
                CurrentView = GeneratorVM;
            });
        }
    }
}
