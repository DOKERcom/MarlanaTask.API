using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Entities;

namespace Task.DAL.DbContexts
{
    public class MarlanaTaskDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<TasksBlockEntity> TasksBlocks { get; set; }

        public MarlanaTaskDbContext(DbContextOptions<MarlanaTaskDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
