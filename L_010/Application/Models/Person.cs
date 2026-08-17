namespace Models;

// As previously noted, the C# compiler automatically handles certain 
// boilerplate code, such as inheriting from the 'object' class 
// and invoking 'base()' in constructors. 
// Most developers omit these to keep the codebase clean and concise.

// Historically, being explicit helped prevent issues during 
// Visual Studio version migrations and simplified the debugging process.
// For educational purposes, I am explicitly writing these implicit 
// elements to gain a deeper understanding of how the compiler operates.
public class Person : object
{
	// Note: In future implementations, this class may inherit from 
	// custom base classes or implement specific interfaces 
	// (e.g., public class Person : BaseEntity, IHasIsActive).

	public Person() : base()
	{
	}

	// ************************************************************
	// Primary Key (PK) Data Types:
	// 'int', 'long', and 'Guid' (System.Guid) are the most common 
	// types used for Primary Keys.
	// In this example, using 'int' enables the "Identity" behavior 
	// (Auto-Increment) within the database.
	public int Id { get; set; }

	// public long Id { get; set; }
	// public System.Guid Id { get; set; }
	// ************************************************************

	// ************************************************************
	// Nullable Reference Types:
	// Marking the string as '?' allows it to store null values 
	// and maps to a NULL column in the database schema.
	public string? Name { get; set; }
	// ************************************************************
}