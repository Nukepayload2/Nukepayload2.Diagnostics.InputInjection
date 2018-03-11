Imports System.ComponentModel

''' <summary>
''' 表示用于发送输入数据的虚拟输入设备。
''' </summary>
Public NotInheritable Class InputInjection
    Private Sub New()

    End Sub

    ''' <summary>
    ''' 初始化可以合成输入事件并向你的应用提供相应输入数据的虚拟触控设备。
    ''' </summary>
    ''' <param name="visualMode">触控输入式注入的可视反馈模式。</param>
    Public Sub InitializeTouchInjection(visualMode As InjectedInputVisualizationMode,
                                        Optional maxCount As Integer = 10)
        If Not UnsafeNativeMethods.InitializeTouchInjection(maxCount, visualMode) Then
            Throw New Win32Exception
        End If
    End Sub

    Public Sub InjectTouchInput(ParamArray input As InjectedInputTouchInfo())
        If Not UnsafeNativeMethods.InjectTouchInput(input.Count, input) Then
            Throw New Win32Exception
        End If
    End Sub

    ''' <summary>
    ''' 尝试创建 InputInjector 类的新实例。
    ''' </summary>
    ''' <returns>如果成功，则会返回 InputInjector 类的新实例。 否则，将返回 null。</returns>
    Public Shared Function TryCreate() As InputInjection
        Dim winver = Environment.OSVersion.Version
        If winver.Major > 6 Then
            Return New InputInjection
        ElseIf winver.Major = 6 Then
            If winver.Minor >= 2 Then
                Return New InputInjection
            End If
        End If
        Return Nothing
    End Function

End Class
