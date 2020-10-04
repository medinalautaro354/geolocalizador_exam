using AdreaniExam.Repositories.EntityFramework.Configuration;
using AdreaniExam.Repositories.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdreaniExam.Repositories.EntityFramework
{
    public class AdreaniExamContext : DbContext
    {
        public DbSet<AddressRequest> AddressRequests { get; set; }
        public DbSet<AddressResult> AddressResults { get; set; }

        private static bool HasBeenMigrated = false;
        private static readonly object _lock = new object();
        private static void Migrate(AdreaniExamContext instance)
        {
            if (HasBeenMigrated) return;

            lock (_lock)
            {
                if (!HasBeenMigrated)
                {
                    instance.Database.Migrate();
                    HasBeenMigrated = true;
                }
            }
        }

        public AdreaniExamContext(DbContextOptions<AdreaniExamContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Migrate(this);
        }

        public async Task DropMigrate()
        {
            await Database.EnsureDeletedAsync();
            await Database.MigrateAsync();
        }

        public async Task Migrate()
        {
            await Database.MigrateAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressRequestConfiguration());
            modelBuilder.ApplyConfiguration(new AddressResultConfiguration());
        }
    }
}
