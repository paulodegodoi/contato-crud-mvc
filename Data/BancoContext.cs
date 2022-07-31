using Microsoft.EntityFrameworkCore;
using NovoMVC.Models;

namespace NovoMVC.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : base(options)
		{

		}

		public DbSet<ContatoModel> Contatos { get; set; }
	}
}
