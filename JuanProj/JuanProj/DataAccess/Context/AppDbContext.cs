﻿
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Contex;

public class AppDbContext:IdentityDbContext <AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SlideItem> SlideItems { get; set; } = null!;

}
