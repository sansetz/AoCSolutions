using SonarSweep;

namespace SonarSweepTest {
    public class SonarSweepTest {
        [Fact]
        public void Test1() {
            List<int> data = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int result = SonarSweepUtils.CountMeasurementIncreases(data);
            Assert.Equal(7, result);
        }
    }
}
