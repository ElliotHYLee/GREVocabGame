   M S B A M L   `   `   `  ����   GREVocabGame    GREVocabGame.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  GREVocab��$��657.162��$��1076.449��.��� $��	0,0,2,-21q� � ColumnDefinitions �� $	��80* ��� $
��453* �.+��� $
��Left=�$��	10,30,0,0q�$	��842��$	��550��$	��Top=�$��1��.@��� -   $��tabViewVocab��$��Viewer��.��� 
�������$��
11,7,14,22q� � RowDefinitions �� $	��18* ��� $
��475* �.+��� $
��Word��$
��Left=�$��28��$��	34,55,0,0q�$	��Top=�$��66��$��1���� $��	Word Type��$
��Left=�$��27��$��	34,93,0,0q�$	��Top=�$��72��$��1���� $��Meaning��$
��Left=�$��27��$��
34,129,0,0q�$	��Top=�$��56��$��1���� $��Relation��$
��Left=�$��23��$��
41,316,0,0q�$	��Top=�$��61��$��1���� $��
Realted To��$
��Left=�$��23��$��179,316,0,0q�$	��Top=�$��72��$��1���� $	��Day��$
��Left=�$��28��$��	34,19,0,0q�$	��Top=�$��66��$��1���� -   $��txtDay��$
��Left=�$��23��$��
131,24,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��277��$��0��$��1���� -   $��txtWord��$
��Left=�$��23��$��
131,60,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��277��$��1��$��1���� -   $��txtWordType��$
��Left=�$��23��$��
131,97,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��277��$��2��$��1���� -   $��txtMean��$
��Left=�$��39��$��131,133,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��277��$��3��$��1���� -   $��txtRelation��$
��Left=�$��24��$��
41,344,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$��74��$��5��$��1���� -   $��txtRealtedTo��$
��Left=�$��24��$��131,344,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��165��$��6��$��1���� -   $��
txtExample��$
��Left=�$��86��$��
44,230,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��364��$��4��$��1���� -	   $��	listWords��$
��Left=�$	��448��$��
423,24,0,0q�$	��Top=�$	��187����.  J� 	AllowDrop . $��1���� -
   $��btnAdd��$	��Add��$
��Left=�$��28��$��
34,392,0,0q�$	��Top=�$��94��$��1���� -   $��	btnModify��$��Modify��$
��Left=�$��28��$��157,392,0,0q�$	��Top=�$��94��$��1���� -   $��btnDelte��$��Delete��$
��Left=�$��30��$��
34,442,0,0q�$	��Top=�$��94��$��1���� -   $��btnSave��$��Save This List��$
��Left=�$��30��$��157,442,0,0q�$	��Top=�$��94��$��1���� $��Example Sentence��$
��Left=�$��38��$��
44,192,0,0q�$	��Top=�$	��110��$��1���� -   $��listDays��$
��Left=�$	��448��$��
644,24,0,0q�$	��Top=�$	��122����.  . $��1���� -   $��btnClear��$��Clear��$
��Left=�$��26��$��276,394,0,0q�$	��Top=�$��78��$��1���� -   $��chkFocus��$��Focus��$
��Left=�$��24��$��324,344,0,0q�$��1��$	��Top=�$��84���� -    ��Name$ btnPrevVocab��$
��prev��$
��Left=�$��23��$��276,442,0,0q�$��1��$	��Top=�$��41���� -   $ btnNextVocab��$
��next��$
��Left=�$��23��$��334,442,0,0q�$��1��$	��Top=�$��40���� -   $��tabTestVocab��$
��Test��.��� $��0,-4,-2,-10q� �� $��7* ��� $
��265* �.+��� -    ��Name$ txtSentence��$
��Left=�$��50��$��	20,68,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��479��$��2���� -   $ btnGen��$��generate��$
��Left=�$��29��$��	368,9,0,0q�$	��Top=�$	��109��$��1���� -   $ 	txtDaySet��$
��Left=�$��28��$��	71,10,0,0q�$
 Wrap=�$��1��$	��Top=�$��73��$��1���� -    ��Name$ label��$��	Day From:��$
��Left=�$��29��$��	20,10,0,0q�$	��Top=�$��67��$��2���� -   $ label1��$��# of Questions��$
��Left=�$��29��$��
188,10,0,0q�$	��Top=�$��95��$��1���� -   $ txtNumQu��$
��Left=�$��28��$��
288,10,0,0q�$
 Wrap=�$��5��$	��Top=�$��75��$��1���� -   $ txtResponse��$
��Left=�$��26��$��306,123,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��171��$��1���� -   $ 	btnSubmit��$��Submit��$
��Left=�$	��112��$��
20,123,0,0q�$	��Top=�$	��303��$��2���� -   $ txtScore��$
��Left=�$��28��$��
583,11,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��128��$��1���� -   $ label2��$��score��$
��Left=�$��28��$��
533,11,0,0q�$	��Top=�$��46��$��1���� -    ��Name$ 	lstResult��$
��Left=�$	��454��$��
533,44,0,0q�$	��Top=�$	��252��$��1���� -   $ txtHint��$
��Left=�$��46��$��	1,435,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��398��$��1���� -    $ btnHint��$��	Show Hint��$
��Left=�$��46��$��405,435,0,0q�$	��Top=�$��76��$��1���� -!   $ 	lblNumber��$�� ��$
��Left=�$��24��$��1,39,0,0q�$	��Top=�$��48��$��1��	� -"   	 	�Name$	 opBox1��$��_��$
��Left=�$��22��$��	0,263,0,0q�$	��Top=�$	��105��$��1��	� -#   $	 opBox2��$��_��$
��Left=�$��22��$��	0,317,0,0q�$	��Top=�$	��105��$��1��	� -$   $	 opBox3��$��_��$
��Left=�$��22��$��	0,371,0,0q�$	��Top=�$	��105��$��1��	� -%   $	 opBox4��$��_��$
��Left=�$��22��$��155,263,0,0q�$	��Top=�$	��106��$��1��	� -&   $	 opBox5��$��_��$
��Left=�$��22��$��155,317,0,0q�$	��Top=�$	��106��$��1��	� -'   $	 opBox6��$��_��$
��Left=�$��22��$��155,371,0,0q�$	��Top=�$	��106��$��1���� -(   $ lblTime��$�� ��$
��Left=�$��24��$��
368,44,0,0q�$	��Top=�$��50��$��1���� -)   $ lblTimeTarget��$�� ��$
��Left=�$��24��$��
428,44,0,0q�$	��Top=�$��50��$��1���� -*   $ btnAll��$	��All��$��1��$
��Left=�$��21��$��
288,44,0,0q�$	��Top=�$��76���� -+   $ btnNext��$
��next��$��1��$
��Left=�$��21��$��
109,42,0,0q�$	��Top=�$��35���� -,   $ btnPrev��$
��prev��$��1��$
��Left=�$��21��$��	71,42,0,0q�$	��Top=�$��35���� --   
 ��Name$
 chkBriefMode��$��
Brief Mode��$��1��$
��Left=�$��19��$��
188,44,0,0q�$	��Top=�$��95���� -.   $��	btnViewer��$��Viewer��$
��Left=�$��34��$��	29,46,0,0q�$	��Top=�$	��105���� -/   $��btnTest��$
��Test��$
��Left=�$��34��$��
29,108,0,0q�$	��Top=�$	��105��