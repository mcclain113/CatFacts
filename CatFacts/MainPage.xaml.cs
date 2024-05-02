using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using CatFacts;

namespace CatFacts
{
    public partial class MainPage : ContentPage
    {
        private readonly CatFactService _catFactService;
     

        public MainPage()
        {
            InitializeComponent();
            _catFactService = new CatFactService();
            RefreshCatFact();
        }

        private async void RefreshCatFact()
        {
            
            try
            {
                var fact = await _catFactService.GetRandomCatFactAsync();
         
                    FactLabel.Text = fact;
             
            }
            catch (Exception ex)
            {
                FactLabel.Text = "Failed to fetch cat fact: " + ex.Message;
            }
            
        }

        private void OnGetFactClicked(object sender, EventArgs e)
        {
            RefreshCatFact();


        }
    }
}
