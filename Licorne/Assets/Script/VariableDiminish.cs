using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDiminish : MonoBehaviour
{
    public float endTime;
    public float minimalLevelRoof;
    public float minimalLevelHalo;
    public float increaseMetronomFrequency;
    private float beginTime;
    private float toDiminishHalo;
    private float haloDecreasePerStep;
    private float currHaloRange;
    private float currLevel;
    private float range;
    private float step;
    private float toDiminish;
    private float yDecreasePerStep;
    private float toIncreaseMetronomPerStep;
    private float roofLevelToAttain;
    private float haloLeveltoAttain;
    private float metronomPeriodToAttain;
    private GameObject roof;
    private Light halo;
    private CountDown countDown;
    private bool endRoof;
    private bool endHalo;
    private bool endFrequency;

    // Start is called before the first frame update
    void Start()
    {
        beginTime=Time.time;
        roof=GameObject.Find("Roof");
        halo=GameObject.Find("Halo").GetComponent<Light>();
        countDown=GameObject.Find("metronom").GetComponent<CountDown>();
        float metronomPeriod=countDown.period;
        currHaloRange=halo.range;
        currLevel=roof.transform.position.y;
        step=endTime/Time.deltaTime;
        roofLevelToAttain=minimalLevelRoof*currLevel;
        haloLeveltoAttain=minimalLevelHalo*currHaloRange;
        metronomPeriodToAttain=increaseMetronomFrequency*metronomPeriod;
        float toDiminish=currLevel-roofLevelToAttain;
        float toDiminishHalo=currHaloRange-haloLeveltoAttain;
        float toIncreasePeriod=metronomPeriod-metronomPeriodToAttain;
        yDecreasePerStep=toDiminish/step;
        haloDecreasePerStep=toDiminishHalo/step;
        toIncreaseMetronomPerStep=toIncreasePeriod/step;
        endRoof = false;
        endHalo = false;
        endFrequency = false;

    }

    // Update is called once per frame
    void Update()
    {
        DiminishHalo();
        DiminishRoof();
        IncreaseMetronom();
        if(endRoof && endHalo && endFrequency)
        {
            Debug.Log("Disable");
            Destroy(this.gameObject.GetComponent<VariableDiminish>());
        }
    }

    void DiminishHalo()
    {
        if(halo.range>=haloLeveltoAttain){
            halo.range=halo.range-haloDecreasePerStep;
        }
        else
        {
            endHalo = true;
        }
    }

    void DiminishRoof()
    {
        
        currLevel=roof.transform.position.y;
        if(currLevel>=roofLevelToAttain){
            roof.transform.Translate(new Vector3(0,-yDecreasePerStep,0));
        }
        else
        {
            endRoof = true;
        }
    }

    void IncreaseMetronom()
    {
        float currMetronomPeriod=countDown.period;
        if(currMetronomPeriod>metronomPeriodToAttain){
            countDown.period=countDown.period-toIncreaseMetronomPerStep;
        }
        else
        {
            endFrequency = true;
        }
    }
}
