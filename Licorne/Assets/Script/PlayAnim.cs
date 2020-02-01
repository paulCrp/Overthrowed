using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    enum State{
        INIT,
        FIRST,
        SECOND,
        FINAL
    }

    public AudioClip _clip;
    private float _beginTime;
    private State _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _beginTime=Time.time;
        _currentState=State.INIT;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentState==State.INIT){
            GameObject user=GameObject.Find("Capsule");
            Vector3 userPos=user.transform.position;
            GameObject audioSource=GameObject.Find("audioSource");
            AudioSource audio = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            audio.clip=_clip;
            audio.spatialBlend=1;
            audio.enabled=true;
            audio.minDistance=1;
            audio.maxDistance=3;
            Vector3 shift=new Vector3(1,0,5);
            audioSource.transform.parent=user.transform;
            audioSource.transform.position=userPos-shift;
            audio.Play();
            _currentState=State.FIRST;
        } else if(_currentState==State.FIRST){
            float currentTime=Time.time;
            if(currentTime-_beginTime>1){
                GameObject audioSource=GameObject.Find("audioSource");
                AudioSource audio=audioSource.GetComponent<AudioSource>();
                Destroy(audio);
                _currentState=State.SECOND;
            }
        } else if(_currentState==State.SECOND){
            GameObject user=GameObject.Find("Capsule");
            Vector3 userPos=user.transform.position;
            GameObject audioSource=GameObject.Find("audioSource");
            AudioSource audio = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            audio.clip=_clip;
            audio.spatialBlend=1;
            audio.enabled=true;
            audio.minDistance=1;
            audio.maxDistance=3;
            Vector3 shift=new Vector3(1,0,-5);
            audioSource.transform.parent=user.transform;
            audioSource.transform.position=userPos-shift;
            // audio.Play();
            _currentState=State.FINAL;
        }
    }
}
