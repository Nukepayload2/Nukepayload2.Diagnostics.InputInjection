'typedef struct tagPOINTER_TOUCH_INFO {
'    POINTER_INFO    pointerInfo;
'    TOUCH_FLAGS     touchFlags;
'    TOUCH_MASK      touchMask;
'    RECT            rcContact;
'    RECT            rcContactRaw;
'    UINT32          orientation;
'    UINT32          pressure;
'} POINTER_TOUCH_INFO;
''' <summary>
''' 表示以编程方式生成的触控输入。
''' </summary>
Public Structure InjectedInputTouchInfo
    ''' <summary>
    ''' 获取或设置触控输入共有的基本指针信息。
    ''' </summary>
    Dim PointerInfo As InjectedInputPointerInfo
    Dim TouchFlags As UInteger ' TOUCH_FLAG_NONE = 0
    ''' <summary>
    ''' 获取或设置用于模拟触控输入的触摸状态。
    ''' </summary>
    Dim TouchParameters As InjectedInputTouchParameters
    ''' <summary>
    ''' 获取或设置表示触控接触区域的边界框的屏幕坐标。以与设备无关的像素 (DIP) 为单位。 默认值为 0 × 0 矩形，以指针 PixelLocation 为中心。
    ''' </summary>
    Dim Contact As InjectedInputRectangle
    Dim ContactRaw As InjectedInputRectangle
    ''' <summary>
    ''' 获取或设置指针设备绕长轴（z 轴，垂直于数字化仪的表面）的逆时针方向旋转角度。值介于 0 和 359 之间，其中 0 表示与 x 轴对齐并从左向右指向的触摸指针；增加值表示逆时针方向上的旋转度。 默认值为 0。
    ''' </summary>
    Dim Orientation As UInteger
    ''' <summary>
    ''' 获取或设置由指针设备施加在数字化仪表面上的力。规范化为 0 和 1024 之间的范围。默认值为 0。
    ''' </summary>
    Dim Pressure As UInteger
End Structure
