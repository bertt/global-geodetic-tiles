# global-geodetic-tiles

Functions for global geodetic tiling profile.  The global geodetic tiling profile uses the TMS tiling schema (origin [0,0] in bottom-left) but the pyramid has on top level two tiles, so it is not square but rectangle. Area [-180,-90,180,90] is scaled to 512x256 pixels. 

Inspired on functions in https://quantized-mesh-tile.readthedocs.io/en/latest/globalgeodetic.html

NuGet package: https://www.nuget.org/packages/global-geodetic-tiles

Functions:

- public static int GetNumberOfXTilesAtZoom( int zoom)

- public static int GetNumberOfYTilesAtZoom(int zoom)

- public static (double px, double py) LonLatToPixels(double lon, double lat, int zoom)

- public static (int x, int y) LonLatToTile(double lon, double lat, int zoom)

- public static (int x, int y) PixelsToTile(double px, double py)

- public static double[] TileBounds(int tx, int ty, int zoom)

- public static double Resolution(int level)
