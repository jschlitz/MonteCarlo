using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonteCarlo
{
  class Program
  {
    static void Main(string[] args)
    {
      var ThreeD6 = MathEx.MonteCarlo(() => D(6) + D(6) + D(6), MONTE_SIZE);
      var ThreeD6Best = MathEx.MonteCarlo(() => Math.Max(D(6) + D(6) + D(6), D(6) + D(6) + D(6)), MONTE_SIZE);
      var FourD6DropLow = MathEx.MonteCarlo(() =>
        {
          var tmp = new[] { D(6), D(6), D(6), D(6) };
          return tmp.Sum() - tmp.Min();
        }, MONTE_SIZE);
      var D20 = MathEx.MonteCarlo(() => D(20), MONTE_SIZE);
      var D20Advantage = MathEx.MonteCarlo(() => Math.Max(D(20), D(20)), MONTE_SIZE);
      var D20Disadvantage = MathEx.MonteCarlo(() => Math.Min(D(20), D(20)), MONTE_SIZE);

      FormatMC("3d6", ThreeD6);
      FormatMC("3d6, best of 2", ThreeD6Best);
      FormatMC("4d6, drop low", FourD6DropLow);
      FormatMC("D20", D20);
      FormatMC("D20, advantage", D20Advantage);
      FormatMC("D20, disadvantage", D20Disadvantage);

      Console.WriteLine("Press any key to continue");
      Console.ReadKey(true);
    }

    private static void FormatMC(string caption, MathEx.MonteResult r)
    {
      Console.WriteLine(string.Format("{0,20}{1,10:F2}{2,10:F2}", caption, Math.Round(r.Average, 2), Math.Round(r.StDev,2)));
    }

    const int MONTE_SIZE = 1000000;
    static Random Rand = new Random();

    static int D(int size)
    {
      return Rand.Next(size) + 1;
    }
  }
}
