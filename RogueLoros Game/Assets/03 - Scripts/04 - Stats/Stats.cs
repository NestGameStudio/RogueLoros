using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Stats: MonoBehaviour {

    [Header("Experience Manager")]
    [Space(5)]

    [NamedListAttribute("Level Up XP")]
    public List<int> LevelCap;


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