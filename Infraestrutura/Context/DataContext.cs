using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>().ToTable("Todo");
            builder.Entity<TodoItem>().Property(x => x.Id);
            builder.Entity<TodoItem>().Property(x => x.User).HasColumnType("varchar(120)");
            builder.Entity<TodoItem>().Property(x => x.Title).HasColumnType("varchar(160)");
            builder.Entity<TodoItem>().Property(x => x.Done);
            builder.Entity<TodoItem>().Property(x => x.Date);
            builder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}
