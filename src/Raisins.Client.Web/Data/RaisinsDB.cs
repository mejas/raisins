﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Raisins.Client.Web.Models;

namespace Raisins.Client.Web.Data
{
    public class RaisinsDB : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WinnerLog> WinnerLogs { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}