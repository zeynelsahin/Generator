﻿using System.Collections.Generic;
using System.Text;
using Generator.Entities;
using Microsoft.EntityFrameworkCore;

namespace Generator.DataAccess.EntitiyFramework
{
    public class GeneratorContext : DbContext
    {
        public DbSet<ObjectEntity> Objects { get; set; }
        public DbSet<ObjectResult> ObjectResults { get; set; }
        public DbSet<ObjectParameter> ObjectParameters{ get; set; }

        //public DbSet<ObjectParameter> Type { get; set; }
        //public DbSet<ObjectResult> ObjectResults { get; set; }
        //public DbSet<ServiceMethod> ServiceMethods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<ObjectResult>()
                .HasKey(c => new {c.ObjectId,c.ProfileId,c.ResultId});
            modelBuilder.Entity<ObjectEntity>()
                .HasKey(c => new { c.ObjectId, c.ProfileId, c.SchemaName });
            modelBuilder.HasDefaultSchema("CGEN");
            modelBuilder.Entity<ObjectParameter>()
                .HasKey(c=>new {c.ObjectId,c.ProfileId,c.ParameterId});

            //TABLE NAME
            modelBuilder.Entity<ObjectEntity>().ToTable("OBJECTS");
            modelBuilder.Entity<ObjectResult>().ToTable("OBJECT_RESULTS");
            modelBuilder.Entity<ObjectParameter>().ToTable("OBJECT_PARAMETERS");


            //ObjectParameter
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.ObjectId).HasColumnName("OBJECT_ID");
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.ProfileId).HasColumnName("PROFILE_ID");
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.ParameterId).HasColumnName("PARAMETER_ID");
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.DataType).HasColumnName("DATA_TYPE");
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.InputOutput).HasColumnName("INPUT_OUTPUT");
            modelBuilder.Entity<ObjectParameter>().Property(s=>s.NullableFlag).HasColumnName("NULLABLE_FLAG");
            //ObjectResult
            modelBuilder.Entity<ObjectResult>().Property(s => s.ObjectId).HasColumnName("OBJECT_ID");
            modelBuilder.Entity<ObjectResult>().Property(s => s.ProfileId).HasColumnName("PROFILE_ID");
            modelBuilder.Entity<ObjectResult>().Property(s => s.ResultId).HasColumnName("RESULT_ID");
            modelBuilder.Entity<ObjectResult>().Property(s => s.DataType).HasColumnName("DATA_TYPE");
            modelBuilder.Entity<ObjectResult>().Property(s => s.NullableFlag).HasColumnName("NULLABLE_FLAG");
            modelBuilder.Entity<ObjectResult>().Property(s => s.ObjectId).HasColumnName("OBJECT_ID");
            //Object
            modelBuilder.Entity<ObjectEntity>().Property(s => s.ValidFlag).HasColumnName("VALID_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.GenerateUIFlag).HasColumnName("GENERATE_UI_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.UIPathSuffix).HasColumnName("UI_PATH_SUFFIX");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.ObjectId).HasColumnName("OBJECT_ID");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.ObjectType).HasColumnName("OBJECT_TYPE");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.ProfileId).HasColumnName("PROFILE_ID");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.RepositoryName).HasColumnName("REPOSITORY_NAME");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.SchemaName).HasColumnName("SCHEMA_NAME");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.OracleSchemaName).HasColumnName("ORACLE_SCHEMA_NAME");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.Text).HasColumnName("TEXT");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.OracleText).HasColumnName("ORACLE_TEXT");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.ResultCollectionFlag).HasColumnName("RESULT_COLLECTION_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.SpcallFlag).HasColumnName("SPCALL_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.IgnoreDefaultColumnsFlag).HasColumnName("IGNORE_DEFAULT_COLUMNS_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.LocalTransactionFlag).HasColumnName("LOCAL_TRANSACTION_FLAG");
            modelBuilder.Entity<ObjectEntity>().Property(s => s.CustomPagedFlag).HasColumnName("CUSTOM_PAGED_FLAG");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=datadev;Database=EVEREST_CGEN;Integrated Security=True");
        }
    }
}