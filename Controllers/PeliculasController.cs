using System;
using System.Data;
using System.Data.Entity;
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
    public class PeliculasController : Controller
    {
        private Cine_DAS2021Entities ddbb = new Cine_DAS2021Entities();

        // GET: Peliculas
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

        public ActionResult Agregar()
        {
            return View();
        }
        //Este metodo aunque tenga el mismo nombre que el de arriba, solamente se encarga de la accion post
        [HttpPost]
        public ActionResult Agregar(PeliculasCLS peliculasCLS)
        {

            if (!ModelState.IsValid)
            {
                return View(peliculasCLS);
            }
            else
            {
                using (var bd = new Cine_DAS2021Entities())
                {
                    pelicula opelicula = new pelicula();
                    opelicula.titulo = peliculasCLS.titulo;
                    opelicula.sinopsis = peliculasCLS.sinopsis;
                    opelicula.titulo = peliculasCLS.titulo;
                    opelicula.director = peliculasCLS.director;
                    opelicula.puntuacion = peliculasCLS.puntuacion;
                    opelicula.poster_name = peliculasCLS.poster_name;
                    HttpPostedFileBase http = Request.Files[0];
                    WebImage webImagen = new WebImage(http.InputStream);
                    opelicula.poster = webImagen.GetBytes();
                    bd.peliculas.Add(opelicula);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        //Metodo para cargar la imagen
        public ActionResult getImage(int? id)
        {
            pelicula peliculas = ddbb.peliculas.Find(id);
            byte[] byteImage = peliculas.poster;

            MemoryStream memoryStream = new MemoryStream(byteImage); //nos crea una emmoria auxiliar con los bytes de la imagen
            Image image = Image.FromStream(memoryStream); //creo un objeto tipo Image en base a l memory stream

            memoryStream = new MemoryStream(); // vacio el memoryStream para llenarlo con la info de la imagen
            image.Save(memoryStream, ImageFormat.Jpeg); //valido el formato que voy a cargar de la imagen
            memoryStream.Position = 0;

            return File(memoryStream, "image/Jpg");
        }
        //metodo para llenar el modelo con la data que necesito para la grafica
        public ActionResult Grafica()
        {
            List<PeliculasCLS> listaPeliculas = null;

            using (var bd = new Cine_DAS2021Entities())
            {
                listaPeliculas = (from pelicula in bd.peliculas
                                  select new PeliculasCLS
                                  {
                                    iid_pelicula = pelicula.id_pelicula,
                                    titulo = pelicula.titulo,
                                    puntuacion = pelicula.puntuacion,   
                                  }
                                  ).ToList();
            }
            return View(listaPeliculas);
        }

    }
}