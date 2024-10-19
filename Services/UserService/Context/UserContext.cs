﻿using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
