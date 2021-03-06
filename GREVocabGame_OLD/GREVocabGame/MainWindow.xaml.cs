﻿using GREVocabGame.Controller;
using GREVocabGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GREVocabGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControllerNewVocab _ControllerNewVocab;
        private ModelToWrite _ModelToWrite;
        private TestController _ControllerTest;
        /** Constructor
         * 
         * 
         */         
        public MainWindow()
        {
            InitializeComponent();
            this._ModelToWrite = new ModelToWrite();
            this._ControllerNewVocab = new ControllerNewVocab(this, _ModelToWrite);
            this._ControllerTest = new TestController(this, _ControllerNewVocab);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerNewVocab.addToList();
        }

        private void enterTyped(object sender, KeyEventArgs e)
        {
            this._ControllerNewVocab.enterTyped(sender, e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerNewVocab.saveList();
        }

        private void btnViewer_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerNewVocab.viewTabFocus();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerNewVocab.testTabFocus();
        }

        private void listDays_DoubleClick(object sender, EventArgs e)
        {
            this._ControllerNewVocab.scatterToListWords(sender, e);
        }

        private void listWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._ControllerNewVocab.scatterToText(sender, e);
        }

        private void listDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerNewVocab.clearAll();
        }

        private void txtMean_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGen_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerTest.generateSession();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerTest.processAnswer();
        }

        private void btnHint_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerTest.showHint();
        }

        private void txtResponse_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this._ControllerTest.processAnswer();
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            this._ControllerTest.getTotalVocabs();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            txtDaySet.Text = (Int32.Parse(txtDaySet.Text) + 1).ToString();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            txtDaySet.Text = (Int32.Parse(txtDaySet.Text) - 1).ToString();
        }
    }
}