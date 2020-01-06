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

            if (currentChest.Coin > 0)
                Debug.Log("Dinheiro: " + currentChest.Coin);
            if (currentChest.HealValue > 0)
                Debug.Log("Vida: " + currentChest.HealValue);
            if (currentChest.XP > 0)
                Debug.Log("XP: " + currentChest.XP);

            // randomiza quais dos feiticos possiveis podem sair
            if (currentChest.Feiticos.Count > 0) {

                int typeIndex = Random.Range(0, currentChest.Feiticos.Count);

                // cria o feitico
                GameObject Spell = SpellManager.Instance.CreateSpell(currentChest.Feiticos[typeIndex]);

                if (Spell != null) {
                    Debug.Log("Feitiços: " + currentChest.Feiticos[typeIndex]);
                } else {
                    Debug.Log("Limite de feitiços atingido");
                }

                // Adiciona o feitico a lista de feiticos

            }

            //Tocar animação do bau abrindo
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Animator>().Play("Bau-Open");

            PlayerInstance.Instance.Keys -= 1;
            ExperienceManager.Instance.UpdateUI();
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
