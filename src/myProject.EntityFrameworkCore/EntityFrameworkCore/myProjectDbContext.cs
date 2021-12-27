using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using myProject.Authorization.Roles;
using myProject.Authorization.Users;
using myProject.MultiTenancy;
using myProject.Data.Entities.Products;

namespace myProject.EntityFrameworkCore
{
    public class myProjectDbContext : AbpZeroDbContext<Tenant, Role, User, myProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; } //product

        public myProjectDbContext(DbContextOptions<myProjectDbContext> options)
            : base(options)
        {
        }
    }
}