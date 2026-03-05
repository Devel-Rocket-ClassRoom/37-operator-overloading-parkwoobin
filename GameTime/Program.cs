using System;

// README.md를 읽고 코드를 작성하세요.

struct GameTime
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    public GameTime(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Normalize();
    }

    private void Normalize()    // S 60이상 M 60 이상일시 자동 올림 정규화
    {
        while (Seconds >= 60)
        {
            Seconds -= 60;
            Minutes++;
        }

        while (Minutes >= 60)
        {
            Minutes -= 60;
            Hours++;
        }
    }

    public static GameTime operator +(GameTime a, GameTime b)   // +
    {
        return new GameTime(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);
    }

    public static GameTime operator -(GameTime a, GameTime b) // -
    {
        if (a.Hours - b.Hours < 0 || a.Minutes - b.Minutes < 0)
        {
            return new GameTime(0, 0, 0);
        }
        return new GameTime(a.Hours - b.Hours, a.Minutes - b.Minutes, a.Seconds - b.Seconds);
    }

    public static bool operator ==(GameTime a, GameTime b)
    {
        return a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds;
    }
    public static bool operator !=(GameTime a, GameTime b)
    {
        return !(a == b);
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        return a.GetTotalSeconds() > b.GetTotalSeconds();
    }


    public static bool operator <(GameTime a, GameTime b)
    {
        return a.GetTotalSeconds() < b.GetTotalSeconds();
    }

    public static GameTime operator *(GameTime now, int num)
    {
        return new GameTime(0, 0, now.GetTotalSeconds() * num);
    }


    public override bool Equals(object obj)
    {
        if (obj is GameTime)
        {
            GameTime other = (GameTime)obj;
            return this == other;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }

    public override string ToString()
    {
        return $"{Hours}h {Minutes}m {Seconds}s";
    }
    public int GetTotalSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }


}