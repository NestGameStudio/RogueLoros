using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionProtection : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Protecao");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
