﻿' 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
'
' 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
' 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
' 元素中:
'
'     xmlns:MyNamespace="clr-namespace:DemoProgram"
'
'
' 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
' 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
' 元素中:
'
'     xmlns:MyNamespace="clr-namespace:DemoProgram;assembly=DemoProgram"
'
' 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
' 并重新生成以避免编译错误:
'
'     在解决方案资源管理器中右击目标项目，然后依次单击
'     “添加引用”->“项目”->[浏览查找并选择此项目]
'
'
' 步骤 2)
' 继续操作并在 XAML 文件中使用控件。请注意，XML 编辑器中的 Intellisense
' 目前对自定义控件及其子元素不起作用。
'
'     <MyNamespace:ToggleSwitch/>
'

Imports System.Windows.Controls.Primitives


Public Class ToggleSwitch
    Inherits ToggleButton

    Shared Sub New()
        '此 OverrideMetadata 调用通知系统该元素希望提供不同于其基类的样式。
        '此样式定义在 themes\generic.xaml 中
        DefaultStyleKeyProperty.OverrideMetadata(GetType(ToggleSwitch), new FrameworkPropertyMetadata(GetType(ToggleSwitch)))
    End Sub

End Class
