Imports System.Runtime.InteropServices

Namespace Preview

    Friend Module UnsafeNativeMethods

        'WINUSERAPI
        'BOOL
        'WINAPI
        'InjectMouseInput(
        '    _In_reads_(count) CONST PMOUSEINPUT pMouseInput,
        '    _In_ UINT32 count
        '    );
        Declare Function InjectMouseInput Lib "user32.dll" (
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)>
            mouseInput As InjectedInputMouseInfo(),
            count As Integer
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean

        'WINUSERAPI
        'BOOL
        'WINAPI
        'InjectKeyboardInput(
        '    _In_reads_(count) CONST PKEYBDINPUT pKeyboardInput,
        '    _In_ UINT32 count
        '    );
        Declare Unicode Function InjectKeyboardInput Lib "user32.dll" (
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)>
            keyboardInput As InjectedInputKeyboardInfo(),
            count As Integer
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean

        ''' <summary>
        ''' The set of valid MapTypes used in MapVirtualKey
        ''' </summary>
        Enum MapVirtualKeyMapTypes
            ''' <summary>
            ''' uCode is a virtual-key code and is translated into a scan code.
            ''' If it is a virtual-key code that does not distinguish between left- and
            ''' right-hand keys, the left-hand scan code is returned.
            ''' If there is no translation, the function returns 0.
            ''' </summary>
            MAPVK_VK_TO_VSC = &H0

            ''' <summary>
            ''' uCode is a scan code and is translated into a virtual-key code that
            ''' does not distinguish between left- and right-hand keys. If there is no
            ''' translation, the function returns 0.
            ''' </summary>
            MAPVK_VSC_TO_VK = &H1

            ''' <summary>
            ''' uCode is a virtual-key code and is translated into an unshifted
            ''' character value in the low-order word of the return value. Dead keys (diacritics)
            ''' are indicated by setting the top bit of the return value. If there is no
            ''' translation, the function returns 0.
            ''' </summary>
            MAPVK_VK_TO_CHAR = &H2

            ''' <summary>
            ''' The uCode parameter is a scan code and is translated into a virtual-key code 
            ''' that distinguishes between left- and right-hand keys. If there is no translation, 
            ''' the function returns 0. 
            ''' </summary>
            MAPVK_VSC_TO_VK_EX = &H3

            ''' <summary>
            ''' The uCode parameter is a virtual-key code and is translated into a scan code. 
            ''' If it is a virtual-key code that does not distinguish between left- and right-hand keys,
            ''' the left-hand scan code is returned. If the scan code is an extended scan code,
            ''' the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code.
            ''' If there is no translation, the function returns 0.
            ''' </summary>
            MAPVK_VK_TO_VSC_EX = &H4
        End Enum

        Declare Function GetKeyboardLayout Lib "user32" (idThread As UInteger) As IntPtr

        Declare Unicode Function MapVirtualKeyEx Lib "user32.dll" Alias "MapVirtualKeyExW" (
            uCode As Integer, uMapType As MapVirtualKeyMapTypes, dwhkl As IntPtr) As Integer
    End Module
End Namespace
