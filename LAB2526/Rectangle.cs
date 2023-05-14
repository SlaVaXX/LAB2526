using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB2526
{
    class Rectangle<T> where T : notnull
    {
        private Point<T> TopLeft = new Point<T>();
        private Point<T> BottomLeft = new Point<T>();
        private Point<T> TopRight = new Point<T>();
        private Point<T> BottomRight = new Point<T>();
        private Point<float> Center = new Point<float>();

        private float LeftSideLength;
        private float TopSideLength;
        private float RightSideLength;
        private float BottomSideLength;

        public float GetLeftSideLength => LeftSideLength;
        public float GetTopSideLength => TopSideLength;
        public float GetRightSideLength => RightSideLength;
        public float GetBottomSideLength => BottomSideLength;
        public Rectangle(T TopLeftX, T TopLeftY, T BottomLeftX, T BottomLeftY, T BottomRightX, T BottomRightY)
        {
            string CurrentType = TopLeftX.GetType().ToString();
            if (!(CurrentType == "System.Single" || CurrentType == "System.Double" || CurrentType == "System.Decimal"))
            {
                throw new Exception("Not a floating point type!");
            }
            Vector2 TopLeft = new Vector2(Convert.ToSingle(TopLeftX), Convert.ToSingle(TopLeftY));
            Vector2 BottomLeft = new Vector2(Convert.ToSingle(BottomLeftX), Convert.ToSingle(BottomLeftY));
            Vector2 BottomRight = new Vector2(Convert.ToSingle(BottomRightX), Convert.ToSingle(BottomRightY));

            Vector2 Side1 = TopLeft - BottomLeft;      // |
            Vector2 Side2 = BottomRight - BottomLeft;  // _
            Vector2 Hypotenuse = BottomRight - TopLeft;// \

            float Side1Length = Side1.Length();
            float Side2Length = Side2.Length();
            float HypotenuseLength = Hypotenuse.Length();

            Vector2 Side1Normalized = Vector2.Normalize(Side1);
            Vector2 Side2Normalized = Vector2.Normalize(Side2);
            Vector2 HypotenuseNormalized = Vector2.Normalize(Hypotenuse);


            float Side1HypotenuseAngle = (float)Math.Round(ConvertRadiansToDegrees(Math.Acos(Vector2.Dot(-Side1Normalized, HypotenuseNormalized))), 1);
            float Side2HypotenuseAngle = (float)Math.Round(ConvertRadiansToDegrees(Math.Acos(Vector2.Dot(Side2Normalized, HypotenuseNormalized))), 1);

            if (
                Side1Length > (Side2Length + HypotenuseLength) || (Side2Length > (Side1Length + HypotenuseLength) || HypotenuseLength > (Side1Length + Side2Length))
                || (Side1HypotenuseAngle + Side2HypotenuseAngle) != 90
                )
            {
                throw new Exception("Not a right triangle!");
            }

            this.TopLeft = new Point<T>(TopLeftX, TopLeftY);
            this.BottomLeft = new Point<T>(BottomLeftX, BottomLeftY);
            this.BottomRight = new Point<T>(BottomRightX, BottomRightY);
            this.TopRight = new Point<T>(BottomRightX, TopLeftY);
            this.Center = new Point<float>((Convert.ToSingle(TopRight.GetCoordinateX) - Convert.ToSingle(BottomLeft.X)) / 2, (Convert.ToSingle(TopRight.GetCoordinateY) - BottomLeft.Y) / 2);
            LeftSideLength = new Vector2(Convert.ToSingle(TopLeftX), Convert.ToSingle(TopLeftY)).Length();
            RightSideLength = LeftSideLength;
            BottomSideLength = new Vector2(Convert.ToSingle(BottomRightX), Convert.ToSingle(BottomRightY)).Length();
            TopSideLength = BottomSideLength;

        }
        public Rectangle()
        {

        }
        private double ConvertRadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }
        public float Area()
        {
            return (float)Math.Round(LeftSideLength * BottomSideLength, 1);
        }

        public float Perimeter()
        {
            return (float)Math.Round(2 * LeftSideLength + 2 * BottomSideLength, 1);
        }
        public static Rectangle<T> NewRectangle(T TopLeftX, T TopLeftY, T BottomLeftX, T BottomLeftY, T BottomRightX, T BottomRightY)
        {
            return new Rectangle<T>(TopLeftX, TopLeftY, BottomLeftX, BottomLeftY, BottomRightX, BottomRightY);
        }
        public void PrintCoordinates()
        {
            Console.WriteLine($"\nКоординати лівої вершньої вершини = <{TopLeft.GetCoordinateX}|{TopLeft.GetCoordinateY}>");
            Console.WriteLine($"\nКоординати лівої нижньої вершини = <{BottomLeft.GetCoordinateX}|{BottomLeft.GetCoordinateY}>");
            Console.WriteLine($"\nКоординати правої вершньої вершини = <{TopRight.GetCoordinateX}|{TopRight.GetCoordinateY}>");
            Console.WriteLine($"\nКоординати правої нижньої вершини = <{BottomRight.GetCoordinateX}|{BottomRight.GetCoordinateY}>");
        }
    }
}
