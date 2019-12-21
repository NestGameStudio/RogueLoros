using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionSuperArmor : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Super Armadura");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
