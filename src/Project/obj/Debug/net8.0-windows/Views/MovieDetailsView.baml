   M S B A M L   `   `   `  ����  Project$    Project.Views.MovieDetailsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20 10q�6;   .+�5      �� $��
← Wróć��6      BackButtonStyle#��[  5      ��5      �� *NavigateBackCommand+5      �� 5      $��24(�5      $
��Bold"�5      $��20 0 0 0q�5      $��Center=�5      ��5      �� *Movie.Title+5      5      � 5   
   $��1��6   $��20q�6    � ColumnDefinitions 5      �� 5      $	��300 �6#   �� 5      $��* �6#   .+�5       �� $	��450��5!      $	��300��5"      $��UniformToFill=�5#      $��0��5$      ��5       �� *Movie.PosterUrl+5$      �� 5&      $��1��6   $��20 0 0 0q�6)   .+�5'      �� $��24(�5(      $
��Bold"�5)      ��5'      �� *Movie.Title+5)      �� 5+      $��18(�5,      $��0 10 0 0q�5-      ��5+      �� *Movie.Director+5-      �� 5/      $ 
Horizontal=�6   $��0 5 0 0q�66   .+�50      �� $��16(�51       ��50       �� *
Movie.Year+51       �� 52      $�� • ��6    $��16(�53       �� 54      $��16(�55       ��54       �� *Movie.Genre+55       �� 56      $�� • ��6    $��16(�57       �� 58      $��16(�59       ��58       �� *Movie.Rating+ �� StringFormat$ {0}/10��59       5:      �� 5<      $��Opis:��6   $��18(�5=      $
��Bold"�5>      $��0 20 0 0q�5?      �� 5A      $��16(�5B      $
��Wrap=�5C      $��0 10 0 0q�5D      ��5A      �� *Movie.Description+5D      5E      5F      5G      5H      