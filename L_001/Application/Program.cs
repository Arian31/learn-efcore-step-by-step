// ************************************************************
// Learn more about the new console template at:
// https://aka.ms/new-console-template
// Introduced in .NET 6; largely used for simplicity
// and modern template presentation.
// System.Console.WriteLine("Hello, World!");
// ************************************************************

// ************************************************************
// Best Practice: Use named arguments when calling methods 
// to improve code readability and intent.
// 
// System.Console.WriteLine(value: "Hello, World!");
// ************************************************************

// ************************************************************
// Standard boilerplate used by default until .NET 5.
// Recommendation: Using this explicit structure in Program.cs
// is often preferred for clarity in larger applications.
// namespace Application
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             System.Console.WriteLine("Hello, World!");
//         }
//     }
// }
// ************************************************************

// ************************************************************
// Core Principle: Be explicit.
// We explicitly write what the compiler would otherwise 
// automatically generate or assume behind the scenes.
// namespace Application
// {
//     internal class Program : object
//     {
//         private Program() : base()
//         {
//         }
//
//         private static void Main(string[] args)
//         {
//             System.Console.WriteLine("Hello, World!");
//         }
//     }
// }
// ************************************************************

namespace Application
{
	// A static class can only inherit directly 
	// from the System.Object class.
	internal static class Program // Note: 'base : object' is implicit for static classes
	{
		// A static constructor is executed only once:
		// Either when the first instance is created, or when 
		// a static member is accessed for the first time.
		// It runs at most once during the application's lifecycle.
		static Program()
		{
		}

		private static void Main(string[] args)
		{
			System.Console.WriteLine(value: "Hello, World!");
		}
	}
}