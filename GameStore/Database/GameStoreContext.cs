using Microsoft.EntityFrameworkCore;
using GameStore.Models;

namespace GameStore.Database
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ComputerGame> ComputerGames => Set<ComputerGame>();
    }
}
