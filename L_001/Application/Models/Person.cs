using System;

// Recommendation: Use generic class names for Entities.
// This practice facilitates code reusability across 
// different projects as your codebase grows.

// Recommendation: It is better to use a dedicated "Class Library" 
// project instead of simply using a folder within a Console app.

// Historical Note: In older architectures, the name "Models" was 
// commonly used. In modern patterns (like DDD), this name has 
// evolved to "Domain".  

// Note: No NuGet packages are required for this POCO class.
// POCO => Plain Old CLR Object

namespace Models;

public class Person : Object
{
	public Person() : base()
	{
	}

	// ************************************************************
	// Primary Key (PK) Constraints:
	// Each table can only have one Primary Key.
	// A PK can be defined on a single field or multiple fields (Composite Key).
	// Using Composite Keys is generally not recommended for beginners.

	// EF Core Convention: If a property is named in one of the 
	// following 4 ways, it is automatically recognized as a PK:
	public int Id { get; set; }
	// public int ID { get; set; }
	// public int PersonId { get; set; }
	// public int PersonID { get; set; }

	// Alternative: Using Data Annotations (Attributes).
	// Entity configuration is handled via two methods:
	// 1. Data Annotations (Attributes)
	// 2. Fluent API (inside the DbContext)

	// [System.ComponentModel.DataAnnotations.Key]
	// public int Key { get; set; }
	// ************************************************************

	// ************************************************************
	// Nullability in C#:
	// Strings are Reference Types and are inherently nullable.
	// However, with "Nullable Reference Types" enabled, we must 
	// explicitly state if a property can be null using '?'.
	public string? Name { get; set; }

	// If the '?' is removed, a compiler warning will occur.
	// To resolve this without '?', we must either:
	// 1. Provide an initial value (e.g., = string.Empty;).
	// 2. Initialize it via the constructor.
	// public string Name { get; set; }
	// ************************************************************
}