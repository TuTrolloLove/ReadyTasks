   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views       ReadyTasks.Views.AdminView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� .+��� .@��� -     ��Name$  TIDashboard��$��	Dashboard��.���� $
��Auto=�.��� .+��� $	��123��$	��100��$��
235,57,0,0q�$
��Left=�$	��Top=�
������� �� RadiusX$ 10�� �� RadiusY$ 10��
���   � 
  Shadow#��[  �� -    ��Name$ TBTotalNotes��$��256,63,481,343q�$��Notas���� -   $ TBTotalNotesCount��$��256,78,434,304q�$��30(�$	��120���� $	��176��$	��100��$��
372,57,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $ TBTotalNotesCompleted��$��388,63,247,342q�$��Notas completadas���� -   $  TBTotalNotesCompletedCount��$��388,77,291,303q�$��30(�$��80���� $	��192��$	��100��$��
566,57,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $ TBTotalNotesNoCompleted��$��582,63,47,343q���  � Language$ es-es�$�N���� $�otas no completadas���� -   $" TBTotalNotesNoCompletedCount��$��582,77,89,309q�$��30(�$��40���� $	��192��$	��100��$��120,186,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $ TBTotalHighPriorityNotes��$��146,198,491,202q�$��Notas con prioridad alta���� -	   $# TBTotalHighPriorityNotesCount��$��146,210,515,172q�$��30(�$��10���� $	��192��$	��100��$��340,186,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -
   $  TBTotalMediumPriorityNotes��$��366,198,256,202q�$��Notas con prioridad media���� -   $% TBTotalMediumPriorityNotesCount��$��366,210,295,172q�$��30(�$��30���� $	��192��$	��100��$��560,186,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $ TBTotalLowPriorityNotes��$��586,198,50,202q�$��Notas con prioridad baja���� -   $" TBTotalLowPriorityNotesCount��$��586,210,75,172q�$��30(�$��80���� $	��123��$	��100��$��	93,57,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $ TBTotalUsers��$��100,63,573,337q�$��Usuarios���� -   $ TBTotalUsersCount��$��100,78,561,304q�$��30(�$��80���� $	��192��$	��100��$��226,302,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $  TBPercentageNotesCompleted��$��252,314,385,86q��� $ es-es�$�Notas completadas (%)���� -   $% TBPercentageNotesCompletedCount��$��252,326,409,56q�$��30(�$��10���� $	��192��$	��100��$��456,302,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $" TBPercentageNotesNoCompleted��$��472,314,142,86q��� $�Notas no completadas (%)���� -   $' !TBPercentageNotesNoCompletedCount��$��482,326,180,56q�$��30(�$��10���� $	��192��$	��100��$��123,417,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $# TBPercentageNotesHighPriority��$��139,429,474,-29q��� $"�Notas con prioridad alta (%)���� -   $( "TBPercentageNotesHighPriorityCount��$��149,441,512,-59q�$��30(�$��10���� $	��192��$	��100��$��346,417,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $% TBPercentageNotesMediumPriority��$��362,429,250,-29q��� $#�Notas con prioridad media (%)���� -   $* $TBPercentageNotesMediumPriorityCount��$��372,441,288,-59q�$��30(�$��10���� $	��192��$	��100��$��560,417,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  �� -   $" TBPercentageNotesLowPriority��$��576,429,38,-29q��� $"�Notas con prioridad baja (%)���� -   $' !TBPercentageNotesLowPriorityCount��$��586,441,76,-59q�$��30(�$��10���� -   $  TIUser��$�� ��.���  � ColumnDefinitions �� $	��29* ��� $	��11* ��� $	��44* ��� $
��710* �.+��� -    ��Name$ 	rUserData��$��3��$	��249��$	��167��$��8,82,0,0q�$
��Left=�$	��Top=�
�������$ 10��$ 10��
���   �#��[  $y�Hidden=��� -   $ TBEmailOrID��$��2��$��2��$��1,12,698,388q�$�� ��$
��Wrap=��� -    ��Name$ tbEmailOrID��$��3��$	��231��$��	17,12,0,0q�$
��Left=�$	��Top=� �� TextWrapping$
 Wrap=��� -   	 ��Name$	 btnFindUserData��$��3��$��71��$��18��$��
253,10,0,0q�$
��Left=�$	��Top=�$��Center=�$��Center=�
������ 
������ $�� ��$
��Bold"����� 
 �� 
TargetType"
 ��.R��� #��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property � �� �� Value
 ���� �� -   $
 tbID��$��3��$��
31,105,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=��� -    $ tbEmail��$��3��$��
31,130,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=��� -!   $ tbfromGoogle��$��3��$��
31,153,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=��� -"   $ tbCountNotes��$��3��$��
31,178,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=��� -#   $ 	tbIsAdmin��$��3��$��
31,205,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=��� -$   $  TINotes��$��	-2,0,-2,0q�$�� ��.��� -%    �Name$ notesMainGrid��.+��� -&   $ TBIDUserOrIDNote��$��20,13,632,391q�$�� ��$
��Wrap=��� -'    ��Name$ cbIDOrNoteID��$	��120��$��
167,11,0,0q�$
��Left=�$	��Top=� �� SelectedIndex$ 0��.@��� -(    ��Name$ 	CBIIDUser��$�� ���� -)   $ 	CBIIDNote��$�� ���� -*   $ tbIDOrNoteID��$��66��$��
292,13,0,0q�$
��Left=�$	��Top=�$
 Wrap=��� -+   $ TBTitleOrContent��$��20,59,672,344q�$�� ��$
��Wrap=��� -,   $ tbTitleOrContent��$	��231��$��
127,59,0,0q�$
��Left=�$	��Top=�$
 Wrap=��� --   $	 btnFindNotes��$��72��$��19��$��
363,12,0,0q�$
��Left=�$	��Top=�$��Center=�$��Center=�
������ 
������ $�� ��$
��Bold"����� "
 ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� �� -.   $ 	 btnFindNotesTitleOrContent��$��70��$��19��$��
365,58,0,0q�$
��Left=�$	��Top=�$��Center=�$��Center=�
������ 
������ $�� ��$
��Bold"����� "
 ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� �� $��435,13,312,345q�.+���  �� Left$	 -10��
 �� Top$ 9��$��Center=�$	��Top=�
���   �$��4��	 �� X1$ 10��	 �� X2$ 50��	 �� Y1$ 0��	 �� Y2$ 0���� $	 -10��$ 56��$��Center=�$	��Top=�
���   �$��4��$ 10��$ 50��$ 0��$ 0���� $ 38��$ -3��$
��Left=�$��Center=� J� RenderTransformOrigin$	 0,0&�
���   �$��4��$ 10��$ 61��$ 0��$ 0��z�V� .~��� �� ��  �� Angle$ 89.734Q�T� �� $ 27��$ 32��$
��Left=�$	��Top=�$	 0,0&�
���   �$��4��$ 10��$ 20��$ 0��$ 0���� -/   $	 btnCombinedSearch��$ 49��$ 23��$
��Left=�$��Center=�
������ 
������   AdminViewTab2ButtonCombined#��[ $
��Bold"����� "
 ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� 