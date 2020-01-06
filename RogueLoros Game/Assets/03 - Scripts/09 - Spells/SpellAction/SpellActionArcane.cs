using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionArcane : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Arcana");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
