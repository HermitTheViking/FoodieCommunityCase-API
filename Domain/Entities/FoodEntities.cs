using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace FoodieCommunityCase.Domain.Entities
{
    public class FoodEntities : DbContext
    {
        public FoodEntities(DbContextOptions<FoodEntities> options) : base(options)
        {
        }

        public DbSet<Recip> Recipes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<NutrientInfo> NutrientInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
