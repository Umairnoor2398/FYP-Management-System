   M S B A M L   `   `   `  ????C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectA.UserControlsProjectA.UserControls  5      -    'ProjectA.UserControls.Group.CRUDGroupUC   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ProjectA.UserControls     5      6tk-http://schemas.microsoft.com/wpf/2008/toolkit  5      _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5         MaterialDesignBody#???   5      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5      
??????   MaterialDesignFont#???  5       ? 	Resources 5        	addButton ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? CornerRadius ?? Triggers	 P? Property
 P? Value??%  &	       ?? 5   
   " ??5      .?5      ??  ? ?? ?#6741d95      ?? 5       ? ?? ?#ffffff5      ?? 5       ?@?FocusVisualStyle 5      Z? ?? 5       ? ??$	 150??5      ?? 5        ? ??$ 35??5!      ?? 5"       ? ??$ Right=?5#      ?? 5$       ? ??$ 0 20 0 0q?5%      ?? 5&       ? ??$ 13(?5'      ?? 5(       ? ??$ 1??5)      ?? 5*       ? ?? 5+      ?? 5,      " ??6&   .R?5-      ?? #??z??6!   $ 7??5.   !   ._?5/      ?? $??Center=?6/   $??Center=?50   /   51      52      54       56      P? 57      	 ?@J?IsMouseOver
 . . ?59      ??  ? ?? ?#7b5cd65:      ?? 5;       ? ?? ?#ffffff5<      5=      5@      5F      .??5H      #  MaterialDesignThemes.Wpf.Card  $??32q?6   $??16q?5I      .??5K   
   ?  ? RowDefinitions 5L      ?? 5M      $	??100 ?6    ?? 5N      $??* ?6    .+?5Q      ? $??0??6    ? ColumnDefinitions 5R      ?? 5S      $??* ?6'   ?? 5T      $
??auto ?6'   .+?5V      ?? $??0??6   $??Managing Groups Section??5W      $??1??5X      $??32(?5Y      $??SemiBold"?5Z      $??0 20 0 0q?5[      $??Center=?5\      $
??Left=?5]      ???#1215185^      ?? 5`      -   5         ??Name$ createGroupBtn??5b      $??1??5`      #??[ 5a      $??Create New Group??5d      5e      5f      ?? 5h      -   5         ??Name$ editGroupForm??5i      $??1??5h      $y?	Collapsed=?5j      .??5k      >? -   5         >?Name$ groupUC??5k      5l      &   System.Windows.Controls.DataGrid  5p      -   5          Name$ GroupDataGrid??5q      $??1??5p         
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .     CanUserResizeColumns .     AutoGenerateColumns .   ?? 
GroupStyle 5z      (  "System.Windows.Controls.GroupStyle  5|         ContainerStyle 5}      ?? 5~      " ??6$   .?5   "   ??  ? ??$ 0,0,0,5q?5?   )   ?? 5?   "    ? ?? 5?   &   ?? 5?   *   " ??6:   .R?5?   .   9?  9? 
IsExpanded . $??1,1,1,5q?5?   7   ??5?   2   ]? 5?   6   .+?5?   :   ?? $
??Bold"?6D   $??0,0,0,0q?5?   D   $	??100??5?   D   ??5?   D   ??  ?? Path$
 Name?5?   D   ?? 5?   :   $?? (??6D   ?? 5?   :   ??6D   ?? *	ItemCount+?? 5?   :   $??
 Students)??6D   5?   7   ??5?   2   ?? 5?   6   5?   /   5?   +   5?   #   5?      5?        5?         HeaderTemplate 5?      ?? 5?      .R?5?   "   ]? 
????ح?.+?5?   &   ?? 
????  ?$??30,0,0,0q?5?   0   $	??100??5?   0   ??5?   0   ?? *Name+5?   0   ?? 5?   &   
????  ???60   ?? $ 	ItemCount?5?   0   5?   #   5?      5?         Columns 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Group ID??6-       Width5  /System.Windows.Controls.DataGridLengthConverter$
  Auto 5?   -   !   CellTemplate! 5?      ?? 5?      .R?5?   "   ?? ??6,   ?? *	GroupId+5?      5?        5?      $ Project??6-   $
  Auto 5?   -   ! 5?      ?? 5?      .R?5?   "   ?? ??6,   ?? $ Title?5?      5?        5?      $ Students??6-   $
  Auto 5?   -   ! 5?      ?? 5?      .R?5?   "   ?? ??6,   ?? *
GStudent+5?      5?        5?      $ Creation Date??6-   $
  Auto 5?   -   ! 5?      ?? 5?      .R?5?   "   ?? ??6,   ?? *
Created_On+5?      5?        5?      $ 
Operations??6-   "   
IsReadOnly" . $
  auto 5?   -   ! 5?      ?? 5?      .R?5?   "   ?? # ?? Orientation$# 
Horizontal=?6-   .+?5?   &   ?? $ editBtn??6-   -   5        
?????? 
?????? .??5?   *   .  (MahApps.Metro.IconPacks.PackIconMaterial  $   Kind$$ PencilOutline=?6@   
???????5?   @   5?   '   ?? 5?   &   $ 
detailsBtn??5?   .   -   5        $??5 0 0 0q?5?   .   
?????? 
?????? 
% ? Tag$% Group Details??5?   .   .??5?   *     $$ Details=?6@   
???  ??5?   @   5?   '   5?   #   5?      5?      5?      5?      5?      5?      