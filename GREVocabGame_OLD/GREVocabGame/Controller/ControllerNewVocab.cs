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
        private ModelToWrite dataWrite;
        private ModelToWrite[] dayArray;
        

        public ControllerNewVocab(MainWindow view, ModelToWrite dataWrite)
        {
            
            //this.dataWrite = dataWrite;
            this.dayArray = new ModelToWrite[30];

            dayArray[0] = new ModelToWrite();


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
                    this.dayArray[day - 1] = new ModelToWrite();
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
                this.view.txtDay.Text = this.dataWrite.day;
                this.view.txtMean.Text = this.dataWrite.listMean[lBox.SelectedIndex];
                this.view.txtRealtedTo.Text = this.dataWrite.listRelatedTo[lBox.SelectedIndex];
                this.view.txtRelation.Text = this.dataWrite.listRelation[lBox.SelectedIndex];
                this.view.txtWordType.Text = this.dataWrite.listWordType[lBox.SelectedIndex];
                this.view.txtWord.Text = this.dataWrite.listWord[lBox.SelectedIndex];
                this.view.txtExample.Text = this.dataWrite.listExample[lBox.SelectedIndex];
            }
            catch (Exception exxxx)
            {

            }
        }

        public ModelToWrite GetData
        {            
            get { return dataWrite;}
        }

        public ModelToWrite[] GetDays
        {
            get { return dayArray; }
        }

        public void scatterToDayArray(string fileName)
        {
            Console.WriteLine(fileName);
            String strDay = fileName.Substring(3, 2);
            int day = int.Parse(strDay);
            this.dataWrite = this.dayArray[day - 1];
            this.dataWrite.day = strDay;
            //this.view.txtDay.Text = this.dataWrite.day;
            if (true)
            {

                StreamReader fIn = new StreamReader(getVocabFolderAddr() + fileName);
                String temp;
                while (!fIn.EndOfStream)
                {
                    fIn.ReadLine(); // get rid of index
                    temp = fIn.ReadLine();
                    this.dataWrite.listWord.Add(temp);
                    //this.view.listWords.Items.Add(temp);
                    //this.autoScrollListBox(this.view.listWords);

                    temp = fIn.ReadLine();
                    this.dataWrite.listWordType.Add(temp);

                    temp = fIn.ReadLine();
                    this.dataWrite.listMean.Add(temp);
                    temp = fIn.ReadLine();
                    this.dataWrite.listRelation.Add(temp);
                    temp = fIn.ReadLine();
                    this.dataWrite.listRelatedTo.Add(temp);
                    temp = fIn.ReadLine();
                    this.dataWrite.listExample.Add(temp);
                }
                fIn.Close();
            }
        }

        public void scatterToListWords(object sender, EventArgs e)
        {
            String strDay = this.view.listDays.SelectedItem.ToString().Substring(3, 2);
            int day = int.Parse(strDay);
            this.dataWrite = this.dayArray[day - 1];
            this.view.txtDay.Text = this.dataWrite.day;
            Console.WriteLine(this.dataWrite.listWord.Count);
            this.view.listWords.Items.Clear();
            for (int i = 0; i < this.dataWrite.listWord.Count; i++)
            {
                this.view.listWords.Items.Add(this.dataWrite.listWord.ElementAt(i));
                this.autoScrollListBox(this.view.listWords);
            }
        }


        public void addToList()
        {
            // before add, need to check if the focus in on the right array element
            
            int day = int.Parse(this.view.txtDay.Text);
            bool newDay = false;

            if (this.dataWrite == null)
            {
                // there's one already
                if (this.dayArray[day - 1] != null)
                {
                    this.dataWrite = this.dayArray[day - 1];
                }
                else // there's no one yet
                {
                    this.dayArray[day - 1] = new ModelToWrite();
                    this.dataWrite = this.dayArray[day - 1];
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
                if (int.Parse(this.dataWrite.day) != day)
                {
                    // there's one already
                    if (this.dayArray[day - 1] != null)
                    {
                        this.dataWrite = this.dayArray[day - 1];
                    }
                    else // there's no one yet
                    {
                        this.dayArray[day - 1] = new ModelToWrite();
                        this.dataWrite = this.dayArray[day - 1];
                        Console.WriteLine("asdkfjalsdjfaldf");
                        newDay = true;
                    }
                }
            }

            if (this.checkConventionForAdd())
            {
                // add the data to model
                this.dataWrite.day = this.view.txtDay.Text;
                this.dataWrite.listWord.Add(this.view.txtWord.Text);
                this.dataWrite.listWordType.Add(this.view.txtWordType.Text);
                this.dataWrite.listMean.Add(this.view.txtMean.Text);
                this.dataWrite.listRelation.Add(this.view.txtRelation.Text);
                this.dataWrite.listRelatedTo.Add(this.view.txtRealtedTo.Text);
                this.dataWrite.listExample.Add(this.view.txtExample.Text);

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
            else if (this.dataWrite.day == null)
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

        private void writeFile(String fileName)
        {
            // create a file
            StreamWriter fout = new StreamWriter(fileName);

            // write the file
            for (int i = 0; i < this.dataWrite.listWord.Count; i++)
            {
                fout.WriteLine(i.ToString());
                fout.WriteLine(this.dataWrite.listWord[i]);
                fout.WriteLine(this.dataWrite.listWordType[i]);
                fout.WriteLine(this.dataWrite.listMean[i]);
                fout.WriteLine(this.dataWrite.listRelation[i]);
                fout.WriteLine(this.dataWrite.listRelatedTo[i]);
                fout.WriteLine(this.dataWrite.listExample[i]);
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
