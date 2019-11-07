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
	public partial class Notificaciones : ContentPage
	{
		public Notificaciones ()
		{
			InitializeComponent ();
            Actualizar();
		}
        public async void Actualizar()
        {
            try
            {




                Class1 notificacion = new Class1();
                var res = await notificacion.getCampana();



                if (res != null)
                {
                    usuarios.ItemsSource = res;
                }




            }
            catch (Exception e1)
            {

            }
        }
	}
}