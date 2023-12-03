using ProyectoWebDL.Models.Entities;

namespace ProyectoWebDL.Services.IServices
{
    public interface ILibroServices
    {
        public Task<List<Libro>> GetLibros();
        public Task<Libro> GetByIdLibro(int id);

        public Task<Libro> CrearLibro(Libro i);
        public Task<Libro> EditarLibro(Libro i);
        public bool EliminarLibro(int id);
    }
}
