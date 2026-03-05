using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

// README.md를 읽고 아래에 코드를 작성하세요.

Celcius c = new Celcius(100);
Fahrenheit f = (Fahrenheit)c; // 암시적 변환
Console.WriteLine(c);
Console.WriteLine(f);

Vector3 v1 = new Vector3(1, 2, 3);
Vector3 v2 = new Vector3(4, 5, 6);

Console.WriteLine(v1 + v2);
Console.WriteLine(v1 - v2);
Console.WriteLine(v1 * 2);
Console.WriteLine(3 * v2);
Console.WriteLine(-v1);
Console.WriteLine(v1 == v2);



struct Celcius
{
    public double Degrees;

    public Celcius(double degrees)
    {
        Degrees = degrees;
    }

    public static implicit operator Fahrenheit(Celcius c)
    {
        return new Fahrenheit(c.Degrees * 9 / 5 + 32);
    }
    public static implicit operator Celcius(Fahrenheit f)
    {
        return new Celcius((f.Degrees - 32) * 5 / 9);
    }

    public override string ToString()
    {
        return $"{Degrees} °C";
    }
}

struct Fahrenheit
{
    public double Degrees;

    public Fahrenheit(double degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return $"{Degrees} °F";
    }

}

struct Vector3
{
    public double X;
    public double Y;
    public double Z;

    public Vector3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)  // 덧셈
    {
        return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)  // 뺄셈
    {
        return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3 operator *(Vector3 v, float scalar)   // 스칼라곱
    {
        return new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static Vector3 operator *(float scalar, Vector3 v)   // 스칼라곱 양방향
    {
        return v * scalar;
    }

    public static Vector3 operator -(Vector3 v) // 단항 음수
    {
        return new Vector3(-v.X, -v.Y, -v.Z);
    }

    public static bool operator ==(Vector3 a, Vector3 b)  // 동등 비교
    {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }
    public static bool operator !=(Vector3 a, Vector3 b)  // 동등 비교
    {
        return !(a == b);
    }
    public override bool Equals(object obj)
    {
        if (obj is Vector3 other)
        {
            return this == other;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }


}