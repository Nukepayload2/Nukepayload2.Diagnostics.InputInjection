# Nukepayload2.Diagnosis.InputInjection
A .NET Framework Port of Windows.UI.Input.Preview.Injection

You can use it for software testing ~~or writing tools for cheating in games~~.

We will not wrap undocumented APIs since they have potential compatibility issues.

## Progress
- [x] Touch Injection (Wrap [user32] InjectTouchInput and InitializeTouchInjection)
- [x] Convenient Touch Injection for RAD scenario
- [ ] ~~Uninitialize Touch Injection~~ (UninitializeTouchInjection does not exist in user32)
- [ ] ~~Gamepad Injection~~ ([user32] InjectDeviceInput and InitializeInputDeviceInjection are undocumented)
- [ ] ~~Convenient Gamepad Injection for RAD scenario~~
- [ ] ~~Uninitialize Gamepad Injection~~
- [ ] ~~Pen Injection~~ ([user32] InjectPointerInput and InitializePointerDeviceInjection are undocumented)
- [ ] ~~Convenient Pen Injection for RAD scenario~~
- [ ] ~~Uninitialize Pen Injection~~
- [ ] ~~Mouse Injection~~ ([user32] InjectMouseInput is undocumented)
- [ ] ~~Convenient Mouse Injection for RAD scenario~~
- [ ] ~~Keyboard Injection~~ ([user32] InjectKeyboardInput is undocumented)
- [ ] ~~Convenient Keyboard Injection for RAD scenario~~
- [ ] ~~Shortcut Injection~~ ([user32] InjectKeyboardInput is undocumented)
- [ ] ~~Convenient Shortcut Injection for RAD scenario~~
- [x] Xml Document for zh-CN locale
- [ ] Xml Document for en-US locale
