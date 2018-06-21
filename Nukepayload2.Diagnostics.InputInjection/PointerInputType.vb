'enum tagPOINTER_INPUT_TYPE {
'    PT_POINTER = 1,   // Generic pointer
'    PT_TOUCH = 2,   // Touch
'    PT_PEN = 3,   // Pen
'    PT_MOUSE = 4,   // Mouse
'#if(WINVER >= 0x0603)
'    PT_TOUCHPAD = 5,   // Touchpad
'#endif /* WINVER >= 0x0603 */
'};
Public Enum PointerInputType
    ''' <summary>
    ''' Generic pointer
    ''' </summary>
    Pointer = 1
    ''' <summary>
    ''' Touch
    ''' </summary>
    Touch
    ''' <summary>
    ''' Pen
    ''' </summary>
    Pen
    ''' <summary>
    ''' Touchpad (Windows 8.1 或更高)
    ''' </summary>
    Touchpad
End Enum
