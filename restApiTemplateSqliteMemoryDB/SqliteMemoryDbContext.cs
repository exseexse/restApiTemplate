

using Microsoft.EntityFrameworkCore;
using restApiTemplateDBEntities;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace restApiTemplateSqliteDB
{
    public class sqliteMemoryDbContext : EntityTemplateDbContext
    {
        private static bool _createDB = true;
        public sqliteMemoryDbContext()
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
            optionbuilder.UseSqlite(@"Data Source=" + pathGroups + "ArchieveDB1.db");

        }
    }
}
