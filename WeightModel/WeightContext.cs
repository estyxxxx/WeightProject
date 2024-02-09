using Microsoft.EntityFrameworkCore;
using WeightModel.model;

namespace WeightModel
{
    public class WeightContext : DbContext
    {
        public WeightContext(DbContextOptions<WeightContext> options) : base(options)
        {

        }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}