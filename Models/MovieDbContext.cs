using Microsoft.EntityFrameworkCore;

namespace MovieWebsite.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WatchHistory> WatchHistories { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình khóa chính cho bảng MovieGenre
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieID, mg.GenreID });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreID)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa chính cho bảng MovieCategory
            modelBuilder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.MovieID, mc.CategoryID });

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình bảng User và Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình các mối quan hệ khác
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WatchHistory>()
                .HasOne(w => w.User)
                .WithMany(u => u.WatchHistories)
                .HasForeignKey(w => w.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WatchHistory>()
                .HasOne(w => w.Movie)
                .WithMany(m => m.WatchHistories)
                .HasForeignKey(w => w.MovieID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
