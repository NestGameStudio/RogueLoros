using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionMegaFireball : SpellAction
{
    public override void DoAction() {
        base.DoAction();
        Debug.Log("Mega bola de fogo");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
