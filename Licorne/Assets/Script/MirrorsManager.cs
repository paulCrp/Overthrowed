using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorsManager : MonoBehaviour
{
    [SerializeField]
    private int MirrorsCounter = 0;

    [SerializeField]
    private int Morceaux = 5;

    public StoryboardManager sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        MouseHighlighter.MirrorFound += MirrorsFound;
    }
    private void OnDisable()
    {
        MouseHighlighter.MirrorFound -= MirrorsFound;
    }

    public void MirrorsFound()
    {
        MirrorsCounter++;
    }

    public void MirrorsDeposed()
    {
        Morceaux--;
        if (Morceaux == 4)
        {
            sm.CallStoryBoard2();
        }
        if (Morceaux == 3)
        {
            sm.CallStoryBoard3();
        }
        if (Morceaux == 2)
        {
            sm.CallStoryBoard4();
        }
        if (Morceaux == 1)
        {
            sm.CallStoryBoard5();
        }
        if (Morceaux == 0)
        {
            sm.CallStoryBoard6();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
