using ChallengeLocaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeLocaweb.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<EmailModel> Emails { get; set; }
        public virtual DbSet<PreferenciaModel> Preferencias { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<ContatoModel> Contatos { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TABELA EMAIL
            modelBuilder.Entity<EmailModel>(entity =>
            {
                entity.ToTable("Email");
                entity.HasKey( e => e.Id);
                entity.Property( e => e.Remetente).IsRequired();
                entity.Property( e => e.Destinatario);
                entity.Property(e => e.Assunto);
                entity.Property(e => e.Texto).IsRequired();
                entity.Property(e => e.DataEnvio).HasColumnType("date");
                entity.Property(e => e.VerificadorSpam).IsRequired();
            });

            //TABELA PREFERENCIAS
            modelBuilder.Entity<PreferenciaModel>(entity =>
            {
                entity.ToTable("Preferencias");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tema);
                entity.Property(e => e.Cor);
                entity.Property(e => e.Categoria);
                entity.Property(e => e.Etiqueta);

                entity.HasOne(e => e.Usuario)
                    .WithMany()
                    .HasForeignKey(e => e.UsuarioID);
            });

            //TABELA USUARIOS
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Sobrenome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Senha).IsRequired();
                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.HasOne(e => e.Preferencia)
                    .WithMany()
                    .HasForeignKey(e => e.PreferenciaId); 
            });

            //TABELA CONTATOS
            modelBuilder.Entity<ContatoModel>(entity =>
            {
                entity.ToTable("Contato");
                entity.HasKey(e => e.IdContato);
                entity.Property(e => e.NomeCont).IsRequired();
                entity.Property(e => e.NumeroCont).IsRequired();
                entity.Property(e => e.EmailCont).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
