using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Stats: MonoBehaviour {

    // Se a progressão disso for igual pra todos os levels ele precisa estar no experience Manager - Serviria só para isso na real
    // Para health ele iria crescer linearmente
    // Para o dano e feitiço ele teria um valor de aumento de amplitude e outro de magnitude

    [Header("Experience Manager")]
    [Space(5)]

    [NamedListAttribute("Next Level Up XP")]
    public List<int> LevelCap;

    // Sempre diminuir 1 quando for olhar a lista com essa variável
    [HideInInspector] public int currentLevel = 1;

    // -------- Funções relativas ao load de jogo -----------

    virtual public void LoadStat() { }

    virtual public void IncreaseLevel() {
        if (currentLevel < LevelCap.Count) {
            currentLevel += 1;
        }
    }

    public int GetNextLevelXP() {
        return LevelCap[currentLevel - 1];
    }

    // Pensar em como fazer quando sofrer prestígio - Só não pega do bd? discutir com o time as mudanças
}

// Permite que o valor da lista de nivel seja atribuido
public class NamedListAttribute : PropertyAttribute {
    public readonly string ListElementName;
    public NamedListAttribute(string ListElementName) { this.ListElementName = ListElementName; }
}

// A lista de forma customizável
[CustomPropertyDrawer(typeof(NamedListAttribute))]
public class NamedArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label) {
        try {
            //int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
            EditorGUI.PropertyField(rect, property, new GUIContent(((NamedListAttribute)attribute).ListElementName));
        } catch {
            EditorGUI.PropertyField(rect, property, label);
        }
    }
}