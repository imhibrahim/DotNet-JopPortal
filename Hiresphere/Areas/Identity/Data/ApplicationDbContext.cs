using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiresphere.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<user>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Employee> Employee { get; set; }
     public DbSet<Job> Job { get; set; }
    public DbSet<Jobseeker> Jobseeker { get; set; }
    public DbSet<JobApplication> JobApplication { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new Userconfiguration());
    }
}

internal class Userconfiguration : IEntityTypeConfiguration<user>
{
    public void Configure(EntityTypeBuilder<user> builder)
    {
     
    }
}