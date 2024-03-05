namespace qbcal.Application.Interfaces
{
    public interface IMigrationService
    {
        string RunDbMigrations(string connectionString);
    }
}
