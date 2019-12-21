﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyInstance : MonoBehaviour
{
    // elementos da HUD do inimigo
    public Image HUDArt;
    public TMP_Text HUDLife;
    public TMP_Text HUDAttack;

    // Faz os ajustes de dificuldade - poe o inimigo no preset certo dele
    public Enemy[] EnemyTypesEasy;
    public Enemy[] EnemyTypesMedium;
    public Enemy[] EnemyTypesHard;
    public Enemy[] EnemyBoss;

    // tem uma funcao onde quando é intanciado e é boss, carrega os dados do boss
    [HideInInspector]
    public bool isBossNode = false;

    // Informações do inimigo
    [HideInInspector] public Sprite Art;
    [HideInInspector] public int Life = 0;
    [HideInInspector] public int AttackMin = 0;
    [HideInInspector] public int AttackMax = 0;
    [HideInInspector] public int XPDrop = 0;
    [HideInInspector] public int CoinDrop = 0;

    private Enemy currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        // Se eu tirar isso vai dar merda?
        isBossNode = false;
        setInitialState();

        // If the node is the initial node this does apply
        DisplayInHUD();
    }

    private void setInitialState() {

        // Randomiza um inimigo
        if (isBossNode) {
            int run = RunManager.Instance.getCurrentRun();

            switch (run) {
                case 1:
                    currentEnemy = EnemyBoss[0];
                    break;
                case 2:
                    currentEnemy = EnemyBoss[1];
                    break;
                case 3:
                    currentEnemy = EnemyBoss[2];
                    break;
                default:
                    currentEnemy = EnemyBoss[0];
                    break;
            }

        // é um inimigo comum
        } else {

            Difficulty difficulty = DifficultyManager.Instance.currentDifficulty;

            switch (difficulty)
            {
                case Difficulty.Easy:
                    currentEnemy = EnemyTypesEasy[Random.Range(0, EnemyTypesEasy.Length)];
                    break;
                case Difficulty.Medium:
                    currentEnemy = EnemyTypesMedium[Random.Range(0, EnemyTypesMedium.Length)];
                    break;
                case Difficulty.Hard:
                    currentEnemy = EnemyTypesHard[Random.Range(0, EnemyTypesHard.Length)];
                    break;
                default:
                    currentEnemy = EnemyTypesEasy[Random.Range(0, EnemyTypesEasy.Length)];
                    break;
            }
        }

        // Seta os valores iniciais do inimigo
        Art = currentEnemy.Image;
        Life = currentEnemy.Life;
        AttackMin = currentEnemy.AttackMin;
        AttackMax = currentEnemy.AttackMax;
        XPDrop = currentEnemy.XPDrop;
        CoinDrop = currentEnemy.CoinDrop;

    }

    private void DisplayInHUD() {

        Debug.Log(currentEnemy.Life);

        if (Art) {
            HUDArt.sprite = Art;
        }
        HUDLife.text = Life.ToString();
        HUDAttack.text = AttackMin.ToString() + " - " + AttackMax.ToString();
    }

}
