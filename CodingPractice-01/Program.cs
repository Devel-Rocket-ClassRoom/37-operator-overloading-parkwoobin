using System;

// README.md를 읽고 아래에 코드를 작성하세요.


Counter c = new Counter(5);
Console.WriteLine(-c); // 5
c++;
Console.WriteLine(c); // 6

Fraction f = new Fraction(1, 2);
Fraction g = new Fraction(1, 3);
Console.WriteLine(f + g); // 5/6
Console.WriteLine(f * g); // 1/6

Money m1 = new Money(1000, "KRW");
Money m2 = new Money(2000, "KRW");
Console.WriteLine(m1 == m2); // False
Console.WriteLine(m1 != m2); // True

Vector2 v1 = new Vector2(1, 2);
v1 += new Vector2(3, 4);
Console.WriteLine(v1); // (4, 6)

Celcius temp = 36.5;
double value = temp;
Console.WriteLine(value);






struct Counter
{
    public int Value;

    public Counter(int v)
    {
        Value = v;
    }

    public static Counter operator -(Counter c)
    {
        return new Counter(-c.Value);
    }

    public static Counter operator ++(Counter c)
    {
        return new Counter(c.Value + 1);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}


struct Fraction
{
    public int Numerator;
    public int Denominator;

    public Fraction(int n, int d)
    {
        Numerator = n;
        Denominator = d;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int Numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int Denominator = a.Denominator * b.Denominator;
        return new Fraction(Numerator, Denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}


struct Money
{
    public decimal Amount;
    public string Currency;

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static bool operator ==(Money a, Money b)
    {
        return a.Currency == b.Currency && a.Amount == b.Amount;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }
    public static bool operator >(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("통화가 다릅니다.");
        }
        return a.Amount > b.Amount;
    }
    public static bool operator <(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("통화가 다릅니다.");
        }
        return a.Amount < b.Amount;
    }

    public override bool Equals(object obj)
    {
        if (obj is Money money)
        {
            return this == money;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}

struct Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

struct Celcius
{
    public double Degrees;

    public Celcius(double degrees)
    {
        Degrees = degrees;
    }

    // double -> Celcius
    public static implicit operator Celcius(double d)
    {
        return new Celcius(d);
    }

    // Celcius -> double
    public static implicit operator double(Celcius c)
    {
        return c.Degrees;
    }
}