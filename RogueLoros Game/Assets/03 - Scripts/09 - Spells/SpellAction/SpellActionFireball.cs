using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionFireball : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Bola de fogo");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
