using PrimeraAplicacion.Models;
using PrimeraAplicacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeraAplicacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurverDetailsView : ContentPage
	{
		public SurverDetailsView ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<SurveyDetailViewModel, Survey>(this, "SaveSurvey", async (a, s) =>
            {
                await Navigation.PopModalAsync();
            });
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<SurveyDetailViewModel, Survey>(this, "SaveSurvey");
        }
    }
}