using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager20._01._22.Models;


namespace TaskManager20._01._22.Data
{
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            //1
            builder.ToTable("MyTasks");
            builder.HasKey(mt => mt.MyTaskId);
            builder.Property(mt => mt.MyTaskId)
                .HasColumnType("int");

            //2
            
            builder.Property(mt => mt.MyTaskTitle)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            //3

            builder.Property(mt => mt.MyTaskAbout)
                .IsRequired()
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            //4

            builder.Property(mt => mt.MyTaskDate)
                .IsRequired()
                .HasColumnType("date");

            //5

            builder.Property(mt => mt.MyTaskTerm)
                .IsRequired()
                .HasColumnType("int");

            //6

            builder.Property(mt => mt.CategoryId)
                .IsRequired()
                .HasColumnType("int");
            builder.HasOne(mt => mt.Category)
                .WithMany(c => c.MyTasks)
                .HasForeignKey(mt => mt.CategoryId);

            //7

            builder.Property(mt => mt.StatusId)
                .IsRequired()
                .HasColumnType("int");
            builder.HasOne(mt => mt.Status)
                .WithMany(s => s.MyTasks)
                .HasForeignKey(mt => mt.StatusId);

            //8

            builder.Property(mt => mt.UserId)
                .IsRequired()
                .HasColumnType("nvarchar(450)");
            builder.HasOne(mt => mt.User)
                .WithMany(au => au.MyTasks)
                .HasForeignKey(mt => mt.UserId);

        }
    }
}
