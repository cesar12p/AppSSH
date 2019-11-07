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
	public partial class Login : ContentPage
	{
        string usuario;
        string contraseña;
        public Login ()
		{
			InitializeComponent ();
            clickedd();
        }
        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {

            usuario = txtUser.Text;
            contraseña = txtPasw.Text;
            try
            {
                usuario = txtUser.Text;
                contraseña = txtPasw.Text;
                Class1 clas = new Class1();
                var res = await clas.getUsuarios(usuario, contraseña);

                if (res.ElementAtOrDefault(0) != null)
                {
                    await Navigation.PushAsync(new Menu());
                }
                else
                {
                    await DisplayAlert("", "Genera una cuenta", "ok");
                }



            }
            catch (Exception e1)
            {

            }

        }
        async void clickedd()
        {
            lbClick.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new Registro());
                }
                )

            });


        }
    }
}