using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {
    public float thrust;
    public Rigidbody rbB;
    public GameObject myPrefab;
    public Material Mat;
    public Material[] randomMaterials;
    public Transform dropPoint;
    public Countdown count;
    Vector3 explosionPos;
    float x;
    float z;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        rbB = GetComponent<Rigidbody>();
        rbB.AddForce(transform.forward * thrust);
        Mat = randomMaterials[Random.Range(0, randomMaterials.Length)];
        GetComponent<Renderer>().sharedMaterial = Mat;
    }

	void Update ()
    {
        if (count.currentTime == 1)
        {
            rbB.AddExplosionForce(8, explosionPos, 2, 0.75f);
        }
    }

    void OnCollisionEnter(Collision B)
    {
        if (B.gameObject.tag == "Ball")
        {
            Vector3 dir = B.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rbB.AddForce(dir * thrust * 25);
            instantiate();
        }
           else if (B.gameObject.tag == "Block")
        {
            Vector3 dir = B.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rbB.AddForce(dir * thrust);
        }
        else if (B.gameObject.tag == "Floor")
        {
            count.currentScore++;
        }
    }
    void OnCollisionStay(Collision BB)
    {
        if (BB.gameObject.tag == "Block")
        {
            Vector3 dir = BB.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rbB.AddForce(dir * thrust);
        }
    }
    void instantiate()
        {
         x = Random.Range(-1.8f, 1.8f);
         z = Random.Range(-1.8f, 1.8f);
        Instantiate(myPrefab, new Vector3(x, 3f, z), Quaternion.identity);
    }
}
