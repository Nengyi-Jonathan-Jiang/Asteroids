using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrap : MonoBehaviour
{
    GameObject[] clones;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        clones = new GameObject[8];
        for (int i = 0; i < clones.Length; i++) {
            clones[i] = Instantiate(transform.GetChild(0).gameObject);
        }

        rb = GetComponent<Rigidbody2D>();

        updateClones();
    }

    void updateClones() {
        if (rb.transform.position.x < -8) {
            rb.transform.position += new Vector3(16, 0, 0);
        }
        else if (rb.transform.position.x > 8) {
            rb.transform.position -= new Vector3(16, 0, 0);
        }
        if (rb.transform.position.y < -5) {
            rb.transform.position += new Vector3(0, 10, 0);
        }
        else if (rb.transform.position.y > 5) {
            rb.transform.position -= new Vector3(0, 10, 0);
        }

        for (int x = -1, i = 0; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 0 && y == 0) continue;

                Vector3 offset = new Vector2(x, y) * new Vector2(16, 10);
                clones[i].transform.rotation = transform.rotation;
                clones[i].transform.position = transform.position + offset;
                i++;
            }
        }
    }

    void FixedUpdate()
    {
        updateClones();
    }
}
