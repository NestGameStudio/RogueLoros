using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum NodeType { None, Health, Enemy }

public class NodeInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> NodeTypes;

    [HideInInspector]
    public bool canWalkInThisNode = false;

    public Shader lineShader;

    private List<GameObject> lines = new List<GameObject>();

    //private NodeType tipo = NodeType.None;

    // -------- Funções responsaveis em criar o node -----------

    public GameObject RandomizeType() {

        int rand = Random.Range(0, NodeTypes.Count);
        return NodeTypes[rand];
    }

    // -------- Funções responsaveis em gerar os caminhos -----------

    public void DrawLine(Vector3 end) {

        GameObject myLine = new GameObject();
        myLine.transform.position = this.transform.position;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(/*Shader.Find("Particles/Alpha Blended Premultiply")*/ lineShader);
        lr.SetColors(Color.magenta, Color.blue);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, end);
        lines.Add(myLine);
    }

    public void DestroyLines() {

        foreach (GameObject line in lines) {
            Destroy(line);
        }

    }

}
