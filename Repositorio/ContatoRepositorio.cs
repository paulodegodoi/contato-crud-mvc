using Microsoft.AspNetCore.Mvc;
using NovoMVC.Data;
using NovoMVC.Models;

namespace NovoMVC.Repositorio
{
	public class ContatoRepositorio : IContatoRepositorio
	{
		private readonly BancoContext _bancoContext;

		public ContatoRepositorio(BancoContext bancoContext)
		{
			_bancoContext = bancoContext;
		}
		public List<ContatoModel> GetAllRegisters()
		{
			return _bancoContext.Contatos.ToList();
		}

		public ContatoModel ListId(int id)
		{
			return _bancoContext.Contatos.FirstOrDefault(user => user.Id == id);
		}
		public ContatoModel AddContact(ContatoModel contact)
		{
			_bancoContext.Contatos.Add(contact);
			_bancoContext.SaveChanges();
			return contact;
		}
		public ContatoModel UpdateContact(ContatoModel contact)
		{
			ContatoModel contactDB = ListId(contact.Id);
			if (contactDB == null) throw new Exception("Houve um erro na atualização do contato!");

			contactDB.Nome = contact.Nome; 
			contactDB.Email = contact.Email; 
			contactDB.Contato = contact.Contato;

			_bancoContext.Contatos.Update(contactDB);
			_bancoContext.SaveChanges();
			return contactDB;
		}

		bool IContatoRepositorio.Delete(int id)
		{
			ContatoModel contactDB = ListId(id);
			if (contactDB == null) throw new Exception("Houve um erro ao deletar o contato!");

			_bancoContext.Contatos.Remove(contactDB);
			_bancoContext.SaveChanges();
			return true;
		}

	}
}
