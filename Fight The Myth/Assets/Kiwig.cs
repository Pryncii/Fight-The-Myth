using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Kiwig : MonoBehaviour
{

    private Transform target;
    public float speed;
    public int health = 100;
    public GameObject effect;
    public GameObject scoring;
    private float wait;
    public Animator kiwiganim;
    public Animator camAnim;
    public int damage;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public Rigidbody2D rb;
    
    public float startdash;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //scoring
        rb.GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }


        if (dashTime <= 0)
        {
           
            rb.velocity = Vector2.zero;
        }
        if (Vector2.Distance(transform.position, target.position) >= 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            dashSpeed = 6;
        }

        if (Vector2.Distance(transform.position, target.position) < 3 && Vector2.Distance(transform.position, target.position) > 2.5 && wait <= 0)
        {
            dashTime = startDashTime;
            wait = startdash;
        }

            if (Vector2.Distance(transform.position, target.position) < 3 )
        {
            
            if (dashTime >= 0)
            {
               
                transform.position = Vector2.MoveTowards(transform.position, target.position, dashSpeed * Time.deltaTime);
                dashTime -= Time.deltaTime;

            }

        }




        if (health <= 75)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0.8f, 0.8f, 0.1f);
        }

        if (health <= 50)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 0.6f, 1f);
        }

        if (health <= 25)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 0.3f, 0.5f);
        }



        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
           
            

         
          
        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;

        }


  


    }
  


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
           // add damage deal
           //audio
           // cam shake
        }

       


    }

    public void takedamage(int damage)
    {
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(1f);

        // add animation
        

    }
}
