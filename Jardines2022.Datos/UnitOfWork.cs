using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Jardines2022DbContext context;
        public UnitOfWork(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
