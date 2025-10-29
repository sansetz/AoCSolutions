using SeaCucumber;

namespace SeaCucumberTest {
    public class SonarSweepTests {
        [Fact]
        public void TestSeaCucumberOutput() {
            string[] seaCucumberData = new string[]
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

            int result = SeaCucumberUtils.MoveCucumbers(seaCucumberData, false);
            Assert.Equal(58, result);
        }
    }
}
