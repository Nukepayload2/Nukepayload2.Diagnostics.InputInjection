Namespace Preview
    Public Module Interaction

        ''' <summary>
        ''' 注入全局的按键按下输入
        ''' </summary>
        ''' <param name="keyCode">按键的扫描码。</param>
        Public Sub SendKeyDown(keyCode As ScanCode)
            If s_injection Is Nothing Then
                Throw New PlatformNotSupportedException
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = keyCode, .KeyOptions = InjectedInputKeyOptions.ScanCode
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        ''' <summary>
        ''' 注入全局的按键按下输入
        ''' </summary>
        ''' <param name="key">按键的虚拟键码。将发送等价的扫描码。</param>
        Public Sub SendKeyDown(key As VirtualKey)
            SendKeyDown(key.ToScanCode)
        End Sub

        ''' <summary>
        ''' 注入全局的按键松开输入
        ''' </summary>
        ''' <param name="keyCode">按键的扫描码。</param>
        Public Sub SendKeyUp(keyCode As ScanCode)
            If s_injection Is Nothing Then
                Throw New PlatformNotSupportedException
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = keyCode, .KeyOptions = InjectedInputKeyOptions.ScanCode Or
                InjectedInputKeyOptions.KeyUp
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        ''' <summary>
        ''' 注入全局的按键松开输入
        ''' </summary>
        ''' <param name="key">按键的虚拟键码。将发送等价的扫描码。</param>
        Public Sub SendKeyUp(key As VirtualKey)
            SendKeyUp(key.ToScanCode)
        End Sub

        ''' <summary>
        ''' 注入全局的按键按下然后松开输入。通常对游戏模拟输入需要用这种方式。
        ''' </summary>
        ''' <param name="keyCode">按键的扫描码。可以通过 Win32 API MapVirtualKey 得到扫描码。</param>
        ''' <param name="delay">按键按下到松开的间隔 (毫秒)</param>
        Public Async Function SendKeyPressToGameAsync(keyCode As ScanCode, delay As Integer) As Task
            If s_injection Is Nothing Then
                Throw New PlatformNotSupportedException
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = keyCode, .KeyOptions = InjectedInputKeyOptions.ScanCode
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
            Await Task.Delay(delay)
            keyboardInfo.KeyOptions = InjectedInputKeyOptions.KeyUp Or InjectedInputKeyOptions.ScanCode
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Function

        ''' <summary>
        ''' 注入全局的按键按下然后松开输入。通常对游戏模拟输入需要用这种方式。
        ''' </summary>
        ''' <param name="key">按键的虚拟键码。将对游戏发送等价的扫描码。</param>
        ''' <param name="delay">按键按下到松开的间隔 (毫秒)</param>
        Public Async Function SendKeyPressToGameAsync(key As VirtualKey, Optional delay As Integer = 34) As Task
            Await SendKeyPressToGameAsync(key.ToScanCode, delay)
        End Function

        ''' <summary>
        ''' 注入全局的虚拟按键输入
        ''' </summary>
        ''' <param name="key">按键的虚拟键码。</param>
        Public Sub SendKey(key As VirtualKey)
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .VirtualKey = key
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        ''' <summary>
        ''' 注入全局的字符输入。用于模拟输入法和包含特殊文字的键盘。
        ''' </summary>
        ''' <param name="unicodeChar">按键的 Unicode 码。</param>
        Public Sub SendChar(unicodeChar As Char)
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = AscW(unicodeChar), .KeyOptions = InjectedInputKeyOptions.Unicode
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        ''' <summary>
        ''' 注入全局的字符串输入。用于模拟输入法和包含特殊文字的键盘。
        ''' </summary>
        ''' <param name="text">需要输入的文本</param>
        ''' <param name="interval">输入文本的间隔 (毫秒)</param>
        Public Async Function SendTextAsync(text As String, Optional interval As Integer = 34) As Task
            If text = Nothing Then
                Return
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .KeyOptions = InjectedInputKeyOptions.Unicode
            }
            For Each ch In text
                keyboardInfo.ScanCode = AscW(ch)
                s_injection.InjectKeyboardInput(keyboardInfo)
                Await Task.Delay(interval)
            Next
        End Function
    End Module
End Namespace