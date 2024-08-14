using System;
using Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence;

public class ApplicationDbContext:DbContext
{
    public DbSet<CustomerModel> Customers => Set<CustomerModel>();
    public DbSet<EventModel> Events => Set<EventModel>();
    public DbSet<TicketModel> Tickets => Set<TicketModel>();
    
    public string DbPath { get; }

    public ApplicationDbContext():base()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ticket.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    }
}

