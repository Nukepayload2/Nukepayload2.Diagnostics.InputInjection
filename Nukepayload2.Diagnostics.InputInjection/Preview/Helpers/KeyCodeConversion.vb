Option Strict On

Namespace Preview
    <System.Runtime.CompilerServices.Discardable>
    Module KeyCodeConversion
        Function AsciiLetterToScanCode(letter As Char) As ScanCode
            letter = Convert.ToChar(AscW(letter) Or &H20)
            Select Case letter
                Case "a"c : Return ScanCode.KEY_A
                Case "b"c : Return ScanCode.KEY_B
                Case "c"c : Return ScanCode.KEY_C
                Case "d"c : Return ScanCode.KEY_D
                Case "e"c : Return ScanCode.KEY_E
                Case "f"c : Return ScanCode.KEY_F
                Case "g"c : Return ScanCode.KEY_G
                Case "h"c : Return ScanCode.KEY_H
                Case "i"c : Return ScanCode.KEY_I
                Case "j"c : Return ScanCode.KEY_J
                Case "k"c : Return ScanCode.KEY_K
                Case "l"c : Return ScanCode.KEY_L
                Case "m"c : Return ScanCode.KEY_M
                Case "n"c : Return ScanCode.KEY_N
                Case "o"c : Return ScanCode.KEY_O
                Case "p"c : Return ScanCode.KEY_P
                Case "q"c : Return ScanCode.KEY_Q
                Case "r"c : Return ScanCode.KEY_R
                Case "s"c : Return ScanCode.KEY_S
                Case "t"c : Return ScanCode.KEY_T
                Case "u"c : Return ScanCode.KEY_U
                Case "v"c : Return ScanCode.KEY_V
                Case "w"c : Return ScanCode.KEY_W
                Case "x"c : Return ScanCode.KEY_X
                Case "y"c : Return ScanCode.KEY_Y
                Case "z"c : Return ScanCode.KEY_Z
                Case Else
                    Return Nothing
            End Select
        End Function

        Function AsciiNumberToScanCode(number As Char, useNumPad As Boolean) As ScanCode
            Select Case number
                Case "0"c : Return If(useNumPad, ScanCode.NUMPAD0, ScanCode.KEY_0)
                Case "1"c : Return If(useNumPad, ScanCode.NUMPAD1, ScanCode.KEY_1)
                Case "2"c : Return If(useNumPad, ScanCode.NUMPAD2, ScanCode.KEY_2)
                Case "3"c : Return If(useNumPad, ScanCode.NUMPAD3, ScanCode.KEY_3)
                Case "4"c : Return If(useNumPad, ScanCode.NUMPAD4, ScanCode.KEY_4)
                Case "5"c : Return If(useNumPad, ScanCode.NUMPAD5, ScanCode.KEY_5)
                Case "6"c : Return If(useNumPad, ScanCode.NUMPAD6, ScanCode.KEY_6)
                Case "7"c : Return If(useNumPad, ScanCode.NUMPAD7, ScanCode.KEY_7)
                Case "8"c : Return If(useNumPad, ScanCode.NUMPAD8, ScanCode.KEY_8)
                Case "9"c : Return If(useNumPad, ScanCode.NUMPAD9, ScanCode.KEY_9)
                Case Else
                    Return Nothing
            End Select
        End Function

        Function AsciiSymbolToScanCode(number As Char, useNumPad As Boolean) As ScanCode
            Select Case number 'WIP
                Case " "c : Return ScanCode.SPACE
                Case "\"c : Return ScanCode.SPACE
                Case "/"c : Return ScanCode.SPACE
                Case "["c : Return ScanCode.SPACE
                Case "]"c : Return ScanCode.SPACE
                Case ";"c : Return ScanCode.SPACE
                Case "'"c : Return ScanCode.SPACE
                Case ","c : Return ScanCode.SPACE
                Case "."c : Return ScanCode.SPACE
                Case "-"c : Return ScanCode.SPACE
                Case "/"c : Return ScanCode.SPACE
                Case Else
                    Return Nothing
            End Select
        End Function
    End Module
End Namespace