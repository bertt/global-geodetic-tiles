using System;

namespace GlobalGeodetic
{
    // methods from: https://quantized-mesh-tile.readthedocs.io/en/latest/globalgeodetic.html
    public static class GlobalGeodetic
    {
        private static int tileSize = 256;
        private static double resFact = 180.0 / tileSize;
        private static int numberOfLevelZeroTilesX = 2;
        private static int numberOfLevelZeroTilesY = 1;

        // Returns the number of tiles over x at a given zoom level (only 256px)
        public static int GetNumberOfXTilesAtZoom( int zoom)
        {
            return numberOfLevelZeroTilesX << zoom;
        }

        // Returns the number of tiles over y at a given zoom level (only 256px)
        public static int GetNumberOfYTilesAtZoom(int zoom)
        {
            return numberOfLevelZeroTilesY << zoom;
        }

        public static (double px, double py) LonLatToPixels(double lon, double lat, int zoom)
        {
            var res = resFact / Math.Pow(2, zoom);
            var px = (180 + lon) / res;
            var py = (90 + lat) / res;
            return (px, py);
        }

        // Returns the tile for zoom which covers given lon/lat coordinates
        public static (int x, int y) LonLatToTile(double lon, double lat, int zoom)
        {
            (double px, double py) = LonLatToPixels(lon, lat, zoom);
            return PixelsToTile(px, py);
        }

        // Returns coordinates of the tile covering region in pixel coordinates
        public static (int x, int y) PixelsToTile(double px, double py)
        {
            var tx = Convert.ToInt32(Math.Ceiling((float)px / tileSize) - 1);
            var ty = Convert.ToInt32(Math.Ceiling((float)py / tileSize) - 1); 
            return (tx, ty);
        }

        // Returns bounds of the given tile
        public static double[] TileBounds(int tx, int ty, int zoom)
        {
            var res = resFact / Math.Pow(2, zoom);

            var xmin = tx * tileSize * res - 180;
            var ymin = ty * tileSize * res - 90;
            var xmax = (tx + 1) * tileSize * res - 180;
            var ymax = (ty + 1) * tileSize * res - 90;
            return new double[] { xmin, ymin, xmax, ymax };
        }

        // Resolution (arc/pixel) for given zoom level (measured at Equator)
        public static double Resolution(int level)
        {
            return (resFact / Math.Pow(2, level));
        }
    }
}
