using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AnalizadorTexto.Servicios;

namespace AnalizadorTexto.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaAnalizador : ContentPage
    {
        public PaginaAnalizador()
        {
            InitializeComponent();
        }

        private async void AnalyzeButton_Clicked(object sender, EventArgs e)
        {
            Loading(true);

            var sentiment = await ServicioText.AnalyzeText(MessageEntry.Text);

            if (sentiment != null)
            {
                ScoreLabel.Text = sentiment.Score.ToString("N4");
            }

            Loading(false);
        }

        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }
    }
}