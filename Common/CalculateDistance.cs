using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMarket.Common
{
    public class CalculateDistance
    {
        /// <summary>
        /// The units of measure when calculating distance between 2 coordinates
        /// </summary>
        public enum MeasureUnits { Miles, Kilometers };
        /// <summary>
        /// Gets or sets the latitude of the coordinate.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the coordinate.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public CalculateDistance(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Calculates the approximate birds-flight distance between this coordinate and the coordinate in the parameter
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <param name="units">The units to measure in</param>
        /// <returns></returns>
        public double DistanceFrom(CalculateDistance coordinate, MeasureUnits units)
        {
            double earthRadius = (units == MeasureUnits.Miles) ? 3960 : 6371;
            double dLat = Deg2Rad(coordinate.Latitude - Latitude);
            double dLon = Deg2Rad(coordinate.Longitude - Longitude);
            double a = Math.Sin(dLat / 2) *
                       Math.Sin(dLat / 2) +
                       Math.Cos(Deg2Rad(Latitude)) *
                       Math.Cos(Deg2Rad(coordinate.Latitude)) *
                       Math.Sin(dLon / 2) *
                       Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = earthRadius * c;
            return d;
        }

        /// <summary>
        /// Converts from Degrees to Radians
        /// </summary>
        /// <param name="deg">The degrees</param>
        /// <returns>The radians</returns>
        private double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

    }
}