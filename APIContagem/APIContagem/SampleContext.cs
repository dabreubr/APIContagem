using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace APIContagem
{
    public class SampleContext : DbContext
    {
        public override bool Equals(object obj)
        {
            return obj is SampleContext context &&
                   base.Equals(obj) &&
                   EqualityComparer<Database>.Default.Equals(Database, context.Database) &&
                   EqualityComparer<DbChangeTracker>.Default.Equals(ChangeTracker, context.ChangeTracker) &&
                   EqualityComparer<DbContextConfiguration>.Default.Equals(Configuration, context.Configuration);
        }
    }
}