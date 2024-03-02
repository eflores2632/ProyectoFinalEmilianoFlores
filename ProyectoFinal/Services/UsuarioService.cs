using IntegrandoApi.Database;
using IntegrandoApi.Models;
namespace IntegrandoApi.Services
{
    public class UsuarioService
    {
        private UsuarioData Udata;
        public UsuarioService(UsuarioData udata)
        {
            this.Udata = udata;
        }
        public Usuario ObternerUsuariaporUsuarioContrasena(string usuario, string contrasena)
        {
            List<Usuario> usuarios = this.Udata.ListarUsuarios();

            Usuario? user = usuarios.Find(u => u.NombreUsuario == usuario && u.Contrasena == contrasena);
            if (user is null) { throw new Exception("Usuario no encontrado"); }
            return user;
        }
        public Usuario ObtenerUsuario(string nombreusuario)
        {
            return this.Udata.ObtenerUsuario(nombreusuario);
        }
        public List<Usuario> ListarUsuarios()
        {
            return this.Udata.ListarUsuarios();
        }
        public bool CrearUsuario(Usuario user)
        {
            return this.Udata.CrearUsuario(user);
        }
        public bool ModificarUsuario(int id, Usuario user)
        {
            return this.Udata.ModificarUsuario(id, user);
        }
        public bool EliminarUsuario(int id)
        {
            return this.Udata.EliminarUsuario(id);
        }
    }
}
