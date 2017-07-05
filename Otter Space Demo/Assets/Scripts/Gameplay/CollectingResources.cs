using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingResources : MonoBehaviour
{
    public List<GameObject> Trees;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        for (int i = 0; i < Trees.Count; i++)
        {
            Trees[i].SetActive(false);
            Trees.RemoveAt(i);
            PlayerPrefs.SetString("PlayerHasWood", "true");
        }
    }
}
