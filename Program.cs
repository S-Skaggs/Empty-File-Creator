using EmptyFileCreator;

try
{
    Console.WriteLine("Checking for arguments...");
    if (args.Length != 2 )
    {
        throw new ArgumentException("Expected two arguments: 'path' and 'file type'.");
    }
    Console.WriteLine($@"Attempting to create {args[0]}\SomeFileName.{args[1]}");
    Generator generator = new(args[0], args[1]);
    Console.WriteLine(generator.GenerateFile());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Environment.ExitCode = 1;
}
finally
{
    Thread.Sleep(1000);
}
