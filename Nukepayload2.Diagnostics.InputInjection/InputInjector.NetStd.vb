﻿Imports System.Runtime.InteropServices

Partial Public Class InputInjector

    ''' <summary>
    ''' 尝试创建 InputInjector 类的新实例。
    ''' </summary>
    ''' <returns>如果成功，则会返回 InputInjector 类的新实例。 否则，将返回 null。</returns>
    Public Shared Function TryCreate() As InputInjector
        Dim isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        If isWindows AndAlso
           InputInjectionApiInformation.IsInjectTouchInputApiPresent Then
            Return New InputInjector
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' 尝试创建支持预览功能的 InputInjector 类的新实例。
    ''' </summary>
    ''' <returns>如果成功，则会返回 InputInjector 类的新实例。 否则，将返回 null（在 Visual Basic 为 Nothing）。</returns>
    Public Shared Function TryCreateWithPreviewFeatures() As InputInjector
        Dim isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        If isWindows AndAlso
           InputInjectionApiInformation.IsInjectTouchInputApiPresent AndAlso
           InputInjectionApiInformation.IsInjectKeyboardInputApiPresent AndAlso
           InputInjectionApiInformation.IsInjectMouseInputApiPresent Then
            Return New InputInjector
        End If
        Return Nothing
    End Function

End Class
