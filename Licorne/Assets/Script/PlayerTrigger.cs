using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case ("ExitTriggerNorth"):
                GameManager.GetComponent<GameManager>()._currentState = TriggerState.GLTRIGGER_NORTH;
                other.gameObject.SetActive(false);
                break;
            case ("ExitTriggerSouth"):
                GameManager.GetComponent<GameManager>()._currentState = TriggerState.GLTRIGGER_SOUTH;
                other.gameObject.SetActive(false);
                break;
            case ("ExitTriggerEast"):
                GameManager.GetComponent<GameManager>()._currentState = TriggerState.GLTRIGGER_EAST;
                other.gameObject.SetActive(false);
                break;
            case ("ExitTriggerWest"):
                GameManager.GetComponent<GameManager>()._currentState = TriggerState.GLTRIGGER_WEST;
                other.gameObject.SetActive(false);
                break;
            case ("TriggerBox"):
                GameManager.GetComponent<GameManager>()._currentState = TriggerState.BOXTRIGGER;
                other.gameObject.SetActive(false);
                break;
        }
        
    }
}
