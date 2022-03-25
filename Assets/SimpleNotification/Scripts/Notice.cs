/*****************************************

    文件：Notice.cs
    日期：2022/3/21 14:50:50
    功能：显示通知

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    public static Notice Instance { get; private set; }

    public Canvas noticeCanvas;//通知面板
    public GameObject notificationObject;//通知

    private Canvas _noticeCanvas;

    public List<GameObject> _notificationObjectList;

    public class NotifyVariable
    {
        /// <summary>
        /// 通知文字
        /// </summary>
        public string text="请填写文字";
        /// <summary>
        /// 通知颜色（默认为白色）
        /// </summary>
        public Color color=new Color(1.0f,1.0f,1.0f,0.5f);
        /// <summary>
        /// 通知是否自动消失（默认为自动消失）
        /// </summary>
        public bool whetherToShutDownAutomatical=true;
        /// <summary>
        /// 通知消失时间（默认3.0秒）
        /// </summary>
        public float showTime=3.0f;
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _noticeCanvas = Instantiate(noticeCanvas,this.transform);

    }

    /// <summary>
    /// 显示通知
    /// </summary>
    /// <param name="text">需要显示的文字</param>
    /// <param name="color">显示颜色(默认为白色)</param>
    /// <param name="whetherToShutDownAutomatical">是否自动消失</param>
    /// <param name="showTime">显示时间（默认为3s）</param>
    /// <returns>通知物体</returns>
    public GameObject AccordingToNotice(NotifyVariable notifyVariable)
    {

        GameObject g = Instantiate(notificationObject, _noticeCanvas.transform);

        g.transform.GetChild(0).GetComponent<Image>().color = notifyVariable.color;
        g.transform.GetChild(1).GetComponent<Text>().text = notifyVariable.text;
        
        _notificationObjectList.Add(g);

        if (notifyVariable.whetherToShutDownAutomatical==true)
        {
            StartCoroutine(DelayToDelete(notifyVariable.showTime, g));
        }

        return g;
    }

    /// <summary>
    /// 延迟删除
    /// </summary>
    /// <param name="f">延迟时间</param>
    /// <param name="g">需要删除的物体</param>
    /// <returns></returns>
    IEnumerator DelayToDelete(float f, GameObject g)
    {
        yield return new WaitForSeconds(f);
        
        CloseToInform(g);

    }

    /// <summary>
    /// 关闭通知
    /// </summary>
    /// <param name="g">需要被关闭的通知</param>
    public void CloseToInform(GameObject g)
    {
        foreach (var _g in _notificationObjectList)
        {
            if (g==_g)
            {
                
                _g.GetComponent<Animator>().SetTrigger("Close");

                Destroy(_g,1.0f);
                _notificationObjectList.Remove(_g);
                return;
            }
        }
    }
    
    /// <summary>
    /// 关闭所有通知
    /// </summary>
    public void CloseToInform()
    {
        for (int i = _notificationObjectList.Count; i >0 ; i--)
        {
            var _g = _notificationObjectList[_notificationObjectList.Count-1];
            _g.GetComponent<Animator>().SetTrigger("Close");

            Destroy(_g,1.0f);
            _notificationObjectList.Remove(_g);
        }
    }
    
}
