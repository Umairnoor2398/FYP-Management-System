   M S B A M L   `   `   `  ????C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectA.UserControlsProjectA.UserControls  5      2    ,ProjectA.UserControls.PDFReports.PDFReportUC   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ProjectA.UserControls     5      6tk-http://schemas.microsoft.com/wpf/2008/toolkit  5      _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5
         MaterialDesignBody#???   5      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5      
??????   MaterialDesignFont#???  5      .??5      #  MaterialDesignThemes.Wpf.Card  $??32q?6   $??16q?5      .??5   
   ?  ? RowDefinitions 5      ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    .+?5       ? $??0??6   $??5q?5!       ? ColumnDefinitions 5"      ?? 5#      $??* ?6'   ?? 5$      $
??auto ?6'   .+?5&      ?? $??0??6   $
??Left=?5'      $
??Wrap=?5(      $??Center=?5)      $%??Generate Report of all Students??5*      ?? 5+      -   5         ??Name$ StudentReportBtn??5-      $??Right=?5+      $??Center=?5,      $??Generate Report??5/      50      ? 52      $??1??6   $??5q?53       54      ?? 55      $??* ?6'   ?? 56      $
??auto ?6'   .+?58      ?? $??0??6   $
??Left=?59      $
??Wrap=?5:      $??Center=?5;      $%??Generate Report of all Advisors??5<      ?? 5=      -   5        $ 
AdvisorBtn??5?      $??Right=?5=      $??Center=?5>      $??Generate Report??5A      5B      ? 5D      $??2??6   $??5q?5E       5F      ?? 5G      $??* ?6'   ?? 5H      $
??auto ?6'   .+?5J      ?? $??0??6   $
??Left=?5K      $
??Wrap=?5L      $??Center=?5M      $@??:Generate Report of all Projects Along their Advisory Board??5N      ?? 5O      -   5        $ ProjectAdvisorBtn??5Q      $??Right=?5O      $??Center=?5P      $??Generate Report??5S      5T      ? 5V      $??3??6   $??5q?5W       5X      ?? 5Y      $??* ?6'   ?? 5Z      $
??auto ?6'   .+?5\      ?? $??0??6   $
??Left=?5]      $
??Wrap=?5^      $??Center=?5_      $+??%Generate Report of Students Marksheet??5`      ?? 5a      -   5        $ MarkSheetBtn??5c      $??Right=?5a      $??Center=?5b      $??Generate Report??5e      5f      ? 5h      $??4??6   $??5q?5i       5j      ?? 5k      $??* ?6'   ?? 5l      $
??auto ?6'   .+?5n      ?? $??0??6   $
??Left=?5o      $
??Wrap=?5p      $??Center=?5q      $2??,Generate Report of all Available evaluations??5r      ?? 5s      -   5        $ EvaluationReportBtn??5u      $??Right=?5s      $??Center=?5t      $??Generate Report??5w      5x      ? 5z      $??5??6   $??5q?5{       5|      ?? 5}      $??* ?6'   ?? 5~      $
??auto ?6'   .+?5?      ?? $??0??6   $
??Left=?5?      $
??Wrap=?5?      $??Center=?5?      $#??Generate Report of all Groups??5?      ?? 5?      -   5        $ groupReportBtn??5?      $??Right=?5?      $??Center=?5?      $??Generate Report??5?      5?      5?      5?      5?      