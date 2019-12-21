using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionArmor : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Armadura");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
