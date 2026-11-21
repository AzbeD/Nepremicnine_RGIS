using Microsoft.EntityFrameworkCore;

public class BazaContext : DbContext
{
    public BazaContext(DbContextOptions<BazaContext> options) : base(options){}


    public DbSet<Uporabnik> Uporabniki { get; set; }
    public DbSet<Oglas> Oglasi { get; set; }
    public DbSet<Povprasevanje> Povprasevanja { get; set; }
    public DbSet<Priljubljen> Priljubljeni { get; set; }
    public DbSet<ShranjenoIskanje> ShranjenaIskanja { get; set; }
    public DbSet<Ocena> Ocene { get; set; }
    public DbSet<BlokiranUporabnik> BlokiraniUporabniki { get; set; }
    public DbSet<Prijava> Prijave { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=nepremicnine.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Uporabnik>()
        .HasIndex(u => u.UporabniskoIme)
        .IsUnique();

    modelBuilder.Entity<Priljubljen>()
        .HasKey(p => new { p.UporabnikId, p.OglasId });

    modelBuilder.Entity<BlokiranUporabnik>()
        .HasKey(b => new { b.BlokerId, b.BlokiranId });

    modelBuilder.Entity<BlokiranUporabnik>()
        .HasOne(b => b.Bloker).WithMany()
        .HasForeignKey(b => b.BlokerId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<BlokiranUporabnik>()
        .HasOne(b => b.Blokiran).WithMany()
        .HasForeignKey(b => b.BlokiranId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Ocena>()
        .HasOne(o => o.Avtor).WithMany()
        .HasForeignKey(o => o.AvtorId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Ocena>()
        .HasOne(o => o.OcenjeniUporabnik).WithMany()
        .HasForeignKey(o => o.OcenjeniUporabnikId)
        .OnDelete(DeleteBehavior.Restrict);
    }

}