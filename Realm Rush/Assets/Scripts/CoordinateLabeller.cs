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
    [SerializeField] Color exploredColour = Color.black;
    [SerializeField] Color pathColour = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    
    // int snapSquareSize = 10;
    // UnityEditor.EditorSnapSettings.move.x
    // this should be used instead of a fixed value of 10
    // and yet it does not work even with scale

    GridManager gridManager;


    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        gridManager = FindObjectOfType<GridManager>();
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
        if (gridManager == null) {
            return;
        }
        
        Node node = gridManager.GetNode(coordinates);

        if (node == null) {
            return;
        }

        if (!node.isWalkable) {
            label.color = blockedColour;
        }
        else if (!node.isPath) {
            label.color = pathColour;
        }
        else if (!node.isExplored) {
            label.color = exploredColour;
        } else {label.color = defaultColour;
        }
    }

    private void DisplayCurrCoord()
    {
        if (gridManager == null) { return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjName() {
        transform.parent.name = coordinates.ToString();
    }
}
