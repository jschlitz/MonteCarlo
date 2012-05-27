using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MonteCarlo
{
  public static class MathEx
  {
    /// <summary>
    /// Standard dev of population sqrt(sum((item-mean)^2) / N)
    /// </summary>
    public static double StdevP(this IEnumerable<double> items)
    {
      double count = items.Count();
      if (count < 1) throw new ArgumentException("StdevP called with < 1 items", "StdevP");

      double mean = items.Average();
      double sum = items.Sum<double>(d => (d - mean) * (d - mean));
      return Math.Sqrt(sum / count);
    }

    /// <summary>
    /// Standard dev of population sqrt(sum((item-mean)^2) / (N-1))
    /// </summary>
    public static double StdevS(this IEnumerable<double> items)
    {
      double count = items.Count();
      if (count < 2) throw new ArgumentException("StdevP called with < 2 items", "StdevP");

      double mean = items.Average();
      double sum = items.Sum<double>(d => (d - mean) * (d - mean));
      return Math.Sqrt(sum / (count - 1));
    }


    /// <summary>
    /// Run a function f count times, get the average and stdev of the sample.
    /// </summary>
    public static MonteResult MonteCarlo(Func<double> f, int count)
    {
      var l = YieldNumber(f).Take(count).ToArray();
      return new MonteResult { Average = l.Average(), StDev = l.StdevS() };
    }

    private static IEnumerable<double> YieldNumber(Func<double> f)
    {
      while (true)
        yield return f();
    }

    /// <summary>
    /// Result from a Monte Carlo
    /// </summary>
    public class MonteResult
    {
      public double Average { get; internal set; }
      public double StDev { get; internal set; }
    }
  }
}
