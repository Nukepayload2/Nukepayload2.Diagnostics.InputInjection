Public Class PointPicker

    Private Sub PointPicker_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.PreviewMouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub PointPicker_PreviewMouseMove(sender As Object, e As MouseEventArgs) Handles Me.PreviewMouseMove
        If e.LeftButton = MouseButtonState.Pressed Then DragMove()
    End Sub

    Private Sub PointPicker_PreviewMouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles Me.PreviewMouseLeftButtonUp
        Close()
    End Sub
End Class
