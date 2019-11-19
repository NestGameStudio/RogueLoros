using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPoints : Stats
{
    [Header("Magic Points Manager")]
    [Space(5)]

    [Tooltip("Valor que cresce assim que o jogador dá um level up nesse stat")]
    public int LinearMPMagnitudeUpgrade = 1;    // Mexe no valor minimo
    public int LinearMPAmplitudeUpgrade = 2;    // Mexe no valor maximo

    [Tooltip("Valor máximo de vida inicial")]
    public int MaxValueInLevel = 2;
    public int MinValueInLevel = 1;

    // -------- Funções relativas ao load de jogo -----------

    public override void LoadStat() {
        base.LoadStat();

        if (PlayerInstance.Instance.Data != null) {

            int levelLimit = PlayerInstance.Instance.Data.MagicLevel - currentLevel;

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
            MaxValueInLevel += LinearMPAmplitudeUpgrade;
        // Se o level for impar faz upgrade na magnitude
        } else {
            MinValueInLevel += LinearMPMagnitudeUpgrade;
        }
    }

    public int GetMaxPossibleMagicRange() {
        return MaxValueInLevel;
    }

    public int GetMinPossibleMagicRange() {
        return MinValueInLevel;
    }

}
