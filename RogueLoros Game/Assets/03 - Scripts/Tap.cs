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

    // Raycast
    private RaycastHit2D hit;

    private void OnMouseDown() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
    }

    private void OnMouseUp() {

        // Faz a acao do node e faz o player andar até o node
        if (hit.collider.gameObject != null)
        {
            if (hit.collider.gameObject.GetComponent<NodeInstance>().canWalkInThisNode)
            {
                this.GetComponent<NodeAction>().DoAction();
                gameObject.gameObject.GetComponent<Animator>().SetTrigger("Tap");
                PlayerMovimentation playerMov = PlayerMovimentation.Instance;
                playerMov.MovePlayer(this.gameObject);
                playerMov.allowNextMovimentation();
            }
        }
    }

}
