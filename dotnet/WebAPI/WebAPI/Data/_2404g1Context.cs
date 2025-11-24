using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

public partial class _2404g1Context : DbContext
{
    public _2404g1Context()
    {
    }

    public _2404g1Context(DbContextOptions<_2404g1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07D8EB3212");

            entity.Property(e => e.ProdDesc).HasColumnType("text");
            entity.Property(e => e.ProdName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
