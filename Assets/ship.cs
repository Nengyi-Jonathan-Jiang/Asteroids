using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public GameObject bullet;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private float cooldown = 0;
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void shoot() {
        if (cooldown < 0) {
            _shoot();
            cooldown = .2f;
        }
    }

    private void _shoot() {
        Vector2 direction = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * rb.rotation), Mathf.Cos(Mathf.Deg2Rad * rb.rotation));

        Rigidbody2D brb = Instantiate(bullet).GetComponent<Rigidbody2D>();
        brb.position = transform.position + (Vector3) direction;
        brb.velocity = direction * 10f + rb.velocity;
        brb.rotation = rb.rotation;
    }
}
