using APIRESTFULL_paises.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebPaises.Controllers
{
    public class PaisController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Paises Registrados.";
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync("https://localhost:44329/api/paises");
            //var Paises = JsonConvert.DeserializeObject<List<Pais>>(json);
            //return View(Paises);

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44329/");
            var request = clienteHttp.GetAsync("api/pais").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listadoPaises = JsonConvert.DeserializeObject<List<Pais>>(resultString);
                return View(listadoPaises);
            }
            else
            {
                return View();
            }
        }

        //http get Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //HTTP POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Pais pais)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44329/");

            var contenido = JsonConvert.SerializeObject(pais);

            HttpContent nuevopais = new StringContent(contenido, Encoding.UTF8, "application/json");
            
            var request = await clienteHttp.PostAsync("api/pais", nuevopais);
            if (request.IsSuccessStatusCode)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return View();
            }
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44329/");

            var request = clienteHttp.GetAsync("api/pais/"+Id.ToString()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listadoPaises = JsonConvert.DeserializeObject<Pais>(resultString);
                return View(listadoPaises);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Pais pais)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44329/");

            var contenido = JsonConvert.SerializeObject(pais);

            HttpContent nuevopais = new StringContent(contenido, Encoding.UTF8, "application/json");

            var request = await clienteHttp.PutAsync("api/pais/"+pais.Id, nuevopais);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? Id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44329/");

            var request = await clienteHttp.DeleteAsync("api/pais/" + Id.ToString());
            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
    }