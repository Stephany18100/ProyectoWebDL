using ProyectoWebDL.Models.Entities;

namespace ProyectoWebDL.Services.IServices
{
    public interface IArticuloServices
    {
        public Task<List<Articulo>> GetArticulos();
        public Task<Articulo> GetByIdArticulo(int id);

        public Task<Articulo> CrearArticulo(Articulo i);
        public Task<Articulo> EditarArticulo(Articulo i);
        public bool EliminarArticulo(int id);
    }
}
