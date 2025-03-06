using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;

namespace DAL
{
    public class ManejadoraAPI
    {
        public static async Task<List<Personas>> getPersonas()
        {
            string uri = Url.getUri();
            List<Personas> listaPersonas = new List<Personas>();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            string textoJsonRes;

            try
            {
                response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    textoJsonRes = await httpClient.GetStringAsync(uri);
                    httpClient.Dispose();
                    listaPersonas = JsonConvert.DeserializeObject<List<Personas>>(textoJsonRes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaPersonas;
        }


        public static async Task<HttpStatusCode> insertarPersona(Personas per)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = Url.getUri();
            Uri miUri = new Uri($"{miCadenaUrl}");
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(per);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }

        public static async Task<bool> actualizarPersona(Personas per)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = Url.getUri();
            Uri miUri = new Uri($"{miCadenaUrl}/{per.Id}");
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(per);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.IsSuccessStatusCode;
        }
    }  
}
