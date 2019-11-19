using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoints : Stats
{
    [Header("Attack Points Manager")]
    [Space(5)]

    [Tooltip("Valor que cresce assim que o jogador dá um level up nesse stat")]
    public int LinearAPMagnitudeUpgrade = 1;    // Mexe no valor minimo
    public int LinearAPAmplitudeUpgrade = 1;    // Mexe no valor maximo

    [Tooltip("Valor máximo de vida inicial")]
    public int MaxValueInLevel = 3;
    public int MinValueInLevel = 3;

    // -------- Funções relativas ao load de jogo -----------

    public override void LoadStat() {
        base.LoadStat();

        if (data != null) {

            int levelLimit = data.AttackLevel - currentLevel;

            for (int i = 0; i < levelLimit; i++) {
                IncreaseLevel();
            }
        }
    }

    // -------- Funções relativas aos valores de vida -----------

    override public void IncreaseLevel() {
        base.IncreaseLevel();

        // Se o level for par faz upgrade na amplitude
        if (currentLevel % 2 == 0) {
            MaxValueInLevel += LinearAPAmplitudeUpgrade;
            // Se o level for impar faz upgrade na magnitude
        } else {
            MinValueInLevel += LinearAPMagnitudeUpgrade;
        }

    }

    public int GetMaxPossibleAttackRange() {
        return MaxValueInLevel;
    }

    public int GetMinPossibleAttackRange() {
        return MinValueInLevel;
    }

    // -------- Funções relativas aos inimigos -----------

    // Para cada inimigo o valor de vida inicial depende da dificuldade 
    // Ter um array com os presets de dificuldade?
    public void SetInitialLevel(int difficulty) {

    }
}
