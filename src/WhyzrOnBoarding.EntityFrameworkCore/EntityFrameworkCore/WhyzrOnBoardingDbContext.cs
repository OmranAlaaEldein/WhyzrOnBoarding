﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using WhyzrOnBoarding.Products;

namespace WhyzrOnBoarding.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class WhyzrOnBoardingDbContext : 
        AbpDbContext<WhyzrOnBoardingDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion
        
        public DbSet<Product> Products { set; get; }
        public DbSet<Variant> Variants { set; get; }


        public WhyzrOnBoardingDbContext(DbContextOptions<WhyzrOnBoardingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            builder.Entity<Product>(b =>
            {
                b.ToTable(WhyzrOnBoardingConsts.DbTablePrefix + "Products", WhyzrOnBoardingConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(ProductsConst.MaxNameLength);
                b.HasIndex(x => x.Name);
                b.HasMany<Variant>(g => g.variants).WithOne(x => x.product).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Variant>(b =>
            {
                b.ToTable(WhyzrOnBoardingConsts.DbTablePrefix + "Variants", WhyzrOnBoardingConsts.DbSchema);
                b.ConfigureByConvention();
                //name max
                b.Property(x => x.ValueOPtionA).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionA1).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionA2).HasMaxLength(ProductsConst.MaxVariantnLength);
                
                b.Property(x => x.ValueOPtionB).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionB1).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionB2).HasMaxLength(ProductsConst.MaxVariantnLength);
                
                b.Property(x => x.ValueOPtionC).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionC1).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionC2).HasMaxLength(ProductsConst.MaxVariantnLength);
                
                b.Property(x => x.ValueOPtionD).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionD1).HasMaxLength(ProductsConst.MaxVariantnLength);
                b.Property(x => x.ValueOPtionD2).HasMaxLength(ProductsConst.MaxVariantnLength);

                //b.HasOne<Product>(x => x.product).WithMany(g => g.variants).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}