using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class MapGraph : MonoBehaviour
{
    [SerializeField]
    private Sprite CircleSprite;
    private RectTransform GraphContainer;

    // Start is called before the first frame update
    void Start()
    {
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        List<int> coordinatesList = new List<int>() { 35, 74, 76, 99, 69, 33, 50 };
        ShowMap(coordinatesList);
    }

    private GameObject CreateCircle (Vector2 anchor)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        gameObject.GetComponent<Image>().sprite = CircleSprite;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchor;
        rectTransform.sizeDelta = new Vector2(30, 30);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowMap(List<int> coordinatesList)
    {
        float graphHeight = GraphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 50f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < coordinatesList.Count; i++)
        {
            float xPosition = i * xSize;
            float yPosition = (coordinatesList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            if (lastCircleGameObject != null)
            {
                MapConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void MapConnection (Vector2 mapPositionA, Vector2 mapPositionB)
    {
        GameObject gameObject = new GameObject("mapConnection", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 direction = (mapPositionB - mapPositionA).normalized;
        float distance = Vector2.Distance(mapPositionA, mapPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 1f);
        rectTransform.anchoredPosition = mapPositionA+ direction*distance*0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
