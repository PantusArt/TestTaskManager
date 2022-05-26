using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager20._01._22.Models;


namespace TaskManager20._01._22.Data
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            //1
            builder.ToTable("Statuses");
            builder.HasKey(s => s.StatusId);
            builder.Property(s => s.StatusId)
                .HasColumnType("int");

            //2
            builder.HasIndex(s => s.StatusName)
                .IsUnique();
            builder.Property(s => s.StatusName)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
        }
    }
}
