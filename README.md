# 简单的Unity全局通知

[WebGl示例](https://cr-zhichen.github.io/SimpleNotification/)

## 资源使用方式

1. 直接克隆该项目
2. 导入[unitypackage包](https://github.com/cr-zhichen/SimpleNotification/releases)

## 使用方法

### 显示通知

示例调用：

```c#
GameObject _notice =  Notice.Instance.AccordingToNotice(new Notice.NotifyVariable()
        {
            //通知文字
            text = "通知文字",
            //通知颜色
            color = Color.Red,
            //通知是否自动消失
            whetherToShutDownAutomatical = true,
            //通知消失时间
            showTime = 3.0f
        },(g) =>
        {
            //点击通知后删除通知
            Notice.Instance.CloseToInform(g);
        });
```

### 关闭对应通知

示例调用：

```c#
Notice.Instance.CloseToInform(_notice);
```

### 关闭所有通知

示例调用：

```c#
Notice.Instance.CloseToInform();
```

### 更换通知颜色与文字

示例调用：

```c#
public void LoadingNotice()
    {
        Coroutine _Load = null;
        
        GameObject _g= Notice.Instance.AccordingToNotice(new Notice.NotifyVariable()
        {
            text = "加载中",
            color = new Color(1.0f,0.5f,0.5f,0.5f),
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
```

## 演示视频

https://user-images.githubusercontent.com/57337795/161046944-c2138569-c8a2-4dd7-9435-d04665d054a7.mp4
