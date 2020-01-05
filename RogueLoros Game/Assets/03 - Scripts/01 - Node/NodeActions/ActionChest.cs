﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChest : NodeAction {

    private ChestInstance currentChest;

    public override void DoAction() {
        base.DoAction();

        currentChest = this.GetComponent<ChestInstance>();

        // Ganha itens do chest se tiver uma chave
        if (PlayerInstance.Instance.Keys > 0) {

            PlayerInstance.Instance.IncreaseMoney(currentChest.Coin);
            PlayerInstance.Instance.IncreaseHealth(currentChest.HealValue);
            ExperienceManager.Instance.IncreaseXPPoints(currentChest.XP);

            Debug.Log("Dinheiro: " + currentChest.Coin);
            Debug.Log("Vida: " + currentChest.HealValue);
            Debug.Log("XP: " + currentChest.XP);

            // randomiza quais dos feiticos possiveis podem sair
            if (currentChest.Feiticos.Count > 0) {

                int typeIndex = Random.Range(0, currentChest.Feiticos.Count);

                // cria o feitico
                GameObject Spell = SpellManager.Instance.CreateSpell(currentChest.Feiticos[typeIndex]);

                Debug.Log("Feitiços: " + currentChest.Feiticos[typeIndex]);

                // Verifica quantos espacos vazios ainda tem na HUD de feiticos
                // Adiciona o feitico a lista de feiticos

            }

            // fazer algo para acrescentar feitiço

            //Tocar animação do bau abrindo
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Animator>().Play("Bau-Open");

            PlayerInstance.Instance.Keys -= 1;
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
