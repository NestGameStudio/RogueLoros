using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionFenix : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Fenix");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
