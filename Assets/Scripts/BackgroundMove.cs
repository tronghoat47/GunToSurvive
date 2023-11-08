using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    float width = 22.33f;
    int number_img = 2;
    void Start() {

    }

    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        Vector3 pos = transform.position;

        if (pos.x < -width) {
            pos.x += width * number_img;
            transform.position = pos;
        }

    }
}
