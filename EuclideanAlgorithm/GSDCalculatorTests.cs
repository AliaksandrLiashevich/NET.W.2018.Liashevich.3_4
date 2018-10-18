using NUnit.Framework;
using GSDSearch;


namespace NET.W._2018.Liashevich._3_4.Tests
{
    [TestFixture]
    public class GSDCalculatorTests
    {
        [TestCase(new int[] { 15, 10, 20 }, 5)]
        [TestCase(new int[] { -154, 75, 53 }, 1)]
        [TestCase(new int[] { 154, 320, 539, 89 }, 1)]
        [TestCase(new int[] { 5 }, 5)]
        public void EuclideanAlgorithm_15and10and20_5returned(int[] numbers, int expected)
        {
            Assert.AreEqual(expected, GSDCalculator.EuclideanAlgorithm(numbers));
        }

        [TestCase(new int[] { 15, 10, 20 }, 5)]
        [TestCase(new int[] { 54, 12, 57, 3 }, 3)]
        [TestCase(new int[] { -5, 10, 15, -60 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        public void BinaryEuclideanAlgorithm_15and10and20_5returned(int[] numbers, int expected)
        {
            Assert.AreEqual(expected, GSDCalculator.BinaryEuclideanAlgorithm(numbers));
        }
    }    
}
