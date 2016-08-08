using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GREVocabGame.Model
{
    class DayPacket
    {
        VPacket vocab;
        List<VPacket> vocabList;
        List<VPacket> focusedVocabList;
        string day;

        public DayPacket()
        {
            vocabList = new List<VPacket>();
        }

        public int Count
        {
            get { return vocabList.Count; }
        }


        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        public void newVPacket()
        {
            vocab = new VPacket();
            vocab.Day = day;
        }

        public void addWord(string word)
        {
            vocab.Word = word;
        }

        public void addWordType(string wordType)
        {
            vocab.WordType = wordType;
        }

        public void addMean(string mean)
        {
            vocab.Mean = mean;
        }

        public void addRelation(string relation)
        {
            vocab.Relation = relation;
        }

        public void addRelatedTo(string relatedTo)
        {
            vocab.RelatedTO = relatedTo;
        }

        public void addExample(string ex)
        {
            vocab.Example = ex;
        }

        public void addFocus(bool isFocused)
        {
            vocab.Focus = isFocused;
        }


        public void insertVPacket()
        {
            vocabList.Add(vocab);
        }

        public VPacket at(int index)
        {
            return vocabList[index];
        }

        public void deleteAt()
        {
            MessageBox.Show("Not implemented");
        }

        

        public List<VPacket> FocusedVocabList
        {
            get
            {
                focusedVocabList = new List<VPacket>();
                foreach(VPacket vocab in vocabList)
                {
                    if (vocab.Focus) focusedVocabList.Add(vocab);
                }

                shuffle(focusedVocabList);

                return focusedVocabList;
            }
        }

        public void shuffle(List<VPacket> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                VPacket value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
