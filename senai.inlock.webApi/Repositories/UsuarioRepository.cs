using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conex�o com o banco de dados que recebe os seguintes par�metros:
        /// Data Source: Nome do servidor 
        /// Initial Catalog: Nome do banco de dados
        /// Autentifica��o:
        ///     -Windows: Integrated Security = true
        ///     -SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = DESKTOP-T9B12O6; Initial Catalog = inlock_games; User Id = sa; Pwd = Info@134";

        /// <summary>
        /// Autenticar o usu�rio com seu email e senha, usando login do objeto usuario.
        /// </summary>
        /// <param name="email">Um string representando o email do usu�rio.</param>
        /// <param name="senha">Um string representando a senha do usu�rio</param>
        /// <returns></returns>
        public UsuarioDomain Login(string email, string senha)
        {
            //instanciando string de conex�o
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario, IdTipoUsuario, Email FROM Usuario WHERE Email = @Email AND Senha = @Senha";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Email = rdr["Email"].ToString()
                        };
                        return usuario;

                    }
                    return null;
                }
            }
        }
    }
}