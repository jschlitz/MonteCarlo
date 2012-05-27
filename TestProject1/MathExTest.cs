using MonteCarlo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MathExTest and is intended
    ///to contain all MathExTest Unit Tests
    ///</summary>
  [TestClass()]
  public class MathExTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for StdevP
    ///</summary>
    [TestMethod()]
    public void StdevPTest()
    {
      IEnumerable<double> items = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      double expected = 2.87228132326901;
      double actual = MathEx.StdevP(items);
      Assert.IsTrue(CloseEnough(actual, expected));
    }

    /// <summary>
    ///A test for StdevS
    ///</summary>
    [TestMethod()]
    public void StdevSTest()
    {
      IEnumerable<double> items = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      double expected = 3.02765035409749;
      double actual = MathEx.StdevS(items);
      Assert.IsTrue(CloseEnough(actual, expected));

    }

    public static bool CloseEnough(double d1, double d2)
    {
      return Math.Abs(d1 - d2) < 0.0001;
    }
  }
}
