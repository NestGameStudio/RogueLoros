using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pega a linha seguinte que ele pode andar
// encontra os blocos mais proximos a ele (os dois acima)
// permite ele dar tap nesses dois acima

public class PlayerMovimentation: MonoBehaviour {

    private int nextLineToMove = 0;

    private void Start() {
        allowNextMovimentation();
    }

    // -------- Funções relativas a permitir que o player se mova -----------

    // Pega os dois nodes mais proximos do player e ativa a possibilidade de dar tap nele
    private void allowNextMovimentation()
    {
        GameObject nextLine = GridManager.Instance.GetLine(nextLineToMove);
        List<GameObject> nodes = GetClosestNodes(nextLine);

        foreach (GameObject node in nodes) {
            Debug.Log(node);
            node.GetComponentInChildren<Tap>(true).enabled = true;
        }
    }

    // Pega os dois nodes mais proximos do player
    List<GameObject> GetClosestNodes(GameObject line)
    {
        List<GameObject> closestNodes = new List<GameObject>();

        List<GameObject> allNodesInLine = line.GetComponent<LineInstance>().getNodeList();
        Debug.Log(allNodesInLine.Count);

        GameObject closestNode = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        while (closestNodes.Count < 2) {

            foreach(GameObject node in allNodesInLine) {
                Debug.Log(closestNode + " NODE");
                float dist = Vector3.Distance(node.transform.position, currentPos);

                if (dist < minDist) {
                    closestNode = node;
                    minDist = dist;
                }
            }

            Debug.Log(closestNode + " NODE ENTROU");

            closestNodes.Add(closestNode);
            allNodesInLine.Remove(closestNode);

            closestNode = null;
            minDist = Mathf.Infinity;
        }

        return closestNodes;
    }

    // -------- Funções relativas a mover o player -----------

    // Move o player para o node
    // Adiciona uma nova linha na grid para que player ande
    // Chamado pelo Tap
    public void MovePlayer() {

        changePlayerNode();
        GridManager.Instance.AddLineInGrid();
    }

    private void changePlayerNode() {
        Debug.Log("Andou");
    }
}
