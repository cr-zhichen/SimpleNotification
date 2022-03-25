using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeganToNotice : MonoBehaviour
{

    public List<NotifyVariable> notifyVariables = new List<NotifyVariable>();

    public void StartNotice(int i)
    {
        Notice.Instance.AccordingToNotice(new Notice.NotifyVariable()
        {
            text = notifyVariables[i].text,
            color = notifyVariables[i].color,
            whetherToShutDownAutomatical = notifyVariables[i].whetherToShutDownAutomatical,
            showTime = notifyVariables[i].showTime
        });
    }

    public void CloseAllNotifications()
    {
        Notice.Instance.CloseToInform();
    }
    
    [System.Serializable]
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
}
