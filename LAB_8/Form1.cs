using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_8
{
    public partial class Form1 : Form
    {
        string openText;
        string keyWord;
        char[] alphabet = {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                           'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        public Form1()
        {
            InitializeComponent();
        }

        private void CipherButton_Click(object sender, EventArgs e)
        {
            AnswerTB.Text = null;
            openText = OpenTextTB.Text.ToLower();
            keyWord = KeyTB.Text.ToLower();

            List<char> newAlphabet = new List<char>();
            
            for (int i = 0; i < keyWord.Length; i++) 
                newAlphabet.Add(keyWord[i]);

            AnswerTB.Text = "Исходный алфавит:";
            for (int i = 0; i < 33; i++) 
                AnswerTB.Text += alphabet[i];
            AnswerTB.Text += '\n';

            foreach (var a in alphabet)
            {
                if (newAlphabet.Contains(a)) continue;
                else newAlphabet.Add(a);
            }

            AnswerTB.Text += "Новый алфавит:\t ";
            for (int i = 0; i < newAlphabet.Count; i++)
                AnswerTB.Text += newAlphabet[i];
            AnswerTB.Text += '\n';
            
            string cipheredText = "";

            for (int i = 0; i < openText.Length; i++)
            {
                if (openText[i] == ' ')
                {
                    cipheredText += ' ';
                    continue;
                }
                int index = Array.IndexOf(alphabet, openText[i]);
                cipheredText += newAlphabet[index];
            }

            AnswerTB.Text += $"\nЗашифрованное слово >> {cipheredText}";
        }

        private void DecipherButtom_Click(object sender, EventArgs e)
        {
            AnswerTB.Text = null;
            openText = OpenTextTB.Text.ToLower();
            keyWord = KeyTB.Text.ToLower();

            List<char> newAlphabet = new List<char>();

            for (int i = 0; i < keyWord.Length; i++)
                newAlphabet.Add(keyWord[i]);

            AnswerTB.Text = "Исходный алфавит:";
            for (int i = 0; i < 33; i++)
                AnswerTB.Text += alphabet[i];
            AnswerTB.Text += '\n';

            foreach (var a in alphabet)
            {
                if (newAlphabet.Contains(a)) continue;
                else newAlphabet.Add(a);
            }

            AnswerTB.Text += "Новый алфавит:\t ";
            for (int i = 0; i < newAlphabet.Count; i++)
                AnswerTB.Text += newAlphabet[i];
            AnswerTB.Text += '\n';

            string decipheredText = "";

            for (int i = 0; i < openText.Length; i++)
            {
                if (openText[i] == ' ')
                {
                    decipheredText += ' ';
                    continue;
                }
                int index = Array.IndexOf(newAlphabet.ToArray(), openText[i]);
                MessageBox.Show(index.ToString());
                decipheredText += alphabet[index];
            }

            AnswerTB.Text += $"\nРасшифрованное слово >> {decipheredText}";
        }
    }
}
