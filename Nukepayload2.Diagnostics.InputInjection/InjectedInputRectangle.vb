
''' <summary>
''' 表示触控接触区域的边界框的屏幕坐标。
''' </summary>
Public Structure InjectedInputRectangle
    ''' <summary>
    ''' 矩形左侧的 x 坐标位置，在非 Raw 参数中以与设备无关的像素 (DIP) 为单位。
    ''' </summary>
    Public Left As Integer
    ''' <summary>
    ''' 矩形顶部的 y 坐标位置，在非 Raw 参数中以与设备无关的像素 (DIP) 为单位。
    ''' </summary>
    Public Top As Integer
    ''' <summary>
    ''' 矩形底部的 y 坐标位置，在非 Raw 参数中以与设备无关的像素 (DIP) 为单位。
    ''' </summary>
    Public Bottom As Integer
    ''' <summary>
    ''' 矩形左侧的 y 坐标位置，在非 Raw 参数中以与设备无关的像素 (DIP) 为单位。
    ''' </summary>
    Public Right As Integer
End Structure
