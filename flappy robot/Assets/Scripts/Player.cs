using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbodyBird;
    public Animator ani;
    public float force = 100;
    private bool death = false;
    public delegate void DeathNotify();
    private Vector3 initPos;
    public event DeathNotify OnDeath;
    public UnityAction<int> OnScore;

    // Start is called before the first frame update
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        this.Idle();
        initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.death) { return; }
        else { 
            if (Input.GetMouseButtonDown(0)) {
                rigidbodyBird.velocity = Vector2.zero;
                rigidbodyBird.AddForce(new Vector2(0, force),ForceMode2D.Force);
            }
        }
    }
    public void Idle() {
        this.rigidbodyBird.simulated = false;
        this.ani.SetTrigger("Idle");
    }
    public void Fly()
    {
        this.rigidbodyBird.simulated = true;
        this.transform.position = new Vector2(0, 0);
        this.ani.SetTrigger("Fly");
    }
    private void Die()
    {
        this.death = true;
        if (this.OnDeath != null) {
            this.OnDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D:" + collision.gameObject.name + ":" + gameObject.name + ":" + Time.time);
        this.Idle();
        this.Die();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name+":"+gameObject.name+":"+Time.time);
        if (collision.gameObject.name.Equals("ScoreArea"))
        { }
        else { 
        this.Idle();
        this.Die();}
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + ":" + gameObject.name + ":" + Time.time);
        if (collision.gameObject.name.Equals("ScoreArea"))
        {
            if (this.OnScore != null)
                this.OnScore(1);
        }
    }

    public void Init() {
        this.transform.position = initPos;
        this.Idle();
        this.death = false;
    }
}
