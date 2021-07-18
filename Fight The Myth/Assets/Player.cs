using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 40f;
    public GameObject circle, dot;
    public Rigidbody2D rb;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public int direction;
    public float wait;
    public float startdash;


    public
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        circle.SetActive(false);
        dot.SetActive(false);
        dashTime = startDashTime;
          
    }

    // Update is called once per frame
    void Update()
    {
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }
       
        if (dashTime >= 0)
            {
            rb.velocity = moveDirection * dashSpeed;
            dashTime -= Time.deltaTime;

            }

        if (dashTime <= 0)
        {

           
            rb.velocity = Vector2.zero;
        }

        if (Input.touchCount > 0)

        {
            oneTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);

            if (oneTouch.position.x < Screen.width / 2)
            {
                switch (oneTouch.phase)
                {
                    case TouchPhase.Began:

                        circle.SetActive(true);
                        dot.SetActive(true);
                        circle.transform.position = touchPosition;
                        dot.transform.position = touchPosition;

                        break;

                    case TouchPhase.Stationary:

                        Move();

                        break;

                    case TouchPhase.Moved:

                        Move();

                        break;

                    case TouchPhase.Ended:

                        circle.SetActive(false);
                        dot.SetActive(false);

                        rb.velocity = Vector2.zero;

                        break;
                }
            }
        }
    }

    private void Move()
    {
        dot.transform.position = touchPosition;

        dot.transform.position = new Vector2(Mathf.Clamp(dot.transform.position.x, circle.transform.position.x - 0.8f,
            circle.transform.position.x + 0.8f), Mathf.Clamp(dot.transform.position.y, circle.transform.position.y - 0.8f,
            circle.transform.position.y + 0.8f));

        moveDirection = (dot.transform.position - circle.transform.position).normalized;
        if (dashTime <= 0)
        {
            rb.velocity = moveDirection * speed;
        }
    }

    public void dash()
    {
        rb.velocity = Vector2.zero;
        if (wait <= 0)
        {
            if (dashTime <= 0)
            {

                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }

            wait = startdash;
        }
     
    }
}
