using UICore;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    protected override void InitUiOnAwake()
    {
        base.InitUiOnAwake();
    }

    //初始化界面数据
    protected override void InitDataOnAwake()
    {
    }

    protected override void RegistBtnsAnimation()
    {
        base.RegistBtnsAnimation();
    }


    protected override void RegistBtns()
    {
        base.RegistBtns();

        BtnAniType = ButtonAniType.Scale;
        RegistBtnsAnimation();
    }
}
