using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings 
{
    public float strength = 1f;
    public float rougness = 2f;
    public float BaseRougness = 1f;
    public float persistence = 0.5f;
    [Range(1,8)]
    public int numLayers = 1;
    public Vector3 centre;
    public float minValue;
}
