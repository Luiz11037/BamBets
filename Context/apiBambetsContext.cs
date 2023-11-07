using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiBambets.Model;

namespace apiBambets.Context;

public class apiBambetsContext : DbContext
{
    public apiBambetsContext(DbContextOptions options) : base(options) {}

    public DbSet<Aposta>? Apostas {get; set;}

    public DbSet<Apostador>? Apostadores {get; set;}
    public DbSet<Jogo>? Jogos {get; set;}
}