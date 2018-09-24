﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_tour
{
    public struct Point
    {
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Overload + operator to add two Point objects.
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public override string ToString()
        {
            return ("[" + X + "," + Y + "]");
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
