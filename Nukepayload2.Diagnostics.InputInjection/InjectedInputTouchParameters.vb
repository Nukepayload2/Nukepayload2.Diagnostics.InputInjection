''' <summary>
''' 指定用于通过 InjectedInputTouchInfo 模拟触摸输入的触摸状态。
''' </summary>
<Flags>
Public Enum InjectedInputTouchParameters As UInteger
    ''' <summary>
    ''' 未报告触摸状态。 默认值。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 表示触控接触区域的边界框的屏幕坐标。
    ''' </summary>
    Contact = 1
    ''' <summary>
    ''' 指针设备绕长轴（z 轴，垂直于数字化仪的表面）的逆时针方向旋转角度。
    ''' </summary>
    Orientation = 2
    ''' <summary>
    ''' 由指针设备施加在数字化仪表面上的力。
    ''' </summary>
    Pressure = 4
End Enum
