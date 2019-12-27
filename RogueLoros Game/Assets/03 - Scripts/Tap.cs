using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tap presente em cada node, apenas os nodes que estão masi próximos possuem o tap ativado
// Quando o tap é feito o player vai até o local do node e faz a ação dele

public class Tap : MonoBehaviour
{
    public GameObject Player;

    public Animator anim;

    // Raycast
    private RaycastHit2D hit;

    private bool isEnemy = false;

    private bool canWalk = true;

    private void OnMouseDown() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
    }

    private void OnMouseUp() {

        // Faz a acao do node e faz o player andar até o node
        if (hit.collider.gameObject != null)
        {
            if (hit.collider.gameObject.GetComponent<NodeInstance>().canWalkInThisNode && canWalk)
            {


                if (this.GetComponent<ActionEnemy>() != null) {
                    isEnemy = true;

                    //hit.collider.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    //hit.collider.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                }


                this.GetComponent<NodeAction>().DoAction();
                gameObject.gameObject.GetComponent<Animator>().SetTrigger("Tap");

                // Se o node não é inimigo ele anda
                if (!isEnemy) {

                    // é um chest
                    if (this.GetComponent<ActionChest>() != null && anim) {
                        StartCoroutine(WaitForAnimation("Bau-Open"));
                    } else {
                        MovePlayer();
                    }
				}

            }
        }
    }

    private void MovePlayer() {

        PlayerMovimentation.Instance.MovePlayer(this.gameObject);
        PlayerMovimentation.Instance.allowNextMovimentation();
        isEnemy = false;
    }

    private IEnumerator WaitForAnimation(string animationName) {

        anim.SetTrigger("Open");

        canWalk = false;

        do {
            yield return null;
        } while (anim.GetCurrentAnimatorStateInfo(0).IsName(animationName));

        MovePlayer();

        canWalk = true;
    }

}
