using SonarSweep;

namespace SonarSweepTest {
    public class SonarSweepTest {
        [Fact]
        public void TestPart1WithAoCData() {
            List<int> data = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int result = SonarSweepUtils.CountMeasurementIncreases(data);
            Assert.Equal(7, result);
        }

        [Theory]
        [InlineData(new int[] { }, 0)]                          // no data
        [InlineData(new int[] { 100 }, 0)]                      // not enough data
        [InlineData(new int[] { 300, 200, 100 }, 0)]            // all go down
        [InlineData(new int[] { 100, 200, 300 }, 2)]            // all go up
        [InlineData(new int[] { 100, 100, 100, 100 }, 0)]       // all data equal, so no increases
        [InlineData(new int[] { -5, -3, -10, -1, 0 }, 3)]       // negatives
        public void TestPart1ForVariousEdgeCaseData(int[] input, int expectedResult) {
            int result = SonarSweepUtils.CountMeasurementIncreases(input.ToList());
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestPart2WithAoCData() {
            List<int> data = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int result = SonarSweepUtils.CountMeasurementWindowIncreases(data, 3);
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(new int[] { }, 0)]                          // no data
        [InlineData(new int[] { 100 }, 0)]                      // not enough data
        [InlineData(new int[] { 100, 200 }, 0)]                 // not enough data
        [InlineData(new int[] { 100, 200, 300 }, 0)]            // just one window, so not enough data
        [InlineData(new int[] { 400, 300, 200, 100 }, 0)]       // all go down
        [InlineData(new int[] { 100, 200, 300, 400 }, 1)]       // all go up
        [InlineData(new int[] { 100, 100, 100, 100, 100 }, 0)]  // all data equal, so no increases
        [InlineData(new int[] { -5, -3, -10, -1, 0 }, 2)]       // negatives 

        public void TestPart2ForVariousEdgeCaseData(int[] input, int expectedResult) {
            var result = SonarSweepUtils.CountMeasurementWindowIncreases(input.ToList(), 3);
            Assert.Equal(expectedResult, result);
        }
    }
}
