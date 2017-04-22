using System;

namespace Gridness.Models
{
    public struct Coordinate : IEquatable<Coordinate>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordinate(double X, double Y)
        {
            this.X = X;
            this.Y = Y;

            Z = -X - Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;

                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate && Equals((Coordinate)obj);
        }

        public bool Equals(Coordinate second)
        {
            return X == second.X && Y == second.Y && Z == second.Z;
        }
    }
}
