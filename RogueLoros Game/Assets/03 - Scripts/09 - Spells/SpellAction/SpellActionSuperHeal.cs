using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionSuperHeal : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Super Heal");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
