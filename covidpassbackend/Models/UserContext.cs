﻿using Microsoft.EntityFrameworkCore;

namespace covidpassbackend.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }

    }
}