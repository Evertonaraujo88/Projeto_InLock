using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Interface respons�vel pelo reposit�rio UsuarioRepository
        /// Definir os m�todos que ser�o implementados pelo UsuarioRepository
        /// </summary>
        UsuarioDomain Login(string email, string senha);
    }
}