#region Solution 1 --Basic CRUD Operations

//namespace Application;
//internal static class Program : object
//{

//	static Program()
//	{
//	}

//	private static void Main(string[] args)
//	{
//		CreatePerson();
//	}

//	/// <summary>
//	/// CRUD Operations Overview:
//	/// C => Create   | R => Retrieve (Read) 
//	/// U => Update   | D => Delete
//	/// 
//	/// Retrieve Patterns:
//	/// - Zero or one result: Use FirstOrDefault()
//	/// - Zero or many results: Use ToList()
//	/// </summary>
//	private static void CreatePerson() 
//	{
//		// Initializing the Database Context
//		Models.DatabaseContext databaseContext = new Models.DatabaseContext();

//		// Creating a new Entity instance
//		Models.Person person = new Models.Person();
//		person.Name = "p1";

//		// Step 1: Add the entity to the Change Tracker
//		databaseContext.Add(entity: person);

//		// Step 2: Persist changes to the database (Generates SQL INSERT)
//		databaseContext.SaveChanges();
//	}
//}
//// ************************************************************
//// Key Differences between EF (Classic) and EF Core 
//// Regarding Database and Table Creation:
////
//// EF Classic: 
//// The database and tables were typically generated lazily. 
//// Creation occurred only when the first command was sent to 
//// the database (e.g., executing SaveChanges, FirstOrDefault, or ToList). 
//// Furthermore, if schema changes were detected, EF Classic 
//// would often drop and recreate the entire table/database 
//// based on the configured "Database Initializer."
////
//// EF Core: 
//// By using the Database.EnsureCreated() method, the database 
//// and its schema are explicitly created. If this method is 
//// called within the constructor, the database is generated 
//// as soon as the DatabaseContext is instantiated (Newed up).
//// ************************************************************
#endregion


#region Solution 2: Object Initializers and Implicit Typing

//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main(string[] args)
//	{
//		CreatePerson();
//	}

//	private static void CreatePerson()
//	{
//		Models.DatabaseContext databaseContext = new Models.DatabaseContext();

//		// Using 'var' for implicit typing: The compiler infers the type 
//		// based on the right-hand side of the assignment.
//		// Using Object Initializer syntax: Allows property assignment 
//		// during instantiation without explicitly calling a specific constructor.
//		var person = new Models.Person
//		{
//			// Note: The trailing comma after "p2" is intentional. 
//			// In C#, trailing commas in initializers are allowed to 
//			// facilitate easier property additions and cleaner version control (Git) diffs.
//			Name = "p2",
//		};

//		databaseContext.Add(entity: person);
//		databaseContext.SaveChanges();
//	}
//}

#endregion


#region Solution 3: Explicit Resource Management (Try-Catch-Finally)

// Although this approach is considered legacy, it offers more flexibility 
// and granular control, particularly within the Catch and Finally blocks.
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

	private static void CreatePerson()
	{
		// Declaring the context outside the try block to ensure it is 
		// accessible within the finally block for proper disposal.
		Models.DatabaseContext? databaseContext = null;

		try
		{
			databaseContext = new Models.DatabaseContext();

			var person = new Models.Person
			{
				Name = "p3",
			};

			databaseContext.Add(entity: person);
			databaseContext.SaveChanges();
		}
		catch (System.Exception ex)
		{
			// Critical Step: Log the exception details to a file or monitoring system.
			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			// The finally block executes regardless of whether an exception occurred.
			if (databaseContext != null)
			{
				// Explicitly releasing database connections and unmanaged resources.
				databaseContext.Dispose();

				// Note: Explicitly setting the context to null was a common convention 
				// in EF Classic to aid the Garbage Collector. In EF Core, this practice 
				// is generally unnecessary as Dispose handles resource cleanup efficiently.
				// databaseContext = null;
			}
		}
	}
}

#endregion


#region Solution 4
// در این روش خوانایی برنامه نسبت به سلوشن 5 بالاتر هست
// در دنیای امروز برخلاف گذشته که اگر با یک خط ده کار را انجام میدادی و خوشحال بودی. کلین کد حرف اول را میزند
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main(string[] args)
//	{
//		CreatePerson();
//	}

//	private static void CreatePerson()
//	{

//		using (var databaseContext = new Models.DatabaseContext())
//		{ 

//			var person =
//				new Models.Person
//				{

//					Name = "p4",
//				};

//		databaseContext.Add(entity: person);
//		databaseContext.SaveChanges();
//		}
//	}
//}

#endregion
#region Solution 5
// من ترجیح میدم از سلوشن 3 یا 4 استفاده کنم
// ولی این روش هم وجود دارد و میتوانید از اون استفاده کنید
//namespace Application;

//internal static class Program : object
//{
//	static Program()
//	{
//	}

//	private static void Main(string[] args)
//	{
//		CreatePerson();
//	}

//	private static void CreatePerson()
//	{

//		using var databaseContext =
//			new Models.DatabaseContext();


//		var person =
//			new Models.Person
//			{

//				Name = "p5",
//			};

//		databaseContext.Add(entity: person);
//		databaseContext.SaveChanges();
//	}
//}

#endregion

