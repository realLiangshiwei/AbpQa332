using AbxEps.CentralTools.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Saas;

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

            builder.Entity<QaTenant>()
                .HasOne(x => x.MasterTenant)
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.MasterId);
            builder.Entity<QaTenant>()
                .HasOne(x => x.AbpTenant)
                .WithOne()
                .HasPrincipalKey<Tenant>(x => x.Id)
                .HasForeignKey<QaTenant>(x => x.AbpTenantId);


            builder.Entity<QaTenant>(b =>
            {
                b.ToTable("CT_CA_TENANT", "QA");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).HasColumnName("C_TENANT").IsRequired().ValueGeneratedNever();
                b.Property(x => x.ShortName)
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("S_TENANT_INT").HasMaxLength(30);
                b.Property(x => x.FullName)
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("S_TENANT").HasMaxLength(50);
                b.Property(x => x.CompanyId).HasColumnName("C_COMPANY").IsRequired();
                b.Property(x => x.Comment)
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("S_COMMENT").HasMaxLength(200);
                b.Property(x => x.MasterId).HasColumnName("C_MASTER_TENANT");
                b.Property(x => x.AbpTenantId).HasColumnName("C_ABP_TENANT").IsRequired();
                b.Property(x => x.IsMaster).HasColumnName("C_MASTER");
                b.MapLogProperties();
            });
        }

        private static void MapLogProperties(this EntityTypeBuilder b)
        {
            if (typeof(IMayHaveCreatorName).IsAssignableFrom(b.Metadata.ClrType))
            {
                b.Ignore("CreatorId");
                b.Property("CreationTime").HasColumnName("D_INS");
                b.Property("CreatorName")
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("C_USR_INS").HasMaxLength(10);
            }
            if (typeof(IMayHaveLastModifierName).IsAssignableFrom(b.Metadata.ClrType))
            {
                b.Ignore("LastModifierId");
                b.Property("LastModificationTime").HasColumnName("D_UPD");
                b.Property("LastModifierName")
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("C_USR_UPD").HasMaxLength(10);
            }
            if (typeof(IMayHaveDeleterName).IsAssignableFrom(b.Metadata.ClrType))
            {
                b.Property("DeleterName")
                    .HasConversion(new ValueConverter<string, string>(v => v.Trim(), v => v.Trim()))
                    .HasColumnName("C_USR_DEL").HasMaxLength(10);
            }
            if (typeof(ISoftDelete).IsAssignableFrom(b.Metadata.ClrType))
            {
                b.Property("IsDeleted").HasColumnName("C_DELETED");
            }
            if (typeof(IDeletionAuditedObject).IsAssignableFrom(b.Metadata.ClrType))
            {
                b.Ignore("DeleterId");
                b.Property("DeletionTime").HasColumnName("D_DEL");
            }
        }
    }
}
