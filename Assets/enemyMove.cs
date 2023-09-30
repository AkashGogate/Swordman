using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    float timing = 0;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (timing < 8 && timing > 5)
        {
            animator.SetTrigger("attack");
        }
        if (timing > 12 && timing < 14)
        {
            animator.SetTrigger("attack");
        }
        if (timing < 5)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.Translate(-1 * Time.deltaTime, 0, 0);
            animator.SetTrigger("walk");
        }
        else if (timing < 8)
        {
            animator.SetBool("walk", false);
        }
        else if (timing < 13)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            transform.Translate(1 * Time.deltaTime, 0, 0);
            animator.SetTrigger("walk");
        }
        else if (timing < 16)
        {
            animator.SetBool("walk", false);
        }
        else
        {
            animator.SetBool("walk", false);
            timing = 0;
        }
    }
}
