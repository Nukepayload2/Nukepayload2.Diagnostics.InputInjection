Namespace Preview

    ''' <summary>
    ''' Specifies the various options, or modifiers, used to simulate input from physical or virtual keyboards 
    ''' through <see cref="InjectedInputKeyboardInfo"/>.
    ''' </summary>
    <Flags>
    Public Enum InjectedInputKeyOptions
        ''' <summary>
        ''' No keystroke modifier. Default.
        ''' </summary>
        None
        ''' <summary>
        ''' The key Is an extended key, such As a Function key Or a key On the numeric keypad.
        ''' </summary>
        ExtendedKey = &B1
        ''' <summary>
        ''' The key Is released.
        ''' </summary>
        KeyUp = &B10
        ''' <summary>
        ''' The key is a Unicode value.
        ''' </summary>
        Unicode = &B100
        ''' <summary>
        ''' The OEM, device-dependent identifier for the key on the keyboard.
        ''' A keyboard generates two scan codes when the user types a key—one 
        ''' when the user presses the key and another when the user releases the key.
        ''' </summary>
        ScanCode = &B1000
    End Enum

End Namespace