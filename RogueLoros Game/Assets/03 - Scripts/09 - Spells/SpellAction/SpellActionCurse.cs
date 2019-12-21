using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionCurse : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Maldicao");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
