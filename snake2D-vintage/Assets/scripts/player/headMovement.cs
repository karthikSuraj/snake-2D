using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovement : MonoBehaviour
{
  public  List<Transform> _body = new List<Transform>();
    public Transform  body;
    int horizontal = 1;
    int vertical = 0;
    float speed = 0.005f;
    int score = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {

        direction();
    }
    private void FixedUpdate()
    {
        follower();

        move();
        


    }

    void direction()
    {   
        if (Input.GetKeyDown(KeyCode.W) && horizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            horizontal = 0;
            vertical = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S) && horizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            horizontal = 0;
            vertical = -1;
        }
        else if (Input.GetKeyDown(KeyCode.A) && vertical != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
           
            horizontal = -1;
            vertical = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D) && vertical != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            horizontal = 1;
            vertical = 0;
        }
        
    }
    void move()
    {
        float x = Mathf.Round(this.transform.position.x) + horizontal;
        float y = Mathf.Round(this.transform.position.y) + vertical;
        this.transform.position = new Vector2(x, y);
    }
     void Grow()
    {

        Transform tail = Instantiate(body);
        tail.position = _body[_body.Count - 1].position;
        _body.Add(tail);
    }
                     

    void follower()
    {
        for(int i = _body.Count-1; i>0 ; i--)
        {
            _body[i].position = _body[i - 1].position;
       
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<foodManager>()!=null)
        {
            Grow();
          collision.gameObject.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-4.5f, 4.27f), 0);
            foodManager fm = collision.gameObject.GetComponent<foodManager>();
            if(fm.nameOFTheFood== "YellowPepper")
            {
                score += fm.PickUpPoints;
                Debug.Log(score);
            } if(fm.nameOFTheFood== "strawBerry")
            {
                score += fm.PickUpPoints;
                Debug.Log(score);
            }
        }



        if (collision.gameObject.CompareTag("body"))
            Debug.LogError("die");
    }
}

