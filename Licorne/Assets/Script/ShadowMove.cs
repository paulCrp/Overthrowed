using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
{
    private float _speed=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting shadow move");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject shadow=GameObject.Find("shadow");
        shadow.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * _speed);
    }
}
