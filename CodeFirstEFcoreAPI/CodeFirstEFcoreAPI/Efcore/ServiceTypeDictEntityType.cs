using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Efcore
{
    public class ServiceTypeDictEntityType : IEntityTypeConfiguration<ServiceTypeDict>
    {
        public void Configure(EntityTypeBuilder<ServiceTypeDict> builder)
        {
            builder.HasKey(obj => obj.IdServiceType);
            builder.Property(obj => obj.IdServiceType).ValueGeneratedOnAdd();

            builder.Property(obj => obj.ServiceType).IsRequired().HasMaxLength(20);
            builder.Property(obj => obj.Price).IsRequired();

        }
    }
}
