using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum State {
        INIT,
        FIRST_TRIGGER,
        AFTER_FIRST,
        SECOND_TRIGGER,
        THIRD_TRIGGER
    }

    private State _currentState;
    private GameObject _user;
    private float _beginTime;
    // Start is called before the first frame update
    void Start()
    {
        _currentState=State.INIT;
        _user=GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        CheckTransition();
    }

    void CheckTransition(){
        if(_currentState==State.INIT){
            Vector3 userPos=_user.transform.position;
            Vector3 firstTriggerPos=GameObject.Find("firstTrigger").transform.position;
            Debug.Log(Vector3.Distance(userPos,firstTriggerPos));
            if(Vector3.Distance(userPos,firstTriggerPos)<4){
                _currentState=State.FIRST_TRIGGER;
                _beginTime=Time.time;
                TriggerSound();
            }
        } else if(_currentState==State.FIRST_TRIGGER){
            float currentTime=Time.time;
            if(currentTime-_beginTime>3){
                _currentState=State.AFTER_FIRST;
            }
        }
    }

    void TriggerSound(){
        PlayAnim audioAnim=GameObject.Find("audioSource").GetComponent<PlayAnim>();
        audioAnim.enabled=true;

    }

    void StopSound(){
        GameObject audioSource=GameObject.Find("audioSource");
        AudioSource audio=audioSource.GetComponent<AudioSource>();
        audioSource.transform.parent=null;
    }
}
