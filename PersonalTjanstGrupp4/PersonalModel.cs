namespace PersonalTjanstGrupp4
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonalModel : DbContext
    {
        public PersonalModel()
            : base("name=PersonalModel")
        {
        }

        public virtual DbSet<Personal> Personal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal>()
                .Property(e => e.Anvandarnamn)
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
                .IsFixedLength();
        }
    }
}
