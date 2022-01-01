
using UnityEngine;
using System.Collections;

public class TrailSpawner : MonoBehaviour
{
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
            var moveLeft = go.GetComponent<MoveLeft>();
            moveLeft.speed += Random.Range(1f, 3f);
            go.transform.localScale = new Vector3(
                go.transform.localScale.x * Random.Range(2f, 8f),
                go.transform.localScale.y,
                go.transform.localScale.z
            );

            go.transform.position += new Vector3(0f, Random.Range(-25f, 25f), 0f);
        }
    }
}
