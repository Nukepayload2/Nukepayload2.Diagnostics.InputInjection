Imports System.ComponentModel
Imports Nukepayload2.Diagnostics.Preview

''' <summary>
''' For binary compatibility.
''' </summary>
<Obsolete("Use InputInjector instead")>
<EditorBrowsable(EditorBrowsableState.Never)>
Public Class InputInjection
    Private ReadOnly _injector As InputInjector

    Private Sub New(injector As InputInjector)
        _injector = injector
    End Sub

    <Obsolete("Use InputInjector.InjectMouseInput instead")>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub InjectMouseInput(ParamArray input As InjectedInputMouseInfo())
        _injector.InjectMouseInput(input)
    End Sub
    <Obsolete("Use InputInjector.InjectKeyboardInput instead")>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub InjectKeyboardInput(ParamArray input As InjectedInputKeyboardInfo())
        _injector.InjectKeyboardInput(input)
    End Sub
    <Obsolete("Use InputInjector.InjectTouchInput instead")>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function InjectTouchInput(ParamArray input As InjectedInputTouchInfo()) As Boolean
        Return _injector.InjectTouchInput(input)
    End Function
    <Obsolete("Use InputInjector.InitializeTouchInjection instead")>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub InitializeTouchInjection(visualMode As InjectedInputVisualizationMode,
                                        Optional maxCount As Integer = 10)
        _injector.InitializeTouchInjection(visualMode, maxCount)
    End Sub
    <Obsolete("Use InputInjector.TryCreate instead")>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shared Function TryCreate() As InputInjection
        Dim injector = InputInjector.TryCreate
        Return New InputInjection(injector)
    End Function
End Class