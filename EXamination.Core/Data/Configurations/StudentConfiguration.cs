﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EXamination.Core.Data;
using EXamination.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace EXamination.Core.Data.Configurations
{
    public partial class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Student> entity);
    }
}
