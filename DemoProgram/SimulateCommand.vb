Imports Nukepayload2.Diagnostics

Public Class SimulateCommand
    Inherits Singleton(Of SimulateCommand)
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Dim rnd As New Random
    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim vm = TouchInjectionViewModel.Instance
        Dim offset = vm.HumanInputSimulateParameters
        SendTouch(vm.PositionX - offset.InaccurateX / 2 + rnd.NextDouble * offset.InaccurateX,
                  vm.PositionY - offset.InaccurateY / 2 + rnd.NextDouble * offset.InaccurateY,
                  vm.HoldTimeMilliseconds + rnd.NextDouble * offset.HoldTimeMaxOffset,
                  vm.Orientation, pressure:=vm.Pressure)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
