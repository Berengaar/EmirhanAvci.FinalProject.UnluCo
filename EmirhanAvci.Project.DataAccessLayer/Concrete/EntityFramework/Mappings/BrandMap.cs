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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //Base properties
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(b => b.ModifiedByName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();

            //Primary Key + identity
            builder.HasKey(b => b.Id);  
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            //Customize Property
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(b => b.Name).IsUnique();

            //Table
            builder.ToTable("tbl_Brands");

            //First Data Entry
           
        }
    }
}
