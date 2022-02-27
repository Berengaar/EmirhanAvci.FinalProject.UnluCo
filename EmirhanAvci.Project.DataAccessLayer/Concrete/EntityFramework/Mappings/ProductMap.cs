using EmirhanAvci.Project.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.DataAccessLayer.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Base properties
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.ModifiedByName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ImagePath).HasMaxLength(400);

            //Primary Key + Identity
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            //Customized Properties
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(400);
            builder.Property(p => p.IsOfferable).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.IsSold).IsRequired().HasDefaultValue(false);

            //Relation one to one
            builder.HasOne<Order>(s => s.Order)
           .WithOne(ad => ad.Product)
           .HasForeignKey<Order>(ad => ad.ProductId);
            //Table
            builder.ToTable("tbl_Products");

            //First Data Entry
        }
    }
}
