using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * rb.rotation), Mathf.Cos(Mathf.Deg2Rad * rb.rotation));

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(direction);
        }
        if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(-.05f);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(.05f);
        }

        if (Input.GetKey(KeyCode.Space)) {
            GetComponent<ship>().shoot();
        }
    }
}
