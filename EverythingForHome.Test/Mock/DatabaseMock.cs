using DataBaseevEverythingForHome.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingForHome.Test.Mock
{
    public static class DatabaseMock
    {
        public static EverythingForHomeDBContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<EverythingForHomeDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
                return new EverythingForHomeDBContext(dbContextOptions);
            }
        }
    }
}
