using NUnit.Framework;

namespace global_geodetic_tiles_tests
{
    public class Tests
    {
        [Test]
        public void LonLatToTileTest()
        {
            (int tx, int ty) = GlobalGeodetic.GlobalGeodetic.LonLatToTile(5.116882, 51.926908, 10);
            Assert.IsTrue(tx == 1053);
            Assert.IsTrue(ty == 807);
        }

        [Test]
        public void Test1()
        {
            (int x, int y) = GlobalGeodetic.GlobalGeodetic.LonLatToTile(5.116882, 51.926908,10);
            Assert.IsTrue(x > 0);
            Assert.IsTrue(y > 0);
        }

        [Test]
        public void ResolutionTest()
        {
            var resolution = GlobalGeodetic.GlobalGeodetic.Resolution(10);
            Assert.IsTrue(resolution == 0.0006866455078125);
        }

        [Test]
        public void LonLatToPixelsTests()
        {
            (double px, double py) = GlobalGeodetic.GlobalGeodetic.LonLatToPixels(5.116882, 51.926908, 10);
            Assert.IsTrue(px == 269595.99952782225);
            Assert.IsTrue(py == 206696.04094862222);
        }

        [Test]
        public void PixelToTileTests()
        {
            (int tx, int ty) = GlobalGeodetic.GlobalGeodetic.PixelsToTile(269595.99952782225, 206696.04094862222);
            Assert.IsTrue(tx == 1053);
            Assert.IsTrue(ty == 807);
        }

        [Test]
        public void TileBoundsTests()
        {
            var z = 10;
            var x = 1563;
            var y = 590;
            var bounds = GlobalGeodetic.GlobalGeodetic.TileBounds(x, y, z);
            Assert.IsTrue(bounds[0] == 94.74609375);
            Assert.IsTrue(bounds[1] == 13.7109375);
            Assert.IsTrue(bounds[2] == 94.921875);
            Assert.IsTrue(bounds[3] == 13.88671875);
        }

        [Test]
        public void GetNumberOfTilesAtZoomTest()
        {
            Assert.IsTrue(GlobalGeodetic.GlobalGeodetic.GetNumberOfXTilesAtZoom(10)== 2048);
            Assert.IsTrue(GlobalGeodetic.GlobalGeodetic.GetNumberOfYTilesAtZoom(10) == 1024);
        }
    }
}