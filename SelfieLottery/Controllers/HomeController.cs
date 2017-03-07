using Newtonsoft.Json;
using SelfieLottery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace SelfieLottery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registrazione()
        {
          

            return View();
        }

        [HttpGet]
        public ActionResult ResetDayLottery()
        {
            string day = DateTime.Now.ToString("yyyyMMdd");
            string pathData = Path.Combine(Server.MapPath("~/App_Data"), day);
            DirectoryInfo dirInfo = new DirectoryInfo(pathData);
            if (dirInfo.Exists)
            {
                foreach (var item in dirInfo.GetFiles("*.json"))
                {
                    System.IO.File.Delete(item.FullName);

                }
            }
           return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult Registrazione(Registrazione model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string day = DateTime.Now.ToString("yyyyMMdd");
            string pathImages = Path.Combine(Server.MapPath("~/Images"), day);
            DirectoryInfo dirInfo = new DirectoryInfo(pathImages);
            if (!(dirInfo.Exists))
            {
                Directory.CreateDirectory(pathImages);
            }
            string filename = "";
            string filePath = "";

            if (model.Foto != null)
            {
                filename = model.Foto.FileName.Replace(Path.GetFileNameWithoutExtension(model.Foto.FileName), model.Id);
                filePath = Path.Combine(pathImages, filename);
                model.Foto.SaveAs(filePath);
            }
            else
            {
                int indiceParametro = model.Url.LastIndexOf("?");
                filename = model.Url.Substring(0, indiceParametro).Replace("_", "");
                int indiceNome = model.Url.LastIndexOf("/");
                filename = filename.Substring(indiceNome + 1);
                filePath = Path.Combine(pathImages, filename);

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(model.Url), filePath);                    
                }
            }    

            string pathData = Path.Combine(Server.MapPath("~/App_Data"), day);
            dirInfo = new DirectoryInfo(pathData);
            if (!(dirInfo.Exists)) {
                Directory.CreateDirectory(pathData);
            }

            DatiPartecipante dati = new DatiPartecipante();
            dati.Id = model.Id;
            dati.Nome = model.Nome;
            dati.Cognome = model.Cognome;
            dati.ImageUrl = string.Format("/images/{0}/{1}", day, filename);

            string data = JsonConvert.SerializeObject(dati);

            System.IO.File.WriteAllText(Path.Combine(pathData, model.Id + ".json"),data);

            ViewBag.Ok = true;


            return View();
        }


        public ActionResult Estrazione()
        {
           
            List<DatiPartecipante> partecipanti = new List<DatiPartecipante>();
            string day = DateTime.Now.ToString("yyyyMMdd");
            string pathData = Path.Combine(Server.MapPath("~/App_Data"), day);
            DirectoryInfo dirInfo = new DirectoryInfo(pathData);
            if (dirInfo.Exists)
            {
                foreach (var item in dirInfo.GetFiles("*.json"))
                {
                    var dati = JsonConvert.DeserializeObject<DatiPartecipante>(System.IO.File.ReadAllText(item.FullName));
                    if (dati != null)
                    {
                        partecipanti.Add(dati);
                    }

                }


            }


            return View(partecipanti);
        }

       
    }
}
