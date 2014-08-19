using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicZDem.MdSpa.Domain;

namespace MicZDem.MdSpa.SqlData
{
    public class SqlDbContext : DbContext
    {
        public IDbSet<Person> Persons { get; set; }

        public SqlDbContext()
            : base("name=DefaultConnection")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public SqlDbContext(string connectionString)
            : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SqlDbContext>());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
