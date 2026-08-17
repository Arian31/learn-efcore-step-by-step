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

//// Although this approach is considered legacy, it offers more flexibility 
//// and granular control, particularly within the Catch and Finally blocks.
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
//		// Declaring the context outside the try block to ensure it is 
//		// accessible within the finally block for proper disposal.
//		Models.DatabaseContext? databaseContext = null;

//		try
//		{
//			databaseContext = new Models.DatabaseContext();

//			var person = new Models.Person
//			{
//				Name = "p3",
//			};

//			databaseContext.Add(entity: person);
//			databaseContext.SaveChanges();
//		}
//		catch (System.Exception ex)
//		{
//			// Critical Step: Log the exception details to a file or monitoring system.
//			System.Console.WriteLine(value: ex.Message);
//		}
//		finally
//		{
//			// The finally block executes regardless of whether an exception occurred.
//			if (databaseContext != null)
//			{
//				// Explicitly releasing database connections and unmanaged resources.
//				databaseContext.Dispose();

//				// Note: Explicitly setting the context to null was a common convention 
//				// in EF Classic to aid the Garbage Collector. In EF Core, this practice 
//				// is generally unnecessary as Dispose handles resource cleanup efficiently.
//				// databaseContext = null;
//			}
//		}
//	}
//}

#endregion


#region Solution 4: Standard Using Block for Scoped Disposal

//// This approach often provides better readability compared to Solution 5.
//// In modern software development, Clean Code principles prioritize clarity 
//// and maintainability over minimizing the number of lines written.
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
//		// The 'using' block ensures that the IDisposable object (DatabaseContext) 
//		// is automatically disposed of as soon as the block is exited.
//		// This syntax clearly defines the scope and lifetime of the resource.
//		using (var databaseContext = new Models.DatabaseContext())
//		{
//			var person = new Models.Person
//			{
//				Name = "p4",
//			};

//			databaseContext.Add(entity: person);
//			databaseContext.SaveChanges();
//		}
//		// Disposal happens here automatically, even if an exception occurs.
//	}
//}

#endregion


#region Solution 5: Using Declarations (C# 8.0+)

//// Personally, I prefer Solution 3 or 4 due to their explicit boundary definitions.
//// However, this modern syntax is available and offers a more streamlined approach.
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
//		// 'Using declaration' (introduced in C# 8.0): 
//		// The variable is disposed at the end of the enclosing scope (the method).
//		// This eliminates the need for extra curly braces and reduces indentation.
//		using var databaseContext = new Models.DatabaseContext();

//		var person = new Models.Person
//		{
//			Name = "p5",
//		};

//		databaseContext.Add(entity: person);
//		databaseContext.SaveChanges();

//		// Note: The database connection remains open until the very end of 
//		// this method, even if we no longer need it after SaveChanges().
//	}
//}

#endregion

#region Solution 6

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
		using (var databaseContext = new Models.DatabaseContext())
		{
			var person = new Models.Person
			{
				Name = "p6",
			};
			// type : Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry
			// در این خصوص در آینده بیشتر باهاش کار میکنیم.
			// فعلا به عنوان نمونه می نویسم
			var entityEntry =
				databaseContext.people.Add(entity: person);
			// OR
			entityEntry =
				databaseContext.Entry(entity: person);
			// اینطور تصور کنید که یک کالکشن مخفی وجود دارد و کارهایی که با entityها انجام می دهید؛ رکورد ها در آن کالکشن ایجاد می شود و یک state بهش میخوره
			// زمانی که دستور SaveChanges را بکار می برید، از آن لیست، نه از databaseContext.people یک لوپ میزند و نگاه میکند هر رکورد چه اتفاقی برایش افتاده
			//Detached و Unchanged در آن لیست نمیرود
			switch (entityEntry.State)
			{
				// بعد از اینکه شخص را نیو کردم.دستور خط بالا رو بنویسم
				// رو هوا ساخته شده، نه ربطی به دیتابیس داره،هیچ اتفاقی برایش نیوفتاده
				case Microsoft.EntityFrameworkCore.EntityState.Detached:
				break;
				// اگر یک رکورد را از دیتابیس بیاوریم و هیچ کاری با آن نکنیم به این حالت در می آید
				case Microsoft.EntityFrameworkCore.EntityState.Unchanged:
				break;
				// اگر رکوردی را حذف کنیم
				case Microsoft.EntityFrameworkCore.EntityState.Deleted:
				break;
				// اگر یک رکورد را از دیتابیس بیاوریم و یکی از پروپرتی ها را تغییر دهیم
				case Microsoft.EntityFrameworkCore.EntityState.Modified:
				break;
				// زمانی که شخص اضافه میشود state آن این میشود
				case Microsoft.EntityFrameworkCore.EntityState.Added:
				break;
				default:
				break;
			}

			// new in EF Core
			// خروجی آن از جنس Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry است.
			entityEntry =
				databaseContext.Add(entity: person);

			int id =
				person.Id;
			//در EF Core خطا می دهد
			// در EF خطا نمیداد و صرفا به آن بی توجه بود
			//person.Id = 123;
			//Error : Cannot insert explicit value for identity column
			// in table 'people' when IDENTITY_INSERT is set
			// to off
			id =
				person.Id;

			databaseContext.Add(entity: person);
			databaseContext.SaveChanges();
		}
	}
}

#endregion