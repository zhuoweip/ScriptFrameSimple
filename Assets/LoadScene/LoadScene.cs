using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    private AsyncOperation async;
    private uint _nowprocess;
    private Slider processBar;
    private Text text;

    private void Awake()
    {
        processBar = GameTool.GetTheChildComponent<Slider>(gameObject, "Slider");
        text = GameTool.GetTheChildComponent<Text>(gameObject, "Text");
    }

    void Start()
    {
        _nowprocess = 0;
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        async = SceneManager.LoadSceneAsync("Main");
        //flag = true;
        async.allowSceneActivation = false;
        yield return async;
    }

    private const string startStr = "加载素材";
    private const string endStr = "%...";

    //bool flag;
    void Update()
    {
        if (async == null)
            return;

        //if (flag)
        //    processBar.value = async.progress;

        uint toProcess;
        //Debug.Log(async.progress * 100);
        if (async.progress < 0.9f)//坑爹的progress，最多到0.9f
            toProcess = (uint)(async.progress * 100);
        else
            toProcess = 99;

        if (_nowprocess < toProcess)
            _nowprocess++;

        text.text = startStr + _nowprocess.ToString() + endStr;
        processBar.value = _nowprocess / 100f;

        if (_nowprocess >= 99)//async.isDone应该是在场景被激活时才为true
        {
            async.allowSceneActivation = true;
            async = null;
        }
    }
}
