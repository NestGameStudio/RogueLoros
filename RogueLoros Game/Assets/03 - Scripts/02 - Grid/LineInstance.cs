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

    [HideInInspector] public bool isBoss = false;

    private List<GameObject> nodeList = new List<GameObject>();
    private float nodeSize;

    private void Start() {

        createNodeList();
    }

    // -------- Funções relativas a criar a line -----------

    public List<GameObject> getNodeList() {
        return nodeList;
    }

    // Cria uma lista de nodes para a linha
    private void createNodeList() {

        if (!isBoss) {

            for (int i = 0; i < maxNodesInLine; i++) {

                GameObject nodeType = nodePrefab.GetComponent<NodeInstance>().RandomizeType();
                GameObject node = Instantiate(nodeType, calculatePostitionInWorld(i), nodePrefab.transform.rotation, this.transform);      // cria uma copia do prefab

                // adiciona o node à lista de nodes da linha
                nodeList.Add(node);
            }

        } else {

            GameObject nodeType = nodePrefab.GetComponent<NodeInstance>().BossNode();
            if(nodeType != null) {
                GameObject node = Instantiate(nodeType, calculatePostitionInWorld(0), nodePrefab.transform.rotation, this.transform);      // cria uma copia do prefab

                // adiciona o node à lista de nodes da linha
                nodeList.Add(node);
            }
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

        // quantidade de nodes por linha é par
        if (maxNodesInLine % 2 == 0) {

            if (i % 2 == 0) {   // dispôe os blocos pares a direita e os impares à esquerda

                int index = 0;
                if (i > 0)
                    index = i - i / 2;

                linePos = new Vector3((nodeSize + offSetBetweenNodes)/2 + (nodeSize + offSetBetweenNodes) * index, 0, 0);
            } else {

                int index = 1;
                if (i > 1)
                    index = i - (i / 2);

                linePos = new Vector3((nodeSize + offSetBetweenNodes)/2 + (nodeSize + offSetBetweenNodes) * -index, 0, 0);
            }

        // Quantidade de nodes por linha é ímpar
        } else {

            if (i % 2 == 0) {   // dispôe os blocos pares a direita e os impares à esquerda

                int index = 0;
                if (i > 0)
                    index = i - i / 2;

                linePos = new Vector3((nodeSize + offSetBetweenNodes) * index, 0, 0);
            } else {

                int index = 1;
                if (i > 1)
                    index = i - (i / 2);

                linePos = new Vector3((nodeSize + offSetBetweenNodes) * -index, 0, 0);
            }

        }

        linePos = this.transform.TransformPoint(linePos);

        return linePos;
    }

}
