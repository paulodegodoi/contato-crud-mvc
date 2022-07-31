using Microsoft.AspNetCore.Mvc;
using NovoMVC.Models;
using NovoMVC.Repositorio;

namespace NovoMVC.Controllers
{
	public class ContatoController : Controller
	{
		private readonly IContatoRepositorio _contatoRepositorio;
		public ContatoController(IContatoRepositorio contatoRepositorio)
		{
			_contatoRepositorio = contatoRepositorio;
		}
		public IActionResult Index()
		{
			List<ContatoModel> contacts = _contatoRepositorio.GetAllRegisters();
			return View(contacts);
		}
		public IActionResult CreateContact()
		{
			return View();
		}
		public IActionResult EditContact(int id)
		{
			ContatoModel contact = _contatoRepositorio.ListId(id);
			return View(contact);
		}
		public IActionResult DeleteConfirm(int id)
		{
			ContatoModel contact = _contatoRepositorio.ListId(id);

			return View(contact);
		}

		public IActionResult DeleteContact(int id)
		{
			try
			{
				bool deleted = _contatoRepositorio.Delete(id);
				if (deleted)
				{
					TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
				}
				else
				{
					TempData["MensagemErro"] = "Não foi possível apagar o contato!";
				}
				return RedirectToAction("Index");
			}
			catch (System.Exception erro)
			{
				TempData["MensagemSucesso"] = $"Contato cadastrado com sucesso! Mais detalhes do erro: {erro.Message}";

				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult CreateContact(ContatoModel contact)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_contatoRepositorio.AddContact(contact);
					TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
					return RedirectToAction("Index");
				}

				return View(contact);
			}
			catch (System.Exception erro)
			{
				TempData["MensagemErro"] = $"Ops, ocorreu um erro ao cadastrar o contato! Detalhe do erro: {erro.Message}";

				return RedirectToAction("Index");
			}

		}
		[HttpPost]
		public IActionResult EditContact(ContatoModel contact)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_contatoRepositorio.UpdateContact(contact);
					TempData["MensagemSucesso"] = "O contato foi editado com sucesso!";
					return RedirectToAction("Index");
				}

				return View("EditContact", contact);
			}
			catch (System.Exception erro)
			{
				TempData["MensagemErro"] = $"Não foi possível editar o contato! Detalhe do erro: {erro.Message}";

				return RedirectToAction("Index");

			}
		}
	}
}
