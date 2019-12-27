using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInstance : MonoBehaviour
{
    public Chest[] PossibleChestsEasy;
    public Chest[] PossibleChestsMedium;
    public Chest[] PossibleChestsHard;

    [HideInInspector] public Sprite Image;

    [HideInInspector] public int Coin = 0;
    [HideInInspector] public int HealValue = 0;
    [HideInInspector] public int XP = 0;

    // Feitico vai ser um scoobydoos sorteado entre alguns
    [HideInInspector] public int Feitico = 0;

    [HideInInspector] public Chest currentChest;

    private void Start()
    {
        setInitialState();
    }

    private void setInitialState() {

        Difficulty difficulty = DifficultyManager.Instance.currentDifficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                currentChest = PossibleChestsEasy[Random.Range(0, PossibleChestsEasy.Length)];
                break;
            case Difficulty.Medium:
                currentChest = PossibleChestsMedium[Random.Range(0, PossibleChestsMedium.Length)];
                break;
            case Difficulty.Hard:
                currentChest = PossibleChestsHard[Random.Range(0, PossibleChestsHard.Length)];
                break;
            default:
                currentChest = PossibleChestsEasy[Random.Range(0, PossibleChestsEasy.Length)];
                break;
        }

        // Seta os valores iniciais do inimigo
        Image = currentChest.Image;
        Coin = currentChest.Coin;
        HealValue = currentChest.HealValue;
        XP = currentChest.XP;
        Feitico = currentChest.Feitico;
    }


}
