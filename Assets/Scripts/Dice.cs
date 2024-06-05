using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Dice instance;
    public DiceRoller diceRoller;
    public Roulette roulette;
    public GameObject diceObj;
    private void Awake()
    {
        instance = this;
    }
    public int GetRoll()
    {
        diceObj.SetActive(true);
        int r = Random.Range(1, 6);
        
        // diceRoller.Roll(r);
        roulette.Rotete();
        return r;
    }
}
