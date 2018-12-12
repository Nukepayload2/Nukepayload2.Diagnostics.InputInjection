Imports System.ComponentModel

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
    Public Structure InjectedInputKeyboardInfo
        ''' <summary>
        ''' A device-independent identifier mapped to a key on a physical or software keyboard.
        ''' </summary>
        Public VirtualKey As VirtualKey
        ''' <summary>
        ''' Gets or sets an OEM, device-dependent identifier for a key on a physical keyboard.
        ''' Note:
        ''' A keyboard generates two scan codes When the user types a key—one 
        ''' When the user presses the key And another When the user releases the key.
        ''' </summary>
        Public ScanCode As ScanCode
        ''' <summary>
        ''' The various options, or modifiers, used to simulate input from physical or virtual keyboards.
        ''' </summary>
        Public KeyOptions As InjectedInputKeyOptions
        ''' <summary>
        ''' Not used
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Time As Integer
        ''' <summary>
        ''' Not used
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ExtraInfo As IntPtr
    End Structure
End Namespace
