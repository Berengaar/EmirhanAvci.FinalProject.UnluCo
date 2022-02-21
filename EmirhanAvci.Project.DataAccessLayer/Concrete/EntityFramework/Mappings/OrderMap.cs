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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Base properties
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.ModifiedByName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.ModifiedDate).IsRequired();
            builder.Property(o => o.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.CreatedDate).IsRequired();

            //Primary Key + Identity
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            //Customized Properties
            builder.Property(o => o.OrderCode).IsRequired().HasMaxLength(12);
            builder.Property(o => o.IsBuy).IsRequired().HasDefaultValue(false);

            //Table
            builder.ToTable("tbl_Orders");

            //First Data Entry
            
        }
    }
}
