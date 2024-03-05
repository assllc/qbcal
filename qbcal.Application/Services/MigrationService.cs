using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qbcal.Common.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using qbcal.Application.Interfaces;

namespace qbcal.Application.Services
{
    public class MigrationService : IMigrationService
    {
        private IAppLogger _logger;

        public MigrationService(IAppLogger logger)
        {
            _logger = logger;
        }

        public string RunDbMigrations(string connectionString)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    MigrateUp(connectionString);
                    return $"RunDbMigrations Completed";
                }
                else
                {
                    _logger.Log(LogLevel.Information, "RunDbMigrations Error", "connectionString missing");
                    return $"RunDbMigrations Error";
                }
            }
            catch (Exception exc)
            {
                _logger.LogError("RunDbMigrations Exception", exc);
                return $"RunDbMigrations Exception {exc.Message}";
            }
        }

        private void MigrateUp(string connectionString)
        {
            var serviceProvider = new ServiceCollection()
            // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
            // Set the connection string
            .AddSQLite()
            .WithGlobalCommandTimeout(TimeSpan.FromMinutes(5))
            .WithGlobalConnectionString(connectionString)
            // Define the assembly containing the migrations
            .ScanIn(typeof(qbcal.DataAccess.DataAccessExtension).Assembly).For.Migrations())
            // Enable logging to console in the FluentMigrator way
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            // Build the service provider
            .BuildServiceProvider(false);
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
