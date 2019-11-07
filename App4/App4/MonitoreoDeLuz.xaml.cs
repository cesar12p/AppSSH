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
    public partial class MonitoreoDeLuz : ContentPage
    {
        static int valorFoco;
        static int valorFoco2;
        public MonitoreoDeLuz()
        {
            InitializeComponent();
            inicializarBotones();
        }
        private async void Boton1_Clicked(object sender, EventArgs e)
        {
            if (valorFoco == 1)
            {
                
                valorFoco = 0;
                boton1.Image = "focoOFF.png";
                cambiar("Foco1",0);
            }
            else
            {
                valorFoco = 1;
                boton1.Image = "focoON.png";
                cambiar("Foco1",1);
            }
        }
        private async void Boton2_Clicked(object sender, EventArgs e)
        {
            if (valorFoco2 == 1)
            {
               
                valorFoco2 = 0;
                boton2.Image = "focoOFF.png";
                cambiar("Foco2",0);
            }
            else
            {
                valorFoco2 = 1;
                boton2.Image = "focoON.png";
                cambiar("Foco2",1);
            }





        }
        private async void cambiar(string Nombre, int estado)
        {
            try
            {
                Class1 cambiar = new Class1();
                var res = await cambiar.getFoco(Nombre,estado);
            }
            catch (Exception e1)
            {

            }
        }

        private async void inicializarBotones()
        {
            try
            {
                Class1 clas = new Class1();
                var res = await clas.getInicializarFoco();

                int id = res.ElementAtOrDefault(0).id;
                int valor = res.ElementAtOrDefault(0).Estado;

                int id2 = res.ElementAtOrDefault(1).id;
                int valor2 = res.ElementAtOrDefault(1).Estado;
                valorFoco = valor;
                valorFoco2 = valor2;
                if (valor == 1)
                {
                    // boton1.Text = "Encendido";
                    boton1.Image = "focoON.png";
                }
                else
                {
                    //boton1.Text = "Apagado";
                    boton1.Image = "focoOFF.png";
                }
                if (valor2 == 1)
                {
                    // boton1.Text = "Encendido";
                    boton2.Image = "focoON.png";
                }
                else
                {
                    //boton1.Text = "Apagado";
                    boton2.Image = "focoOFF.png";
                }


            }
            catch (Exception e1)
            {

            }



        }
    }
}