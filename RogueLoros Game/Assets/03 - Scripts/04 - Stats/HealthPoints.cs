using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints: Stats {

    [Header("Health Points Manager")]
    [Space(5)]

    [Tooltip ("Valor que cresce assim que o jogador dá um level up nesse stat")]
    public int LinearHPMaxValueIncreasePerLevel = 1;

    [Tooltip("Valor máximo de vida inicial")]
    public int MaxValueInLevel = 3;

    private int currentValue = 3;

    // -------- Funções relativas ao load de jogo -----------

    public override void LoadStat() {
        base.LoadStat();

        SaveData data = SaveSystem.LoadData();

        if (data != null) {

            int levelLimit = data.HealthLevel - currentLevel;

            for (int i = 0; i < levelLimit; i++) {
                IncreaseLevel();
            }
        }
    }

    // -------- Funções relativas aos valores de vida -----------

    override public void IncreaseLevel() {
        base.IncreaseLevel();

        MaxValueInLevel += LinearHPMaxValueIncreasePerLevel;
    }

    public int GetCurrentLife() {
        return currentValue;
    }

    public int GetMaxPossibleLife() {
        return MaxValueInLevel;
    }

    // -------- Funções relativas aos inimigos -----------

    // Para cada inimigo o valor de vida inicial depende da dificuldade 
    // Ter um array com os presets de dificuldade?
    public void SetInitialLevel(int difficulty) {

    }


}
