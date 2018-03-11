'typedef struct tagPOINTER_INFO {
'    POINTER_INPUT_TYPE    pointerType;
'    UINT32          pointerId;
'    UINT32          frameId;
'    POINTER_FLAGS   pointerFlags;
'    HANDLE          sourceDevice;
'    HWND            hwndTarget;
'    POINT           ptPixelLocation;
'    POINT           ptHimetricLocation;
'    POINT           ptPixelLocationRaw;
'    POINT           ptHimetricLocationRaw;
'    DWORD           dwTime;
'    UINT32          historyCount;
'    INT32           InputData;
'    DWORD           dwKeyStates;
'    UINT64          PerformanceCount;
'    POINTER_BUTTON_CHANGE_TYPE ButtonChangeType;
'} POINTER_INFO;
''' <summary>
''' 包含所有指针类型通用的基本指针信息。
''' </summary>
Public Structure InjectedInputPointerInfo
    Dim PointerType As PointerInputType
    ''' <summary>
    ''' 指针生命周期的唯一标识符。 指针在进入检测范围时创建，并在离开检测范围时被破坏。 如果指针超出检测范围，然后返回，则将其视为新指针，并可能会分配一个新的标识符。
    ''' </summary>
    Dim PointerId As UInteger
    Dim FrameId As UInteger
    ''' <summary>
    ''' 不同的选项或修饰符，用于通过 InjectedInputMouseInfo、InjectedInputPenInfo 和 InjectedInputTouchInfo 模拟指针输入。
    ''' </summary>
    Dim PointerOptions As InjectedInputPointerOptions
    Dim SourceDevice As IntPtr
    Dim HwndTarget As IntPtr
    ''' <summary>
    ''' 指针的屏幕坐标，以与设备无关的像素 (DIP) 为单位。
    ''' </summary>
    Dim PixelLocation As InjectedInputPoint
    Dim HimetricLocation As InjectedInputPoint
    Dim PixelLocationRaw As InjectedInputPoint
    Dim HimetricLocationRaw As InjectedInputPoint
    ''' <summary>
    ''' 定时输入事件（如双击/点击）的基线或参考值，以毫秒为单位。
    ''' </summary>
    Dim TimeOffsetInMilliseconds As UInteger
    Dim HistoryCount As UInteger
    Dim InputData As Integer
    Dim KeyStates As UInteger
    ''' <summary>
    ''' 用于时间间隔测量的高分辨率（小于 1 微秒）时间戳。
    ''' </summary>
    Dim PerformanceCount As ULong
    Dim ButtonChangeType As PointerButtonChangeType
End Structure
