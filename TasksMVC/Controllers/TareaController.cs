using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksMVC.Models;

namespace TasksMVC.Controllers
{
    public class TareaController : Controller
    {
        private List<Tarea> listaTareas = new List<Tarea>()
        {
            new Tarea()
            {
                Titulo = "Crear tarea",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Titulo = "Listar tareas",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Titulo = "Completar tarea",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Titulo = "Remover tarea",
                AsignadaA = "Victor",
                Completada = false
            }
        };

        // GET: Tarea
        public ActionResult Index()
        {            

            return View(listaTareas);
        }
    }
}