using Microsoft.EntityFrameworkCore;
using restApiTemplateDBEntities;
using System;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace restApiTemplateSqliteDB
{
    public class sqliteDbContext : EntityTemplateDbContext
    {
        private static bool _createDB = true;
        public sqliteDbContext()
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
