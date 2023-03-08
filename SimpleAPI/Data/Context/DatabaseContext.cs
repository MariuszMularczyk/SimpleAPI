namespace SimpleAPI
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public static DatabaseContext Create()
        {
            return (new DatabaseContextFactory()).CreateDbContext(new string[0]);
        }

        //Add-Migration -Context DatabaseContext -o ".\Data\Migrations\" <Nazwa migracji>
        //Update-Database -Context DatabaseContext
        //Remove-Migration -Context DatabaseContext
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Mail> Mails { get; set; }

    }
}
