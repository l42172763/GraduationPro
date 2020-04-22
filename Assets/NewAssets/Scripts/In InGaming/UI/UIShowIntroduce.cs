using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIShowIntroduce : MonoBehaviour
{
    public static UIShowIntroduce Instance { get; private set; }

    [Header("Show one character time(seconds)")]
    public float showOneCharacterTime = 0.1f;

    private Text title;
    private DOTweenAnimation contentText;
    private float topY;
    private float height;
    private Tweener moveUpTweener;
    private Tweener moveDownTweener;
    //private Coroutine checkStartCoroutine;
    private RectTransform rect;
    private bool isHaveAnotherToShow = false;
    private string anotherTitle;
    private string anotherContent;
    public bool needshow;
    public Toggle toggle;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        title = transform.Find("Name/Text").GetComponent<Text>();
        contentText = transform.Find("Content/Text").GetComponent<DOTweenAnimation>();
        height = GetComponent<RectTransform>().rect.height;
        DOTween.defaultAutoKill = false;
        DOTween.defaultAutoPlay = AutoPlay.None;

        //获取目标transform.Y
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);
        topY = transform.position.y;
        rect.anchoredPosition = new Vector2(0, height);
        //down
        moveDownTweener = transform.DOMoveY(topY, 1);
        //up
        moveUpTweener = transform.DOMoveY(topY + height, 1);
        moveUpTweener.OnComplete(OnCloseComplete);

        gameObject.SetActive(false);

        toggle.onValueChanged.AddListener(ToggleEvent);
        needshow = true;
    }

    public void Close()
    {
        //moveDownTweener.Pause();
        moveUpTweener.ChangeStartValue(transform.position);
        moveUpTweener.Play();
    }

    private void OnCloseComplete()
    {
        moveUpTweener.Rewind();
        gameObject.SetActive(false);
        /*if(isHaveAnotherToShow)
        {
            isHaveAnotherToShow = false;
            StartIntroduce(anotherTitle, anotherContent);
        }*/
    }

    public void StartIntroduce(string title, string content)
    {
        if(!AllStatics.AutoNavingNow && needshow)
        {
            //if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
                SetTitleAndContent(title, content);
            }
            /*else
            {
                isHaveAnotherToShow = true;
                anotherTitle = title;
                anotherContent = content;
            }*/
        }
    }

    /*private IEnumerator CheckStartCoroutine(string title, string content)
    {
        yield return null;
        while(gameObject.activeSelf)
        {
            yield return null;

        }
        yield return null;
        SetTitleAndContent(title, content);
        gameObject.SetActive(true);
    }*/

    private void SetTitleAndContent(string title, string content)
    {
        this.title.text = title;
        ((Tweener)contentText.tween).ChangeEndValue(content, (content.Length - 1) * showOneCharacterTime);
    }

    void OnEnable()
    {
        moveDownTweener.Play();
    }


    void OnDisable()
    {
        moveDownTweener.Rewind();
    }
    public void CloseIntroPage()
    {
        if (needshow)
        {
            needshow = false;
        }
        else needshow = true;
    }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isOn">toggle 的选中与否</param>
    private void ToggleEvent(bool isOn)
    {
        needshow = isOn;
        if (gameObject.activeSelf && !needshow) 
        {
            Close();
        }
    }
}
