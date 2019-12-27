using System.Collections;
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

            // randomiza quais dos feiticos possiveis podem sair
            if (currentChest.Feiticos.Length > 0) {

                int typeIndex = Random.Range(0, currentChest.Feiticos.Length);

                // cria o feitico
                GameObject Spell = SpellManager.Instance.CreateSpell(currentChest.Feiticos[typeIndex]);

                // Verifica quantos espacos vazios ainda tem na HUD de feiticos
                // Adiciona o feitico a lista de feiticos

            }

            PlayerInstance.Instance.Keys -= 1;
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
