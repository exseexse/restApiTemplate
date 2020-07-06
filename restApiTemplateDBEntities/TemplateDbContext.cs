
using Microsoft.EntityFrameworkCore;

namespace restApiTemplateDBEntities
{
    public abstract class EntityTemplateDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParentEntity>().Property(s => s.RowVersion).IsRowVersion();


            modelBuilder.Entity<ParentEntity>().HasMany(s => s.ChildEntity)
                .WithOne(e => e.ParentEntity).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SubClassEntity>().HasOne(s => s.ParentEntity)
            .WithOne(e => e.SubClassEntity).HasForeignKey<SubClassEntity>(f => f.parentFK).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParentEntity>().HasMany(s => s.FirstBranch)
            .WithOne(e => e.FirstBranchParent).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ParentEntity>().HasMany(s => s.SecondBranch)
            .WithOne(e => e.SecondBranchParent).OnDelete(DeleteBehavior.SetNull);
        }


        public virtual DbSet<ParentEntity> ParentEntity { get; set; }
        public virtual DbSet<ChildEntity> ChildEntity { get; set; }  
      

    }
}
