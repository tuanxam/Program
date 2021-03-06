using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculation 
{
   
    public static float DamgeTaken(float attack, float def)
    {
        return attack -= (attack * def / 100);
    }

    public static int TotalCostBought(float costTurret, float costUpgrade, int level)
    {
        return (int)costTurret + (int)costUpgrade * level;
    }

    public static int ReturnCoinSold(int coin)
    {
        return  coin * 30 / 100;
    }

    public static float AttackUpgrade(float attack)
    {
        return attack += attack * 20 / 100;
    }

    public static string GetSuffix(int num)
    {
        string suffix = "";
        string s = num.ToString();

        if (num < 10000) return num.ToString();

        switch ((s.Length - 1) / 3)
        {
            case 0:
                suffix = string.Empty;
                break;
            case 1:
                suffix = "K";
                break;
            case 2:
                suffix = "M";
                break;
            case 3:
                suffix = "B";
                break;
            case 4:
                suffix = "T";
                break;
            case 5:
                suffix = "Qa";
                break;
            case 6:
                suffix = "Qi";
                break;
            case 7:
                suffix = "S";
                break;
        }

        if (s.Length % 3 == 1)
            return s.Substring(0, 1) + "." + s.Substring(1, 1) + s.Substring(2, 1) + suffix; // 4.35m

        if (s.Length % 3 == 2)
            return s.Substring(0, 1) + s.Substring(1, 1) + "." + s.Substring(2, 1) + suffix; // 4.35m

        if (s.Length % 3 == 0)
            return s.Substring(0, 1) + s.Substring(1, 1) + s.Substring(2, 1) + suffix; // 4.35m

        return "";
    }
}
