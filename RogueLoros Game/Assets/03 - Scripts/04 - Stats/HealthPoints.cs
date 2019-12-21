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

        if (PlayerInstance.Instance.Data != null) {

            int levelLimit = PlayerInstance.Instance.Data.HealthLevel - currentLevel;

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

    public void SetInitialLife(int value) {
		currentValue = value;
	}

    public int GetMaxPossibleLife() {
        return MaxValueInLevel;
    }

    public void IncreaseLifePoints(int value) {

        if (currentValue < MaxValueInLevel) {
            currentValue += value;

            // verifica se a vida não aumentou mais que o normal possivel
            if (currentValue > MaxValueInLevel) {
                currentValue = MaxValueInLevel;
            }
        }
        ExperienceManager.Instance.UpdateUI();
    }

    public void DecreaseLifePoints(int value) {

        if (currentValue > 0) {
            currentValue -= value;

            // verifica se a vida não aumentou mais que o normal possivel
            if (this.GetComponent<PlayerInstance>()) {
                if (currentValue <= 0) {
                    currentValue = 0;
                    RunManager.Instance.LoseRun();
                }
            }
        }

        ExperienceManager.Instance.UpdateUI();
    }

    // -------- Funções relativas aos inimigos -----------

    // Para cada inimigo o valor de vida inicial depende da dificuldade 
    // Ter um array com os presets de dificuldade?
    public void SetInitialLevel(int difficulty) {

    }


}
