using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum TriggerState {
        INIT,
        GLTRIGGER_NORTH,
        GLTRIGGER_SOUTH,
        GLTRIGGER_EAST,
        GLTRIGGER_WEST,
        L1FIRST_TRIGGER,
        L1AFTER_FIRST,
        L1SECOND_TRIGGER,
        L1THIRD_TRIGGER,   
    }

    public GameObject ExitCentralNorth;
    public GameObject ExitCentralSouth;
    public GameObject ExitCentralEast;
    public GameObject ExitCentralWest;

    public GameObject Player;
    public GameObject L1Trigger1;
    public GameObject GL_TriggerNorth;
    public GameObject GL_TriggerSouth;
    public GameObject GL_TriggerEast;
    public GameObject GL_TriggerWest;

    private Dictionary<TriggerState, Vector3> triggersPos;
    private TriggerState _currentState;
    private float _beginTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        triggersPos = new Dictionary <TriggerState, Vector3>();
        _initTriggerPos();
        _currentState = TriggerState.INIT;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceToTriggers();
        _TriggerActions();
    }


    private void CheckDistanceToTriggers()
    {
        Vector3 userPos = Player.transform.position;
        foreach (var item in triggersPos)
            if (Vector3.Distance(userPos, item.Value) < 4) _currentState = item.Key;
    }

    private void _TriggerActions()
    {
        switch (_currentState)
        {
            case (TriggerState.GLTRIGGER_NORTH):
                GetComponent<LevelManager>().LoadNextLevel(ExitCentralNorth);
                break;
            case (TriggerState.GLTRIGGER_SOUTH):
                GetComponent<LevelManager>().LoadNextLevel(ExitCentralSouth);
                break;
            case (TriggerState.GLTRIGGER_EAST):
                GetComponent<LevelManager>().LoadNextLevel(ExitCentralEast);
                break;
            case (TriggerState.GLTRIGGER_WEST):
                GetComponent<LevelManager>().LoadNextLevel(ExitCentralWest);
                break;


            case (TriggerState.L1FIRST_TRIGGER):
                TriggerSound();
                break;

        }
    }


    
    


    /*
        void CheckTriggers(){
        if(_currentState==State.INIT){
            // position joueur
            Vector3 userPos=_user.transform.position;
            // position triggers
            Vector3 firstTriggerPos= L1Trigger1.transform.position;
            Vector3 Pos_GLTriggerNorth = ;

            //Debug.Log(Vector3.Distance(userPos,firstTriggerPos));
            if (Vector3.Distance(userPos,firstTriggerPos)<4){
                _currentState=State.L1FIRST_TRIGGER;
                _beginTime=Time.time;
                TriggerSound();
            }

            

        } else if(_currentState==State.L1FIRST_TRIGGER)
        {
            float currentTime=Time.time;
            if(currentTime-_beginTime>3){
                _currentState=State.L1AFTER_FIRST;
            }
        }
        else if (_currentState == State.L1FIRST_TRIGGER)
    }



    }



    private void triggerLevel()
    {

    }

    */








    private void _initTriggerPos()
    {
        triggersPos.Add(TriggerState.GLTRIGGER_NORTH, GL_TriggerNorth.transform.position);
        triggersPos.Add(TriggerState.GLTRIGGER_SOUTH, GL_TriggerSouth.transform.position);
        triggersPos.Add(TriggerState.GLTRIGGER_EAST, GL_TriggerEast.transform.position);
        triggersPos.Add(TriggerState.GLTRIGGER_WEST, GL_TriggerWest.transform.position);

        // Ici Ajouter les triggers des autre niveaux
    }
    public void _initTriggerL1Pos()
    {
        // exemple MAJ trigger
        // triggersPos[TriggerState.GLTRIGGER_NORTH] = GL_TriggerNorth.transform.position;
    }
    public void _initTriggerL2Pos()
    {
        //
    }
    public void _initTriggerL3Pos()
    {
        //
    }
    public void _initTriggerL4Pos()
    {
        //
    }



    void TriggerSound()
    {
        PlayAnim audioAnim = GameObject.Find("audioSource").GetComponent<PlayAnim>();
        audioAnim.enabled = true;
    }

    void StopSound()
    {
        GameObject audioSource = GameObject.Find("audioSource");
        AudioSource audio = audioSource.GetComponent<AudioSource>();
        audioSource.transform.parent = null;
    }






}
