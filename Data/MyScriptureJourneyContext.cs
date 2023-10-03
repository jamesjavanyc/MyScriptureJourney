using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyScriptureJourney.models;

namespace MyScriptureJourney.Data
{
    public class MyScriptureJourneyContext : DbContext
    {
        public MyScriptureJourneyContext (DbContextOptions<MyScriptureJourneyContext> options)
            : base(options)
        {
        }

        public DbSet<MyScriptureJourney.models.Scripture> Scripture { get; set; } = default!;
    }
}
