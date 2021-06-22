using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Efcore
{
    public class InsceptionEntityType : IEntityTypeConfiguration<Insception>
    {
        public void Configure(EntityTypeBuilder<Insception> builder)
        {
            builder.HasKey(obj => obj.IdInsception);
            builder.Property(obj => obj.IdInsception).ValueGeneratedOnAdd();
            
            builder.Property(obj => obj.InsceptionDate).IsRequired();
            builder.Property(obj => obj.Comment).HasMaxLength(300);

            builder.HasOne(dr => dr.IdCarNavigation)
                            .WithMany(p => p.CarInsceptons)
                            .HasForeignKey(f => f.IdCar);

            builder.HasOne(dr => dr.IdMechanicNavigation)
                            .WithMany(p => p.MechanicInsceptions)
                            .HasForeignKey(f => f.IdMechanic);
        }
    }
}
