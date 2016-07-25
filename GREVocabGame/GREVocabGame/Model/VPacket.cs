﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREVocabGame.Model
{
    class VPacket
    {
        string day, word, wordType, mean, relation, relatedTo, example;
        string processedEx;

        public string Day
        {
            get { return day; }
            set { day = value;}
        }

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public string WordType
        {
            get { return wordType; }
            set { wordType = value; }
        }

        public string Mean
        {
            get { return mean; }
            set { mean = value; }
        }

        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        public string RelatedTO
        {
            get { return relatedTo; }
            set { relatedTo = value; }
        }

        public string Example
        {
            get { return example; }
            set { example = value; }
        }

        public string ProEx
        {
            get { return processedEx;}
        }

        public void processSentence()
        {
            
            List<string> strTokenList = Tokenizer.getTokens(example);
            int index = 0, targetIndex=0;
            foreach (string token in strTokenList)
            {
                if (!token.ToLower().Equals("the"))
                {
                    if (wordType.Equals("n") || wordType.Equals("v"))
                    {
                        if (word.Length > 3)
                        {
                            try
                            {
                                if (token.Length > 3)
                                {
                                    if (token.Substring(0, 4).Contains(word.Substring(0, 4)))
                                    {
                                        targetIndex = index;
                                        Console.WriteLine("target index: " + index.ToString());
                                    }
                                }

                            }
                            catch (Exception easdf)
                            {
                                Console.WriteLine("exception at: " + token);
                            }

                        }
                        else
                        {
                            processedEx = "hard noun and verb..";
                            return;
                        }
                    }
                    else
                    {
                        if (token.Contains(word))
                        {
                            targetIndex = index;
                        }
                    }
                }
                

                index++;
            }

            processedEx = "";
            for(int i=0; i<strTokenList.Count; i++)
            {
                if (i==targetIndex)
                {
                    processedEx +=  " _____ ";
                }
                else
                {
                    processedEx += " " + strTokenList[i];
                }
            }

        }







    }
}
