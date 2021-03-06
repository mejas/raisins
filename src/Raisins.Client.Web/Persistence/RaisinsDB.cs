﻿using Raisins.Client.Web.Models;
using System.Data.Entity;

namespace Raisins.Client.Web.Persistence
{
    public class RaisinsDB : DbContext
    {

        public RaisinsDB()
            : base("Default")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasRequired(p => p.Currency).WithMany().HasForeignKey(p => p.CurrencyID);
            modelBuilder.Entity<Payment>().HasRequired(p => p.Beneficiary).WithMany().HasForeignKey(p => p.BeneficiaryID);
            modelBuilder.Entity<Payment>().HasRequired(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedByID);
            modelBuilder.Entity<Payment>().HasOptional(p => p.AuditedBy).WithMany().HasForeignKey(p => p.AuditedByID);
            modelBuilder.Entity<Payment>().HasOptional(p => p.Executive).WithMany().HasForeignKey(p => p.ExecutiveID);

            modelBuilder.Entity<Account>().HasMany(a => a.Roles).WithMany();
            modelBuilder.Entity<Account>().HasRequired(a => a.Profile).WithMany().HasForeignKey(a => a.AccountProfileID);

            modelBuilder.Entity<AccountProfile>().HasMany(ap => ap.Currencies).WithMany();
            modelBuilder.Entity<AccountProfile>().HasMany(ap => ap.Beneficiaries).WithMany();

            modelBuilder.Entity<Activity>().HasMany(a => a.Roles).WithMany();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<AccountProfile> Profiles { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MailQueue> MailQueues { get; set; }

    }
}