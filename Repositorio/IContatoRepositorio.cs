using NovoMVC.Models;

namespace NovoMVC.Repositorio
{
	public interface IContatoRepositorio
	{
		ContatoModel ListId(int id);
		List<ContatoModel> GetAllRegisters();
		ContatoModel AddContact(ContatoModel contact);
		ContatoModel UpdateContact(ContatoModel contact);
		bool Delete(int id);
	}
}
