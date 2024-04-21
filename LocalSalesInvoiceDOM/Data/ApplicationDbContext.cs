﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalSalesInvoiceDOM.Models;

namespace LocalSalesInvoiceDOM.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasIndex(c => c.CountryCode).IsUnique(true);
            builder.Entity<State>().HasIndex(s => s.StateCode).IsUnique(true);
            builder.Entity<City>().HasIndex(c => c.CityCode).IsUnique(true);
            builder.Entity<UserType>().HasIndex(ut => ut.Name).IsUnique(true);
            builder.Entity<User>().HasIndex(u => new {u.EmailId, u.UIDNumber}).IsUnique(true);
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
