Public Class InputInjectionApiInformation

    Public Shared Function IsInjectKeyboardInputApiPresent() As Boolean
        Return IsProcedurePresent(User32DllName, NameOf(Preview.InjectKeyboardInput))
    End Function

    Public Shared Function IsInjectMouseInputApiPresent() As Boolean
        Return IsProcedurePresent(User32DllName, NameOf(Preview.InjectMouseInput))
    End Function

    Public Shared Function IsInjectTouchInputApiPresent() As Boolean
        Return IsProcedurePresent(User32DllName, NameOf(InjectTouchInput))
    End Function

    Public Shared Function IsProcedurePresent(library As String, procedure As String) As Boolean
        If String.IsNullOrWhiteSpace(library) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(procedure) Then
            Return False
        End If

        Dim hModule = LoadLibrary(library)
        If hModule = IntPtr.Zero Then
            Return False
        End If

        Dim proc = GetProcAddress(hModule, procedure)
        Return proc <> IntPtr.Zero
    End Function

End Class
