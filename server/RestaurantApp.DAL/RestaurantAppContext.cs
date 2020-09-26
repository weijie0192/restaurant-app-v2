﻿using Microsoft.EntityFrameworkCore;
using RestaurantApp.DAL.Models;
using System;

namespace RestaurantApp.DAL
{
    public class RestaurantAppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
        public DbSet<OrderedItemMenuOptionItem> OrderedItemMenuOptionItems { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuEntry> MenuEntries { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemMenuOptionGroup> MenuItemMenuOptionGroups { get; set; }
        public DbSet<MenuOptionGroup> MenuOptionGroups { get; set; }
        public DbSet<MenuOptionItem> MenuOptionItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("BloggingDatabase");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemMenuOptionGroup>()
                .HasKey(x => new { x.MenuItemID, x.MenuOptionGroupID });

            modelBuilder.Entity<MenuItemMenuOptionGroup>()
                .HasOne(x => x.MenuOptionGroup)
                .WithMany(y => y.MenuItemMenuOptionGroups)
                .HasForeignKey(x => x.MenuOptionGroupID);

            modelBuilder.Entity<MenuItemMenuOptionGroup>()
                   .HasOne(x => x.MenuItem)
                   .WithMany(y => y.MenuItemMenuOptionGroups)
                   .HasForeignKey(x => x.MenuItemID);

            modelBuilder.Entity<OrderedItemMenuOptionItem>()
                .HasKey(x => new { x.MenuOptionItemID, x.OrderedItemID });

            modelBuilder.Entity<OrderedItemMenuOptionItem>()
                .HasOne(x => x.OrderedItem)
                .WithMany(y => y.OrderedItemMenuOptionItems)
                .HasForeignKey(x => x.OrderedItemID);

            modelBuilder.Entity<OrderedItemMenuOptionItem>()
                   .HasOne(x => x.MenuOptionItem)
                   .WithMany(y => y.OrderedItemMenuOptionItems)
                   .HasForeignKey(x => x.MenuOptionItemID);
        }
    }
}
