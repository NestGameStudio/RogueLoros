using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInstance : MonoBehaviour
{
    public int maxNodesInLine = 6;
    // fazer um array para sortear os nodes
    public GameObject nodePrefab;

    private List<GameObject> nodeList = new List<GameObject>();

    private void Start() {
        createNodeList();
        Debug.Log("Criei lista");
    }

    // -------- Funções relativas a criar a line -----------

    public List<GameObject> getNodeList() {
        return nodeList;
    }

    // Cria uma lista de nodes para a linha
    private void createNodeList() {

        for (int i=0; i<maxNodesInLine; i++) {

            GameObject node = Instantiate(nodePrefab);      // cria uma copia do prefab
            node.transform.SetParent(this.transform);       // Coloca o node como filho da linha

            // seta as infos do node
            //node = node.GetComponent<NodeInstance>().createNode();

            // adiciona o node à lista de nodes da linha
            nodeList.Add(node);
        }
    }

}
