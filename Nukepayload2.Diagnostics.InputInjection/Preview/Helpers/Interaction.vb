Namespace Preview
    Public Module Interaction

        Public Sub SendKeyDown(keyCode As ScanCode)
            If s_injection Is Nothing Then
                Throw New PlatformNotSupportedException
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = keyCode, .KeyOptions = InjectedInputKeyOptions.ScanCode
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

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

        Public Sub SendKey(key As VirtualKey)
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .VirtualKey = key
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        Public Sub SendChar(unicodeChar As Char)
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .ScanCode = AscW(unicodeChar), .KeyOptions = InjectedInputKeyOptions.Unicode
            }
            s_injection.InjectKeyboardInput(keyboardInfo)
        End Sub

        Public Async Function SendTextAsync(text As String, Optional delay As Integer = 34) As Task
            If text = Nothing Then
                Return
            End If
            Dim keyboardInfo As New InjectedInputKeyboardInfo With {
                .KeyOptions = InjectedInputKeyOptions.Unicode
            }
            For Each ch In text
                keyboardInfo.ScanCode = AscW(ch)
                s_injection.InjectKeyboardInput(keyboardInfo)
                Await Task.Delay(delay)
            Next
        End Function
    End Module
End Namespace