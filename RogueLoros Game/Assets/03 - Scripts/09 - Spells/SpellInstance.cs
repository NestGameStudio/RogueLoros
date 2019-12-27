using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInstance : MonoBehaviour
{
    // criar um controller na HUD de spells pra organizar a forma que eles aparecem, entram e saem dessa HUD
    // os botoes da HUd vão ter uma função de tap que ativa a spell
    // Vao ter feiticos que vc escolhe qual inimigo voce vai usar o feitico contra (caso tenha mais de um na linha de alcance)
    // Tem feitições que são só usar

    [SerializeField]
    public List<GameObject> SpellTypes;

    private SpellType currentType = SpellType.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
