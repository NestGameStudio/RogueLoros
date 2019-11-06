using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pega a linha seguinte que ele pode andar
// encontra os blocos mais proximos a ele (os dois acima)
// permite ele dar tap nesses dois acima

public class PlayerMovimentation: MonoBehaviour {

    private static PlayerMovimentation _instance;
    public static PlayerMovimentation Instance { get { return _instance; } }

    private int nextLineToMove = 0;

    private List<GameObject> currentPossibleNodes = new List<GameObject>();

    // Precisa estar no awake por conta do execution order
    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        allowNextMovimentation();
    }

    // -------- Funções relativas a permitir que o player se mova -----------

    // Pega os dois nodes mais proximos do player e ativa a possibilidade de dar tap nele
    public void allowNextMovimentation()
    {
        GameObject nextLine = GridManager.Instance.GetLine(nextLineToMove);
        currentPossibleNodes = GetClosestNodes(nextLine);

        foreach (GameObject node in currentPossibleNodes) {
            node.GetComponent<NodeActive>().enabled = true;
        }
    }

    // Pega os dois nodes mais proximos do player
    List<GameObject> GetClosestNodes(GameObject line)
    {
        List<GameObject> closestNodes = new List<GameObject>();

        List<GameObject> allNodesInLine = line.GetComponent<LineInstance>().getNodeList();

        GameObject closestNode = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        while (closestNodes.Count < 2) {

            foreach(GameObject node in allNodesInLine) {
                float dist = Vector3.Distance(node.transform.position, currentPos);

                if (dist < minDist) {
                    closestNode = node;
                    minDist = dist;
                }
            }

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
    public void MovePlayer(Vector3 position) {

        changePlayerNode(position);
        GridManager.Instance.AddLineInGrid();
    }

    private void changePlayerNode(Vector3 position) {
        this.transform.position = position;

        foreach(GameObject node in currentPossibleNodes) {
            if (node != this.gameObject) {
                node.GetComponent<NodeActive>().enabled = false;
            }
        }

        nextLineToMove++;
    }
}
