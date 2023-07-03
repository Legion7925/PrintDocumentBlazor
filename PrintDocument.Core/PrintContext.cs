﻿using Microsoft.EntityFrameworkCore;
using PrintDocument.Core.Entities;

namespace PrintDocument.Core;

public class PrintContext : DbContext
{
    public PrintContext()
    {
        
    }

    public PrintContext(DbContextOptions<PrintContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Document> Documents { get; set; }
}
