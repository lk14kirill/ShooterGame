using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public enum States
    {
        idle,
        moving,
        dead
    }
[RequireComponent(typeof(Rigidbody))]
public class AIManager : MonoBehaviour
{
    Rigidbody rb;
 
        public States state;
        public  int health;
        public  float speed = 10;
        public  int distance;
        public  int idleTime;
    public string type;
        [Header("AudioSources")]
        public AudioSource DieSound;

        void Start()
        {
        rb = GetComponent<Rigidbody>();
            state = States.idle;

           
              StartCoroutine("Idle");
        }

        IEnumerator Move()
        {
        if (state == States.moving)
            {
                for (int i = 0; i < distance; i++)
                {
                if(state != States.dead)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                
                yield return new WaitForSeconds(.05f);
                }
                state = States.idle;
              StartCoroutine("Idle");
            
        }
        }


    void FixedUpdate()
    {

        if (health < 0&& state != States.dead)
        {
            StartCoroutine("Die");
        }
    }
   
    IEnumerator Die()
    {
        
            state = States.dead;
            DieSound.Play();
            this.tag = tag.Replace("Dummie", "Dead");
        RaycastUI.Ray.StartCoroutine("RayShoot");
            yield return new WaitForSeconds(.5f);
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            //transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            Destroy(GetComponent<BoxCollider>());
            Destroy(gameObject,3);

        
    }
     public void Damage()
    {
        health -= GunScript.damage;
    }
        IEnumerator Idle()
        {
            
            if (state == States.idle)
            {
                transform.Rotate(0, 90, 0);
                yield return new WaitForSeconds(idleTime);
                state = States.moving;
            StartCoroutine("Move");
        }
          

        
      }
    
}
