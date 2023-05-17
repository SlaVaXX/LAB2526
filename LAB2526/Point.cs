using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB2526
{
    class Point<T>
    {
        private T CoordinateX;
        private T CoordinateY;
        public T GetCoordinateX => CoordinateX;
        public T GetCoordinateY => CoordinateY;

        public Point(T coordinateX, T coordinateY)
        {
            string coordinateXType = coordinateX.GetType().ToString();
            string coordinateYType = coordinateY.GetType().ToString();
            if (!(coordinateXType == "System.Single" || coordinateXType == "System.Double" || coordinateXType == "System.Decimal")
                && (!(coordinateYType == "System.Single" || coordinateYType == "System.Double" || coordinateYType == "System.Decimal")))
            {
                throw new ArgumentException("\nNot a floating point type!");
            }

            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public Point()
        {
        }
    }
}