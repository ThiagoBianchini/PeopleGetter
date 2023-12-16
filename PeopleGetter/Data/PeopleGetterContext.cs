using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleGetter.Models;

namespace PeopleGetter.Data
{
    public class PeopleGetterContext : DbContext
    {
        public PeopleGetterContext (DbContextOptions<PeopleGetterContext> options)
            : base(options)
        {
        }

        public DbSet<PeopleGetter.Models.Pessoas> Pessoas { get; set; } = default!;
    }
}
