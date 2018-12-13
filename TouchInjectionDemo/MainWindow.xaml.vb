Imports System.Windows.Threading
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

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        DataContext = TouchInjectionViewModel.Instance
    End Sub

    Private Sub RectPointPicker_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles RectPointPicker.PreviewMouseLeftButtonDown
        Dim picker As New PointPicker
        Dim mousePt = e.GetPosition(Me)
        Dim mouseX = mousePt.X + Left
        Dim mouseY = mousePt.Y + Top
        picker.Left = mouseX - 16
        picker.Top = mouseY - 16
        RectPointPicker.Visibility = Visibility.Collapsed
        picker.Focus()
        AddHandler picker.Closing,
            Sub()
                Dim vm = TouchInjectionViewModel.Instance
                vm.PositionX = picker.Left + 16
                vm.PositionY = picker.Top + 16
                RectPointPicker.Visibility = Visibility.Visible
            End Sub
        picker.Show()
    End Sub

End Class
