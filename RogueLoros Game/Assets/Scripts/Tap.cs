using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tap presente em cada node, apenas os nodes que estão masi próximos possuem o tap ativado
// Quando o tap é feito o player vai até o local do node e faz a ação dele

public class Tap : MonoBehaviour
{
    // OBS: limitar o drag em favor do tap, se tiver segurando tempo suficiente vira drag
    // Talvez considerar tap se o objecto não se mover

    public GameObject Player;

    // Tempo maximo até o player soltar o botão para que ele considere como tap
    public float tapTime = 0.13f;

    private bool tapped = false;
    private float timer = 0;

    private void OnMouseDown() {
        tapped = true;
    }

    private void OnMouseUp() {

        tapped = false;

        if (timer <= tapTime) {

            // Faz a acao do node e faz o player andar até o node
            Debug.Log("Fez o tap");
            this.GetComponent<NodeAction>().DoAction();

            PlayerMovimentation.Instance.MovePlayer(this.transform.position);
            PlayerMovimentation.Instance.allowNextMovimentation();
        }

        timer = 0;

    }

    private void Update() {

        if (tapped) {
            timer += Time.deltaTime;
        }

    }
}
