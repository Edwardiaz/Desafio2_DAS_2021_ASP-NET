using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Helpers;
using Desafio_2_DAS_2021.Models;

namespace Desafio_2_DAS_2021.Controllers
{
    public class HomeController : Controller
    {
        private Cine_DAS2021Entities ddbb = new Cine_DAS2021Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }

        public ActionResult Grafica()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult getImage(int? id)
        {
            pelicula peliculas = ddbb.peliculas.Find(id);
            byte[] byteImage = peliculas.poster;

            MemoryStream memoryStream = new MemoryStream(byteImage); //nos crea una emmoria auxiliar
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg); //valido el formato que voy a cargar de la imagen
            memoryStream.Position = 0;

            return File(memoryStream, "image/Jpg");
        }

    }
}