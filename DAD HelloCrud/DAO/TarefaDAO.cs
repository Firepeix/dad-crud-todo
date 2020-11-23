using DAD_HelloCrud.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAD_HelloCrud.DAO
{
    public class TarefaDAO : Conexao
    {
        public void Salvar(Tarefa tarefa)
        {
            try
            {
                Abrir();
                string query = "INSERT INTO tarefas (nome, dificuldade) VALUES (" +
                    "'" + tarefa.nome + "', " +
                    "'" + int.Parse(tarefa.dificuldade) + "'" +
                    ")";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public void Editar(Tarefa tarefa)
        {
            try
            {
                int feita = tarefa.feita ? 1 : 0;
                Abrir();
                String query = "UPDATE tarefas SET nome='"
                    + tarefa.nome + "', dificuldade='"
                    + int.Parse(tarefa.dificuldade) + "', feita="
                    + tarefa.feita + " WHERE id='" + tarefa.id + "'";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public void Deletar(int id)
        {
            try
            {
                Abrir();
                String query = "DELETE FROM tarefas where id = '" + id + "'";
                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public Tarefa BuscarTarefa(int id)
        {
            Tarefa tarefa = new Tarefa();

            try
            {
                Abrir();
                String query = "SELECT * FROM tarefas where id = '" + id + "'";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;

                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    tarefa.id = int.Parse(reader.GetString(0));
                    tarefa.nome = reader.GetString(1);
                    tarefa.dificuldade = reader.GetString(2);
                    tarefa.feita = reader.GetString(3) == "1";
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }

            return tarefa;
        }
        public List<Tarefa> Listar()
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            try
            {
                Abrir();
                String query = "SELECT * FROM tarefas";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;

                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Tarefa tarefa = new Tarefa();
                    tarefa.id = int.Parse(reader.GetString(0));
                    tarefa.nome = reader.GetString(1);
                    tarefa.dificuldade = reader.GetString(2);
                    tarefa.feita = reader.GetString(3) == "1";

                    tarefas.Add(tarefa);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }

            return tarefas;
        }
    }
}