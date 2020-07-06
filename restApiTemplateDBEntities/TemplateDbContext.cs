
using Microsoft.EntityFrameworkCore;

namespace restApiTemplateDBEntities
{
    public abstract class EntityTemplateDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParentEntity>().HasMany(s => s.ChildEntity)
                .WithOne(e => e.ParentEntity).OnDelete(DeleteBehavior.Cascade);
        }
        public virtual DbSet<ParentEntity> ParentEntity { get; set; }
        public virtual DbSet<ChildEntity> ChildEntity { get; set; }  
      

    }
}
