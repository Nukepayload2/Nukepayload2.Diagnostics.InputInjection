''' <summary>
''' 指定不同的选项或修饰符，用于通过 InjectedInputMouseInfo、InjectedInputPenInfo 和 InjectedInputTouchInfo 模拟指针输入。
''' </summary>
Public Enum InjectedInputPointerOptions As UInteger
    ''' <summary>
    ''' 无指针修饰符。 默认值。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 表示新指针的到达。
    ''' </summary>
    [New] = 1
    ''' <summary>
    ''' 表示指针继续存在。 当该标志未设置时，表示指针已离开检测范围。
    ''' </summary>
    InRange = 2
    ''' <summary>
    ''' 表示指针与数字化仪表面或区域接触。当此标志未设置时，它表示悬停指针。
    ''' </summary>
    InContact = 4
    ''' <summary>
    ''' 表示主要操作。
    ''' </summary>
    FirstButton = 16
    ''' <summary>
    ''' 表示辅助操作。
    ''' </summary>
    SecondButton = 32
    ''' <summary>
    ''' 表示指针可执行除非主指针可用的操作之外的操作。 例如，当主指针与窗口表面接触时，它可以为窗口提供激活的机会。
    ''' </summary>
    Primary = 8192
    ''' <summary>
    ''' 表示来自源设备的关于指针是否表示预期或意外交互的建议，这与意外交互（例如用手掌）可触发输入的触摸指针尤其相关。 该标志的存在表示源设备非常确定该输入是预期交互的一部分。
    ''' </summary>
    Confidence = 16384
    ''' <summary>
    ''' 表示指针以异常方式离开，例如当系统接收到指针的无效输入时，或者当具有活动指针的设备突然离开时。 如果接收输入的应用程序处于这样做的位置，则它应该将交互视为未完成，并且反转指针的任何效果。
    ''' </summary>
    Canceled = 32768
    ''' <summary>
    ''' 表示此指针与数字化仪表面接触。 触摸指针在与数字化仪表面接触时设置该标志。
    ''' </summary>
    PointerDown = 65536
    ''' <summary>
    ''' 表示不包括指针状态更改的简单更新。
    ''' </summary>
    Update = 131072
    ''' <summary>
    ''' 表示此指针结束与数字化仪表面的接触。 触摸指针在结束与数字化仪表面的接触时设置该标志。
    ''' </summary>
    PointerUp = 262144
    ''' <summary>
    ''' 表示此指针由另一个元素捕获（关联），并且原始元素已丢失捕获。
    ''' </summary>
    CaptureChanged = 2097152
End Enum
