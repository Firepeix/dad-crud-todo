using DAD_HelloCrud.DAO;
using DAD_HelloCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAD_HelloCrud.Controllers
{
    public class TarefasController : Controller
    {
        public ActionResult Index()
        {
            TarefaDAO tarefasDatabase = new TarefaDAO();
            List<Tarefa> tarefas = tarefasDatabase.Listar();

            return View(tarefas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TarefaDAO tarefasDatabase = new TarefaDAO();
                    tarefasDatabase.Salvar(tarefa);

                    return Sucesso(tarefa);
                }
                catch (Exception ex)
                {
                    return View(ex.ToString());
                }
            }
            else
            {
                return View(tarefa);
            }
        }

        public ActionResult Edit(int id)
        {
            Tarefa tarefa = new Tarefa();

            try
            {
                TarefaDAO tarefasDatabase = new TarefaDAO();
                tarefa = tarefasDatabase.BuscarTarefa(id);
            }
            catch
            {
                return View();
            }

            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Edit(int id, Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TarefaDAO tarefasDatabase = new TarefaDAO();
                    tarefasDatabase.Editar(tarefa);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.ToString());
                }
            }
            else
            {
                return View(tarefa);
            }
        }

        public ActionResult DoneTarefa(int id)
        {
            try
            {
                TarefaDAO tarefasDatabase = new TarefaDAO();
                Tarefa tarefa = tarefasDatabase.BuscarTarefa(id);
                tarefa.feita = true;

                tarefasDatabase.Editar(tarefa);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.ToString());
            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            try
            {
                TarefaDAO tarefasDatabase = new TarefaDAO();
                tarefasDatabase.Deletar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Sucesso(Tarefa tarefa)
        {
            return View("Sucesso", tarefa);
        }
    }
}