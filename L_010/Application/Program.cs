#region Solution 1 --Basic CRUD Operations

namespace Application;
internal static class Program : object
{

	static Program()
	{
	}

	private static void Main(string[] args)
	{
		CreatePerson();
	}

	/// <summary>
	/// CRUD Operations Overview:
	/// C => Create   | R => Retrieve (Read) 
	/// U => Update   | D => Delete
	/// 
	/// Retrieve Patterns:
	/// - Zero or one result: Use FirstOrDefault()
	/// - Zero or many results: Use ToList()
	/// </summary>
	private static void CreatePerson() 
	{
		// Initializing the Database Context
		Models.DatabaseContext databaseContext = new Models.DatabaseContext();

		// Creating a new Entity instance
		Models.Person person = new Models.Person();
		person.Name = "p1";

		// Step 1: Add the entity to the Change Tracker
		databaseContext.Add(entity: person);

		// Step 2: Persist changes to the database (Generates SQL INSERT)
		databaseContext.SaveChanges();
	}
}
#endregion
