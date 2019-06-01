using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksMVC.Models;

namespace TasksMVC.Services
{
    public class AdministradorTareas
    {
        /// <summary>
        /// La sesion
        /// </summary>
        private System.Web.SessionState.HttpSessionState _session;

        /// <summary>
        /// Nombre de variable de sesion para almacenar tareas
        /// </summary>
        private readonly string TareasNombreSesion = "Tareas";

        /// <summary>
        /// Tareas iniciales
        /// </summary>
        private List<Tarea> listaTareas = new List<Tarea>()
        {
            new Tarea()
            {
                Id = 1,
                Titulo = "Crear tarea",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Id = 2,
                Titulo = "Listar tareas",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Id = 3,
                Titulo = "Completar tarea",
                AsignadaA = "Victor",
                Completada = false
            },
            new Tarea()
            {
                Id = 4,
                Titulo = "Remover tarea",
                AsignadaA = "Victor",
                Completada = false
            }
        };
        
        public AdministradorTareas(System.Web.SessionState.HttpSessionState session)
        {
            _session = session;

            // Agregar tareas iniciales, sólo en caso de que no haya ya tareas
            _session[TareasNombreSesion] = _session[TareasNombreSesion] != null ? _session[TareasNombreSesion] : listaTareas;
        }

        /// <summary>
        /// Obtiene todas las tareas
        /// </summary>
        /// <returns></returns>
        public List<Tarea> ObtenerTodas()
        {
            return _session[TareasNombreSesion] != null ? (List<Tarea>)_session[TareasNombreSesion] : new List<Tarea>();
        }

        /// <summary>
        /// Agrega una tarea
        /// </summary>
        /// <param name="tarea">La tarea</param>
        /// <returns>True si la tarea fue agregada con éxito</returns>
        public bool Agregar(Tarea tarea)
        {
            // Obtener tareas actuales
            var tareasActuales = _session[TareasNombreSesion] != null ? (List<Tarea>)_session[TareasNombreSesion] : new List<Tarea>();

            // Obtener id máximo
            int maxId = tareasActuales.Max(t => t.Id);

            // Actualizar id
            tarea.Id = maxId + 1;

            // Agregar tarea
            tareasActuales.Add(tarea);

            // Actualizar tareas actuales en sesión
            _session[TareasNombreSesion] = tareasActuales;

            return true;
        }

        /// <summary>
        /// Completa una determinada tarea
        /// </summary>
        /// <param name="id">El id de la tarea a completar</param>
        /// <returns>True si la tarea fue completada</returns>
        public bool Completar(int id)
        {
            // Obtener tareas
            var tareasActuales = this.ObtenerTodas();

            // Obtener tarea a completar
            var tarea = tareasActuales.Where(t => t.Id == id).FirstOrDefault();

            // Validar si existe
            if (tarea != null)
            {
                // Completar tarea
                tarea.Completada = true;

                _session[TareasNombreSesion] = tareasActuales;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Remueve o elimina una tarea
        /// </summary>
        /// <param name="id">El id de la tarea</param>
        /// <returns>True si la tarea fue removida</returns>
        public bool Remover(int id) //USAMOS CODIGO DE COMPLETAR 
        {
            // Obtener tareas
            var tareasActuales = this.ObtenerTodas();

            // Obtener tarea a completar
            var tarea = tareasActuales.Where(t => t.Id == id).FirstOrDefault();

            // Validar si existe
            if (tarea != null)
            {
                tareasActuales.Remove(tarea);

                _session[TareasNombreSesion] = tareasActuales;

                return true;
            }

            return false;
        }
    }
}