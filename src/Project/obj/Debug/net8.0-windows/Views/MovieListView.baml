   M S B A M L   `   `   `  ����  Project!    Project.Views.MovieListView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20 10q�6;   .+�5      �� $	��300��5      $��5q�5         SearchTextBoxStyle#��[  5      
 � Tag$ Wyszukaj film...��5      ��5      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5      5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� $��20q�6:   ��6   �� *Movies+��5      �� 5      .R�5      �� ���#BDC3C7$��0 0 0 1q�67    �� Padding$
 0 10q�6Q   $��0 0 0 10q�6`   ._�5      �  � ColumnDefinitions 5   "   �� 5   &   $	��150 �67   �� 5   &   $��* �67   �� 5   &   $	��150 �67   .+�5"   "   �� -   5        $	��200��5#   (   $	��150��5$   (   $��UniformToFill=�5%   (    � Cursor$
 Hand��5&   (   ��5"   (   �� *	PosterUrl+5'   (   �� 5)   "   $��1��6-   $
��10 0q�6=   .+�5*   &   �� -   5        $��18(�5+   0   $
��Bold"�5,   0   $
 Hand��5-   0   ��5*   0   �� *Title+5.   0   �� 5/   &   $��14(�50   0   ���#7F8C8D��5/   0   �� *
Director+51   0   �� 52   &   $ 
Horizontal=�61   $��0 5 0 0q�6J   .+�53   *   �� $��14(�54   4   ���#7F8C8D��53   4   �� *Year+55   4   �� 56   *   $�� • ��64   $��14(�57   4   ���#7F8C8D58   4   �� 59   *   $��14(�5:   4   ���#7F8C8D��59   4   �� *Genre+5;   4   �� 5<   *   $�� • ��64   $��14(�5=   4   ���#7F8C8D5>   4   �� 5?   *   $��14(�5@   4   ���#7F8C8D��5?   4   �� *Rating+ �� StringFormat$ {0}/10��5A   4   5B   '   �� 5C   &   $��14(�5D   0   $
��Wrap=�5E   0   $��0 10 0 0q�5F   0   ��5C   0   �� *Description+5F   0   5G   #   �� 5I   "   $��2��6-   $��Center=�6=   .+�5J   &   �� $ ��❤️ Dodaj do ulubionych��6-     ActionButtonStyle#��[ 5M   -   $��0 0 0 10q�5N   -    � ToolTip$A ;Dodaje do ulubionych i automatycznie oznacza jako obejrzany��5O   -   ��5K   -   �� *#!DataContext.AddToFavoritesCommand+	 �� RelativeSource	 �� 
 �� AncestorType
 ItemsControl��5L   -   �� 5O   -   �� 5Q   &   $��✔️ Obejrzane��6-   #��[ 5T   -   $��0 0 0 10q�5U   -   ��5R   -   �� *!DataContext.AddToWatchedCommand+	 �� 
 ItemsControl��5S   -   �� 5U   -   �� 5W   &   $��➕ Do obejrzenia��6-   #��[ 5Z   -   ��5X   -   �� *#!DataContext.AddToWatchListCommand+	 �� 
 ItemsControl��5Y   -   �� 5Z   -   5[   #   5\      5]      5^      5`      5a      5b      5c      