   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Project.ConvertersProject.Converters  5      '    !Project.Views.MovieCollectionView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7
converters clr-namespace:Project.Converters     5        � 	Resources  5
      5   /Project.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverter<   6Project.Converters.CollectionTypeToVisibilityConverter ' #CollectionTypeToVisibilityConverter��%:   &	        &	        5   
   62     5   
   69   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20 10q�6;   .+�5      �� $��
← Wróć��6     BackButtonStyle#��[ 5      ��5      �� *NavigateBackCommand+5      �� 5      $��24(�5      $
��Bold"�5      $��20 0 0 0q�5      $��Center=�5      ��5      �� *Title+5      5       �� 5"   
   $��1��6   $ 
Horizontal=�6"   $��20 10q�6;   .+�5#      �� $	��300��5$      $��5q�5%        SearchTextBoxStyle#��[ 5&      
 � Tag$ Wyszukaj w kolekcji...��5'      ��5#      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5'      5(      �� 5*   
   $��2��6   $
��Auto=�6$   .��5+      �� $��
20 0 20 20q�6:   ��6   �� *Movies+��5,      �� 5-      .R�5.      �� ���#BDC3C7$��0 0 0 1q�67    �� Padding$
 0 10q�6Q   $��0 0 0 10q�6`   ._�5/      �  � ColumnDefinitions 50   "   �� 51   &   $	��150 �67   �� 52   &   $��* �67   �� 53   &   $	��150 �67   .+�56   "   �� -   5        $	��200��57   (   $	��150��58   (   $��UniformToFill=�59   (    � Cursor$
 Hand��5:   (   ��56   (   �� *	PosterUrl+5;   (   �� 5=   "   $��1��6-   $
��10 0q�6=   .+�5>   &   �� -   5        $��18(�5?   0   $
��Bold"�5@   0   $
 Hand��5A   0   ��5>   0   �� *Title+5B   0   �� 5C   &   $��14(�5D   0   ���#7F8C8D��5C   0   �� *
Director+5E   0   �� 5F   &   $ 
Horizontal=�61   $��0 5 0 0q�6J   .+�5G   *   �� $��14(�5H   4   ���#7F8C8D��5G   4   �� *Year+5I   4   �� 5J   *   $�� • ��64   $��14(�5K   4   ���#7F8C8D5L   4   �� 5M   *   $��14(�5N   4   ���#7F8C8D��5M   4   �� *Genre+5O   4   �� 5P   *   $�� • ��64   $��14(�5Q   4   ���#7F8C8D5R   4   �� 5S   *   $��14(�5T   4   ���#7F8C8D��5S   4   �� *Rating+ �� StringFormat$ {0}/10��5U   4   5V   '   �� 5W   &   $��14(�5X   0   $
��Wrap=�5Y   0   $��0 10 0 0q�5Z   0   ��5W   0   �� *Description+5Z   0   5[   #   �� 5]   "   $��2��6-   $��Center=�6=   .+�5_   &   �� $��Dodaj do obejrzanych��6-     ActionButtonStyle#��[ 5b   -   $��0 0 0 10q�5c   -   ��5`   -   �� *" DataContext.MoveToWatchedCommand+	 �� RelativeSource	 �� 
 �� AncestorType
 ItemsControl��5a   -   �� y�5d   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl �� 	Converter# [  �� ConverterParameter$ ToWatch���� 5f   &   $��Dodaj do ulubionych��6-   #��[ 5i   -   $��0 0 0 10q�5j   -   ��5g   -   �� *#!DataContext.AddToFavoritesCommand+	 �� 
 ItemsControl��5h   -   �� y�5k   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl# [ $ ToWatch���� 5m   &   $��Usuń z listy��6-   #��[ 5p   -   $��0 0 0 10q�5q   -   ��5n   -   �� *(&DataContext.RemoveFromWatchListCommand+	 �� 
 ItemsControl��5o   -   �� y�5r   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl# [ $ ToWatch���� 5u   &   $��Usuń z obejrzanych��6-   #��[ 5x   -   $��0 0 0 10q�5y   -   ��5v   -   �� *&$DataContext.RemoveFromWatchedCommand+	 �� 
 ItemsControl��5w   -   �� y�5z   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl# [ $ Watched���� 5|   &   $��Dodaj do ulubionych��6-   #��[ 5   -   $��0 0 0 10q�5�   -   ��5}   -   �� *#!DataContext.AddToFavoritesCommand+	 �� 
 ItemsControl��5~   -   �� y�5�   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl# [ $ Watched���� 5�   &   $��Usuń z ulubionych��6-   #��[ 5�   -   ��5�   -   �� *(&DataContext.RemoveFromFavoritesCommand+	 �� 
 ItemsControl��5�   -   �� y�5�   -   �� *DataContext.CollectionType+	 �� 
 ItemsControl# [ $ 	Favorites��5�   #   5�      5�      5�      5�      5�      5�      5�      