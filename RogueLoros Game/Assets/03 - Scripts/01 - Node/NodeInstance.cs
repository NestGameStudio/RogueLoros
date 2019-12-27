using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> NodeTypes;

    [HideInInspector]
    public bool canWalkInThisNode = false;

	[Space(10)]

	public Shader lineShader;
    public GameObject line;

    private List<GameObject> lines = new List<GameObject>();

    // -------- Funções responsaveis em criar o node -----------
    public void Update()
    {

        if (canWalkInThisNode == false)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(73, 71, 82, 255);
        }
        /*
        else if(canWalkInThisNode == true && gameObject.tag == "Enemy")
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
        */
        /*
            if (GameObject.FindGameObjectWithTag("Player").transform.position == gameObject.transform.position)
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            */
        
    }
    public GameObject RandomizeType() {

        int rand = Random.Range(0, NodeTypes.Count);
        return NodeTypes[rand];

        // Chama a funcao do eneym intance para que ele carregue os dados de um inimigo qualquer
    }

    public GameObject BossNode() {

        // Chamaa funcao do Enemy Intance para que ele carregue os dados do boss

        foreach(GameObject node in NodeTypes) {
            if (node.CompareTag("Enemy")) {

                node.GetComponent<EnemyInstance>().isBossNode = true;

                return node;
            }
        }
        return null;
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
