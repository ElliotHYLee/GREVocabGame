using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREVocabGame.Model
{
    class ModelToWrite
    {
        private String _day;
        private List<String> _listWord;
        private List<String> _listWordType;
        private List<String> _listMean;
        private List<String> _listRelation;
        private List<String> _listRealtedTo;
        private List<String> _listExample;

        public ModelToWrite()
        {
            this._day = "";
            this._listWord = new List<String>();
            this._listWordType = new List<String>();
            this._listMean = new List<String>();
            this._listRelation = new List<String>();
            this._listRealtedTo = new List<String>();
            this._listExample = new List<String>();
        }

        public String day
        {
            set { this._day = value; }
            get { return this._day; }
        }

        public List<String> listWord
        {
            set { this._listWord = value; }
            get { return this._listWord; }
        }

        public List<String> listWordType
        {
            set { this._listWordType = value; }
            get { return this._listWordType; }
        }
        
        public List<String> listMean
        {
            set { this._listMean = value; }
            get { return this._listMean; }
        }

        public List<String> listRelation
        {
            set { this._listRelation = value; }
            get { return this._listRelation; }
        }

        public List<String> listRealtedTo
        {
            set { this._listRealtedTo = value; }
            get { return this._listRealtedTo; }
        }

        public List<String> listExample 
        {
            set { this._listExample = value; }
            get { return this._listExample; }
        } 
    }
}
