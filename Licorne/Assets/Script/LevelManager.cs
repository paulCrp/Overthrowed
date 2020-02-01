using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Levels { Null, level1, level2, level3, level4}

public class LevelManager : MonoBehaviour
{
    public GameObject ExitCentralNorth;
    public GameObject ExitCentralSouth;
    public GameObject ExitCentralEast;
    public GameObject ExitCentralWest;

    public GameObject GateL1;
    public GameObject GateL2;
    public GameObject GateL3;
    public GameObject GateL4;

    private Levels lastLevel = Levels.Null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")) LoadNextLevel(ExitCentralNorth);
        if (Input.GetKeyDown("b")) LoadNextLevel(ExitCentralSouth);
        if (Input.GetKeyDown("c")) LoadNextLevel(ExitCentralEast);
        if (Input.GetKeyDown("d")) LoadNextLevel(ExitCentralWest);


    }

    public void LoadNextLevel(GameObject exitGate)
    {
        //Vector3 joinPoint = exitGate.GetComponent<Renderer>().bounds.center;
        switch (lastLevel)
        {
            case (Levels.Null):
                GateL1.transform.position = exitGate.transform.position;
                GateL1.transform.rotation = exitGate.transform.rotation;
                lastLevel = Levels.level1;
                break;
            case (Levels.level1):
                GateL2.transform.position = exitGate.transform.position;
                GateL2.transform.rotation = exitGate.transform.rotation;
                lastLevel = Levels.level2;
                break;
            case (Levels.level2):
                GateL3.transform.position = exitGate.transform.position;
                GateL3.transform.rotation = exitGate.transform.rotation;
                lastLevel = Levels.level3;
                break;
            case (Levels.level3):
                GateL4.transform.position = exitGate.transform.position;
                GateL4.transform.rotation = exitGate.transform.rotation;
                lastLevel = Levels.level4;
                break;
        }
    }
}
