using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV1401\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string Cadastro = "";
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string DeletarPorId = "";
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string SelectAll = "SELECT IdJogos, NomeJogo, Descricao, DataLancamento, Valor, IdEstudio FROM Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(con, stringConexao))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogosDomain Jogo = new JogosDomain
                        {
                            IdJogos = Convert.ToInt32(rdr["IdJogo"]),

                            NomeJogos = rdr["NomeJogo"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataNascimento"]),

                            Valor = rdr["Valor"].ToString(),
                        };
                            Jogo.Estudio.IdEstudio = Convert.ToInt32(rdr[0]);

                        ListarJogos.Add(Jogo);
                    }
                }
            }
            return ListarJogos;
        }
    }
}
