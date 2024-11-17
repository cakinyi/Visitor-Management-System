using System;
using Microsoft.EntityFrameworkCore;
using VisitorManagement.Models;

namespace VisitorManagement.data;

public class InventoryContextt: DbContext
{
   public InventoryContextt(DbContextOptions<InventoryContextt> options):base(options)
   {
    
   }
   public DbSet<Products> Products {get;set;}
   public DbSet<User> User{get; set;}
   public DbSet<Visitor> Visitor{get; set;}
}
