Imports Nukepayload2.Diagnostics
Imports Nukepayload2.Diagnostics.Preview
Imports Nukepayload2.UI.Win32

Class MainWindow
    Private Sub TitleBarDragElement_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TitleBarDragElement.PreviewMouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox("Version: " + My.Application.Info.Version.ToString, MsgBoxStyle.Information)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub MainWindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        Dim windowCompositionFactory As New WindowCompositionFactory
        If Win32ApiInformation.IsWindowAcrylicApiPresent OrElse Win32ApiInformation.IsAeroGlassApiPresent Then
            ' Enable blur effect
            Dim composition = windowCompositionFactory.TryCreateForCurrentView
            If composition?.TrySetBlur(Me, True) Then
                TitleBar.Background = New SolidColorBrush(Color.FromArgb(&H99, &HFF, &HFF, &HFF))
                ClientArea.Background = New SolidColorBrush(Color.FromArgb(&HCC, &HFF, &HFF, &HFF))
                Background = Brushes.Transparent
            End If
        End If
        If Win32ApiInformation.IsProcessDpiAwarenessApiPresent Then
            ' Enable DPI awareness
            DpiAwareness = ProcessDpiAwareness.PerMonitorDpiAware
        End If
    End Sub

    Private Async Sub BtnInputVK_ClickAsync(sender As Object, e As RoutedEventArgs) Handles BtnInputVK.Click
        TxtTest.Focus()
        Await Task.Delay(100)
        Dim inject = InputInjector.TryCreate
        If inject IsNot Nothing Then
            InjectVirtualKeyPress(inject, VirtualKey.W)
            Await Task.Delay(100)
            InjectVirtualKeyPress(inject, VirtualKey.A)
            Await Task.Delay(100)
            InjectVirtualKeyPress(inject, VirtualKey.S)
            Await Task.Delay(100)
            InjectVirtualKeyPress(inject, VirtualKey.D)
        End If
    End Sub

    Private Shared Sub InjectVirtualKeyPress(inject As InputInjector, key As VirtualKey)
        Dim keyboardInfo As New InjectedInputKeyboardInfo With {
            .VirtualKey = key
        }
        inject.InjectKeyboardInput(keyboardInfo)
    End Sub

    Private Shared Sub InjectUnicodeKeyPress(inject As InputInjector, key As Char)
        Dim keyboardInfo As New InjectedInputKeyboardInfo With {
            .ScanCode = AscW(key), .KeyOptions = InjectedInputKeyOptions.Unicode
        }
        inject.InjectKeyboardInput(keyboardInfo)
    End Sub

    Private Shared Async Function InjectScanKeyDownAndUp(
        inject As InputInjector,
        key As ScanCode,
        Optional delay As Integer = 34
    ) As Task
        Dim keyboardInfo As New InjectedInputKeyboardInfo With {
            .ScanCode = key, .KeyOptions = InjectedInputKeyOptions.ScanCode
        }
        inject.InjectKeyboardInput(keyboardInfo)
        Await Task.Delay(delay)
        keyboardInfo.KeyOptions = InjectedInputKeyOptions.KeyUp Or InjectedInputKeyOptions.ScanCode
        keyboardInfo.ScanCode = key
        inject.InjectKeyboardInput(keyboardInfo)
    End Function

    Private Async Sub BtnInputScan_ClickAsync(sender As Object, e As RoutedEventArgs) Handles BtnInputScan.Click
        TxtTest.Focus()
        Await Task.Delay(100)
        Dim inject = InputInjector.TryCreate
        If inject IsNot Nothing Then
            Await SendKeyPressToGameAsync(VirtualKey.Control, VirtualKey.A)
            Await Task.Delay(100)
            Await InjectScanKeyDownAndUp(inject, ScanCode.KEY_W)
            Await Task.Delay(100)
            Await SendKeyPressToGameAsync(VirtualKey.A)
            Await Task.Delay(100)
            Await SendKeyPressToGameAsync(ScanCode.KEY_S, 34)
            Await Task.Delay(100)
            Await SendKeyPressToGameAsync(VirtualKey.D)
        End If
    End Sub

    Private Async Sub BtnInputUnicode_ClickAsync(sender As Object, e As RoutedEventArgs) Handles BtnInputUnicode.Click
        TxtTest.Focus()
        Await Task.Delay(100)
        Dim inject = InputInjector.TryCreate
        If inject IsNot Nothing Then
            InjectUnicodeKeyPress(inject, "W"c)
            Await Task.Delay(100)
            InjectUnicodeKeyPress(inject, "A"c)
            Await Task.Delay(100)
            InjectUnicodeKeyPress(inject, "S"c)
            Await Task.Delay(100)
            SendChar("D"c)
            Await Task.Delay(100)
            Await SendTextAsync("中文にほんご")
        End If
    End Sub
End Class
