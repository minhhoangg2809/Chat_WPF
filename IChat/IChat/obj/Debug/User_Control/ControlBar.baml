   M S B A M L   `   `   `  ����	  IChat#    IChat.User_Control.ControlBar   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5          >�Name$  ucControlbar��5
      $��Center=�5      .��5      � .+�5   
   �� $	��Top=�6   $��Center=�5      $��50��5      $��8��6   
���   � � Cursor$ Cross��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseLeftButtonDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *Drag_Command+   CommandParameter 5   $   ��  �� ElementName$ ucControlbar��5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� 
���   �$
��auto��5      $
��auto��6"   ��5      Z� ��5      Z� ��5      �� *Minimize_Command+��5      �� $ ucControlbar��.��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]	   Kind$	 WindowMinimize=�6*   $��15��6@   $��15��6K   5       �� 5!      
���   �$
��auto��5$      $
��auto��6"   ��5!      Z� ��5"      Z� ��5%      �� *Maximize_Command+��5&      �� $ ucControlbar��.��5'        $	 WindowMaximize=�6*   $��15��6@   $��15��6K   5(      �� 5)      -   5        
 ��Name$
 	btn_close��5)      
���   �$
��auto��5-      $
��auto��6"    � ToolTip$ Đóng��5.      ��5*      Z� ��5+      Z� ��5/      �� *Close_Command+��50      �� $ ucControlbar��.��51        $	 WindowClose=�6g   $��15��6z   $��15��6�   ��6*   ��  �� Path$ 
Background�$ 	btn_close��6�   52      53      55      56      