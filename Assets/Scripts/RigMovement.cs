using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMovement : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnCameraChanged += OnOnCameraChange;
    }

    private void OnOnCameraChange(GameObject marker)
    {
        gameObject.transform.position = marker.transform.position;
        gameObject.transform.rotation = marker.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
