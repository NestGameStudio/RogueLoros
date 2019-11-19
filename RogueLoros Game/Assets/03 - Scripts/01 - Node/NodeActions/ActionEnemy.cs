using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEnemy : NodeAction
{
    public override void DoAction() {
        base.DoAction();

        Debug.Log("Combate");
        ExperienceManager.Instance.IncreaseXPPoints(100);

    }

    public override void EndAction() {
        base.EndAction();
    }
}
