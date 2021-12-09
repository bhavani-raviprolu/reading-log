using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.DataAccess.Configurations;
using MySchool.ReadingLog.DataAccess.Extensions;
using MySchool.ReadingLog.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.DataAccess
{
    public class ReadingLogDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReadingLogDbContext(DbContextOptions<ReadingLogDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRead> BooksRead { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksConfiguration).Assembly);
        }

        public override int SaveChanges()
        {
            ApplyAuditing();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditing();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditing()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            var addedEntries = entries.Where(c => c.State == EntityState.Added).Select(c => c.Entity);
            var modifiedEntries = entries.Where(c => c.State == EntityState.Modified).Select(c => c.Entity);
            var user = this.httpContextAccessor.GetEmail();
            foreach (var entry in addedEntries.OfType<BaseEntity>())
            {
                entry.CreatedBy = user;
                entry.CreatedDate = System.DateTime.Now;
            }

            foreach (var entry in modifiedEntries.OfType<BaseEntity>())
            {
                entry.ModifiedBy = user;
                entry.ModifiedDate = System.DateTime.Now;
            }
        }
    }
}