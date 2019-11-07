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
	public partial class Menu : ContentPage
	{
        static int estado;
		public Menu ()
		{
			InitializeComponent ();
            actulizar();
		}

         private async void Monitoreo_Clicked(object sender, EventArgs e)
        {
            if (Navigation != null)
            {
                var pgp = new Pestanas();
                await Navigation.PushAsync(pgp);
            }
           
        }

        private async void ActivarAlarma_Clicked(object sender, EventArgs e)
        {
            if (estado == 1)
            {
                ActivarAlarma.Image = "abierto.png";
                estado = 0;
                cambiar(1);
                await DisplayAlert("Advertencia", "Alarma Desactivada", "ok");
            }
            else 
            {
                if (estado == 0)
                {
                    ActivarAlarma.Image = "cerrado.png";
                    estado = 1;
                    cambiar(0);
                    await DisplayAlert("Advertencia", "Alarma Activada", "ok");
                }
                else
                {
                    if (estado == 2)
                    {
                        ActivarAlarma.Image = "alerta.png";
                        await DisplayAlert("Advertencia", "Alarma Desactivada", "ok");
                        estado = 1;
                        cambiar(1);
                    }

                }
            }

           

        }
        private async void cambiar(int estado)
        {
            try
            {
                Class1 cambiar = new Class1();
                var res = await cambiar.getCambiar(estado);
            }
            catch (Exception e1)
            {

            }
        }
        private async void actulizar()
        {
            try
            {
                Class1 activar = new Class1();
                var res = await activar.getActivar();

                int id = res.ElementAtOrDefault(0).id;
                int valor = res.ElementAtOrDefault(0).Estado;



                if (valor == 0)
                {
                    // boton1.Text = "Encendido";
                    ActivarAlarma.Image = "cerrado.png";
                    estado = 1;
                    
                }
                else if (valor == 1)
                {
                    //boton1.Text = "Apagado";
                    ActivarAlarma.Image = "abierto.png";
                    estado = 0;
                    
                }
                else if (valor == 2)
                {
                    ActivarAlarma.Image = "alerta.png";
                    estado = 1;
                    
                }


            }
            catch (Exception e1)
            {

            }
        }
        private async void Notificaciones_Clicked(object sender, EventArgs e)
        {
            if (Navigation != null)
            {
                var pgp = new Notificaciones();
                await Navigation.PushAsync(pgp);
            }
        }

        private async void Configuraciones_Clicked_1(object sender, EventArgs e)
        {
            var pgp = new Login();
            await Navigation.PushAsync(pgp);

        }
    }
}