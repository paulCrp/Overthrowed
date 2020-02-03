using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHighlighter : MonoBehaviour
{
    private bool _init = true;


    public delegate void MirrorsDelegate();
    public static event MirrorsDelegate MirrorFound;
    public float endTime;
    public float roof;
    public float halo;
    public float metronom;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        if (!_init)
        {
            return;
        }
        foreach(Material m in GetComponent<MeshRenderer>().materials)
        {
            m.SetColor("_OutlineColor", Color.yellow);
            m.SetFloat("_Thickness", 1.5f);
        }
    }
    private void OnMouseExit()
    {
        if (!_init)
        {
            return;
        }
        foreach (Material m in GetComponent<MeshRenderer>().materials)
        {
            m.SetColor("_OutlineColor", Color.red);
            m.SetFloat("_Thickness", 0);
        }
    }

    private void OnMouseUp()
    {
        if (!_init)
        {
            return;
        }
        _init = false;
        foreach (Material m in GetComponent<MeshRenderer>().materials)
        {
            m.SetColor("_OutlineColor", Color.green);
            m.SetFloat("_Thickness", 2.0f);

        }
        StartCoroutine(GrabObject());
    }

    public IEnumerator GrabObject()
    {
        float timer = 0;
        bool test = false;
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        MirrorFound();
        while (!test)
        {
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                timer = 0;
                test = true;
                yield return null;
            }
            yield return null;
        }
        transform.parent.gameObject.SetActive(false);
        GameObject GM = GameObject.Find("GameManager");
        GM.GetComponent<GameManager>().HavePrisme = true;
        GM.GetComponent<GameManager>()._initBoxActions();
        string name = gameObject.transform.parent.gameObject.name;
        GM.GetComponent<GameManager>().PrismeName = name;
        if (name.Equals("Prisme1"))
        {
            PlayAnimBreathe play = GameObject.Find("audioSource").GetComponent<PlayAnimBreathe>();
            play.enabled = true;
        }
        else if (name.Equals("Prisme2"))
        {   
            PlayAnim play=GameObject.Find("audioSource").GetComponent<PlayAnim>();
            play.enabled = true;
            VariableDiminish vd = GM.AddComponent(typeof(VariableDiminish)) as VariableDiminish;
            vd.enabled = false;
            vd.endTime = endTime;
            vd.minimalLevelRoof = roof;
            vd.minimalLevelHalo = halo;
            vd.increaseMetronomFrequency = metronom;
            vd.enabled = true;
        } else if (name.Equals("Prisme3"))
        {
            PlayAnimStep play = GameObject.Find("audioSource").GetComponent<PlayAnimStep>();
            play.enabled = true;
            VariableDiminish vd = GM.AddComponent(typeof(VariableDiminish)) as VariableDiminish;
            vd.enabled = false;
            vd.endTime = endTime;
            vd.minimalLevelRoof = roof;
            vd.minimalLevelHalo = halo;
            vd.increaseMetronomFrequency = metronom;
            vd.enabled = true;
        }
        else if (name.Equals("Prisme4"))
        {
            PlayAnimBreathe2 play = GameObject.Find("audioSource").GetComponent<PlayAnimBreathe2>();
            play.enabled = true;
            VariableDiminish vd = GM.AddComponent(typeof(VariableDiminish)) as VariableDiminish;
            vd.enabled = false;
            vd.endTime = endTime;
            vd.minimalLevelRoof = roof;
            vd.minimalLevelHalo = halo;
            vd.increaseMetronomFrequency = metronom;
            vd.enabled = true;
        } else if (name.Equals("Prisme5"))
        {
            PlayAnim2 play = GameObject.Find("audioSource").GetComponent<PlayAnim2>();
            play.enabled = true;
            VariableDiminish vd = GM.AddComponent(typeof(VariableDiminish)) as VariableDiminish;
            vd.enabled = false;
            vd.endTime = endTime;
            vd.minimalLevelRoof = roof;
            vd.minimalLevelHalo = halo;
            vd.increaseMetronomFrequency = metronom;
            vd.enabled = true;
        }
        
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
