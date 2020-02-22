Option Strict On

Public Module Interaction
    Friend ReadOnly s_injection As InputInjector

    Sub New()
        s_injection = InputInjector.TryCreate
        s_injection?.InitializeTouchInjection(InjectedInputVisualizationMode.Default)
    End Sub

    ''' <summary>
    ''' 发送一次单点触摸。包括按下，按住，和松开。
    ''' </summary>
    ''' <param name="posX">要触摸的位置 X</param>
    ''' <param name="posY">要触摸的位置 Y</param>
    ''' <param name="durationMilliseconds">触摸的持续时间</param>
    ''' <param name="orientation">指针设备绕长轴（z 轴，垂直于数字化仪的表面）的逆时针方向旋转角度。值介于 0 和 359 之间，其中 0 表示与 x 轴对齐并从左向右指向的触摸指针；增加值表示逆时针方向上的旋转度。</param>
    ''' <param name="pointerId">指针生命周期的唯一标识符。 指针在进入检测范围时创建，并在离开检测范围时被破坏。 如果指针超出检测范围，然后返回，则将其视为新指针，并可能会分配一个新的标识符。</param>
    ''' <param name="pressure">由指针设备施加在数字化仪表面上的力。规范化为 0 和 1024 之间的范围。默认值为 0。</param>
    ''' <param name="areaSize">触控接触区域的边界框的大小。以与设备无关的像素 (DIP) 为单位。默认是 4x4 的矩形。</param>
    ''' <param name="dragTo">按下屏幕期间，需要拖动到哪个点。</param>
    ''' <param name="dragEasingX">需要拖动到的点 X 轴的缓动函数。默认是线性缓动。参数在 0 到 1 之间。</param>
    ''' <param name="dragEasingY">需要拖动到的点 Y 轴的缓动函数。默认是线性缓动。参数在 0 到 1 之间。</param>
    ''' <remarks>缓动函数每秒钟会被执行 10000 次甚至更多。需要确保缓动函数不能包含过于耗时的操作，以免触摸模拟失败。</remarks>
    Public Sub SendTouch(posX As Integer, posY As Integer,
                         Optional durationMilliseconds As Integer = 150,
                         Optional orientation As Integer = 90,
                         Optional pointerId As Integer = 0,
                         Optional pressure As Integer = 1024,
                         Optional areaSize As (Width As Double, Height As Double)? = Nothing,
                         Optional dragTo As (X As Integer, Y As Integer)? = Nothing,
                         Optional dragEasingX As Func(Of Double, Double) = Nothing,
                         Optional dragEasingY As Func(Of Double, Double) = Nothing)
        If durationMilliseconds < 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(durationMilliseconds), "Value can't be < 0.")
        End If
        If orientation < 0 OrElse orientation > 359 Then
            Throw New ArgumentOutOfRangeException(NameOf(orientation), "Value can't be < 0 or > 359.")
        End If
        If pressure < 0 OrElse pressure > 1024 Then
            Throw New ArgumentOutOfRangeException(NameOf(pressure), "Value can't be < 0 or > 1024.")
        End If
        Dim pxWidth As Integer
        Dim pxHeight As Integer
        If areaSize Is Nothing Then
            pxWidth = 2
            pxHeight = 2
        Else
            Dim sizeValue = areaSize.Value
            If sizeValue.Width <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(sizeValue), "Width can't be <= 0.")
            End If
            If sizeValue.Height <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(sizeValue), "Height can't be <= 0.")
            End If
            pxWidth = CInt(sizeValue.Width / 2)
            pxHeight = CInt(sizeValue.Height / 2)
        End If
        If s_injection Is Nothing Then
            Throw New PlatformNotSupportedException
        End If
        With s_injection
            Dim touch As New InjectedInputTouchInfo With {
                .PointerInfo = New InjectedInputPointerInfo With {
                    .PointerId = CUInt(pointerId),
                    .PixelLocation = New InjectedInputPoint With {
                        .PositionX = posX, ' Y co-ordinate of touch on screen
                        .PositionY = posY ' X co-ordinate of touch on screen
                    },
                    .PointerType = PointerInputType.Touch ' Must be set to PointerInputType.Touch. It's different from UWP.
                },
                .TouchParameters =
                    InjectedInputTouchParameters.Contact Or
                    InjectedInputTouchParameters.Orientation Or
                    InjectedInputTouchParameters.Pressure, ' TouchMask
                .Orientation = CUInt(orientation),
                .Pressure = CUInt(pressure)
            }
            ' defining contact area (I have taken area of 4 x 4 pixel)
            Dim pxLoc As InjectedInputPoint = touch.PointerInfo.PixelLocation
            touch.Contact = New InjectedInputRectangle With {
                .Top = pxLoc.PositionY - pxHeight,
                .Bottom = pxLoc.PositionY + pxHeight,
                .Left = pxLoc.PositionX - pxWidth,
                .Right = pxLoc.PositionX + pxWidth
            }

            ' TouchDown
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.PointerDown Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            .InjectTouchInput(touch) ' Injecting the touch Down from screen

            ' Hold
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.Update Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            If durationMilliseconds > 0 Then
                Dim timer As New Stopwatch
                timer.Start()
                Dim spinWait As New Threading.SpinWait
                If dragTo Is Nothing Then
                    Do While timer.ElapsedMilliseconds < durationMilliseconds
                        .InjectTouchInput(touch)
                        spinWait.SpinOnce()
                    Loop
                Else
                    Dim dragToValue = dragTo.Value
                    Dim toX = dragToValue.X
                    Dim toY = dragToValue.Y
                    If dragEasingX Is Nothing Then
                        dragEasingX = Function(d) d
                    End If
                    If dragEasingY Is Nothing Then
                        dragEasingY = Function(d) d
                    End If
                    Do While timer.ElapsedMilliseconds < durationMilliseconds
                        Dim progress = timer.ElapsedMilliseconds / durationMilliseconds
                        Dim x = posX + CInt((toX - posX) * dragEasingX(progress))
                        Dim y = posY + CInt((toY - posY) * dragEasingY(progress))
                        touch.PointerInfo.PixelLocation.PositionX = x
                        touch.PointerInfo.PixelLocation.PositionY = y
                        .InjectTouchInput(touch)
                        spinWait.SpinOnce()
                    Loop
                End If
                timer.Stop()
            End If
            ' TouchUp
            touch.PointerInfo.PointerOptions = InjectedInputPointerOptions.PointerUp
            .InjectTouchInput(touch) ' Injecting the touch Up from screen
        End With
    End Sub

    ''' <summary>
    ''' 发送一次单点触摸。包括按下，按住，和松开。
    ''' </summary>
    ''' <param name="posX">要触摸的位置 X</param>
    ''' <param name="posY">要触摸的位置 Y</param>
    ''' <param name="durationMilliseconds">触摸的持续时间</param>
    ''' <param name="orientation">指针设备绕长轴（z 轴，垂直于数字化仪的表面）的逆时针方向旋转角度。值介于 0 和 359 之间，其中 0 表示与 x 轴对齐并从左向右指向的触摸指针；增加值表示逆时针方向上的旋转度。</param>
    ''' <param name="pointerId">指针生命周期的唯一标识符。 指针在进入检测范围时创建，并在离开检测范围时被破坏。 如果指针超出检测范围，然后返回，则将其视为新指针，并可能会分配一个新的标识符。</param>
    ''' <param name="pressure">由指针设备施加在数字化仪表面上的力。规范化为 0 和 1024 之间的范围。默认值为 0。</param>
    ''' <param name="areaSize">触控接触区域的边界框的大小。以与设备无关的像素 (DIP) 为单位。默认是 4x4 的矩形。</param>
    ''' <param name="dragTo">按下屏幕期间，需要拖动到哪个点。</param>
    ''' <param name="dragEasingX">需要拖动到的点 X 轴的缓动函数。默认是线性缓动。参数在 0 到 1 之间。</param>
    ''' <param name="dragEasingY">需要拖动到的点 Y 轴的缓动函数。默认是线性缓动。参数在 0 到 1 之间。</param>
    ''' <remarks>缓动函数每秒钟会被执行 10000 次甚至更多。需要确保缓动函数不能包含过于耗时的操作，以免触摸模拟失败。</remarks>
    Public Async Function SendTouchAsync(posX As Integer, posY As Integer,
            Optional durationMilliseconds As Integer = 150,
            Optional orientation As Integer = 90,
            Optional pointerId As Integer = 0,
            Optional pressure As Integer = 1024,
            Optional areaSize As (Width As Double, Height As Double)? = Nothing,
            Optional dragTo As (X As Integer, Y As Integer)? = Nothing,
            Optional dragEasingX As Func(Of Double, Double) = Nothing,
            Optional dragEasingY As Func(Of Double, Double) = Nothing) As Task
        If durationMilliseconds < 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(durationMilliseconds), "Value can't be < 0.")
        End If
        If orientation < 0 OrElse orientation > 359 Then
            Throw New ArgumentOutOfRangeException(NameOf(orientation), "Value can't be < 0 or > 359.")
        End If
        If pressure < 0 OrElse pressure > 1024 Then
            Throw New ArgumentOutOfRangeException(NameOf(pressure), "Value can't be < 0 or > 1024.")
        End If
        Dim pxWidth As Integer
        Dim pxHeight As Integer
        If areaSize Is Nothing Then
            pxWidth = 2
            pxHeight = 2
        Else
            Dim sizeValue = areaSize.Value
            If sizeValue.Width <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(sizeValue), "Width can't be <= 0.")
            End If
            If sizeValue.Height <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(sizeValue), "Height can't be <= 0.")
            End If
            pxWidth = CInt(sizeValue.Width / 2)
            pxHeight = CInt(sizeValue.Height / 2)
        End If
        If s_injection Is Nothing Then
            Throw New PlatformNotSupportedException
        End If
        With s_injection
            Dim touch As New InjectedInputTouchInfo With {
                .PointerInfo = New InjectedInputPointerInfo With {
                    .PointerId = CUInt(pointerId),
                    .PixelLocation = New InjectedInputPoint With {
                        .PositionX = posX, ' Y co-ordinate of touch on screen
                        .PositionY = posY ' X co-ordinate of touch on screen
                    },
                    .PointerType = PointerInputType.Touch ' Must be set to PointerInputType.Touch. It's different from UWP.
                },
                .TouchParameters =
                    InjectedInputTouchParameters.Contact Or
                    InjectedInputTouchParameters.Orientation Or
                    InjectedInputTouchParameters.Pressure, ' TouchMask
                .Orientation = CUInt(orientation),
                .Pressure = CUInt(pressure)
            }
            ' defining contact area (I have taken area of 4 x 4 pixel)
            Dim pxLoc As InjectedInputPoint = touch.PointerInfo.PixelLocation
            touch.Contact = New InjectedInputRectangle With {
                .Top = pxLoc.PositionY - pxHeight,
                .Bottom = pxLoc.PositionY + pxHeight,
                .Left = pxLoc.PositionX - pxWidth,
                .Right = pxLoc.PositionX + pxWidth
            }

            ' TouchDown
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.PointerDown Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            .InjectTouchInput(touch) ' Injecting the touch Down from screen

            ' Hold
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.Update Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            If durationMilliseconds > 0 Then
                Dim timer As New Stopwatch
                timer.Start()
                Const YieldThreshold = 10
                Dim yieldCount = 0
                If dragTo Is Nothing Then
                    Do While timer.ElapsedMilliseconds < durationMilliseconds
                        .InjectTouchInput(touch)

                        yieldCount += 1
                        If yieldCount > YieldThreshold Then
                            yieldCount = 0
                            Await Task.Yield
                        End If
                    Loop
                Else
                    Dim dragToValue = dragTo.Value
                    Dim toX = dragToValue.X
                    Dim toY = dragToValue.Y
                    If dragEasingX Is Nothing Then
                        dragEasingX = Function(d) d
                    End If
                    If dragEasingY Is Nothing Then
                        dragEasingY = Function(d) d
                    End If
                    Do While timer.ElapsedMilliseconds < durationMilliseconds
                        Dim progress = timer.ElapsedMilliseconds / durationMilliseconds
                        Dim x = posX + CInt((toX - posX) * dragEasingX(progress))
                        Dim y = posY + CInt((toY - posY) * dragEasingY(progress))
                        touch.PointerInfo.PixelLocation.PositionX = x
                        touch.PointerInfo.PixelLocation.PositionY = y
                        .InjectTouchInput(touch)

                        yieldCount += 1
                        If yieldCount > YieldThreshold Then
                            yieldCount = 0
                            Await Task.Yield
                        End If
                    Loop
                End If
                timer.Stop()
            End If
            ' TouchUp
            touch.PointerInfo.PointerOptions = InjectedInputPointerOptions.PointerUp
            .InjectTouchInput(touch) ' Injecting the touch Up from screen
        End With
    End Function
End Module
