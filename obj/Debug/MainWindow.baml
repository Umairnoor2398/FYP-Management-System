   M S B A M L   `   `   `  ????C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjectAProjectA  5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	       ProjectA.MainWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ProjectA     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   Z	 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf 	 5   	     ? Title$  
MainWindow??5   	    ? WindowStartupLocation$ CenterScreen=?5	   	    ? WindowStyle$
 None=?5
   	    ? AllowsTransparency . 
?????? $	??720??5   	   $
??1080??5   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      MaterialDesignBody#???   5   	     MaterialDesignFont#???  5   	      TextRenderingMode$
 Auto=?5   	    ? 	Resources 5        	topButton ?? 
TargetType ?? Property	 ?? Value
 ?? 
TargetType ?? CornerRadius ?? Triggers P? Property P? Value  
menuButton  menuButtonIcon.  (MahApps.Metro.IconPacks.PackIconMaterial  menuButtonIconImage  menuButtonIcon1! 	 FontAwesome.WPF.FontAwesome  textboxSearch ??Name J? SnapsToDevicePixels ??Name ?? Triggers ?? 
TargetName  	addButton 	 	tabButton 
 textboxFilter ?? BasedOn  pagingButton ?? Padding  pagingButtonIcon  gridEditButton  gridDeleteButton  gridButtonIcon  DataGridStyle1&   System.Windows.Controls.DataGrid5  /System.Windows.Controls.DataGridLengthConverter ?? RelativeSource  DataGridCellStyle1*  $System.Windows.Controls.DataGridCell  DataGridRowStyle1)  #System.Windows.Controls.DataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid ? ColumnDefinitions ? RowDefinitions?	  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA
  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row ?? ConverterParameter!   HeadersVisibilityConverter ?? 	Converter ?? AncestorType  ]? 
Conditions! ?? Property" ?? Value  MaterialDesignThumb   BooleanToVisibilityConverter ) %MaterialDesignGridColumnHeaderGripper  DataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader 1 -GridLinesVisibilityBorderToThicknessConverter??%G-  &	       &	 a    &	     &	 ?    &	 ?    &	 ?    &	 !    &		 2    &	
 )    7  &	 ?    &	 $    &	 ?    &	 >    7  &	 7    &	 ?    &	 ?    &	 E!    &	 ?'    &	 c)    &	 v)    7  &	 $*    7  ?? 5   
   " ??5      .?5      ??  ? ??
	 ???? 5      ?? 5       ? ??	 ?#0000005      ?? 5        ?@?FocusVisualStyle	 5!      Z? ?? 5"       ? ??$	 30??5#      ?? 5$       ? ??$	 30??5%      ?? 5&       ? ??$
	 Left=?5'      ?? 5(       ? ??	 5)      ?? 5*      "
 ??6&   .R?5+      ?? #??z??6!   $ 50??5,   !   ._?5-      ?? $??Center=?6/   $??Center=?5.   /   5/      50      52       54      P? 55       ?@J?IsMouseOver . . ?57      ??  ? ??	 ?#dcdcdc58      59      5<      ?? 5>   
   " ??5?      .?5@      ??  ? ??
	 ???? 5A      ?? 5B       ? ??	 ?#d0c0ff5C      ?? 5D       ?@?FocusVisualStyle	 5E      Z? ?? 5F       ? ??$	 35??5G      ?? 5H       ? ??$
	 15 3q?5I      ?? 5J       ? ??$	 13(?5K      ?? 5L       ? ??$
	 Left=?5M      ?? 5N       ? ??	 5O      ?? 5P      "
 ??6&   .R?5Q      ?? #??z??6!   $ 7??5R   !   ._?5S      ?? $
??Left=?6/   $??Center=?5T   /   5U      5V      5X       5Z      P? 5[       ?@J?IsMouseOver . . ?5]      ??  ? ??	 ?#7b5cd65^      ?? 5_       ? ??	 ?#ffffff5`      5a      5d      ?? 5g   
   "  5h      .?5i      ??  ? ??$	 30??5j      ?? 5k       ? ??$	 30??5l      ?? 5m       ? ??$	 Center=?5n      ?? 5o       ? ??$	 	20 2 20 2q?5p      5q      ?? 5s   
   " ??5t      .?5u      ??  ? ??$	 30??5v      ?? 5w       ? ??$	 30??5x      ?? 5y       ? ??$	 Center=?5z      ?? 5{       ? ??$	 	20 2 20 2q?5|      5}      ?? 5   
   "  5?      .?5?      ??  ? ??$	 35??5?      ?? 5?       ? ??$	 35??5?      ?? 5?       ? ??$	 Center=?5?      ?? 5?       ? ??$	 	20 2 20 2q?5?      5?      ?? 5?   
   " ??5?      .?5?      ??  ? ??	 ?#ffffff5?      ?? 5?       ? ??	 ?#b0b9c65?      ?? 5?       ? ??$	 0q?5?      ?? 5?       ? ??$	 12(?5?      ?? 5?       ? ??$	 40??5?      ?? 5?       ? ??$	 15 10q?5?      ?? 5?       ? ??$	 Center=?5?      ?? 5?       ? ??$
	 0 10q?5?      ?? 5?       ? ??	 5?      ?? 5?      "
 ??6&   .R?5?      ?? $ border??6!   $ 22??5?   !   #??z??5?   !    . $??1q?5?   !   ???#e0e6ed._?5?      ?? $ PART_ContentHost??6+   |?.  $??Hidden=?5?   +   $??Hidden=?5?   +   5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?   "   ?? $ border??5?   )    ? ??	 ?#d9d9d95?      P? 5?       ?@J?IsKeyboardFocused . . ?5?   "   ?? $ border??5?   )    ? ??	 ?#d9d9d95?      5?      5?      5?      ?? 5?   
   " ??5?      .?5?      ??  ? ??	 ?#6741d95?      ?? 5?       ? ??	 ?#ffffff5?      ?? 5?       ?@?FocusVisualStyle	 5?      Z? ?? 5?       ? ??$		 150??5?      ?? 5?       ? ??$	 35??5?      ?? 5?       ? ??$	 Right=?5?      ?? 5?       ? ??$	 0 20 0 0q?5?      ?? 5?       ? ??$	 13(?5?      ?? 5?       ? ??$	 1??5?      ?? 5?       ? ??	 5?      ?? 5?      "
 ??6&   .R?5?      ?? #??z??6!   $ 7??5?   !   ._?5?      ?? $??Center=?6/   $??Center=?5?   /   5?      5?      5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?      ??  ? ??	 ?#7b5cd65?      ?? 5?       ? ??	 ?#ffffff5?      5?      5?      ?? 5?   
   " ??5?      .?5?      ??  ? ??
	 ???? 5?      ?? 5?       ? ??	 ?#1215185?      ?? 5?       ?@?FocusVisualStyle	 5?      Z? ?? 5?       ? ??$	 70??5?      ?? 5?       ? ??$	 45??5?      ?? 5?       ? ??
	 ???? 5?      ?? 5?       ? ??$	 Right=?5?      ?? 5?       ? ??$	 14(?5?      ?? 5       ? ??$	 SemiBold"?5     ?? 5      ? ??	 5     ?? 5     "
 ??6&   .R?5     ?? #??z??6!   $??0 0 0 1q?5  !   #??z??5  !   ._?5     ?? $??Center=?6/   $??Center=?5	  /   5
     5     5      5     P? 5      ?@J?IsMouseOver . . ?5     ??  ? ??	 ?#784ff25     5     5     ?? 5  
   " ??5     8   .?5     ??  ? ??$
	 10 7q?5     ?? 5      ? ??	 5     ?? 5      "
 ??6&   .R?5!     ?? $ border??6!   $ 7??5"  !   #??z??5#  !    . $??1q?5%  !   ???#e0e6ed._?5'     ?? $ PART_ContentHost??6+   |?.  $??Hidden=?5)  +   $??Hidden=?5*  +   5,      5-     P? 5.      ?@J?IsMouseOver . . ?50  "   ?? $ border??52  )    ? ??	 ?#d9d9d953     P? 55      ?@J?IsKeyboardFocused . . ?57  "   ?? $ border??59  )    ? ??	 ?#d9d9d95:     5<     5>     5@     ?? 5B  
   " ??5C     .?5D     ??  ? ??
	 ???? 5E     ?? 5F      ? ??	 ?#6c76825G     ?? 5H      ?@?FocusVisualStyle	 5I     Z? ?? 5J      ? ??$	 13(?5K     ?? 5L      ? ??$		 1 0q?5M     ?? 5N      ? ??	 5O     ?? 5P     "
 ??6&   .R?5Q     ?? #??z??6!   $ 5??5R  !   $
 10 5q?5S  !   ._?5T     ?? $??Center=?6/   $??Center=?5U  /   $??0 0 0 1q?5V  /   5W     5X     5Z      5\     P? 5]      ?@J?IsMouseOver . . ?5_     ??  ? ??	 ?#7950f25`     ?? 5a      ? ??	 ?#ffffff5b     5c     5f     ?? 5h  
   "  5i     .?5j     ??  ? ??$	 10??5k     ?? 5l      ? ??$	 10??5m     ?? 5n      ? ??$	 Center=?5o     5p     ?? 5s  
   " ??5t     .?5u     ??  ? ??	 ?#512da85v     ?? 5w      ? ??	 ?#4a148c5x     ?? 5y      ? ??	 ?#ffffff5z     ?? 5{      ?@?FocusVisualStyle	 5|     Z? ?? 5}      ? ??$	 Center=?5~     ?? 5      ? ??	 5?     ?? 5?     "
 ??6&   .R?5?     ?? #??z??6!   $ 5??5?  !   $ 5q?5?  !   $??1q?5?  !   #??z??5?  !   ._?5?     ?? $??Center=?6/   $??Center=?5?  /   5?     5?     5?      5?     P? 5?      ?@J?IsMouseOver . . ?5?     ??  ? ??	 ?#673ab75?     5?     5?     ?? 5?  
   " ??5?     8   .?5?     ??  ? ??	 ?#d32f2f5?     ?? 5?      ? ??	 ?#b71c1c5?      5?     P? 5?      ?@J?IsMouseOver . . ?5?     ??  ? ??	 ?#f443365?     5?     5?     ?? 5?  
   "  5?     .?5?     ??  ? ??$	 12??5?     ?? 5?      ? ??$	 12??5?     ?? 5?      ? ??$	 Center=?5?     5?     ?? 5?  
   "  5?     .?5?     ??  ? ??
	 ???? 5?     ?? 5?      ? ??	 ?#2225285?     ?? 5?      ? ??$	 0q?5?     ?? 5?       ?@ RowDetailsVisibilityMode$	 VisibleWhenSelected=?5?     ?? 5?      ? ??	 . 5?     ?? 5?      ?@??PanningMode$
	 Both=?5?     ?? 5?      ?@??IsFlicksEnabled	 .  5?     ?? 5?      ?@ AutoGenerateColumns	 .  5?     ?? 5?      ?@ HeadersVisibility$	 Column=?5?     ?? 5?      ? ??$	 0 10 0 0q?5?     ?? 5?      ?@ SelectionMode$	 Single=?5?     ?? 5?      ?@ SelectionUnit$	 FullRow=?5?     ?? 5?      ?@ CanUserAddRows	 .  5?     ?? 5?      ?@ CanUserDeleteRows	 .  5?     ?? 5?      ?@ CanUserResizeColumns	 .  5?     ?? 5?      ?@ CanUserReorderColumns	 .  5?     ?? 5?      ?@ CanUserResizeRows	 .  5?     ?? 5?      ? ??$	 13(?5?     ?? 5?      ?@ ColumnWidth$	 * 5?     ?? 5?      ?@ GridLinesVisibility$
	 None=?5?     ?? 5?      ? ??	 5?     ?? *" (wpf:DataGridAssist.CellPadding)+ ?? *Self+5?     ?? 5?  
   "  5?     .?5?     ??  ? ??
	 ???? 5?     ?? 5?      ? ??$	 Center=?5?     ?? 5?      ?@?FocusVisualStyle	 5?     Z? ?? 5?      ? ??$
	 15 0q?5?     ?? 5?      ? ??	 5?     ?? 5?     "
  6&   .R?5?     ? .+?5?     ?? #??z??6%   $??0q?5?  %    . 5?  %   ?? 5?     #??z??6/   # z 5?  /   5?     5?     5?     5?     ?? 5?  
   "  5?     .?5?     ??  ? ??
	 ?????5?     ?? 5?      ? ??$	 0 4 0 0q?5?     ?? 5?      ?@J?SnapsToDevicePixels	 . 5?     ?? 5?      ? ??	 5      ?? 5     "
  6&   .R?5     ?? $ 
DGR_Border??6!   #??z??5  !   $??0q?5  !    . $ 5??5  !   $	 0 8q?5  !   ._?5        5	  "   ?? 5
  &   $
??Auto ?67   ?? 5  &   $??* ?67    5  "   ?? 5  &   $??* ?64   ?? 5  &   $
??Auto ?64   .+?5  "   	  $??1??69   #??z 5  9   # z 5  9   
  5  "   $??1??6;   $??1??5  ;   #y?z 5  ;     5  "   $??0??64   $??2??5  4   $??0??5  4   y?5  4   ?? *HeadersVisibility+# Z # Z  ?? "  5     5     5     5     ?? 5       ?@=?ErrorTemplate	 5!     Z? ?? 5"      ?@ ValidationErrorTemplate	 5#     ?? 5$     .R?5%     ?? ???#d50000$??2,0,0,0q?5&  $   $??!??5'  $   $??Center=?5(  $   5)     5+      5,     P? 5-      ?@ 
IsSelected . . ?5/     ??  ? ??	 ?#623ed050     ?? 51      ? ??	 ?#ffffff52     53     P? 54      ?@ 
IsSelected .  . ?56     ??  ? ??
	 ?????57     ?? 58      ? ??	 ?#00000059     5:     P? 5;      ?@J?IsMouseOver . . ?5=     ??  ? ??	 ?#623ed05>     ?? 5?      ? ??	 ?#ffffff5@     5A     ]? 5B       5C     ?? 5D     ! ?@ 
IsSelected" . 5E  $   ?? 5F     ! ?@??IsSelectionActive" .  5G  $   ./?5I     ??  ? ??	 ?#dfdfdf5J     5K     5M     ?? 5N  
   " n?5O     .?5P     ??  ? ??
	 ???? 5Q     ?? 5R      ?@?OverridesDefaultStyle	 . 5S     ?? 5T      ? ??$	 8q?5U     ?? 5V      ?@J?SnapsToDevicePixels	 . 5W     ?? 5X      ? ??	 5Y     ?? 5Z     "
 n?6&   .R?5[     ?? $ PART_Border??6!   #??z??5\  !   # z??5]  !   # z 5^  !   5_     5a     5b     ?? 5c  
   6'   ?? 5d  
   8   " n?5f     .?5g     ??  ?@?Cursor$	 SizeWE??5h     ?? 5i      ? ??$	 0q?5j     ?? 5k      ? ??$	 8??5l     5m     ?? 5n  
   "  5o     .?5p     ??  ? ??$	 Center=?5q     ?? 5r      ? ??
	 ???? 5s     ?? 5t      ? ??	 ?#69717d5u     ?? 5v      ? ??$	 
15 0 15 10q?5w     ?? 5x      ? ??	 5y     ?? *HorizontalGridLinesBrush+ ?? "  ?? 5z      ? ??	 5{     ?? *GridLinesVisibility+8    ?? "  ?? 5|      ? ??	 5}     ?? **((wpf:DataGridAssist.ColumnHeaderPadding)+ ?? *Self+?? 5~      ? ??$	 Medium"?5     ?? 5?      ? ??$	 Center=?5?     5?     5?     .??5?     ?? -   5        ???#eff2f7$ 30??5?     ._?5?  
   ?  5?     ?? 5?     $	??250 ?6#   61   ?? 5?     $??* ?6#   6/   .+?5?     ? $??0??6    5?     ?? 5?     $
??auto ?6$   64   ?? 5?     $??* ?6$   61   .+?5?     ?? $??1??6   ???#623ed0$ 30 50 50 30??5?     ._?5?     ]? .+?5?     ?? $??80??6!   $??80??5?  !   $ 3q?5?  !   
???????$	 100??5?  !   $	??Top=?5?  !   $
??Left=?5?  !   $??	20 50 0 0q?5?  !   ._?5?     A? ??5?  "   ?? 5?  &   # ?? ImageSource$# Assets/Logo.jpeg??62   5?     5?     ?? 5?     $	??FYP??6$   
???????$??28(?5?  $   $??SemiBold"?5?  $   $	??Top=?5?  $   $ ?? TextAlignment$$ Center=?5?  $   $??	5 25 0 10q?5?  $   ?? 5?     $??Management System??6$   ???#d0bfff$??14(?5?  $   $??SemiBold"?5?  $   $	??Top=?5?  $   $$ Center=?5?  $   ?? 5?     $??25q?6$   $	??Top=?5?  $   $	??0.8??5?  $   ???#7e5fdc5?  $   ?? 5?     $	??Top=?6'   $
??Auto=?5?  '   $
??Auto=?5?  '   .??5?     ?? $	??Top=?6)   .+?5?  "   ?? -   5        % ??Name$% 
studentBtn??5?  )   #??[ 5?  )   .??5?  &   ?? & ?? Orientation$& 
Horizontal=?61   .+?5?  *   ?? $??Assets/student.png??60   #??[ 5?  0   ?? 5?  *   $??Students??64   $??Center=?5?  4   $	??100??5?  4   5?  '   5?  #   ?? 5?  "   -   5        $% 
advisorBtn??5?  )   #??[ 5?  )   .??5?  &   ?? $& 
Horizontal=?61   .+?5?  *   ?? $??Assets/advisor.png??60   #??[ 5?  0   ?? 5?  *   $??Advisors??64   $??Center=?5?  4   $	??100??5?  4   5?  '   5?  #   ?? 5?  "   -   5        $% 
projectBtn??5?  )   #??[ 5?  )   .??5?  &   ?? $& 
Horizontal=?61   .+?5?  *   ?? $??Assets/project.png??60   #??[ 5?  0   ?? 5?  *   $??Projects??64   $??Center=?5?  4   $	??100??5?  4   5?  '   5?  #   ?? 5?  "   -   5        $% evaluationBtn??5?  )   #??[ 5?  )   .??5?  &   ?? $& 
Horizontal=?61   .+?5?  *   ?? $??Assets/evaluation.png??60   #??[ 5?  0   ?? 5?  *   $??Evaluations??64   $??Center=?5?  4   $	??100??5?  4   5?  '   5?  #   ?? 5?  "   -   5        $% markEvaluationBtn??5?  )   #??[ 5?  )   .??5?  &   ?? $& 
Horizontal=?61   .+?5?  *   ?? $ ??Assets/mark_evaluation.png??60   #??[ 5?  0   ?? 5?  *   $??Mark Evaluation??64   $??Center=?5?  4   $	??100??5   4   5  '   5  #   ?? 5  "   -   5        $% groupBtn??5  )   #??[ 5  )   .??5	  &   ?? $& 
Horizontal=?61   .+?5
  *   ?? $??Assets/group.png??60   #??[ 5  0   ?? 5  *   $??Groups??64   $??Center=?5  4   $	??100??5  4   5  '   5  #   ?? 5  "   -   5        $% assignAdvisorBtn??5  )   #??[ 5  )   .??5  &   ?? $& 
Horizontal=?61   .+?5  *   ?? $??Assets/assign_advisor.png??60   #??[ 5  0   ?? 5  *   $??Assign Advisors??64   $??Center=?5  4   $	??100??5  4   5  '   5  #   ?? 5  "   -	   5        $% 	reportBtn??5  )   #??[ 5  )   .??5   &   ?? $& 
Horizontal=?61   .+?5!  *   ?? $??Assets/report.png??60   #??[ 5"  0   ?? 5#  *   $??Generate Report??64   $??Center=?5$  4   $	??100??5%  4   5&  '   5'  #   5(     5)     ?? 5+     -
   5        $% exitBtn??5+  !   #??[ 5-  !   $??Bottom=?5.  !   $??Bottom=?5/  !   $??
15 15 0 15q?50  !   .??51     ?? $& 
Horizontal=?6)   .+?52  "     '   Kind$' Logout=?68   $??30??53  8   
???   ?#??[ 55  8   ?? 56  "   $
??Exit??6,   $??Center=?57  ,   $	??100??58  ,   59     5:     5=     5>     5?     ?? 5A     -   5        ( ??Name$( CC??5B     $??1??5A     5B     5C     5D     5F     