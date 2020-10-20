using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public GameObject deadEffect;
        public GameObject itemEffect;
        Rigidbody2D rb;
        float angle = 0;
        int xSpeed = 5;
        int ySpeed = 30;
        GameManager gm;
        bool isDead = false;

        float hueValue;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();

            hueValue = Random.Range(0, 10) / 10.0f;

            
        }
        void Start()
        {
            SetBackgroundColor();
        }


        void Update()
        {
            if (isDead == true) return;

            MovePlayer();
            GetInput();
        }

        void MovePlayer() //sağa sola otomatik hareket
        {
            Vector2 pos = transform.position;
            pos.x = Mathf.Cos(angle) * 3;
            transform.position = pos;
            angle += Time.deltaTime * xSpeed;
        }

        void GetInput()
        {
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(new Vector2(0, ySpeed));
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    rb.AddForce(new Vector2(0, -ySpeed/2));
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
            }

            if(Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);
                if(finger.phase == TouchPhase.Stationary)
                {
                    rb.AddForce(new Vector2(0, ySpeed));
                }
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    rb.AddForce(new Vector2(0, -ySpeed / 2));
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                Dead();
            }else if (other.gameObject.tag == "Item")
            {
                GetItem(other);
            }            
        }

        void GetItem(Collider2D other)
        {
            SetBackgroundColor();
            Destroy(Instantiate(itemEffect, other.gameObject.transform.position, Quaternion.identity),0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            gm.AddScore();
        }

        void Dead()
        {
            isDead = true;

            StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

            Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity),0.7f);
            StopPlayer();
            gm.CallGameOver();
        }

        void StopPlayer()
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
        }

        void SetBackgroundColor()
        {
            Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.6f);

            hueValue += 0.1f;
            if(hueValue >= 1)
            {
                hueValue = 0;
            }
        }
    }
}