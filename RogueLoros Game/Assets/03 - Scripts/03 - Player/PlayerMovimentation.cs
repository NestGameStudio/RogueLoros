using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pega a linha seguinte que ele pode andar
// encontra os blocos mais proximos a ele (os dois acima)
// permite ele dar tap nesses dois acima

public class PlayerMovimentation: MonoBehaviour {

    private static PlayerMovimentation _instance;
    public static PlayerMovimentation Instance { get { return _instance; } }

    public GameObject InitialNode;

    [HideInInspector] public bool Started = false;

    private int nextLineToMove = 0;

    private List<GameObject> currentPossibleNodes = new List<GameObject>();

    private GameObject currentNode;

    private void Awake() {

        if (_instance != null && _instance != this){
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        Started = false;
        currentNode = InitialNode;
    }

    private void Start() {

        // Como a execution order do unity nao faz nenhum sentido
        // Usa uma corrotina que aguarda a grid ser toda instanciada para permitir que o player ande
        StartCoroutine(WaitToGrid());
    }

    // -------- Funções relativas a permitir que o player se mova -----------

    // Pega os dois nodes mais proximos do player e ativa a possibilidade de dar tap nele
    public void allowNextMovimentation()
    {
        // Se a proxima linha for a do boss, puxar o boss pra perto do player

        GameObject nextLine = GridManager.Instance.GetLine(nextLineToMove);

        if (nextLine.GetComponent<LineInstance>().isBoss) {
            nextLine.GetComponent<LineInstance>().PullBossCloserToPlayer();
        }

        currentPossibleNodes = GetClosestNodes(nextLine);

        foreach (GameObject node in currentPossibleNodes) {
            node.GetComponent<NodeInstance>().canWalkInThisNode = true;
            currentNode.GetComponent<NodeInstance>().DrawLine(node.transform.position);
            node.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255, 255);
            if (node.CompareTag("Enemy"))
            {
                node.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                node.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            else if(node.CompareTag("Health"))
            {
                node.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                node.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            else if (node.CompareTag("Chest"))
            {
                node.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                node.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    // Modificar isso para o caso do boss (só tem 1 opção)
    // Pega os dois nodes mais proximos do player
    List<GameObject> GetClosestNodes(GameObject line) {

        List<GameObject> closestNodes = new List<GameObject>();
        List<GameObject> allNodesInLine = line.GetComponent<LineInstance>().getNodeList();

        GameObject closestNode = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        if (!line.GetComponent<LineInstance>().isBoss) {

            while (closestNodes.Count < 2) {

                foreach (GameObject node in allNodesInLine) {
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

        } else {

            foreach (GameObject node in allNodesInLine)
            {
                float dist = Vector3.Distance(node.transform.position, currentPos);

                if (dist < minDist)
                {
                    closestNode = node;
                    minDist = dist;
                }
            }

            closestNodes.Add(closestNode);
            allNodesInLine.Remove(closestNode);

        }

        // Verifica se não é uma linha deslocada com 3 possibilidades
        // Avalia se tem algum nó com distancia igual (simetrico nas laterais = 3)
        allNodesInLine = line.GetComponent<LineInstance>().getNodeList();

        // Compara a distancia de cada nó escolhido como próximo
        foreach(GameObject node in allNodesInLine) {
            foreach (GameObject nodeClose in closestNodes) {
                float distClose = Vector3.Distance(nodeClose.transform.position, currentPos);
                float dist = Vector3.Distance(node.transform.position, currentPos);

                if (distClose == dist && node != nodeClose) {
                    closestNodes.Add(node);
                    break;
                }
            }

            if (closestNodes.Count == 3) break;
        }

        return closestNodes;
    }

    // -------- Funções relativas a mover o player -----------

    // Move o player para o node
    // Adiciona uma nova linha na grid para que player ande
    // Chamado pelo Tap
    public void MovePlayer(GameObject node) {
        changePlayerNode(node);
        GameObject.FindGameObjectWithTag("Player").transform.parent = node.transform.GetChild(0);
        GridManager.Instance.AddLineInGrid(node);

        if (node.CompareTag("Chest"))
        {
            //Fazer chest desaparecer
            node.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

    }

    private void changePlayerNode(GameObject newNode) {
        this.transform.position = new Vector2(newNode.transform.position.x, newNode.transform.position.y+0.73f) ;

        currentNode.GetComponent<NodeInstance>().DestroyLines();

        // tira a possibilidade de voltar no node
        foreach(GameObject node in currentPossibleNodes) {
            node.GetComponent<NodeInstance>().canWalkInThisNode = false;
        }

        currentNode = newNode;

        if (!Started)
            Started = true;

        nextLineToMove++;
    }

    // -------- Funções que espera o carregamento da grid -----------

    IEnumerator WaitToGrid() {

        bool gridCreated = false;
        List<GameObject> lineList;

        while (!gridCreated) {

            lineList = GridManager.Instance.GetAllLines();
            if (lineList.Count > 0) {
                foreach (GameObject line in lineList) {
                    if (line.GetComponent<LineInstance>().getNodeList().Count > 0) {
                        gridCreated = true;
                    } else {
                        gridCreated = false;
                    }
                }
            }
            yield return new WaitForEndOfFrame();   
        }

        allowNextMovimentation();
    }
    private void Update()
    {
        currentNode.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
