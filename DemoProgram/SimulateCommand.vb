Imports Nukepayload2.Diagnosis.InputInjection

Public Class SimulateCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Private Shared s_injection As InputInjection
    Private Shared ReadOnly Property Injection As InputInjection
        Get
            If s_injection Is Nothing Then
                s_injection = InputInjection.TryCreate
            End If
            s_injection?.InitializeTouchInjection(InjectedInputVisualizationMode.Default)
            Return s_injection
        End Get
    End Property

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim vm = TouchInjectionViewModel.Instance

        With Injection
            Dim touch As New InjectedInputTouchInfo With {
                .PointerInfo = New InjectedInputPointerInfo With {
                    .PointerId = 0,
                    .PixelLocation = New InjectedInputPoint With {
                        .PositionX = vm.PositionX, ' Y co-ordinate of touch on screen
                        .PositionY = vm.PositionY ' X co-ordinate of touch on screen
                    },
                    .PointerType = PointerInputType.Touch ' Must be set to PointerInputType.Touch. It's different from UWP.
                },
                .TouchParameters =
                    InjectedInputTouchParameters.Contact Or
                    InjectedInputTouchParameters.Orientation Or
                    InjectedInputTouchParameters.Pressure, ' TouchMask
                .Orientation = vm.Orientation,
                .Pressure = vm.Pressure
            }
            ' defining contact area (I have taken area of 4 x 4 pixel)
            Dim pxLoc As InjectedInputPoint = touch.PointerInfo.PixelLocation
            touch.Contact = New InjectedInputRectangle With {
                .Top = pxLoc.PositionY - 2,
                .Bottom = pxLoc.PositionY + 2,
                .Left = pxLoc.PositionX - 2,
                .Right = pxLoc.PositionX + 2
            }

            ' TouchDown
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.PointerDown Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            .InjectTouchInput(touch) ' Injecting the touch Down from screen

            ' Hold
            touch.PointerInfo.PointerOptions =
                InjectedInputPointerOptions.Update Or
                InjectedInputPointerOptions.InRange Or
                InjectedInputPointerOptions.InContact

            Dim timer As New Stopwatch
            timer.Start()
            Dim timeMillsec = vm.HoldTimeMilliseconds
            Do While timer.ElapsedMilliseconds < timeMillsec
                .InjectTouchInput(touch)
            Loop
            timer.Stop()
            ' TouchUp
            touch.PointerInfo.PointerOptions = InjectedInputPointerOptions.PointerUp
            .InjectTouchInput(touch) ' Injecting the touch Up from screen
        End With
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
