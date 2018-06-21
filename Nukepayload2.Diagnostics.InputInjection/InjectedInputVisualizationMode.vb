''' <summary>
''' 指定输入式注入的可视反馈模式。
''' </summary>
Public Enum InjectedInputVisualizationMode
    ''' <summary>
    ''' 表示没有输入的可视反馈。默认值。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 表示输入的默认系统可视反馈。
    ''' </summary>
    [Default] = 1
    ''' <summary>
    ''' 表示输入的间接可视反馈。
    ''' </summary>
    Indirect = 2
End Enum
