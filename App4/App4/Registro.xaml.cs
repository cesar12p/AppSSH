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
    public partial class Registro : ContentPage
    {
        string usuario;
        string nombre;
        string contraseña;
        string apellido;
        string cel;
        string email;
        string direccion;
        string codigoP;
        string idP;
        public Registro()
        {
            InitializeComponent();
        }
        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = txtUsuario.Text;
                contraseña = txtContraseña.Text;
                nombre = txtNombre.Text;
                apellido = txtApellidos.Text;
                cel = txtTelefono.Text;
                email = txtEmail.Text;
                direccion = txtDireccion.Text;
                codigoP = txtCodigoPostal.Text;
                idP = txtIdPlaca.Text;
                Class1 clas = new Class1();
                var res = await clas.getRegistro(usuario, contraseña, nombre, apellido, cel, email, direccion, codigoP, idP);

                if (res.ElementAtOrDefault(0) != null)
                {
                    await DisplayAlert("", "Usuario registrado", "ok");
                }
                else
                {
                    await DisplayAlert("", "Bienvenido", "ok");
                }



            }
            catch (Exception e1)
            {

            }

        }

    }
}