# 一个用C#写的热键类

相比windows自带的 ```RegistetHotKey``` 有如下优势

+ 不占用正常的按键使用
+ 不需要依附与窗口和线程工作，windows自带的```RegisterHotKey```需要依附于windows的消息机制才可以运行
+ 可以绑定指定窗口，也可以注册不需要管理员权限的全局热键。

### 用法

在```Form_Load```的时候调用```HotKey.initialize()```

然后在注册的热键 的地方调用 ```HotKey.registetHotKey(new List<Keys> { Keys.A }, a);```

第一个参数是一个  ```Keys List ``` 需要按下所有的键然后单独按下最后一个键即可，比如 *ctrl + alt + a* 

则需要按住 *ctrl+alt* 然后按下 *a* 

注册的方法是 ```HotKey.registetHotKey(new List<Keys> { Keys.ControlKey , Keys.Meau,Keys.A}, a);`

第二个参数是一个Action委托 具体用法参见 <https://msdn.microsoft.com/zh-cn/library/system.action.aspx>

### 类的各个属性

`bindWindow` : 生效窗口,热键仅在此窗口生效，如果为0则为全局生效。

`sleepTime`：每次扫描间隔时间，默认10ms扫描一次

`Release`：释放热键线程。



# 目前仍存在的问题

如果同时注册 `Ctrl + Alt + A` 和 `Ctrl + A` 则会出现冲突 ，因为 `Ctrl = Shift + Lbutton` 所以目前没有比较好的解决方案