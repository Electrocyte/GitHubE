using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeller : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.blue;
    [SerializeField] Color blockedColour = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    
    int snapSquareSize = 10;
    // UnityEditor.EditorSnapSettings.move.x
    // this should be used instead of a fixed value of 10
    // and yet it does not work even with scale

    Waypoint waypoint;


    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCurrCoord();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying) {
            DisplayCurrCoord();
            UpdateObjName();
            label.enabled = true;
        }

        SetLabelColour();
        ToggleLabels();
    }

    void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColour()
    {
        if (waypoint.IsPlaceable) {
            label.color = defaultColour;
        } else {
            label.color = blockedColour;
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
