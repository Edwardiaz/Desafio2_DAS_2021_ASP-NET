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
            List<PeliculasCLS> listaPeliculas = null;

            using (var bd = new Cine_DAS2021Entities())
            {
                listaPeliculas = (from pelicula in bd.peliculas
                                  select new PeliculasCLS
                                  {
                                      iid_pelicula = pelicula.id_pelicula,
                                      titulo = pelicula.titulo,
                                      sinopsis = pelicula.sinopsis,
                                      director = pelicula.director,
                                      puntuacion = pelicula.puntuacion,
                                      poster_name = pelicula.poster_name,
                                  }
                                  ).ToList();
            }
            return View(listaPeliculas);
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

            MemoryStream memoryStream = new MemoryStream(byteImage); 
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg); 
            memoryStream.Position = 0;

            return File(memoryStream, "image/Jpg");
        }

    }
}