using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Planet : MonoBehaviour
{
    class Planet
    {
        int currencyHeld;
        int currencyIncome;
        int numberOfMercenaries;
        int fraction;
        bool motherPlanet;
        int maxNumberOfMercenaries = 10;

        public Planet(int held, int income, int mercenaries, int fraction, bool mother)
        {
            this.currencyHeld = held;
            this.currencyIncome = income;
            this.numberOfMercenaries = mercenaries;
            this.fraction = fraction;
            this.motherPlanet = mother;
        }
    }
}
