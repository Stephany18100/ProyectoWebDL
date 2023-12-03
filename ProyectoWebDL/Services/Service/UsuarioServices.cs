using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;
using System.Data;

namespace ProyectoWebDL.Services.Service
{
    public class UsuarioServices: IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            try
            {

                return await _context.Usuarios.Include(y=> y.Roles).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Usuario> GetByIdUsuario(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PKUsuario == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Usuario> CrearUsuario(Usuario i)
        {
            try
            {
                Usuario request = new Usuario()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    UserName = i.UserName,
                    Password = i.Password,
                    FkRol = i.FkRol,
                };

                var result = await _context.Usuarios.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Usuario> EditarUsuario(Usuario i)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(i.PKUsuario);

                    usuario.Nombre = i.Nombre;
                    usuario.Apellido = i.Apellido;
                    usuario.UserName = i.UserName;
                    usuario.Password = i.Password;
                    usuario.FkRol = i.FkRol;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);

                if (usuario != null)
                {
                    var res = _context.Usuarios.Remove(usuario);
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
