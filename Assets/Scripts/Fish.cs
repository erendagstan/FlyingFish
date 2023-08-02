using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -30;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField]private AudioSource swim, hit, point;

    private void Awake()
    {
        //Debug.Log("Fish's awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0.0f;
        sp = GetComponent<SpriteRenderer>();
        //_rb.gravityScale = -1.0f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        FishSwim();

    }

    private void FixedUpdate()
    {
        FishRotation();

    }


    void FishSwim()
    {
       
        if (Input.GetMouseButtonDown(0) && GameManager.gameover==false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4.0f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted(); 
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
         
        }
    }
 

    private void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if(touchedGround==false) {
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            //Debug.Log("Scored!...");
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column") && GameManager.gameover==false)
        {
            FishDieEffect();
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameover == false)
            {
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void FishDieEffect()
    {
        hit.Play();
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
        
    }

}
