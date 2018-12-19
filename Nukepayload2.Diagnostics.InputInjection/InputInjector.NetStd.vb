Imports System.Runtime.InteropServices

Partial Public Class InputInjector

    ''' <summary>
    ''' 尝试创建 InputInjector 类的新实例。
    ''' </summary>
    ''' <returns>如果成功，则会返回 InputInjector 类的新实例。 否则，将返回 null。</returns>
    Public Shared Function TryCreate() As InputInjector
        Dim isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        If isWindows Then
            Dim winver = Environment.OSVersion.Version
            If winver.Major > 6 Then
                Return New InputInjector
            ElseIf winver.Major = 6 Then
                If winver.Minor >= 2 Then
                    Return New InputInjector
                End If
            End If
        End If
        Return Nothing
    End Function

End Class
