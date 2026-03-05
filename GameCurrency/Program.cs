using System;

// README.md를 읽고 코드를 작성하세요.


struct GameCurrency
{
    public int Gold;
    public int Silver;

    public GameCurrency(int gold, int silver)
    {
        Gold = gold;
        if (silver >= 100)
        {
            Gold += silver / 100;
            Silver = silver % 100;
        }
        else
        {
            Silver = silver;
        }
    }




    public static GameCurrency operator +(GameCurrency a, GameCurrency b)   // +
    {
        return new GameCurrency(a.Gold + b.Gold, a.Silver + b.Silver);
    }

    public static GameCurrency operator -(GameCurrency a, GameCurrency b) // -
    {
        if (a.Gold - b.Gold < 0 || a.Silver - b.Silver < 0)
        {
            return new GameCurrency(0, 0);
        }
        return new GameCurrency(a.Gold - b.Gold, a.Silver - b.Silver);
    }

    public static bool operator ==(GameCurrency a, GameCurrency b)
    {
        return a.Gold == b.Gold && a.Silver == b.Silver;
    }
    public static bool operator !=(GameCurrency a, GameCurrency b)
    {
        return !(a == b);
    }

    public static bool operator >(GameCurrency a, GameCurrency b)
    {
        return a.GetTotalSilver() > b.GetTotalSilver();
    }

    public static bool operator <(GameCurrency a, GameCurrency b)
    {
        return a.GetTotalSilver() < b.GetTotalSilver();
    }


    public override bool Equals(object obj)
    {
        if (obj is GameCurrency)
        {
            GameCurrency other = (GameCurrency)obj;
            return this == other;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Gold, Silver);
    }

    public override string ToString()
    {
        return $"{Gold}G {Silver}S";
    }


    public int GetTotalSilver()
    {
        return Gold * 100 + Silver;
    }
}