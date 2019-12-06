using System;

namespace ReadOnlyVectorTask
{
    public class Segment
    {
        public readonly Vector Begin;
        public readonly Vector End;

        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }

        public Segment(double beginX, double beginY, double endX, double endY)
        {
            Begin = new Vector(beginX, beginY);
            End = new Vector(endX, endY);
        }

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }

    public class Vector
    {
        public readonly double X;
        public readonly double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y);
        }

        public Vector WithX(double x)
        {
            return new Vector(x, Y);
        }

        public Vector WithY(double y)
        {
            return new Vector(X, y);
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.X + secondVector.X,
                              firstVector.Y + secondVector.Y);
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(
                (segment.End.X - segment.Begin.X) * (segment.End.X - segment.Begin.X)
                + (segment.End.Y - segment.Begin.Y) * (segment.End.Y - segment.Begin.Y));
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(vector.X - segment.Begin.X, 2)
                + Math.Pow(vector.Y - segment.Begin.Y, 2))
                + Math.Sqrt(Math.Pow(segment.End.X - vector.X, 2)
                + Math.Pow(segment.End.Y - vector.Y, 2))
                - GetLength(segment)) < double.Epsilon;
        }
    }
}
