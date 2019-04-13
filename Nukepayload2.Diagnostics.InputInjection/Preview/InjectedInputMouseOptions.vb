Namespace Preview
    ''' <summary>
    ''' Specifies the various options, or modifiers, used to simulate mouse input through <see cref="InjectedInputMouseInfo"/>.
    ''' </summary>
    <Flags>
    Public Enum InjectedInputMouseOptions
        ''' <summary>
        ''' Normalized absolute coordinates between 0 And 65,535. 
        ''' If the flag Is Not Set, relative data (the change In position since the last reported position) Is used.
        ''' Coordinate (0,0) maps onto the upper-left corner Of the display surface;
        ''' coordinate (65535,65535) maps onto the lower-right corner. 
        ''' In a multi-monitor system, the coordinates map To the primary monitor.
        ''' </summary>
        Absolute = 32768
        ''' <summary>
        ''' Mouse tilt wheel.
        ''' </summary>
        HWheel = 4096
        ''' <summary>
        ''' Left mouse button pressed.
        ''' </summary>
        LeftDown = 2
        ''' <summary>
        ''' Left mouse button released.
        ''' </summary>
        LeftUp = 4
        ''' <summary>
        ''' Middle mouse button pressed.
        ''' </summary>
        MiddleDown = 32
        ''' <summary>
        ''' Middle mouse button released.
        ''' </summary>
        MiddleUp = 64
        ''' <summary>
        ''' Move (coalesce move messages). If a mouse event occurs and the application has not yet processed 
        ''' the previous mouse event, the previous one is thrown away. See MoveNoCoalesce.
        ''' </summary>
        Move = 1
        ''' <summary>
        ''' Move (do not coalesce move messages). 
        ''' The application processes all mouse events since the previously processed mouse event. See Move.
        ''' </summary>
        MoveNoCoalesce = 8192
        ''' <summary>
        ''' No mouse modifier. Default.
        ''' </summary>
        None = 0
        ''' <summary>
        ''' Right mouse button pressed.
        ''' </summary>
        RightDown = 8
        ''' <summary>
        ''' Right mouse button released.
        ''' </summary>
        RightUp = 16
        ''' <summary>
        ''' Map coordinates to the entire virtual desktop.
        ''' </summary>
        VirtualDesk = 16384
        ''' <summary>
        ''' Mouse wheel.
        ''' </summary>
        Wheel = 2048
        ''' <summary>
        ''' XBUTTON pressed.
        ''' </summary>
        XDown = 128 '	XBUTTON pressed.
        ''' <summary>
        ''' XBUTTON released.
        ''' </summary>
        XUp = 256
    End Enum
End Namespace
