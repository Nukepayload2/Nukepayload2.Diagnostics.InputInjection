Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Nukepayload2.Diagnostics.Preview

''' <summary>
''' 表示用于发送输入数据的虚拟输入设备。
''' </summary>
Public NotInheritable Class InputInjector
    Private Sub New()

    End Sub

    ''' <summary>
    ''' 初始化可以合成输入事件并向你的应用提供相应输入数据的虚拟触控设备。
    ''' </summary>
    ''' <param name="visualMode">触控输入式注入的可视反馈模式。</param>
    ''' <exception cref="Win32Exception"/>
    Public Sub InitializeTouchInjection(visualMode As InjectedInputVisualizationMode,
                                        Optional maxCount As Integer = 10)
        If Not UnsafeNativeMethods.InitializeTouchInjection(maxCount, visualMode) Then
            Throw New Win32Exception
        End If
    End Sub

    ''' <summary>
    ''' 以编程方式注入触摸输入。如果成功，返回 True。如果注入的间隔小于 0.1 毫秒, 返回 False, 否则引发 <see cref="Win32Exception"/>。
    ''' </summary>
    ''' <param name="input">要注入的触摸输入</param>
    ''' <returns>如果成功，返回 True。如果注入的间隔小于 0.1 毫秒导致系统没能接收触摸注入, 返回 False。</returns>
    ''' <exception cref="Win32Exception"/>
    Public Function InjectTouchInput(ParamArray input As InjectedInputTouchInfo()) As Boolean
        If Not UnsafeNativeMethods.InjectTouchInput(input.Length, input) Then
            Const ERROR_NOT_READY As Integer = 21
            If Marshal.GetLastWin32Error = ERROR_NOT_READY Then
                Return False
            End If
            Throw New Win32Exception
        End If
        Return True
    End Function

    ''' <summary>
    ''' (Preview) Sends programmatically generated keyboard input to the system.
    ''' </summary>
    ''' <param name="input">The keyboard input specified by <see cref="InjectedInputKeyboardInfo"/>.</param>
    Public Sub InjectKeyboardInput(ParamArray input As InjectedInputKeyboardInfo())
        If Not Preview.InjectKeyboardInput(input, input.Length) Then
            Throw New Win32Exception
        End If
    End Sub

    ''' <summary>
    ''' (Preview) Sends programmatically generated mouse input to the system.
    ''' </summary>
    ''' <param name="input">The keyboard input specified by <see cref="InjectedInputMouseInfo"/>.</param>
    Public Sub InjectMouseInput(ParamArray input As InjectedInputMouseInfo())
        If Not Preview.InjectMouseInput(input, input.Length) Then
            Throw New Win32Exception
        End If
    End Sub

End Class
