using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Efcore
{
    public class CarEntityType : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(obj => obj.IdCar);
            builder.Property(obj => obj.IdCar).ValueGeneratedOnAdd();

            builder.Property(obj => obj.name).IsRequired().HasMaxLength(50);

            builder.Property(obj => obj.ProductionYear).IsRequired();
        }
    }
}
