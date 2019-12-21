using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum Difficulty { Easy, Medium, Hard }

public class DifficultyManager : MonoBehaviour
{

    #region Singleton

    private static DifficultyManager _instance;
    public static DifficultyManager Instance { get { return _instance; } }

    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion

    // mantem o track da dificuldade que o player está agora (de acordo com o numeor máximo de lines na run)
    // Mantem track da ultima maior dificuldade que o player estava

    public Difficulty currentDifficulty = Difficulty.Easy;

    // Mantem track de quantas runs o jogador percorreu
    private int currentRun = 0;

    // Define o numero de lines de acordo com a run percorridas
    [NamedListRunAttribute("Number of Lines in Run")]
    public List<int> RunLines;

    public int GetCurrentRun() {
        return currentRun;
    }
}

// Permite que o valor da lista de nivel seja atribuido
public class NamedListRunAttribute: PropertyAttribute
{
    public readonly string ListRunElementName;
    public NamedListRunAttribute(string ListElementName) { this.ListRunElementName = ListElementName; }
}

// A lista de forma customizável
[CustomPropertyDrawer(typeof(NamedListRunAttribute))]
public class NamedRunArrayDrawer: PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label) {
        try {
            //int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
            EditorGUI.PropertyField(rect, property, new GUIContent(((NamedListRunAttribute) attribute).ListRunElementName));
        } catch {
            EditorGUI.PropertyField(rect, property, label);
        }
    }
}
