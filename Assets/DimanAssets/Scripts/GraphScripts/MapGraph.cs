using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGraph : MonoBehaviour
{
    [SerializeField]
    private Sprite CircleSprite;
    private RectTransform GraphContainer;

    // Start is called before the first frame update
    void Start()
    {
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        CreateCircle(new Vector2(200, 200));
    }

    private void CreateCircle (Vector2 anchor)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        gameObject.GetComponent<Image>().sprite = CircleSprite;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchor;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void ShowMap(List<int> coordinatesList)
    {
        float graphHeight = GraphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 50f;
        for (int i = 0; i < coordinatesList.Count; i++)
        {
            float xPosition = i * xSize;
            float yPosition = (coordinatesList[i] / yMaximum) * graphHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
