Imports System.ComponentModel

Public Class TouchInjectionViewModel
    Inherits Singleton(Of TouchInjectionViewModel)
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Dim _PositionX As Integer = 200
    Public Property PositionX As Integer
        Get
            Return _PositionX
        End Get
        Set(value As Integer)
            _PositionX = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(PositionX)))
        End Set
    End Property

    Dim _PositionY As Integer = 300
    Public Property PositionY As Integer
        Get
            Return _PositionY
        End Get
        Set(value As Integer)
            _PositionY = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(PositionY)))
        End Set
    End Property

    Dim _HoldTimeMilliseconds As Integer = 300

    Public Property HoldTimeMilliseconds As Integer
        Get
            Return _HoldTimeMilliseconds
        End Get
        Set(value As Integer)
            _HoldTimeMilliseconds = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(HoldTimeMilliseconds)))
        End Set
    End Property

    Dim _Orientation As Integer = 90
    Public Property Orientation As Integer
        Get
            Return _Orientation
        End Get
        Set(value As Integer)
            _Orientation = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Orientation)))
        End Set
    End Property

    Dim _Pressure As Integer = 1024
    Public Property Pressure As Integer
        Get
            Return _Pressure
        End Get
        Set(value As Integer)
            _Pressure = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Pressure)))
        End Set
    End Property

    Public Property HumanInputSimulateParameters As InaccurateTouchPoint = InaccurateTouchPoint.Button

    Public ReadOnly Property SimulateCommand As New SimulateCommand
End Class
