using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.gerente
{
    public class GerenteDados : ConexaoSqlServer, GerenteInterface
    {
        public void Insert(Gerente gerente)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();

                //instrucao a ser executada
                string sql = "INSERT INTO Gerente (Nr_Gerente, Nm_Gerente) VALUES (@codigo, @nome);";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigo", SqlDbType.Int);
                cmd.Parameters["@codigo"].Value = gerente.Codigo;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = gerente.Nome;

                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();

                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir gerente: " + ex.Message);
            }
        }

        public void Update(Gerente gerente)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();

                //instrucao a ser executada
                string sql = "UPDATE Gerente SET Nr_Gerente = @codigo, Nm_Gerente = @nome WHERE Nr_Gerente = @codigo;";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigo", SqlDbType.Int);
                cmd.Parameters["@codigo"].Value = gerente.Codigo;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = gerente.Nome;

                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar gerente: " + ex.Message);
            }
        }

        public void Delete(Gerente gerente)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();

                //instrucao a ser executada
                string sql = "DELETE FROM Gerente where Nr_Gerente = @codigo;";

                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@codigo", SqlDbType.Int);
                cmd.Parameters["@codigo"].Value = gerente.Codigo;

                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();

                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover gerente: " + ex.Message);
            }
        }

        public bool VerificaDuplicidade(Gerente gerente)
        {
            bool retorno = false;

            try
            {
                //abrir a conexão
                this.abrirConexao();

                //instrucao a ser executada
                string sql = "SELECT Nr_Gerente, Nm_Gerente FROM Gerente WHERE Nr_Gerente = @codigo;";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.Add("@codigo", SqlDbType.Int);
                cmd.Parameters["@codigo"].Value = gerente.Codigo;

                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();

                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }

                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();

                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar duplicidade: " + ex.Message);
            }

            return retorno;
        }

        public List<Gerente> Select(Gerente filtro)
        {
            List<Gerente> retorno = new List<Gerente>();

            try
            {
                //abrir a conexão
                this.abrirConexao();
                 
                //instrucao a ser executada
                string sql = "SELECT Nr_Gerente, Nm_Gerente FROM Gerente WHERE Nr_Gerente = Nr_Gerente ";

                //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
                if (filtro.Codigo > 0)
                {
                    sql += " AND Nr_Gerente = @codigo";
                }

                //se foi passada um nome válido, este nome entrará como critério de filtro
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " AND Nm_Gerente LIKE '%@nome%'";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
                if (filtro.Codigo> 0)
                {
                    cmd.Parameters.Add("@codigo", SqlDbType.Int);
                    cmd.Parameters["@codigo"].Value = filtro.Codigo;
                }
                //se foi passada um nome válido, este nome entrará como critério de filtro
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = filtro.Nome;

                }
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Gerente gerente = new Gerente();

                    //acessando os valores das colunas do resultado
                    gerente.Codigo = DbReader.GetInt32(DbReader.GetOrdinal("numero"));
                    gerente.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));

                    retorno.Add(gerente);
                }

                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();

                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar gerente: " + ex.Message);
            }

            return retorno;
        }
    }
}
