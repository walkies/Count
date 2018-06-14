using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject prefabPe;
    public AudioSource click;
    public AudioSource pop;
    public AudioSource bump;
    public float thrust;
    float roll = 1.6f;
    public Rigidbody rb;
    float x;

    void Start()
    {
        var aSources = GetComponents<AudioSource>();
        x = Random.Range(0, 360);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
        click = aSources[0];
        pop = aSources[1];
        bump = aSources[2];
    }
    void Update()
    {
        if (rb.velocity.magnitude < roll)
        {
           rb.velocity = rb.velocity.normalized * roll;
        }
        if (rb.velocity.magnitude > roll*14)
        {
            rb.velocity = rb.velocity.normalized * roll;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Paddle")
        {
            bump.Play();
            bump.pitch = click.pitch + 0.02f;
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * thrust * 2.3f);
        }
        else if (c.gameObject.tag == "Block")
        {
            click.Play();
            click.pitch = click.pitch + 0.05f;
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * thrust * 1.2f);
        }
        else if (c.gameObject.tag == "Floor")
        {
            pop.Play();
            pop.pitch = pop.pitch + 0.01f;
            click.pitch = 1;
            Instantiate(prefabPe, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(myPrefab, new Vector3(0, 2.3f, 0), Quaternion.Euler(0, x, 0));
            Destroy(gameObject, 0.1f);
        }
    }
}
