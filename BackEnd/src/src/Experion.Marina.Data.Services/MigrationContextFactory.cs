using System.Data.Entity.Infrastructure;

namespace Experion.Marina.Data.Services
{
    public class MigrationContextFactory : IDbContextFactory<MarinaContext>
    {
        public MarinaContext Create()
        {
            return new MarinaContext(@"Data Source=DESKTOP-46GOHVP\SQLEXPRESS;Initial Catalog=TelephoneDirectoryDb;User Id=sa;Password=root;MultipleActiveResultSets=true");
        }
    }
}