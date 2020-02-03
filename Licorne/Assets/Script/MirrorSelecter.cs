using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSelecter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Mouseover() { }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray.direction);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {   
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }

    }
}
