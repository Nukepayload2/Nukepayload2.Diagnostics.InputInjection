Imports System.ComponentModel

Namespace Preview

    'typedef struct tagMOUSEINPUT {
    '    Long    dx;
    '    Long    dy;
    '    DWORD   mouseData;
    '    DWORD   dwFlags;
    '    DWORD   time;
    '    ULONG_PTR dwExtraInfo;
    '} MOUSEINPUT, *PMOUSEINPUT, FAR* LPMOUSEINPUT;

    ''' <summary>
    ''' Represents programmatically generated mouse input.
    ''' </summary>
    Public Structure InjectedInputMouseInfo
        ''' <summary>
        ''' The change in value of an x-coordinate since the last mouse wheel event.
        ''' </summary>
        Public DeltaX As Integer
        ''' <summary>
        ''' The change in value of an y-coordinate since the last mouse wheel event.
        ''' </summary>
        Public DeltaY As Integer
        ''' <summary>
        ''' Gets or sets a value used by other properties.
        ''' The value is based on the <see cref="MouseOptions"/> flags set.
        ''' </summary>
        Public MouseData As Integer
        ''' <summary>
        ''' Gets or sets the various options, or modifiers, used to simulate mouse input.
        ''' </summary>
        Public MouseOptions As InjectedInputMouseOptions
        ''' <summary>
        ''' Gets or sets the baseline, or reference value, for timed input events such as a double click/tap.
        ''' </summary>
        Public TimeOffsetInMilliseconds As Integer
        ''' <summary>
        ''' Not used
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ExtraInfo As IntPtr
    End Structure

End Namespace
