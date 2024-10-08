﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EXamination.Core.Data.Configurations;
using EXamination.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
#nullable enable

namespace EXamination.Core.Data;

public partial class ExaminationContext : DbContext
{
    public ExaminationContext()
    {
    }

    public ExaminationContext(DbContextOptions<ExaminationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentExam> StudentExams { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.ExamConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.StudentExamConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
