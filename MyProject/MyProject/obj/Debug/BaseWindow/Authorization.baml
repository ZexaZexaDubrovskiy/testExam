   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyProject.BaseWindowMyProject.BaseWindow  5   	   (    "MyProject.BaseWindow.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MyProject.BaseWindow     5   	     � Title$  Авторизация��5   	   $	��400��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      � 
������� � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      -   5         ��Name$ 
captchaRow��5   '   $��0 �6   6'   �� 5      $	��100 �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��10q�6,   $��0��68   .+�5      �� $��
Логин��6   
���   �$��Comic Sans MS)�67   $��20(�6R   �� 5      -   5         ��Name$ login��5      ���#76e383
���   �$��Comic Sans MS)�6N   $��20(�6i   �� 5      $��0,0,20,0q�6   $��Пароль��6&   
���   �$��Comic Sans MS)�6J   $��20(�6e   G� 5      -   5         G�Name$ password��5      ���#76e383
���   �$��Comic Sans MS)�6U   $��20(�6p   5      �� 5   
   $ Vertical=�6   $��10q�6,   $��1��68   .+�5      �� -   5        $ capthcaForUser��5      ���#76e383
���   �$��0,0,0,20q�6V   $��Comic Sans MS)�6i   $��Italic$�6�   $��Heavy"�5       �� TextDecorations$ Strikethrough{�6%    �� TextAlignment$ Center=�6E   $��UltraCondensed&�5      $��20(�6/   	 �� 
IsReadOnly	 . 6=   �� 5      -   5        $ capthcaForProject��5      ���#76e383
���   �$ Center=�6Y   $��Comic Sans MS)�6p   $��20(�6�   5      �� 5   
   $ Vertical=�6   $��10q�6,   $��3��68   .+�5      �� -   5        
 ��Name$
 SignIn��5      ���#498c51$	��100��6P   $��30��6\   $��0,0,0,10q�6h   $��20(�6z   $��
Войти��6�   $��Comic Sans MS)�6�   �� 5       -   5        $
 SignInRoleGuest��5       ���#498c51$	��200��6a   $��30��6m   $��20(�6y   $"��Войти как гость��6�   $��Comic Sans MS)�6�   5!      5"      5#      