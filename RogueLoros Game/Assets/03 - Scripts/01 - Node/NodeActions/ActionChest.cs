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

            // fazer algo para acrescentar feitiço

            PlayerInstance.Instance.Keys -= 1;
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
