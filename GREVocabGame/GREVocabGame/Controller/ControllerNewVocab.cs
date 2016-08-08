using GREVocabGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GREVocabGame.Controller
{
    class ControllerNewVocab
    {
        private MainWindow view;
        //private ModelToWrite dataWrite;
        private DayPacket vocabList;
        private List<DayPacket> dayList;
        int currentListBoxIndex;


        public ControllerNewVocab(MainWindow view, ModelToWrite dataWrite)
        {

            //this.dataWrite = dataWrite;
            this.dayList = new List<DayPacket>();
            this.view = view;
            this.clearAll();
            this.fillVocabFileLists();
        }

        private void fillVocabFileLists()
        {
            this.view.listDays.Items.Clear();

            String strDay = "";
            
            int day;

            String dir = getVocabFolderAddr();
            String fileName = "Day";
            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                {
                    fileName += "0" + i.ToString();
                   
                }
                else
                {
                    fileName += i.ToString();
                    
                }
                fileName += ".txt";
               
                //MessageBox.Show(dir + fileName);
                if (File.Exists(dir + fileName))
                {
                    this.view.listDays.Items.Add(fileName);
                    strDay = fileName.Substring(3, 2);
                    day = int.Parse(strDay);
                    
                    scatterToDayArray(fileName);

                    //this.autoScrollListBox(this.view.listDays);
                }
                
                fileName = "Day";
                
            }



        }

        public void enterTyped(object sender, KeyEventArgs e)
        {
            TextBox temp = null;
            try
            {
                temp = (TextBox)sender;
            }
            catch
            {
                MessageBox.Show("Error Occured at enterType() of ControllerNewVocab");
            }

            if (e.Key == Key.Enter)
            {
                if (temp.Name.Equals("txtDay"))
                {
                    //MessageBox.Show("txtDay Enter typed");
                    this.view.txtWord.Focus();
                }
                else if (temp.Name.Equals("txtWord"))
                {
                    this.view.txtWordType.Focus();
                }
                else if (temp.Name.Equals("txtWordType"))
                {
                    this.view.txtMean.Focus();
                }
                else if (temp.Name.Equals("txtMean"))
                {
                    this.view.txtExample.Focus();
                }
                else if (temp.Name.Equals("txtRelation"))
                {
                    this.view.txtRealtedTo.Focus();
                }
                else if (temp.Name.Equals("txtRealtedTo"))
                {
                    this.view.btnAdd.Focus();
                }
                else if (temp.Name.Equals("txtExample"))
                {
                    this.view.txtRelation.Focus();
                }
            }
        }

        public void clearAll()
        {
            this.view.txtDay.Text = "";
            this.view.txtMean.Text = "";
            this.view.txtRealtedTo.Text = "";
            this.view.txtRelation.Text = "";
            this.view.txtWordType.Text = "";
            this.view.txtWord.Text = "";
            this.view.txtExample.Text = "";
        }

        private bool checkConventionForAdd()
        {
            bool result  = true;
            if (this.view.txtDay.Text == "" || 
                this.view.txtMean.Text=="" ||
                this.view.txtRealtedTo.Text=="" ||
                this.view.txtRelation.Text=="" ||
                this.view.txtWordType.Text == "" ||
                this.view.txtWord.Text==""||
                this.view.txtExample.Text == "")
            {
                MessageBox.Show("No Empty Blank");
                result = false;
            }
            return result;
        }

        private void autoScrollListBox(ListBox x)
        {
            var border = (Border) VisualTreeHelper.GetChild(x, 0);
            var scrollViewer = (ScrollViewer) VisualTreeHelper.GetChild(border, 0);
            scrollViewer.ScrollToBottom();
        }

        public void scatterToText(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListBox lBox = (ListBox)sender;
                currentListBoxIndex = lBox.SelectedIndex;
                this.view.txtDay.Text = this.vocabList.Day;
                this.view.txtMean.Text = this.vocabList.at(lBox.SelectedIndex).Mean;
                this.view.txtRealtedTo.Text = this.vocabList.at(lBox.SelectedIndex).RelatedTO;
                this.view.txtRelation.Text = this.vocabList.at(lBox.SelectedIndex).Relation;
                this.view.txtWordType.Text = this.vocabList.at(lBox.SelectedIndex).WordType;
                this.view.txtWord.Text = this.vocabList.at(lBox.SelectedIndex).Word;
                this.view.txtExample.Text = this.vocabList.at(lBox.SelectedIndex).Example;
                this.view.chkFocus.IsChecked = this.vocabList.at(lBox.SelectedIndex).Focus;
            }
            catch (Exception exxxx)
            {

            }
        }


        public List<DayPacket> DayAt
        {
            get { return dayList; }
        }

        public void scatterToDayArray(string fileName)
        {
            Console.WriteLine(fileName);
            String strDay = fileName.Substring(3, 2);
            int day = int.Parse(strDay);

            this.vocabList = new DayPacket();//this.dayList[day - 1];
            this.vocabList.Day = strDay;
            
            if (true)
            {

                StreamReader fIn = new StreamReader(getVocabFolderAddr() + fileName);
                String temp;
                while (!fIn.EndOfStream)
                {
                    this.vocabList.newVPacket();
                    fIn.ReadLine(); // get rid of index
                    temp = fIn.ReadLine();
                    this.vocabList.addWord(temp);
                    //this.view.listWords.Items.Add(temp);
                    //this.autoScrollListBox(this.view.listWords);

                    temp = fIn.ReadLine();
                    this.vocabList.addWordType(temp);
                    temp = fIn.ReadLine();
                    this.vocabList.addMean(temp);
                    temp = fIn.ReadLine();
                    this.vocabList.addRelation(temp);
                    temp = fIn.ReadLine();
                    this.vocabList.addRelatedTo(temp);
                    temp = fIn.ReadLine();
                    this.vocabList.addExample(temp);
                    temp = fIn.ReadLine();
                    this.vocabList.addFocus(bool.Parse(temp));

                    this.vocabList.insertVPacket();
                }
                fIn.Close();
            }

            dayList.Add(vocabList);
        }

        public void scatterToListWords(object sender, EventArgs e)
        {
            String strDay = this.view.listDays.SelectedItem.ToString().Substring(3, 2);
            int day = int.Parse(strDay);
            this.vocabList = this.dayList.ElementAt(day - 1);
            this.view.txtDay.Text = this.vocabList.Day;
            Console.WriteLine(this.vocabList.Count);
            this.view.listWords.Items.Clear();
            for (int i = 0; i < this.vocabList.Count; i++)
            {
                this.view.listWords.Items.Add(this.vocabList.at(i).Word);
                this.autoScrollListBox(this.view.listWords);
            }
        }


        public void addToList()
        {
            // before add, need to check if the focus in on the right array element
            
            int day = int.Parse(this.view.txtDay.Text);
            bool newDay = false;

            if (this.vocabList == null)  // current day's vocab list is null
            {
                if (this.dayList.Count <= day)  // there's the day is existing already in the daylist
                {
                    this.vocabList = this.dayList[day - 1];
                }
                else // there's no one yet
                {
                    this.dayList.Add(new DayPacket());
                    this.vocabList = this.dayList[day - 1];
                    String fileName = null;
                    if (this.view.txtDay.Text.Length < 2)
                    {
                        fileName = "Day0" + this.view.txtDay.Text + ".txt";
                    }
                    else
                    {
                        fileName = "Day" + this.view.txtDay.Text + ".txt";
                    }
                    this.view.listDays.Items.Add(fileName);
                }
            }
            else
            {
                if (int.Parse(this.vocabList.Day) != day)
                {
                    // there's one already
                    if (this.dayList.Count <= day)
                    {
                        this.vocabList = this.dayList[day - 1];
                    }
                    else // there's no one yet
                    {
                        this.dayList.Add(new DayPacket());
                        this.vocabList = this.dayList[day - 1];
                        Console.WriteLine("asdkfjalsdjfaldf");
                        newDay = true;
                    }
                }
            }

            if (this.checkConventionForAdd())
            {
                // add the data to model
                this.vocabList.Day = this.view.txtDay.Text;
                this.vocabList.newVPacket();
                this.vocabList.addWord(this.view.txtWord.Text);
                this.vocabList.addWordType(this.view.txtWordType.Text);
                this.vocabList.addMean(this.view.txtMean.Text);
                this.vocabList.addRelation(this.view.txtRelation.Text);
                this.vocabList.addRelatedTo(this.view.txtRealtedTo.Text);
                this.vocabList.addExample(this.view.txtExample.Text);
                if (this.view.chkFocus.IsChecked == true) this.vocabList.addFocus(true);
                else this.vocabList.addFocus(false);


                this.vocabList.insertVPacket();

                // update list box
                if (newDay)
                {
                    this.view.listWords.Items.Clear();
                    this.view.listWords.Items.Add(this.view.txtWord.Text);
                    this.saveList();
                    newDay = false;
                }
                this.view.listWords.Items.Add(this.view.txtWord.Text);
                
                // auto scroll
                this.autoScrollListBox(this.view.listWords);

                // reset the template
                String temp = this.view.txtDay.Text;
                this.clearAll();
                this.view.txtDay.Text = temp;
                this.view.txtWord.Focus();
             }

        }

        private bool checkConventionForSave()
        {
            bool result = true;
            if (this.view.listWords.Items.Count==0)
            {
                MessageBox.Show("List must have at least one item.");
                result = false;
            }
            else if (this.vocabList.Day == null)
            {
                MessageBox.Show("Day > 0");
                result = false;
            }
            return result;
        }

        private String getVocabFolderAddr()
        {
            // get VocabList Folder's address
            String dir = Environment.CurrentDirectory;
            // dir end with "Release or Debug" as long as development going on
            String check = dir.Substring(dir.Length - 7, 7);
            if (check.Equals("Release"))
            {
                // length(bin\Release) = 11
                dir = dir.Substring(0, dir.Length - 11) + "VocabList\\";
            }
            else
            {
                // length(bin\Debug) = 9
                dir = dir.Substring(0, dir.Length - 9) + "VocabList\\";
            }

            return dir;
        }

        public void saveList()
        {
            // check convention
            if (!checkConventionForSave())
            {
                return;
            }

            String dir = getVocabFolderAddr();
            
            // decide file name
            String fileName=null;
            if (this.view.txtDay.Text.Length < 2)
            {
                fileName = "Day0" + this.view.txtDay.Text + ".txt";
            }
            else
            {
                fileName = "Day" + this.view.txtDay.Text + ".txt";
            }

            // check duplication of file
            if (!File.Exists(dir + fileName)) // no duplication
            {
                writeFile(dir + fileName);
                MessageBox.Show(dir + fileName + " has saved.");
            }
            else // file already exits. decide what to do
            {
                MessageBox.Show("duplication occurred. Will Override");
                writeFile(dir + fileName);
            }
            this.fillVocabFileLists();
        }

        public void modify()
        {
            this.vocabList.at(currentListBoxIndex).Mean = this.view.txtMean.Text;
            this.vocabList.at(currentListBoxIndex).RelatedTO = this.view.txtRealtedTo.Text;
            this.vocabList.at(currentListBoxIndex).Relation = this.view.txtRelation.Text;
            this.vocabList.at(currentListBoxIndex).WordType = this.view.txtWordType.Text;
            this.vocabList.at(currentListBoxIndex).Word = this.view.txtWord.Text;
            this.vocabList.at(currentListBoxIndex).Example = this.view.txtExample.Text;
            if (this.view.chkFocus.IsChecked==true) this.vocabList.at(currentListBoxIndex).Focus = true;
            else this.vocabList.at(currentListBoxIndex).Focus = false;
            
            seeNextWord();
        }

        public void seeNextWord()
        {
            if (currentListBoxIndex < this.vocabList.Count -1 ) currentListBoxIndex++;
            if (this.vocabList.Count >= currentListBoxIndex)
            {
                this.view.txtDay.Text = this.vocabList.Day;
                this.view.txtMean.Text = this.vocabList.at(currentListBoxIndex).Mean;
                this.view.txtRealtedTo.Text = this.vocabList.at(currentListBoxIndex).RelatedTO;
                this.view.txtRelation.Text = this.vocabList.at(currentListBoxIndex).Relation;
                this.view.txtWordType.Text = this.vocabList.at(currentListBoxIndex).WordType;
                this.view.txtWord.Text = this.vocabList.at(currentListBoxIndex).Word;
                this.view.txtExample.Text = this.vocabList.at(currentListBoxIndex).Example;
                this.view.chkFocus.IsChecked = this.vocabList.at(currentListBoxIndex).Focus;
            }
           
        }
        public void seePrevWord()
        {
            if (currentListBoxIndex > 0) currentListBoxIndex--;
            if (currentListBoxIndex >=0)
            {
                this.view.txtDay.Text = this.vocabList.Day;
                this.view.txtMean.Text = this.vocabList.at(currentListBoxIndex).Mean;
                this.view.txtRealtedTo.Text = this.vocabList.at(currentListBoxIndex).RelatedTO;
                this.view.txtRelation.Text = this.vocabList.at(currentListBoxIndex).Relation;
                this.view.txtWordType.Text = this.vocabList.at(currentListBoxIndex).WordType;
                this.view.txtWord.Text = this.vocabList.at(currentListBoxIndex).Word;
                this.view.txtExample.Text = this.vocabList.at(currentListBoxIndex).Example;
                this.view.chkFocus.IsChecked = this.vocabList.at(currentListBoxIndex).Focus;
            }

        }


        public void delete()
        {
            this.vocabList.deleteAt();
        }

        private void writeFile(String fileName)
        {
            // create a file
            StreamWriter fout = new StreamWriter(fileName);

            // write the file
            for (int i = 0; i < this.vocabList.Count; i++)
            {
                fout.WriteLine(i.ToString());
                fout.WriteLine(this.vocabList.at(i).Word);
                fout.WriteLine(this.vocabList.at(i).WordType);
                fout.WriteLine(this.vocabList.at(i).Mean);
                fout.WriteLine(this.vocabList.at(i).Relation);
                fout.WriteLine(this.vocabList.at(i).RelatedTO);
                fout.WriteLine(this.vocabList.at(i).Example);
                fout.WriteLine(this.vocabList.at(i).Focus.ToString());
            }
            //this.dataWrite.listExample.Clear();
            //this.dataWrite.listMean.Clear();
            //this.dataWrite.listRealtedTo.Clear();
            //this.dataWrite.listRelation.Clear();
            //this.dataWrite.listWord.Clear();
            //this.dataWrite.listWordType.Clear();

            // close the file
            fout.Close();
        }
    
        public void viewTabFocus()
        {
            this.view.tabViewVocab.Focus();
        }

        public void testTabFocus()
        {
            this.view.tabTestVocab.Focus();
        }


    }
}
