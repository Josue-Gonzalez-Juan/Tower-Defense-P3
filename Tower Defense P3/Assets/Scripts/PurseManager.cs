using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseManager : MonoBehaviour
{
    public int coins;

    public bool PlaceTower(int amountOfCashRequired)
    {
        if (coins - amountOfCashRequired >= 0)
        {
            coins -= amountOfCashRequired;
            return true;
        }

        return false;
    }
}
