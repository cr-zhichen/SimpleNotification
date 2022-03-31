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
        },(g) =>
        {
            Notice.Instance.CloseToInform(g);
        });
    }

    public void CloseAllNotifications()
    {
        Notice.Instance.CloseToInform();
    }
    
    public void LoadingNotice()
    {
        Coroutine _Load = null;
        
        GameObject _g= Notice.Instance.AccordingToNotice(new Notice.NotifyVariable()
        {
            text = "加载中",
            color = new Color(0.5f,0.5f,0.5f,0.5f),
            whetherToShutDownAutomatical = false,
            showTime = 0
        }, (g) =>
        {
            Notice.Instance.CloseToInform(g);
            StopCoroutine(_Load);
        });
        
         _Load = StartCoroutine(Load(_g));
    }

    IEnumerator Load(GameObject g)
    {
        string s = "加载中";
        float timer=0;
        while (true)
        {
            if (s.Length>=10)
            {
                s = "加载中";
            }
            else
            {
                s += ".";
            }
            Notice.Instance.ChangeNotice(g,null, s);
            yield return new WaitForSeconds(0.5f);
            timer += 0.5f;
            if (timer>5.0f)
            {
                Notice.Instance.ChangeNotice(g,new Color(0.5f,1.0f,0.5f,0.5f),"加载完成");
                //延迟一秒关闭
                yield return new WaitForSeconds(1.0f);
                Notice.Instance.CloseToInform(g);
                break;
            }
        }
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
