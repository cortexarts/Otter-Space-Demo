using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInfo : MonoBehaviour {
    [SerializeField]
    private float m_GravityStrength = 1;

    public float getGravityStrength()
    {
        return m_GravityStrength;
    }
}
