Public Class InaccurateTouchPoint
    Public Property InaccurateX As Integer
    Public Property InaccurateY As Integer
    Public Property XOffset As Integer
    Public Property YOffset As Integer
    Public Property HoldTimeMaxOffset As Integer = 324

    Public Shared ReadOnly Button As New InaccurateTouchPoint With {
        .InaccurateX = 80, .InaccurateY = 20
    }
End Class
