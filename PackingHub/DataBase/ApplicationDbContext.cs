using Microsoft.EntityFrameworkCore;
using PackingHub.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<PackingHub.Models.Action> Actions { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Container> Containers { get; set; }

    public DbSet<CargoRestriction> CargoRestrictions { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<PackingHub.Models.Route> Routes { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Transport> Transports { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
}
