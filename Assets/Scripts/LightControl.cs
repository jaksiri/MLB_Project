using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    [SerializeField]
    private Slider LightSlider;
    [SerializeField]
    private float startValue = 20.0f;   //Set as these values to exaggerate the sun's direction effect on the seats
    [SerializeField]
    private float endValue = 160.0f;
   

    private float lightAngle = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightAngle = Mathf.Lerp(startValue, endValue, LightSlider.value);
        gameObject.transform.localEulerAngles = new Vector3(lightAngle, 0, 0);
    }
}
