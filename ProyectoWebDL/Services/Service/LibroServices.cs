using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;

namespace ProyectoWebDL.Services.Service
{
    public class LibroServices: ILibroServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public LibroServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Libro>> GetLibros()
        {
            try
            {

                return await _context.Libros.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Libro> GetByIdLibro(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Libro response = await _context.Libros.FirstOrDefaultAsync(x => x.PkLibro == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Libro> CrearLibro(Libro i)
        {
            try
            {
                Libro request = new Libro()
                {
                    Titulo = i.Titulo,
                    Descripcion = i.Descripcion,
                    Images = i.Images,
                    Activo = true
                };
                //Con esto se manda a la bd de forma asincrona
                var result = await _context.Libros.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Libro> EditarLibro(Libro i)
        {
            try
            {

                Libro libro = _context.Libros.Find(i.PkLibro);

                libro.Titulo = i.Titulo;
                libro.Descripcion = i.Descripcion;
                //libro.Images = i.Images;

                _context.Entry(libro).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return libro;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarLibro(int id)
        {
            try
            {
                Libro libro = _context.Libros.Find(id);

                if (libro != null)
                {
                    var res = _context.Libros.Remove(libro);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
