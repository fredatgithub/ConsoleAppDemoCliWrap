using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CliWrap;

namespace ConsoleAppDemoCliWrap472
{
  internal class Program
  {
    static  void Main(string[] args)
    {
      try
      {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(6));
        Cli.Wrap("ping")
         .WithArguments("-t google.com")
         .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
         .ExecuteAsync(cts.Token);
      }
      catch (OperationCanceledException)
      {
        Console.WriteLine("cancelled");
      }

      Console.WriteLine("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
