using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings 
{
    public enum FilterType {Simple, Ridged};
    public FilterType filterType;

    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RidgedNoiseSettings ridgedNoiseSettings;

    [System.Serializable]
    public class SimpleNoiseSettings {
        public float strength = 1f;
        public float rougness = 2f;
        public float BaseRoughness = 1f;
        public float persistence = 0.5f;
        [Range(1,8)]
        public int numLayers = 1;
        public Vector3 centre;
        public float minValue;
    }

    [System.Serializable]
    public class RidgedNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultiplier = 0.8f;
    }
}
