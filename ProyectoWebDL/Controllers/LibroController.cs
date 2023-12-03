using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;
using ProyectoWebDL.Services.Service;

namespace ProyectoWebDL.Controllers
{
    public class LibroController : Controller
    {
        //Constructor para el uso de base de datos
        private readonly ILibroServices _libroServices;
        public LibroController(ILibroServices libroServices)
        {
            _libroServices = libroServices;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los articulos para que se muestre al abrir la vista

                return View(await _libroServices.GetLibros());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Libro request)
        {
            try
            {
                var response = _libroServices.CrearLibro(request);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _libroServices.GetByIdLibro(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Libro request)
        {
            var response = _libroServices.EditarLibro(request);
            //Esta funcion return sirve para volver al index despues de la accion
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _libroServices.EliminarLibro(id);
            if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }
        }
    }
}
