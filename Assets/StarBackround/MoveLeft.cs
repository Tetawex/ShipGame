using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Time.deltaTime * speed, 0);

        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }
}
