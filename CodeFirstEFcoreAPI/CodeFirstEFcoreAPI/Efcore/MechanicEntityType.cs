using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Efcore
{
    public class MechanicEntityType : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasKey(obj => obj.IdMechanic);
            builder.Property(obj => obj.IdMechanic).ValueGeneratedOnAdd();

            builder.Property(obj => obj.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(obj => obj.LastName).IsRequired().HasMaxLength(30);


        }
    }
}
