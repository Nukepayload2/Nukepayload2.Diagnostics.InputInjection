Imports Nukepayload2.Diagnostics

Public Class SimulateCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim vm = TouchInjectionViewModel.Instance
        SendTouch(vm.PositionX, vm.PositionY, vm.HoldTimeMilliseconds, vm.Orientation, pressure:=vm.Pressure)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
