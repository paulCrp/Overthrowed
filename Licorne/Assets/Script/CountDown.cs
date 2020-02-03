using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private AudioSource _audio;
    private float _lastTime;
    private float _nextTrigger;
    private float _nextPeriodUpdate;
    public AudioClip clip;
    public float period;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        _audio.clip=clip;
        _audio.spatialBlend=0;
        _audio.enabled=true;
        _audio.minDistance=1;
        _audio.maxDistance=500;
        _lastTime=0;
        _nextTrigger=period;
        volume=0.2f;
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log("Last Time");
        // Debug.Log(_lastTime);
        // Debug.Log("Next Trigger");
        // Debug.Log(_nextTrigger);
        if(_lastTime>_nextTrigger){
            _audio.volume=volume;
            _audio.Play();
            _nextTrigger=_nextTrigger+period;
        }
        _lastTime=Time.time;
    }
}
