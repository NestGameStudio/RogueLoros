using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = gameObject.GetComponentInParent<Animator>();

        float randomIdleStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length); //Set a random part of the animation to start from
        anim.Play("Tile", 0, randomIdleStart);

    }

}
