using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimBreathe2 : MonoBehaviour
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
    private AudioSource _audio;
    private Vector3 _begin;
    private Vector3 _end;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Init");
        _beginTime=Time.time;
        _currentState=State.INIT;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentState==State.INIT){
            GameObject user=GameObject.Find("Capsule");
            Vector3 userPos=user.transform.position;
            Vector3 forward = transform.worldToLocalMatrix.MultiplyVector(user.transform.forward);
            Vector3 left = Vector3.Cross(forward, Vector3.up).normalized;
            GameObject audioSource=GameObject.Find("audioSource");
            _audio = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            _audio.clip=_clip;
            _audio.spatialBlend=0;
            _audio.enabled=true;
            _audio.minDistance=1;
            _audio.maxDistance=10;
            Vector3 shiftBegin=-forward-left;
            Vector3 shiftEnd=-forward+left;
            audioSource.transform.parent=user.transform;
            _begin=userPos-3*shiftBegin;
            _end=userPos-3*shiftEnd;
            audioSource.transform.position=_begin;
            _audio.Play();
            _currentState=State.FIRST;
        } else if(_currentState==State.FIRST){
            float currentTime=Time.time;
            GameObject user=GameObject.Find("Capsule");
            Vector3 userPos=user.transform.position;
            Vector3 forward = transform.worldToLocalMatrix.MultiplyVector(user.transform.forward);
            Vector3 left = Vector3.Cross(forward, Vector3.up).normalized;
            GameObject audioSource=GameObject.Find("audioSource");
            // Vector3 shift=-forward+left;
            // audioSource.transform.parent=user.transform;
            // audioSource.transform.position=userPos-3*shift;

            // The center of the arc
            Vector3 center = (_begin + _end) * 0.5F;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 1, 0);
            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = _begin - center;
            Vector3 setRelCenter = _end - center;
            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - _beginTime) / 2;
            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;
        } else if(_currentState==State.SECOND){
            // _audio.Play();
            _currentState=State.FINAL;
        } else if(_currentState==State.FINAL){
            GameObject audioSource=GameObject.Find("audioSource");
            audioSource.transform.parent=null;
        }
    }
}
