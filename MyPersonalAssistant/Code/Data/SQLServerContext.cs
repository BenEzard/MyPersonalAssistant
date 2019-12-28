using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MyPersonalAssistant.Code.Data.Models;

namespace MyPersonalAssistant.Code.Data
{
    public class SQLServerDBContext : DbContext
    {
        public static readonly ILoggerFactory MyConsoleLoggerFactory = LoggerFactory.Create(builder => 
            { builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole(); 
        });

        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<WorkItemStatus> WorkItemStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=MyPersonalAssistant; Trusted_Connection=True;");
            //optionsBuilder.UseSqlite(@"Data Source=DB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //            modelBuilder.Entity<WorkItemStatus>().Property(r => r.IsConsideredActive).HasConversion(new BoolToZeroOneConverter<bool>());
            //            modelBuilder.Entity<WorkItemStatus>().Property(r => r.IsDefault).HasConversion(new BoolToZeroOneConverter<bool>());

            modelBuilder.Entity<WorkItemStatus>().HasData(
                new WorkItemStatus { WorkItemStatusId = 1, StatusLabel = "Active", IsConsideredActive = 'Y', IsDefault = 'Y' },
                new WorkItemStatus { WorkItemStatusId = 2, StatusLabel = "Awaiting Feedback", IsConsideredActive = 'Y', IsDefault = 'N' },
                new WorkItemStatus { WorkItemStatusId = 3, StatusLabel = "Completed", IsConsideredActive = 'N', IsDefault = 'Y' },
                new WorkItemStatus { WorkItemStatusId = 4, StatusLabel = "Cancelled", IsConsideredActive = 'N', IsDefault = 'N' }
            );

            /*var activeWISH = 
            modelBuilder.Entity<WorkItemStatusHistory>().HasData(
                new { WorkItemStatusHistoryId = 1, WorkItemId = 1, CompletionAmount = 30 },
                new { WorkItemStatusHistoryId = 2, WorkItemId = 2, WorkItemStatusId = 1, CompletionAmount = 30 },
                new { WorkItemStatusHistoryId = 3, WorkItemId = 2, WorkItemStatusId = 3, CompletionAmount = 100 }
            );*/

            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem { WorkItemId = 1, Title = "A Sample WorkItem", Description = "Nothing much here" },
                new WorkItem { WorkItemId = 2, Title = "Second WorkItem", Description = "Blah, blah blah" }
            );

/*            modelBuilder.Entity<WorkItemDueDate>().HasData(
                new WorkItemDueDate { WorkItemDueDateId = 1, WorkItemId = 1, DueDateTime = DateTime.Now.AddDays(10) },
                new WorkItemDueDate { WorkItemDueDateId = 2, WorkItemId = 2, DueDateTime = DateTime.Now.AddDays(20) }
            );*/

        }
    }
}
