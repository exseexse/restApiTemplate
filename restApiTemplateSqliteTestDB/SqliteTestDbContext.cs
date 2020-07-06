
using Microsoft.EntityFrameworkCore;
using restApiTemplateDBEntities;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace restApiTemplateSqliteTestDB
{
    public class SqliteTestDbContext : EntityTemplateDbContext
    {
        private static bool _createDB = true;
        public SqliteTestDbContext()
        {
            if (_createDB)
            {
                _createDB = false;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string pathGroups = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            optionbuilder.UseSqlite(@"Data Source=" + pathGroups + "ArchieveDB.db");

        }
    }
}
