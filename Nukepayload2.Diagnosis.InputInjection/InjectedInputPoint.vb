
''' <summary>
''' 包含指针的屏幕坐标，在非 Raw 参数中以与设备无关的像素 (DIP) 为单位。
''' </summary>
Public Structure InjectedInputPoint
    ''' <summary>
    ''' 指针的 x 坐标（在非 Raw 参数中以与设备无关的像素 (DIP) 为单位）。
    ''' </summary>
    Public PositionX As Integer
    ''' <summary>
    ''' 指针的 y 坐标（在非 Raw 参数中以与设备无关的像素 (DIP) 为单位）。
    ''' </summary>
    Public PositionY As Integer
End Structure
