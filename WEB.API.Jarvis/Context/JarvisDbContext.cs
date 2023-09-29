using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Models;

namespace WEB.API.Jarvis.Context;

public partial class JarvisDbContext : IdentityDbContext<IdentityUser>
{
   
    public JarvisDbContext(DbContextOptions<JarvisDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    
}
