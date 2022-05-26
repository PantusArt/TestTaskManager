using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Data
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //1
            builder.ToTable("Categories");
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId)
                .HasColumnType("int");

            //2
            builder.HasIndex(c => c.CategoryName)
                .IsUnique();
            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
        }
    }
}
