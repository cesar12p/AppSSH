using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace App4
{
    class Class1
    {
        string URL;
        public static string usuario;
        public static string pass;




        // const string URL = "http://prueb.website/prueba1.php";
        //const string URL = "http://prueb.website/Arduino/myjson.php";
        //Genera la conexion
        private HttpClient getCliente()

        {

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }
        //Tarea del login
        public async Task<IEnumerable<Respuesta>> getUsuarios(string usuario, string pass)
        {

            URL = "http://prueb.website/SSHome/login.php?Usuario=" + usuario + "+&Contrasena=" + pass;
            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Respuesta>>(content);
            }
            return Enumerable.Empty<Respuesta>();

        }
        public async Task<IEnumerable<Respuesta>> getRegistro(string usuario, string pass, string nombre, string apellido, string celular, string email, string direccion, string codigoP, string idp)
        {
            //http://prueb.website/SSHome/IngresaUsuarios.php?Usuario=chino&Contrasena=123&Nombre=Hugo&Apellidos=Cruz&Celular=3213828&Email=jfdhjsd@jhsdh&Direccion=Colima&CodigoPostal=28888&IdPlaca=5
            URL = "http://prueb.website/SSHome/IngresaUsuarios.php?Usuario=" + usuario + "&Contrasena=" + pass + "&Nombre=" + nombre + "&Apellidos=" + apellido + "&Celular=" + celular + "&Email=" + email + "&Direccion=" + direccion + "&CodigoPostal=" + codigoP + "&IdPlaca=" + idp;
            //URL = "http://prueb.website/ingresaUsuarioAndroid.php?usu="+usuario+"&pas="+pass;
            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Respuesta>>(content);

            }
            return Enumerable.Empty<Respuesta>();
        }
        public async Task<IEnumerable<foco>> getFoco(string Nombre,int estado)
        {

            URL = "http://prueb.website/SSHome/EstadoFoco.php?Foco="+Nombre+"&Estado=" + estado;

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<foco>>(content);

            }
            return Enumerable.Empty<foco>();
        }

        //Puerta
        public async Task<IEnumerable<puerta>> getActualizarPuerta()
        {

            URL = "http://prueb.website/SSHome/consultarPuerta.php";

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<puerta>>(content);

            }
            return Enumerable.Empty<puerta>();
        }
        //Activar alarma
        public async Task<IEnumerable<Activar>> getActivar()
        {

            URL = "http://prueb.website/SSHome/consultarAlarma.php";

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Activar>>(content);

            }
            return Enumerable.Empty<Activar>();
        }

        //Cambiar alarma
        public async Task<IEnumerable<Activar>> getCambiar(int estado)
        {

            URL = "http://prueb.website/SSHome/EstadoAlarma.php?Estado=" + estado;

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Activar>>(content);

            }
            return Enumerable.Empty<Activar>();
        }
        //Notificacion
        public async Task<IEnumerable<Notificacion>> getCampana()
        {

            URL = "http://prueb.website/SSHome/ConsultarMovimiento.php";

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Notificacion>>(content);

            }
            return Enumerable.Empty<Notificacion>();
        }

        //Movimiento
        public async Task<IEnumerable<Movimiento>> getMovimiento()
        {

            URL = "http://prueb.website/SSHome/ConsultarPir.php";

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Movimiento>>(content);

            }
            return Enumerable.Empty<Movimiento>();
        }
        //Inicializar
        public async Task<IEnumerable<foco>> getInicializarFoco()
        {

            URL = "http://prueb.website/SSHome/consultarFoco.php";

            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<foco>>(content);

            }
            return Enumerable.Empty<foco>();
        }

    }
}
