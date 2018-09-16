using PrimeraAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrimeraAplicacion.ViewModels
{
    public class MainPageViewModel : NotifiactionObject
    {
        public ObservableCollection<Survey> surveys { get; set; }

        public ObservableCollection<Survey> Surveys
        {
            get { return surveys; }
            set { surveys = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; set; }

        public MainPageViewModel()
        {
            Surveys = new ObservableCollection<Survey>();

            AddCommand = new Command(AddCommandExecute);
            MessagingCenter.Subscribe<SurveyDetailViewModel, Survey>(this, "SaveSurvey", (a, s) =>
            {
                Surveys.Add(s);
            });
        }

        private void AddCommandExecute(object obj)
        {
            MessagingCenter.Send(this, "AddSurvey");
        }
    }
}
