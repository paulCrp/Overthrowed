using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryboardManager : MonoBehaviour
{
    public Image InitFaderImage;
    public Canvas initCanvas;
    public GameObject StartPanel;
    public RectTransform StoryboardImage1;
    public RectTransform StoryboardImage2;
    public RectTransform StoryboardImage3;
    public RectTransform StoryboardImage4;
    public RectTransform StoryboardImage5;
    public RectTransform StoryboardImage6;
    public RectTransform StoryboardImage7;
    public RectTransform StoryboardImage8;
    public RectTransform StoryboardImage9;
    public RectTransform StoryboardImage10;
    public RectTransform StoryboardBlack;

    public Canvas UICanvas;
    public RectTransform BandeNoireUp;
    public RectTransform BandeNoireDown;

    public IEnumerator StartScenario()
    {
        bool firstloop = false;
        bool secondloop = false;
        float timer1 = 0;
        float timer2 = 0;
        Color whiteFadeInitFull = Color.white;
        Color whiteFadeInitTrans = new Color(1,1,1,0);
        while (!firstloop)
        {
            timer1 += Time.deltaTime;
            InitFaderImage.color = Color.Lerp(InitFaderImage.color, whiteFadeInitFull, Time.deltaTime*2.0f);

            if (timer1 >= 3.0f)
            {
                firstloop = true;
                InitFaderImage.color = whiteFadeInitFull;
                StartPanel.SetActive(false);
                timer1 = 0;
                yield return null;
            }
            yield return null;
        }
        while (!secondloop)
        {
            timer2 += Time.deltaTime;
            InitFaderImage.color = Color.Lerp(InitFaderImage.color, whiteFadeInitTrans, Time.deltaTime);
            if (timer2 >= 3.0f)
            {
                StartCoroutine(Storyboard1());
                secondloop = true;
                InitFaderImage.color = whiteFadeInitTrans;
                initCanvas.gameObject.SetActive(false);
                timer2 = 0;
                yield return null;
            }
            yield return null;
        }

        yield return null;
    }

    public void StartGame()
    {
        StartCoroutine(StartScenario());
    }

    public IEnumerator Storyboard1()
    {
        float timer1 = 0;
        float timer2 = 0;
        bool firstframe = false;
        bool secondframe = false;
        Vector3 leftpos1 = StoryboardImage1.localPosition;
        Vector2 anchoredpos1 = StoryboardImage1.anchoredPosition;
        Vector3 leftpos2 = StoryboardImage2.localPosition;
        Vector2 anchoredpos2 = StoryboardImage2.anchoredPosition;
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        anchoredpos1.x = 116.2f;
        leftpos1.z = -187.1f;
        anchoredpos2.y = 24.88f;
        leftpos2.z = -362.76f;
        while (!firstframe)
        {
            timer1 += Time.deltaTime;
           StoryboardImage1.localPosition = Vector3.Lerp(StoryboardImage1.localPosition,leftpos1,Time.deltaTime);
            StoryboardImage1.anchoredPosition = Vector2.Lerp(StoryboardImage1.anchoredPosition, anchoredpos1, Time.deltaTime);
            if (timer1 >= 8.0f)
            {
                //StoryboardImage1.localPosition = leftpos;
                //StoryboardImage1.anchoredPosition = anchoredpos;
                firstframe = true;
                timer1 = 0;
                yield return null;
            }
            yield return null;
        }
        while (!secondframe)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 2.0f)
            {
                StoryboardImage2.localPosition = Vector3.Lerp(StoryboardImage2.localPosition, leftpos2, Time.deltaTime);
                StoryboardImage2.anchoredPosition = Vector2.Lerp(StoryboardImage2.anchoredPosition, anchoredpos2, Time.deltaTime);
            }
            StoryboardImage1.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage1.GetComponent<RawImage>().color,FadeColor,Time.deltaTime);
            if (timer2 >= 5.0f)
            {
                //timer2 = 0;
                //secondframe = true;
                StoryboardImage1.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage2.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage2.GetComponent<RawImage>().color, FadeColor, Time.deltaTime);
                yield return null;
            }
            if (timer2 >= 10.0f)
            {
                timer2 = 0;
                secondframe = true;
                StoryboardImage2.GetComponent<RawImage>().color = FadeColor;
                yield return StartCoroutine(HideBandesNoires());
                UICanvas.gameObject.SetActive(false);
            }
            yield return null;
        }
        yield return null;
    }

    public IEnumerator DisplayBandesNoires()
    {
        float timer = 0;
        bool test = false;
        Vector2 anchoredposup = BandeNoireUp.anchoredPosition;
        Vector2 anchoredposdown = BandeNoireDown.anchoredPosition;
        anchoredposup.y = -30.0f;
        anchoredposdown.y = 30.0f;
        while (!test)
        {
            timer += Time.deltaTime;
            BandeNoireUp.anchoredPosition = Vector2.Lerp(BandeNoireUp.anchoredPosition, anchoredposup, Time.deltaTime);
            BandeNoireDown.anchoredPosition = Vector2.Lerp(BandeNoireDown.anchoredPosition, anchoredposdown, Time.deltaTime);
            if (timer >= 2.0f)
            {
                timer = 0;
                test = true;
                yield return null;
            }
            yield return null;
        }
        
        yield return null;
    }
    public IEnumerator HideBandesNoires()
    {
        float timer = 0;
        bool test = false;
        Vector2 anchoredposup = BandeNoireUp.anchoredPosition;
        Vector2 anchoredposdown = BandeNoireDown.anchoredPosition;
        anchoredposup.y = 30.0f;
        anchoredposdown.y = -30.0f;
        while (!test)
        {
            timer += Time.deltaTime;
            BandeNoireUp.anchoredPosition = Vector2.Lerp(BandeNoireUp.anchoredPosition, anchoredposup, Time.deltaTime);
            BandeNoireDown.anchoredPosition = Vector2.Lerp(BandeNoireDown.anchoredPosition, anchoredposdown, Time.deltaTime);
            if (timer >= 2.0f)
            {
                timer = 0;
                test = true;
                yield return null;
            }
            yield return null;
        }

        yield return null;
    }


    public IEnumerator Storyboard2()
    {
        float timer1 = 0;
        bool firstframe = false;
        bool secondframe = false;
        UICanvas.gameObject.SetActive(true);
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        yield return StartCoroutine(DisplayBandesNoires());
        while (!firstframe)
        {
            StoryboardImage3.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage3.GetComponent<RawImage>().color, FullColor, Time.deltaTime); 
            timer1 += Time.deltaTime;
            if (timer1 >= 3.0f)
            {
                //StoryboardImage3.GetComponent<RawImage>().color = FullColor;
                //timer1 = 0;
                //firstframe = true;
                StoryboardImage4.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage4.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
                yield return null;
            }
            if (timer1 >= 6.0f)
            {
                StoryboardImage3.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage4.GetComponent<RawImage>().color = FullColor;
                timer1 = 0;
                firstframe = true;
            }
            yield return null;
        }
        while (!secondframe)
        {
            timer1 += Time.deltaTime;
            StoryboardImage4.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage4.GetComponent<RawImage>().color, FadeColor, Time.deltaTime);
            if (timer1 >= 3.0f)
            {
                timer1 = 0;
                secondframe = true;
                StoryboardImage4.GetComponent<RawImage>().color = FadeColor;
                yield return null;
            }
            yield return null;
        }
        yield return StartCoroutine(HideBandesNoires());
        UICanvas.gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator Storyboard3()
    {
        float timer= 0;
        bool frame1 = false;
        bool frame2 = false;
        bool frame3 = false;
        UICanvas.gameObject.SetActive(true);
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        yield return StartCoroutine(DisplayBandesNoires());
        while (!frame1)
        {
            timer += Time.deltaTime;
            StoryboardImage4.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage4.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame1 = true;
                StoryboardImage4.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame2)
        {
            timer += Time.deltaTime;
            StoryboardImage5.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage5.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 5.0f)
            {
                timer = 0;
                frame2 = true;
                StoryboardImage4.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage5.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame3)
        {
            timer += Time.deltaTime;
            StoryboardImage5.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage5.GetComponent<RawImage>().color, FadeColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame3 = true;
                StoryboardImage5.GetComponent<RawImage>().color = FadeColor;
                yield return null;
            }
            yield return null;
        }
        yield return StartCoroutine(HideBandesNoires());
        UICanvas.gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator Storyboard4()
    {
        float timer = 0;
        bool frame1 = false;
        bool frame2 = false;
        bool frame3 = false;
        UICanvas.gameObject.SetActive(true);
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        yield return StartCoroutine(DisplayBandesNoires());
        while (!frame1)
        {
            timer += Time.deltaTime;
            StoryboardImage5.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage5.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame1 = true;
                StoryboardImage5.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame2)
        {
            timer += Time.deltaTime;
            StoryboardImage6.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage6.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 5.0f)
            {
                timer = 0;
                frame2 = true;
                StoryboardImage5.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage6.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame3)
        {
            timer += Time.deltaTime;
            StoryboardImage6.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage6.GetComponent<RawImage>().color, FadeColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame3 = true;
                StoryboardImage6.GetComponent<RawImage>().color = FadeColor;
                yield return null;
            }
            yield return null;
        }
        yield return StartCoroutine(HideBandesNoires());
        UICanvas.gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator Storyboard5()
    {
        float timer = 0;
        bool frame1 = false;
        bool frame2 = false;
        bool frame3 = false;
        UICanvas.gameObject.SetActive(true);
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        yield return StartCoroutine(DisplayBandesNoires());
        while (!frame1)
        {
            timer += Time.deltaTime;
            StoryboardImage6.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage6.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame1 = true;
                StoryboardImage6.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame2)
        {
            timer += Time.deltaTime;
            StoryboardImage7.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage7.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 5.0f)
            {
                timer = 0;
                frame2 = true;
                StoryboardImage6.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage7.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame3)
        {
            timer += Time.deltaTime;
            StoryboardImage7.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage7.GetComponent<RawImage>().color, FadeColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame3 = true;
                StoryboardImage7.GetComponent<RawImage>().color = FadeColor;
                yield return null;
            }
            yield return null;
        }
        yield return StartCoroutine(HideBandesNoires());
        UICanvas.gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator Storyboard6()
    {
        float timer = 0;
        bool frame1 = false;
        bool frame2 = false;
        bool frame3 = false;
        bool frame4 = false;
        bool frame5 = false;
        bool frame6 = false;
        UICanvas.gameObject.SetActive(true);
        Color FadeColor = new Color(1, 1, 1, 0);
        Color FullColor = Color.white;
        Color FadeBlack = new Color(0, 0, 0, 0);
        Color FullBlack = Color.black;
        yield return StartCoroutine(DisplayBandesNoires());
        while (!frame1)
        {
            timer += Time.deltaTime;
            StoryboardImage7.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage7.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame1 = true;
                StoryboardImage7.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame2)
        {
            timer += Time.deltaTime;
            StoryboardImage8.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage8.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 5.0f)
            {
                timer = 0;
                frame2 = true;
                StoryboardImage8.GetComponent<RawImage>().color = FadeColor;
                StoryboardImage8.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        StoryboardBlack.GetComponent<RawImage>().color = FadeBlack;
        while (!frame3)
        {
            timer += Time.deltaTime;
            StoryboardBlack.GetComponent<RawImage>().color = Color.Lerp(StoryboardBlack.GetComponent<RawImage>().color, FullBlack, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame3 = true;
                StoryboardBlack.GetComponent<RawImage>().color = FullBlack;
                yield return null;
            }
            yield return null;
        }
        StoryboardImage9.GetComponent<RawImage>().color = FadeColor;
        while (!frame4)
        {
            timer += Time.deltaTime;
            StoryboardImage9.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage9.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 5.0f)
            {
                timer = 0;
                frame4 = true;
                StoryboardImage9.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame5)
        {
            timer += Time.deltaTime;
            StoryboardImage10.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage10.GetComponent<RawImage>().color, FullColor, Time.deltaTime);
            if (timer >= 10.0f)
            {
                timer = 0;
                frame5 = true;
                StoryboardImage10.GetComponent<RawImage>().color = FullColor;
                yield return null;
            }
            yield return null;
        }
        while (!frame6)
        {
            timer += Time.deltaTime;
            StoryboardImage10.GetComponent<RawImage>().color = Color.Lerp(StoryboardImage10.GetComponent<RawImage>().color, Color.black, Time.deltaTime);
            if (timer >= 3.0f)
            {
                timer = 0;
                frame6 = true;
                StoryboardImage10.GetComponent<RawImage>().color = Color.black;
                yield return null;
            }
            yield return null;
        }
        //yield return StartCoroutine(HideBandesNoires());
        //UICanvas.gameObject.SetActive(false);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    public void CallStoryBoard1()
    {
        StartCoroutine(Storyboard1());
    }
    */
    public void CallStoryBoard2()
    {
        StartCoroutine(Storyboard2());
    }
    public void CallStoryBoard3()
    {
        StartCoroutine(Storyboard3());
    }
    public void CallStoryBoard4()
    {
        StartCoroutine(Storyboard4());
    }
    public void CallStoryBoard5()
    {
        StartCoroutine(Storyboard5());
    }
    public void CallStoryBoard6()
    {
        StartCoroutine(Storyboard6());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(Storyboard3());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(Storyboard4());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(Storyboard5());
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Storyboard6());
        }
        */
    }
}
