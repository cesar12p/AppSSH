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
	public partial class MonitoreoDeMovimiento : ContentPage
	{
        static int movimiento;
        public MonitoreoDeMovimiento ()
		{
			InitializeComponent ();
            Actualizar.Image = "cincronizar.png";
            inicializarMovimiento();
        }
        private async void inicializarMovimiento()
        {
            try
            {
                Class1 move = new Class1();
                var res = await move.getMovimiento();

                int id = res.ElementAtOrDefault(0).id;
                int valor = res.ElementAtOrDefault(0).Estado;

                int id2 = res.ElementAtOrDefault(1).id;
                int valor2 = res.ElementAtOrDefault(1).Estado;

                movimiento = valor;

                if (valor == 1)
                {
                    // boton1.Text = "Encendido";
                    bMovimiento.Source = "correr.png";
                }
                else
                {
                    //boton1.Text = "Apagado";
                    bMovimiento.Source = "noCorrer.png";
                }


            }
            catch (Exception e1)
            {

            }
        }

        

        private void Actualizar_Clicked(object sender, EventArgs e)
        {
            inicializarMovimiento();
        }
    }
}