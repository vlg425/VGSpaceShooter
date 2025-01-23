using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller2 : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float updatedPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * updatedPosition;
    }
}
