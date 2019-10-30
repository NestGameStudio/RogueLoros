using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInstance : MonoBehaviour
{
    [HideInInspector] public int ID = 0;

    public int maxNodesInLine = 7;
    // fazer um array para sortear os nodes
    public GameObject nodePrefab;

    public float offSetBetweenNodes = 1.5f;

    private List<GameObject> nodeList = new List<GameObject>();
    private float nodeSize;

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

            GameObject node = Instantiate(nodePrefab, calculatePostitionInWorld(i), nodePrefab.transform.rotation, this.transform);      // cria uma copia do prefab
            //node.transform.SetParent(this.transform);       // Coloca o node como filho da linha

            // seta as infos do node
            //node = node.GetComponent<NodeInstance>().createNode();

            // adiciona o node à lista de nodes da linha
            nodeList.Add(node);
        }
    }

    private void calculateMaxNumOfLines() {

        int width = Screen.width;

        // Utiliza o tamanho do node para calcular quantas linhas caberão na tela - fake
        nodeSize = nodePrefab.GetComponent<Renderer>().bounds.size.x;

        // substituir maxLinesPerGrid = numLinesVertical quando for essa funcao estiver direita
        int numLinesHorizontal = (int) (width / (nodeSize + offSetBetweenNodes));
        //Debug.Log(numLinesHorizontal);
    }

    private Vector3 calculatePostitionInWorld(int i) {

        Vector3 linePos;

        // Verifica se a linha é par
        if (ID % 2 == 0) {

            if (i % 2 == 0) {   // dispôe os blocos pares a direita e os impares à esquerda

                // Se o index é 2 ele passa a ser 1 e fica ao lado do item 0
                int index = 0;
                if (i > 0)
                    index = i - i/2;

                linePos = new Vector3((nodeSize + offSetBetweenNodes) / 2 + (nodeSize + offSetBetweenNodes) * index, 0, 0);
            }else {

                // Se o index é 3 ele passa a ser 2 e fica ao lado do item 0
                int index = 1;
                if (i > 1)
                    index = i - (i/2);

                linePos = new Vector3((nodeSize + offSetBetweenNodes) / 2 + (nodeSize + offSetBetweenNodes) * -index, 0, 0);
            }

        } else {

            if (i % 2 == 0) {   // dispôe os blocos pares a direita e os impares à esquerda

                int index = 0;
                if (i > 0)
                    index = i - i/2;

                linePos = new Vector3((nodeSize + offSetBetweenNodes) * index, 0, 0);
            } else {

                int index = 1;
                if (i > 1)
                    index = i - (i / 2);

                linePos = new Vector3((nodeSize + offSetBetweenNodes) * -index, 0, 0);
            }
        }

        //Vector3 lineWorldPos = Camera.main.ScreenToWorldPoint(linePos);

        linePos = this.transform.TransformPoint(linePos);

        return linePos;

    }

}
