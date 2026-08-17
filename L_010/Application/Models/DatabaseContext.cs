using Microsoft.EntityFrameworkCore;

namespace Models;

// Necessary NuGet packages must be installed to support EF Core functionality.
public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext() : base()
	{
		// Creates the database and its schema if they do not already exist.
		Database.EnsureCreated();
	}

	// Define a generic DbSet collection for every class (entity) to represent a database table.
	// Convention: Use plural names for these properties to reflect a collection of items.
	// Recommendation: Arrange properties by line length to enhance visual aesthetics and readability.
	public Microsoft.EntityFrameworkCore.DbSet<Person> people { get; set; }

	// public Microsoft.EntityFrameworkCore.DbSet<Test> Tests { get; set; }

	// protected override void OnConfiguring
	//     (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	// {
	//     base.OnConfiguring(optionsBuilder);
	// }

	// Refactored the above method to the following implementation:
	protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// One of the primary advantages of EF Core is its provider-agnostic nature, 
		// allowing it to support various database engines through a unified API.

		// Option 1: SQL Server Authentication (requires Username and Password)
		//var connectionString =
		//	"Server=.;Database=Learn-EFCore-StepByStep_L_010;User ID=sa;Password=123;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		// Option 2: Windows Authentication (Integrated Security)
		// Use this for local development if you want to connect using your Windows account.
		var connectionString =
			"Server=.;Database=Learn-EFCore-StepByStep_L_010;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
		//**** **** **** ***
		// WARNING: Never use the 'sa' (System Administrator) account 
		// in production environments for security reasons.
		//**** **** **** ***


		// The Microsoft.EntityFrameworkCore.SqlServer package is required 
		// to provide the UseSqlServer extension method.
		optionsBuilder.UseSqlServer(connectionString);
	}
}