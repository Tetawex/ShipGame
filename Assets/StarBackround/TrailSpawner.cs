
using UnityEngine;
using System.Collections;

public class TrailSpawner : MonoBehaviour
{
    private Vector2 origin = new Vector2(0f, 10f);

    public GameObject tPrefab;

    private float elapsedTime = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.1f)
        {
            var go = Instantiate(tPrefab, transform);
            var moveDown = go.GetComponent<MoveLeft>();
            moveDown.speed += Random.Range(1f, 3f);
            go.transform.localScale = new Vector3(
                go.transform.localScale.x,
                go.transform.localScale.y * Random.Range(2f, 8f),
                go.transform.localScale.z
            );

            go.transform.position += new Vector3(Random.Range(-15f, 15f), 0f, 0f);
        }
    }
}
