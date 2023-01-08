using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.EntityTypeConfiguration
{
    public class PaisesEntityTypeConfiguration: EntityTypeConfiguration<Pais>
    {
        public PaisesEntityTypeConfiguration()
        {
            ToTable("Paises");
        }
    }
}
