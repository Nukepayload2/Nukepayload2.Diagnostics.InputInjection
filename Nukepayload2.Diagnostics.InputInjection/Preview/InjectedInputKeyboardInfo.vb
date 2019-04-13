Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace Preview

    'typedef struct tagKEYBDINPUT {
    '    WORD    wVk;
    '    WORD    wScan;
    '    DWORD   dwFlags;
    '    DWORD   time;
    '    ULONG_PTR dwExtraInfo;
    '} KEYBDINPUT, *PKEYBDINPUT, FAR* LPKEYBDINPUT;

    ''' <summary>
    ''' Represents programmatically generated keyboard input.
    ''' </summary>
    <StructLayout(LayoutKind.Explicit, CharSet:=CharSet.Unicode)>
    Public Structure InjectedInputKeyboardInfo
        ''' <summary>
        ''' A device-independent identifier mapped to a key on a physical or software keyboard.
        ''' </summary>
        <FieldOffset(0)>
        Public VirtualKey As VirtualKey '2 字节
        ''' <summary>
        ''' Gets or sets an OEM, device-dependent identifier for a key on a physical keyboard.
        ''' Note:
        ''' A keyboard generates two scan codes When the user types a key—one 
        ''' When the user presses the key And another When the user releases the key.
        ''' </summary>
        <FieldOffset(2)>
        Public ScanCode As ScanCode '2 字节
        ''' <summary>
        ''' Get or sets the unicode key code when <see cref="KeyOptions"/> is <see cref="InjectedInputKeyOptions.Unicode"/>
        ''' </summary>
        <FieldOffset(2)>
        Public Unicode As Char '2 字节
        ''' <summary>
        ''' The various options, or modifiers, used to simulate input from physical or virtual keyboards.
        ''' </summary>
        <FieldOffset(4)>
        Public KeyOptions As InjectedInputKeyOptions '4 字节
        ''' <summary>
        ''' The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.
        ''' </summary>
        <FieldOffset(8)>
        Public Time As Integer '4 字节
        ''' <summary>
        ''' An additional value associated with the keystroke. 
        ''' Use the Win32 GetMessageExtraInfo function to obtain this information. 
        ''' To set a thread's extra message information, use the Win32 SetMessageExtraInfo function.
        ''' </summary>
        <FieldOffset(12)>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ExtraInfo As IntPtr '4 或 8 字节
    End Structure
End Namespace
