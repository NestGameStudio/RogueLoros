using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> NodeTypes;

    [HideInInspector]
    public bool canWalkInThisNode = false;

    public Shader lineShader;
    public GameObject line; 

    private List<GameObject> lines = new List<GameObject>();

    // -------- Funções responsaveis em criar o node -----------

    public GameObject RandomizeType() {

        int rand = Random.Range(0, NodeTypes.Count);
        return NodeTypes[rand];
    }

    // -------- Funções responsaveis em gerar os caminhos -----------

    public void DrawLine(Vector3 end) {

        GameObject myLine = Instantiate(line);
        myLine.transform.position = this.transform.position;
        //myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(lineShader);
        //lr.SetColors(Color.magenta, Color.blue);
        //lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, end);
        lr.gameObject.layer = LayerMask.NameToLayer("LineRenderer");
        lines.Add(myLine);
    }

    public void DestroyLines() {

        foreach (GameObject line in lines) {
            Destroy(line);
        }

    }

}
