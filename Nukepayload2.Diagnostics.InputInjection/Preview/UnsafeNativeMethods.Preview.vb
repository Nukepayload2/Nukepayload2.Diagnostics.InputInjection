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
        Declare Function InjectKeyboardInput Lib "user32.dll" (
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)>
            mouseInput As InjectedInputKeyboardInfo(),
            count As Integer
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Module
End Namespace
