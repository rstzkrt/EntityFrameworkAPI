using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Efcore
{
    public class ServiceTypeDictInsceptionEntityType : IEntityTypeConfiguration<ServiceTypeDictInsception>
    {
        public void Configure(EntityTypeBuilder<ServiceTypeDictInsception> builder)
        {
            builder.HasKey(obj => new
            {
                obj.IdInsception,
                obj.IdServiceType
            });

            builder.Property(obj => obj.Comments).HasMaxLength(300);

            builder.HasOne(dr => dr.IdInsceptionNavigation)
                            .WithMany(p => p.ServiceTypeDictInsceptions_Insceptions)
                            .HasForeignKey(f => f.IdInsception);

            builder.HasOne(dr => dr.IdServiceTypeNavigation)
                                        .WithMany(p => p.ServiceTypeDictInsceptions_ServiceTypeDict)
                                        .HasForeignKey(f => f.IdServiceType);
        }
    }
}
