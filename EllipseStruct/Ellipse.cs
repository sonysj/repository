using System;

namespace EllipseStruct
{
    public struct Ellipse
    {
        private double a;
        private double b;

        public double A
        {
            get => a;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось A должна быть положительным числом");
                a = value;
            }
        }

        public double B
        {
            get => b;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось B должна быть положительным числом");
                b = value;
            }
        }

        public double E
        {
            get
            {
                if (A >= B)
                    return Math.Sqrt((A * A) - (B * B)) / A;
                else
                    return Math.Sqrt((B * B) - (A * A)) / B;
            }
        }

        public double Area
        {
            get => Math.PI * A * B;
        }

        public Ellipse(double a, double b) : this()
        {
            A = a;
            B = b;
        }

        public override string ToString()
        {
            string aStr = A.ToString().Replace(',', '.').Replace(".", ".");
            string bStr = B.ToString().Replace(',', '.').Replace(".", ".");
            return $"Эллипс с полуосями a = {aStr} и b = {bStr}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ellipse))
                throw new ArgumentException("Объект для сравнения не является эллипсом");

            Ellipse other = (Ellipse)obj;
            const double tolerance = 1e-13;
            return Math.Abs(A - other.A) < tolerance && Math.Abs(B - other.B) < tolerance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int prime = 23;
                hash = hash * prime + A.GetHashCode();
                hash = hash * prime + B.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Ellipse x, Ellipse y) => x.Equals(y);
        public static bool operator !=(Ellipse x, Ellipse y) => !x.Equals(y);

        public static Ellipse operator *(double k, Ellipse ellipse)
        {
            if (k <= 0)
                throw new ArgumentException("Коэффициент масштабирования должен быть положительным");

            return new Ellipse(k * ellipse.A, k * ellipse.B);
        }

        public static Ellipse operator *(Ellipse ellipse, double k) => k * ellipse;
    }
}