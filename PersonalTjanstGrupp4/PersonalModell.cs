namespace PersonalTjanstGrupp4
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonalModell : DbContext
    {
        public PersonalModell()
            : base("name=PersonalModell")
        {
        }

        public virtual DbSet<Personal> Personal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal>()
                .Property(e => e.AnvandarNamn)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Losenord)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Namn)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Efternamn)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Roll)
                .IsUnicode(false);
        }
    }
}
