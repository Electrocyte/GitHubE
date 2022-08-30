using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    int snapSquareSize = 10;
    // UnityEditor.EditorSnapSettings.move.x
    // this should be used instead of a fixed value of 10
    // and yet it does not work even with scale

    void Awake() {
        label = GetComponent<TextMeshPro>();
        DisplayCurrCoord();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying) {
            DisplayCurrCoord();
            UpdateObjName();
        }
    }

    private void DisplayCurrCoord()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / snapSquareSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / snapSquareSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjName() {
        transform.parent.name = coordinates.ToString();
    }
}
