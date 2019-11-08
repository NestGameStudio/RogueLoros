using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEnemy : NodeAction
{
    public override void DoAction() {
        base.DoAction();

        Debug.Log("Perde vida");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
