using LitJson;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour {

    #region 游戏配置表

    private static GameConfig m_GameConfig;
    public static GameConfig GetGameConfig
    {
        get {
            if (m_GameConfig == null)
                m_GameConfig = GetConfig(m_GameConfig, "游戏配置表.txt");
            return m_GameConfig; }
    }

    #endregion

    /// <summary>
    /// 获取指定的配置表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static T GetConfig<T>(T config,  string filePath)
    {
        if (config == null)
            config = JsonMapper.ToObject<T>(File.ReadAllText(Application.streamingAssetsPath + "/" + filePath));
        return config;
    }
}

public class GameConfig
{
    public bool 显示GUI;
    public bool 开启鼠标;
    public bool 开启全屏;
}


