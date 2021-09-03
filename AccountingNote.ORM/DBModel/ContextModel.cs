using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AccountingNote.ORM.DBModel
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<UserInfor> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfor>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfor>()
                .Property(e => e.PWD)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfor>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);
        }
    }
}
