Imports System.Runtime.InteropServices

Friend Module UnsafeNativeMethods
    'WINUSERAPI
    'BOOL
    'WINAPI
    'InitializeTouchInjection(
    '    _In_ UINT32 maxCount,
    '    _In_ DWORD dwMode);
    Declare Function InitializeTouchInjection Lib "user32.dll" (
        maxCount As UInteger,
        mode As InjectedInputVisualizationMode
    ) As <MarshalAs(UnmanagedType.Bool)> Boolean

    'WINUSERAPI
    'BOOL
    'WINAPI
    'InjectTouchInput(
    '    _In_ UINT32 count,
    '    _In_reads_(count) CONST POINTER_TOUCH_INFO *contacts);
    Declare Function InjectTouchInput Lib "user32.dll" (
        count As Integer,
        <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)>
        contacts As InjectedInputTouchInfo()
    ) As <MarshalAs(UnmanagedType.Bool)> Boolean

    Public Const User32DllName = "user32.dll"

    'HMODULE LoadLibraryW(
    '    LPCWSTR lpLibFileName
    ');
    Declare Unicode Function LoadLibrary Lib "kernel32.dll" Alias "LoadLibraryW" (fileName As String) As IntPtr

    'FARPROC GetProcAddress(
    '  HMODULE hModule,
    '  LPCSTR  lpProcName
    ');
    Declare Function GetProcAddress Lib "kernel32.dll" (hModule As IntPtr, procName As String) As IntPtr
End Module
