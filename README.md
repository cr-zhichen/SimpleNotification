# 简单的Unity全局通知

## 使用方法

### 调用前准备

将[Notice.cs](./Assets/Scripts/Notice.cs)脚本挂载到场景中  

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
            //通知是否消失
            showTime = 3.0f
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

## 演示截图

![演示截图](https://tc.chengrui.xyz/2022/03/25/1648199064343.gif)  
