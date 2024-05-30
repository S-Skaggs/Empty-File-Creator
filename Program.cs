// See https://aka.ms/new-console-template for more information
using EmptyFileCreator;
using System.Diagnostics;
using System.Runtime.CompilerServices;


try
{
	Console.WriteLine("Checking for arguments...");
	if (args.Length != 2 )
	{
		throw new ArgumentException("Expected two arguments, path and file type.");
	}
	Console.WriteLine(String.Format("Attempting to create {0}\\SomeFileName.{1}", args[0], args[1]));
    Generator generator = new Generator(args[0], args[1]);
	Console.WriteLine(generator.CreateEmptyFile());
}
catch (Exception e)
{
	Console.WriteLine(e.ToString());
	Environment.ExitCode = 1;
}
finally
{
	Thread.Sleep(1000);
}