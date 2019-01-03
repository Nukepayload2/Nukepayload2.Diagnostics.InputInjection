Option Strict On
Imports System.Runtime.CompilerServices

Namespace Preview

    Public Module KeyCodeConversion
        ''' <summary>
        ''' 根据当前的键盘布局转换虚拟键为扫描码。如果无法转换，返回 0。
        ''' </summary>
        ''' <param name="vk"></param>
        <Extension>
        Public Function ToScanCode(vk As VirtualKey) As ScanCode
            Dim layout = GetKeyboardLayout(0)
            Return vk.ToScanCode(layout)
        End Function

        <Extension>
        Friend Function ToScanCode(vk As VirtualKey, layout As IntPtr) As ScanCode
            Dim scan = MapVirtualKeyEx(vk, MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC_EX, layout)
            Return CType(scan, ScanCode)
        End Function

        ''' <summary>
        ''' 根据当前的键盘布局转换虚拟键为字符。如果无法转换，返回 ChrW(0)。
        ''' </summary>
        ''' <param name="vk"></param>
        <Extension>
        Public Function ToChar(vk As VirtualKey) As Char
            Dim layout = GetKeyboardLayout(0)
            Dim scan = MapVirtualKeyEx(vk, MapVirtualKeyMapTypes.MAPVK_VK_TO_CHAR, layout)
            Return ChrW(scan)
        End Function
    End Module
End Namespace