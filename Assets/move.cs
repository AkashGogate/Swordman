using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    float timing = 0;
    float timing2 = 0;
    public Animator animator;
    bool starting;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        timing2 += Time.deltaTime;
        Camera.main.transform.position = new Vector3(transform.position.x, 0f, -10f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            transform.Translate(1 * Time.deltaTime, 0, 0);
            animator.SetTrigger("walk");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.Translate(-1 * Time.deltaTime, 0, 0);
            animator.SetTrigger("walk");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timing > 1f) {
                timing = 0f;
                animator.SetTrigger("attack");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (timing2 > 1f)
            {
                timing2 = 0f;
                animator.SetTrigger("attack2");
            }
        }
    }
}
