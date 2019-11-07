using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonitoreoDePuerta : ContentPage
	{
        static int valorPuerta;
        static int valorPuerta2;
        public MonitoreoDePuerta ()
		{
			InitializeComponent ();
            Sincronizar.Image = "cincronizar.png";
            inicializarPuertas();
        }
        private async void inicializarPuertas()
        {
            try
            {




                Class1 puerta = new Class1();
                var res = await puerta.getActualizarPuerta();

                int id = res.ElementAtOrDefault(0).id;
                int valor = res.ElementAtOrDefault(0).Estado;

                int id2 = res.ElementAtOrDefault(1).id;
                int valor2 = res.ElementAtOrDefault(1).Estado;
                valorPuerta = valor;
                valorPuerta2 = valor2;

                if (valor == 1)
                {
                    // boton1.Text = "Encendido";
                    puerta1.Source = "abiertaPuerta.png";
                }
                else
                {
                    //boton1.Text = "Apagado";
                    puerta1.Source = "cerradaPuerta.png";
                }
                if(valor2 == 1)
                {
                    puerta2.Source = "abiertaPuerta.png";
                }
                else
                {
                    puerta2.Source="cerradaPuerta.png";
                }


            }
            catch (Exception e1)
            {

            }



        }

        private void Sincronizar_Clicked(object sender, EventArgs e)
        {
            inicializarPuertas();

        }
    }
}