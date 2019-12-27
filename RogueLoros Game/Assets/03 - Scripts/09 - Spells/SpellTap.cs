using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTap: MonoBehaviour
{
    // Raycast
    private RaycastHit2D hit;

    private void OnMouseDown() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
    }

    // Por agora cada bloco da HUD vai receber e retirar um Spell Action, caso tenha ele realizaa ação e retira o spell action do spell node
    // Talvez tenha que mudar para que todos tenham spell Instance vazio e vai mudando o valor do spell instance com scoobydoos conforme pega eles nos baús


    private void OnMouseUp() {

        if (hit.collider.gameObject != null) {

            // faz a ação do spell
            if (hit.collider.gameObject.GetComponent<SpellAction>()) {

            }

        }

    }

}
