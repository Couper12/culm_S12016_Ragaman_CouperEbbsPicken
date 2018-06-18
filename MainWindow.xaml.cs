/* 
 * Couper EbbsPicken
 * 6/18/2018
 * Does a problem
 */ 
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
using System.IO;

namespace cul_S1Ragaman_CouperEbbsPicken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global variables
        StreamReader streamReader = new StreamReader("Input.txt");
        string input1;
        string input2;
        string allLetters = "abcdefghijklmnopqrstuvwxyz";
        string word1;
        string word2;
        int asterixCounter;
        bool output;
        int letterCounter;
        int wrongCounter;
        int counter1;
        int counter2;
        bool letterAmount;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            // getting first two lines of input
            while (!streamReader.EndOfStream)
            {
                input1 = streamReader.ReadLine();
                input2 = streamReader.ReadLine();
            }

            // resets variables
            output = true;
            word1 = input1;
            word2 = input2;
            asterixCounter = 0;

            // deltes the letters in the first word from the alphabet
            for (int i = 0; i < allLetters.Length; i++)
            {
                
                if (word1.Contains(allLetters[i]))
                {
                    allLetters = allLetters.Remove(i, 1);
                    i--;
                }
            }

            // counts how many asterixs are in the anagram
            for (int i = 0; i < word2.Length; i++)
            {
                if (word2[i] == '*')
                {
                    asterixCounter++;
                }
            }

            // checks how many letters don't work
            for (int i = 0; i < allLetters.Length; i++)
            {
                if (word2.Contains(allLetters[i]))
                {
                    letterCounter++;
                }

                if (letterCounter > asterixCounter)
                {
                    output = false;
                    lblOutput.Content = "N";
                }
            }

            // runs through the words to see if they work together
            if (output != false)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    wrongCounter = 0;
                    counter1 = 0;
                    counter2 = 0;

                    foreach (char c in word2)
                    {
                        if (c == word1[i])
                        {
                            counter2++;
                        }

                        if (!word1.Contains(c))
                        {
                            wrongCounter++;
                        }
                    }

                    foreach (char c in word1)
                    {
                        if (c == word1[i])
                        {
                            counter1++;
                        }
                    }

                    if (counter2 <= counter1
                        && wrongCounter <= asterixCounter)
                    {
                        letterAmount = true;
                    }

                    else
                    {
                        output = false;
                        lblOutput.Content = "N";
                    }
                }

                // final criteria check
                if (output != false
                    && letterAmount == true)
                {
                    output = true;
                    lblOutput.Content = "A";
                }
            }


        }
    }
}
