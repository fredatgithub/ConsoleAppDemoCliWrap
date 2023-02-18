using CliWrap;
using CliWrap.Buffered;
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(6));

// example 1
//await Cli.Wrap("notepad")
//  //.WithArguments("toto.txt")
//  .WithArguments(arguments => arguments
//    .Add("toto.txt"))
//  .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
//  .WithStandardOutputPipe(PipeTarget.ToFile("log.log"))
//  //.ExecuteAsync();
//  .ExecuteBufferedAsync();

// example 2
try
{
  Cli.Wrap("ping")
   .WithArguments("-t google.com")
   .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
   .ExecuteAsync(cts.Token);
}
catch (OperationCanceledException)
{
  Console.WriteLine("cancelled");
}

Console.WriteLine("press any key to exit:");
Console.ReadKey();
