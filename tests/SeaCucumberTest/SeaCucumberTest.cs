using SeaCucumber;

namespace SeaCucumberTest {
    public class SonarSweepTests {

        [Fact]
        public void TestPart1WithAoCData() {
            string[] inputData = new string[]
            {
                "v...>>.vv>",
                ".vv>>.vv..",
                ">>.>v>...v",
                ">>v>>.>.v.",
                "v>v.vv.v..",
                ">.>>..v...",
                ".vv..>.>v.",
                "v.v..>>v.v",
                "....v..v.>"
            };
            int result = SeaCucumberUtils.MoveCucumbers(inputData, false);
            Assert.Equal(58, result);
        }

        [Theory]
        [InlineData(new string[] { }, 0)]                // no data
        [InlineData(new string[] { "........." }, 1)]    // no cucumbers
        [InlineData(new string[] { ">>>>>>>>>" }, 1)]    // no empty spots
        public void TestPart1ForVariousEdgeCaseData(string[] input, int expectedResult) {
            int result = SeaCucumberUtils.MoveCucumbers(input, false);
            Assert.Equal(expectedResult, result);
        }
    }
}
