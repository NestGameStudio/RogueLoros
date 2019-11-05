using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGainLife : NodeAction {

    public override void DoAction() {
        base.DoAction();
        Debug.Log("GANHA VIDA");
    }

    public override void EndAction() {
        base.EndAction();
    }
}
