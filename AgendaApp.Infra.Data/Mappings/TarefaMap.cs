using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApp.Infra.Data.Mappings;

/// <summary>
/// Classe de mapeamento para a entidade Tarefa
/// </summary>
public class TarefaMap : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        //chave primária
        builder.HasKey(x => x.Id);
        
        //mapeamento dos campos
        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.DataHora).IsRequired();

        builder.Property(x => x.Prioridade).IsRequired();

        builder.Property(x => x.CadastradoEm).IsRequired();

        builder.Property(x => x.DataHora).IsRequired();

        builder.Property(x => x.UltimaAtualizacaoEm).IsRequired();

        builder.Property(x => x.Ativo).IsRequired();

    }
}
