# WPFSharedTest

Test for x:Shared="False"

![2016-03-19_14h48_14](https://cloud.githubusercontent.com/assets/658431/13898973/0520b45e-ede3-11e5-8fa9-eff10c5c02b2.png)

This brush

```xmal
<SolidColorBrush x:Key="TakeThatBrush" Color="YellowGreen" />
```

is used via `DynamicResource` at this icon

```xaml
<Canvas x:Key="appbar_os_windows"
        x:Shared="False"
        Width="76"
        Height="76"
        Clip="F1 M 0,0L 76,0L 76,76L 0,76L 0,0">
    <Path Canvas.Left="15.8333"
          Canvas.Top="16.625"
          Width="45.9167"
          Height="42.75"
          Fill="{DynamicResource TakeThatBrush}"
          Data="F1 M 23.75,19.7917C 23.75,19.7917 25.3333,16.625 33.25,16.625C 37.1223,16.625 39.4162,17.9403 41.4185,19.4987L 36.8968,35.0898C 34.7402,33.6397 32.5299,32.4583 30.0833,32.4583C 23.75,32.4583 20.5833,34.0417 20.5833,34.0417L 23.75,19.7917 Z M 52.25,24.5417C 60.1667,24.5417 61.75,21.375 61.75,21.375L 57,37.2083C 57,37.2083 53.8333,40.375 47.5,40.375C 44.6133,40.375 42.0555,38.7303 39.5268,36.9402L 43.9792,21.588C 46.0059,23.181 48.3116,24.5417 52.25,24.5417 Z M 19,38.7917C 19,38.7917 20.5833,35.625 28.5,35.625C 31.9766,35.625 34.181,36.6853 36.0442,38.0298L 31.5082,53.6702C 29.5528,52.4186 27.5391,51.4583 25.3333,51.4583C 19,51.4583 15.8333,53.0417 15.8333,53.0417L 19,38.7917 Z M 47.5,43.5417C 55.4167,43.5417 57,40.375 57,40.375L 52.25,56.2083C 52.25,56.2083 49.0833,59.375 42.75,59.375C 39.6233,59.375 36.8825,57.4455 34.1466,55.4916L 38.6129,40.0916C 40.8001,41.8876 43.1576,43.5417 47.5,43.5417 Z "
          Stretch="Fill" />
</Canvas>
```

and this icon is used here

```xaml
<Grid Width="60"
      Height="60"
      Margin="10"
      HorizontalAlignment="Center"
      VerticalAlignment="Center"
      Background="{DynamicResource LogoBrush}">
    <Grid.OpacityMask>
        <VisualBrush Stretch="Uniform" Visual="{DynamicResource appbar_os_windows}" />
    </Grid.OpacityMask>
</Grid>
```

I get a `System.NullReferenceException`, if I change the brush via replacing the resource dictionary with a different brush.

```csharp
Application.Current.Resources.MergedDictionaries.Remove(res2);
Application.Current.Resources.MergedDictionaries.Add(res1);
```

A complete Stacktrace from debugging session (with .Net source)  can be found [here](./CallStack.txt)

![2016-03-24_10h37_14](https://cloud.githubusercontent.com/assets/658431/14013832/0a59959c-f1af-11e5-94ff-da7fc742e1c0.png)

Here is the exception

```
System.Windows.Media.Visual.ReleaseOnChannelForCyclicBrush(ICyclicBrush cyclicBrush, Channel channel)
System.Windows.Media.VisualBrush.VisualPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
System.Windows.DependencyObject.OnPropertyChanged(DependencyPropertyChangedEventArgs e)
System.Windows.Media.VisualBrush.OnPropertyChanged(DependencyPropertyChangedEventArgs e)
System.Windows.DependencyObject.NotifyPropertyChange(DependencyPropertyChangedEventArgs args)
System.Windows.DependencyObject.UpdateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry& newEntry, Boolean coerceWithDeferredReference, Boolean coerceWithCurrentValue, OperationType operationType)
System.Windows.DependencyObject.InvalidateProperty(DependencyProperty dp, Boolean preserveCurrentValue)
System.Windows.ResourceReferenceExpression.InvalidateExpressionValue(Object sender, EventArgs e)
System.Windows.FrameworkElement.RaiseClrEvent(EventPrivateKey key, EventArgs args)
System.Windows.TreeWalkHelper.OnResourcesChanged(DependencyObject d, ResourcesChangeInfo info, Boolean raiseResourceChangedEvent)
System.Windows.TreeWalkHelper.OnResourcesChangedCallback(DependencyObject d, ResourcesChangeInfo info, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(FrameworkElement fe, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(FrameworkElement fe, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(FrameworkElement fe, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(FrameworkElement fe, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
System.Windows.DescendentsWalker`1.StartWalk(DependencyObject startNode, Boolean skipStartNode)
System.Windows.TreeWalkHelper.InvalidateOnResourcesChange(FrameworkElement fe, FrameworkContentElement fce, ResourcesChangeInfo info)
System.Windows.ResourceDictionary.NotifyOwners(ResourcesChangeInfo info)
System.Windows.ResourceDictionary.OnMergedDictionariesChanged(Object sender, NotifyCollectionChangedEventArgs e)
System.Collections.ObjectModel.ObservableCollection`1.OnCollectionChanged(NotifyCollectionChangedEventArgs e)
System.Collections.ObjectModel.ObservableCollection`1.InsertItem(Int32 index, T item)
System.Windows.ResourceDictionaryCollection.InsertItem(Int32 index, ResourceDictionary item)
System.Collections.ObjectModel.Collection`1.Add(T item)
WPFSharedTest.MainWindow.SetResDict2OnClick(Object sender, RoutedEventArgs e) MainWindow.xaml.cs: line: 34
System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
System.Windows.UIElement.RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
System.Windows.UIElement.RaiseEvent(RoutedEventArgs e)
System.Windows.Controls.Primitives.ButtonBase.OnClick()
System.Windows.Controls.Button.OnClick()
System.Windows.Controls.Primitives.ButtonBase.OnMouseLeftButtonUp(MouseButtonEventArgs e)
System.Windows.UIElement.OnMouseLeftButtonUpThunk(Object sender, MouseButtonEventArgs e)
System.Windows.Input.MouseButtonEventArgs.InvokeEventHandler(Delegate genericHandler, Object genericTarget)
System.Windows.RoutedEventArgs.InvokeHandler(Delegate handler, Object target)
System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
System.Windows.UIElement.ReRaiseEventAs(DependencyObject sender, RoutedEventArgs args, RoutedEvent newEvent)
System.Windows.UIElement.OnMouseUpThunk(Object sender, MouseButtonEventArgs e)
System.Windows.Input.MouseButtonEventArgs.InvokeEventHandler(Delegate genericHandler, Object genericTarget)
System.Windows.RoutedEventArgs.InvokeHandler(Delegate handler, Object target)
System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
System.Windows.UIElement.RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
System.Windows.UIElement.RaiseTrustedEvent(RoutedEventArgs args)
System.Windows.Input.InputManager.ProcessStagingArea()
System.Windows.Input.InputManager.ProcessInput(InputEventArgs input)
System.Windows.Input.InputProviderSite.ReportInput(InputReport inputReport)
System.Windows.Interop.HwndMouseInputProvider.ReportInput(IntPtr hwnd, InputMode mode, Int32 timestamp, RawMouseActions actions, Int32 x, Int32 y, Int32 wheel)
System.Windows.Interop.HwndMouseInputProvider.FilterMessage(IntPtr hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
System.Windows.Interop.HwndSource.InputFilterMessage(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
MS.Win32.HwndWrapper.WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
MS.Win32.HwndSubclass.DispatcherCallbackOperation(Object o)
System.Windows.Threading.ExceptionWrapper.InternalRealCall(Delegate callback, Object args, Int32 numArgs)
System.Windows.Threading.ExceptionWrapper.TryCatchWhen(Object source, Delegate callback, Object args, Int32 numArgs, Delegate catchHandler)
System.Windows.Threading.Dispatcher.LegacyInvokeImpl(DispatcherPriority priority, TimeSpan timeout, Delegate method, Object args, Int32 numArgs)
MS.Win32.HwndSubclass.SubclassWndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam)
MS.Win32.UnsafeNativeMethods.DispatchMessage(MSG& msg)
System.Windows.Threading.Dispatcher.PushFrameImpl(DispatcherFrame frame)
System.Windows.Threading.Dispatcher.PushFrame(DispatcherFrame frame)
System.Windows.Application.RunDispatcher(Object ignore)
System.Windows.Application.RunInternal(Window window)
System.Windows.Application.Run(Window window)
System.Windows.Application.Run()
WPFSharedTest.App.Main() App.g.cs: line: 0
System.AppDomain._nExecuteAssembly(RuntimeAssembly assembly, String[] args)
System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySecurity, String[] args)
Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
System.Threading.ThreadHelper.ThreadStart_Context(Object state)
System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
System.Threading.ThreadHelper.ThreadStart()
```
