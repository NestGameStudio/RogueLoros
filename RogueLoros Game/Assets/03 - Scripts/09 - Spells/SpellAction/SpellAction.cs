using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellAction : MonoBehaviour {

    // Mudar para sprite no futuro
    public Color HUDImage;

    public virtual void DoAction() { }

    public virtual void EndAction() { }

}
