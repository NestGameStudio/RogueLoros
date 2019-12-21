using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionHeal : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Heal");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
