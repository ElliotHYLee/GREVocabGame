using GREVocabGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GREVocabGame.Controller
{
    class TestController
    {

        ModelToWrite _data;
        MainWindow _view;
        ControllerNewVocab _con;
        List<VPacket> _listPacket;
        List<bool> _listResult;
        List<RadioButton> _listRB;
        int currentQuestionNumber = 0;
        int maxIteration;
        double score=0;
        int hintLevel = 0;
        int trapAnswer, trapResponse;
        int[] listWordIndex;
        int sec, min;
        DispatcherTimer dispatcherTimer;

        public TestController(MainWindow view, ControllerNewVocab tCon)
        {
            _view = view;
            _con = tCon;
            _listPacket = new List<VPacket>();
            _listResult = new List<bool>();
            resetRadio();
        }

        public void resetRadio()
        {
            _listRB = new List<RadioButton>();
            _listRB.Add(_view.opBox1);
            _listRB.Add(_view.opBox2);
            _listRB.Add(_view.opBox3);
            _listRB.Add(_view.opBox4);
            _listRB.Add(_view.opBox5);
            _listRB.Add(_view.opBox6);
        }

        public void generateSession()
        {
            if (prepData())
            {
                _view.lstResult.Items.Clear();
                _listPacket = new List<VPacket>();
                _listResult = new List<bool>();
                resetRadio();

                trapAnswer = 0;
                currentQuestionNumber = 0;
                chooseNRandom();
                displayQuestion();
                
            }
            _view.btnSubmit.IsEnabled = true;
            sec = 0;
            min = 0;
            score = 0;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            int targetTime = Int32.Parse(_view.txtNumQu.Text) * 6;
            int targetMin = targetTime / 60;
            int targetSec = targetTime % 60;
            _view.lblTimeTarget.Content = targetMin.ToString() + ":" + targetSec.ToString();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (sec>=60)
            {
                min++;
                sec = 0;
            }
            String time;
            if (min >= 10) time = min.ToString() + ":";
            else time = "0" + min.ToString() + ":";
            if (sec >= 10) time = time + sec.ToString();
            else time = time + "0" + sec.ToString();
            _view.lblTime.Content = time;
            sec++;
        }

        public void makeTrap()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 6);
            trapAnswer = randomNumber;
            string[] traps = { "", "" ,"", "", "", ""};
            for (int i = 0; i <6; i++)
            {
                randomNumber = random.Next(0, _data.listExample.Count - 1);
                while (listWordIndex.Contains(randomNumber))
                {
                    randomNumber = random.Next(0, _data.listExample.Count - 1);
                }
                VPacket tempVPacket = new VPacket();
                tempVPacket.Word = _data.listWord[randomNumber];
                tempVPacket.RelatedTO = _data.listRelatedTo[randomNumber];
                randomNumber = random.Next(0, 10);
                if (randomNumber > 5) traps[i] = tempVPacket.RelatedTO;
                else traps[i] = tempVPacket.Word;

            }
            int trapIndex=0;
            for (int i = 0; i < 6; i++)
            {
                if (i == trapAnswer) _listRB[i].Content = _listPacket[currentQuestionNumber].Word;
                else
                {
                    _listRB[i].Content = traps[trapIndex];
                    trapIndex++;
                }
            }
        }

        public void displayQuestion()
        {
            hintLevel = 0;
            for (int i = 0; i < _listRB.Count; i++)
            {
                _listRB[i].IsChecked = false;
            }
            _listPacket[currentQuestionNumber].processSentence();
            _view.txtSentence.Text = _listPacket[currentQuestionNumber].ProEx;
            //_view.txtResponse.Text = _listPacket[currentQuestionNumber].Word;
            _view.txtHint.Text = "";
            _view.txtScore.Text = "";
            _view.lblNumber.Content = "Q." + (currentQuestionNumber+1).ToString();
            makeTrap();
            showHint();
        }

        public void chooseNRandom()
        {
            Random random = new Random();
            int randomNumber;
            List<int> listRand = new List<int>();
            if (_view.txtNumQu.Text == "")
            {
                MessageBox.Show("Check numbers");
                return;
            }
            else
            {
                maxIteration = Int32.Parse(_view.txtNumQu.Text);
                listWordIndex = new int[maxIteration];
                VPacket vp;
                for (int i = 0; i < maxIteration; i++)
                {
                    vp = new VPacket();
                    randomNumber = random.Next(0, _data.listExample.Count - 1);
                    while (listRand.Contains(randomNumber))
                    {
                        randomNumber = random.Next(0, _data.listExample.Count - 1);
                    }
                    listRand.Add(randomNumber);
                    listWordIndex[i] = randomNumber;
                    vp.Day = _data.day;
                    vp.Word = _data.listWord[randomNumber];
                    Console.WriteLine(vp.Word);
                    vp.WordType = _data.listWordType[randomNumber];
                    vp.Example = _data.listExample[randomNumber];
                    vp.Mean = _data.listMean[randomNumber];
                    vp.RelatedTO = _data.listRelatedTo[randomNumber];
                    vp.Relation = _data.listRelation[randomNumber];
                    _listPacket.Add(vp);
                }
            }


            
            

        }

        public bool prepData()
        {
            bool isReady = true;
            string fName = detFileName();
            if (fName.Equals("Day")) isReady = false;
            else _data = scatterToDayArray(fName);
            return isReady;
        }

        public string detFileName()
        {
            string fName = "Day";
            if (_view.txtDaySet.Text == "")
            {
                MessageBox.Show("Type day");
            }
            else
            {
                string day = _view.txtDaySet.Text;
                if (day.Length < 2) day = "0" + day;
                fName = fName + day + ".txt";
            }
            return fName;
        }

        public ModelToWrite scatterToDayArray(string fileName)
        {
            ModelToWrite tempData;
            Console.WriteLine(fileName);
            String strDay = fileName.Substring(3, 2);
            int day = int.Parse(strDay);
            tempData = _con.GetDays[day - 1];
            return tempData;
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

        public void processAnswer()
        {
            

            string response = _view.txtResponse.Text;
            string ans = _listPacket[currentQuestionNumber].Word;

            for(int i=0; i< _listRB.Count; i++)
            {
                if (_listRB[i].IsChecked == true)
                {
                    trapResponse = i;
                    break;
                }
                else trapResponse = -1;
            }

            if (ans.Equals(response) || trapResponse==trapAnswer)
            {
                score++;
                _listResult.Add(true);
            }
            else _listResult.Add(false);

            if (currentQuestionNumber == (maxIteration-1))
            {
                score = score/maxIteration*100;
                _view.txtScore.Text = score.ToString();
                showFinalResult();
            }
            else
            {
                hintLevel = 0;
                currentQuestionNumber++;
                displayQuestion();
            }
        }

        public void showFinalResult()
        {
            _view.btnSubmit.IsEnabled = false;
            dispatcherTimer.Stop();
            string tempResult;
            for(int i = 0; i<_listPacket.Count;  i++)
            {
                tempResult = _listPacket[i].Word;
                if (_listResult[i])
                {
                    tempResult = "Correct:     " + tempResult;
                }
                else
                {
                    tempResult = "Incorrect:   " + tempResult;                         
                }
                _view.lstResult.Items.Add(tempResult);
            }
        }

        public void showHint()
        {
            if (hintLevel==0)
            {
                _view.txtHint.Text = "Hint1-> "+_listPacket[currentQuestionNumber].Mean;
                hintLevel++;
            }
            else
            {
                _view.txtHint.Text += "\nHint2-> ";
                _view.txtHint.Text += _listPacket[currentQuestionNumber].Relation
                                    + ": "
                                    + _listPacket[currentQuestionNumber].RelatedTO;
                hintLevel++;
            }

            
        }

    }
}
