using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitting : MonoBehaviour
{
    public GameObject knight;
    public GameObject enemy;
    public Animator animator;
    float timing = 0;
    float timing2 = 0;
    float force = 10f;
    bool attacked = false;
    bool animate = false;
    int count = 0;
    public Image image;
    static float health = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        timing2 += Time.deltaTime;
        animate = (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"));
        if(attacked && timing > 3)
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i<arr.Length; i++)
            {
                Destroy(arr[i]);
                
            }
            //Instantiate(enemy, new Vector3(5, -0.5f, 0), Quaternion.identity);
            attacked = false;
            count = 0;
            animate = false;
            health = 1f;

        }
       
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] arraylist = new GameObject[5];
        if ((collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player")) && animate && timing2>0.5f)
        {
            count++;
            animator.SetTrigger("hit");
            timing2 = 0;
            image.fillAmount -= 0.2f;
            health -= 0.2f;
            Debug.Log("attacked 2");

            if (health <= 0f)
            {
                attacked = true;
                arraylist[0] = (collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Body").gameObject.transform.Find("Arm_L").gameObject);
                arraylist[1] = (collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Body").gameObject.transform.Find("Arm_R").gameObject);
                arraylist[2] = (collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Body").gameObject.transform.Find("Head").gameObject);
                arraylist[3] = (collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Leg_L").gameObject);
                arraylist[4] = (collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Leg_R").gameObject);
                //collision.gameObject.transform.Find("Hip").gameObject.transform.Find("Body").gameObject.transform.Find("Head").transform.DetachChildren();
                Destroy(collision.gameObject);

                for (int i = 0; i < arraylist.Length; i++)
                {
                    arraylist[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    GameObject gameObjtec = Instantiate(arraylist[i], collision.gameObject.transform.position, Quaternion.identity);
                    SpriteRenderer renderer = arraylist[i].GetComponent<SpriteRenderer>();
                    Rigidbody2D rb = gameObjtec.AddComponent<Rigidbody2D>();
                    rb = gameObjtec.GetComponent<Rigidbody2D>();
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

                }
                timing = 0;
                
                count = 0;
            }

            
        

        }
    }
        //if (collision.gameObject.tag == "enemy")
        //{
        //    collision.gameObject.transform.DetachChildren();
        //    for (int i = 0; i< collision.gameObject.transform.childCount; i++)
        //    {
        //        collision.gameObject.transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
        //    }

        //}
    }


