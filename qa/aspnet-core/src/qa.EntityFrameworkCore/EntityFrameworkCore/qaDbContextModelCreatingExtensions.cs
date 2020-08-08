using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace qa.EntityFrameworkCore
{
    public static class qaDbContextModelCreatingExtensions
    {
        public static void Configureqa(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(qaConsts.DbTablePrefix + "YourEntities", qaConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<QaTenant>(b =>
            {
                b.ToTable("QaTenant");
                b.HasOne(x => x.AbpTenant).WithOne();
                b.ConfigureByConvention();
            });
        }
    }
}