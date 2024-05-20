using AgendaApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Contexts;
/// <summary>
/// Classe de contexto para realizarmos o acesso ao BD
/// </summary>
public class DataContext : DbContext
{
    /// <summary>
    /// método para configurar o tipo de conexão com o BD
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AgendaAppBD;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TarefaMap());
    }
}
