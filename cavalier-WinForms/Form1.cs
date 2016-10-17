/*
Autor: Maude Issolah
Date: 12.05.2016
State: ETML Lausanne
Summary: Chess Knight game
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Security.AccessControl;

namespace cavalier_WinForms
{
    public partial class Form1 : Form
    {
        const int chessboardSize = 8; // Configure the chessboard size
        const int BTN_SIZE = 50; // Size of the buttons
        int btn_xPos = 0;
        int btn_yPos = 0;
        int xPosNumberPanel = -10;
        int yPosNumberPanel = 35;
        int nbButtonClicked = 0;
        int btnName;
        int position;
        int nbScores = 0;
        Button[,] chessButton = new Button[8, 8];
        int[] btnClicked = new int[64];
        int[] btnHelp = new int[8];
        string[] tmp = new string[2];
        string userName = "";
        string[] scoresInFile = new string[5];
        string[,] highScores = new string[5, 2];
        string[,] cloneHScores = new string[5, 2];
        string[] tempArray = new string[2];
        bool endGame = true;
        bool isBest;
        const string RULES = "Règles du jeu:\n\nCliquez sur une case, puis déplacez \nvotre cavalier selon les règles du jeu d'échec.\n\nLe but est d'atteindre un maximum \nde cases.";
        string gamePath = Application.StartupPath;

        public Form1()
        {
            InitializeComponent();
            printChessboard(chessboardSize);
            printColorCB(chessboardSize);
            imgGameOver.Visible = false;
            lblAskName.Text = "";
            tbAskName.Visible = false;
            lblRules.Text = RULES;
            lblPoints.Text = "";
            createHscoreArray();
            printHscores(highScores);

        }

        /// <summary>
        /// Clicked button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clicked(object sender, EventArgs e)
        {
            //lblRules.Text = "";
            Button btn = sender as Button;
            btnName = Convert.ToInt32(btn.Name);
            btnClicked[nbButtonClicked] = btnName;
            nbButtonClicked += 1;
            disableButton();

            // Help button array
            btnHelp[0] = btnName - 21;
            btnHelp[1] = btnName - 19;
            btnHelp[2] = btnName - 12;
            btnHelp[3] = btnName - 8;
            btnHelp[4] = btnName + 8;
            btnHelp[5] = btnName + 12;
            btnHelp[6] = btnName + 19;
            btnHelp[7] = btnName + 21;

            // Reset the color
            printColorCB(chessboardSize);
            colorButton(btnClicked);
            btn.BackgroundImage = ((System.Drawing.Image)(cavalier_WinForms.Properties.Resources.cavalier));

            endGame = true;
            // Check if help buttons are in chessboard and weren't clicked
            foreach (int helpButton in btnHelp)
            {
                int isValid = checkIfIsInArray(btnClicked, helpButton);
                if (isValid == 0)
                {
                    // Active button and change color
                    foreach (Button buttonToEnable in chessButton)
                    {
                        if (helpButton == Convert.ToInt32(buttonToEnable.Name))
                        {
                            buttonToEnable.Enabled = true;
                            buttonToEnable.BackColor = Color.Red;
                            endGame = false;
                        }
                    }
                }
            }

            if (endGame) { endTheGame(nbButtonClicked); }
        }

        /// <summary>
        /// Check if a value is in an array
        /// </summary>
        /// <param name="array">the array to check in</param>
        /// <param name="value">the value</param>
        /// <returns></returns>
        private int checkIfIsInArray(int[] array, int value)
        {
            //if (value == 0) { value = 1; }
            foreach (int isInArray in array)
            {
                if (value == isInArray)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Method to create a button
        /// </summary>
        /// <param name="x">x position of the button</param>
        /// <param name="y">y position of the button</param>
        /// <param name="nbObjet">Number of objects created</param>
        private void createButton(int x, int y, int name, int color)
        {
            Button btn = new Button();
            btn.Size = new Size(BTN_SIZE, BTN_SIZE);
            pnl_game.Controls.Add(btn);
            btn.Location = new Point(x, y);
            if (color == 0)
            {
                btn.BackColor = Color.White;
            }
            if (color == 1)
            {
                btn.BackColor = Color.Black;
            }

            btn.Name = Convert.ToString(name);
            btn.Text = Convert.ToString(name);
            btn.Click += new EventHandler(btn_clicked);
            pnl_game.Controls.Add(btn);
        }

        /// <summary>
        /// Method to create label
        /// </summary>
        /// <param name="x">position X</param>
        /// <param name="y">position Y</param>
        /// <param name="text"></param>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        private void createLabel(int x, int y, string text, int sizeX, int sizeY, bool score)
        {
            Label lbl = new Label();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(sizeX, sizeY);
            lbl.ForeColor = Color.DarkSlateGray;
            lbl.Text = text;
            lbl.Font = new Font("Comic Sans MS", 12);
            if (score)
            {
                lbl.ForeColor = Color.Indigo;
                lbl.BackColor = Color.Thistle;
                lbl.Font = new Font("Comic Sans MS", 12);
                pnlScores.Controls.Add(lbl);
            }
            else
            {
                Controls.Add(lbl);
            }
        }

        /// <summary>
        /// Create and print the chessboard
        /// </summary>
        /// <param name="chesboardSize">size of the chessboard</param>
        private void printChessboard(int chesboardSize)
        {
            // Label to print chesboard letters
            label1.Text = "A       B        C        D        E        F        G       H";
            for (int i = 0; i < chesboardSize; i++)
            {
                // Create labels with the chessboard  side numbers
                createLabel(xPosNumberPanel, yPosNumberPanel, Convert.ToString(i), BTN_SIZE, BTN_SIZE, false);
                yPosNumberPanel += 50;
                btn_xPos = 0;

                for (int j = 0; j < chesboardSize; j++)
                {
                    chessButton[i, j] = new Button();
                    ((Button)chessButton[i, j]).Name = "" + (i + 1) + j; // i+1 to avoid problem with button 00
                    ((Button)chessButton[i, j]).Size = new Size(BTN_SIZE, BTN_SIZE);
                    ((Button)chessButton[i, j]).Location = new Point(btn_xPos, btn_yPos);
                    ((Button)chessButton[i, j]).Click += new EventHandler(btn_clicked);
                    pnl_game.Controls.Add((Button)chessButton[i, j]);
                    btn_xPos += BTN_SIZE;
                }
                btn_yPos += BTN_SIZE;
            }
        }

        /// <summary>
        /// Change the chessboard color to black/white
        /// </summary>
        /// <param name="chesboardSize"></param>
        private void printColorCB(int chesboardSize)
        {
            for (int i = 0; i < chesboardSize; i++)
            {
                for (int j = 0; j < chesboardSize; j++)
                {
                    ((Button)chessButton[i, j]).BackgroundImage = null;
                    if (j % 2 == 0 && i % 2 == 0 || j % 2 == 1 && i % 2 == 1)
                    {
                        ((Button)chessButton[i, j]).BackColor = Color.White;
                    }
                    else
                    {
                        ((Button)chessButton[i, j]).BackColor = Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Color choosen button
        /// </summary>
        /// <param name="buttonArray"></param>
        private void colorButton(int[] buttonUsed)
        {
            foreach (Button colorButton in chessButton)
            {
                for (int i = 0; i < nbButtonClicked; i++)
                {
                    if (buttonUsed[i] == Convert.ToInt32(colorButton.Name))
                    {
                        colorButton.BackgroundImage = ((System.Drawing.Image)(cavalier_WinForms.Properties.Resources.stars));
                        colorButton.BackgroundImageLayout = ImageLayout.Center;
                    }
                }
            }

        }

        /// <summary>
        /// Begin a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_play_Click(object sender, EventArgs e)
        {
            lblRules.Text = RULES;
            Array.Clear(btnHelp, 0, btnHelp.Length);
            Array.Clear(btnClicked, 0, btnClicked.Length);
            nbButtonClicked = 0;
            printColorCB(chessboardSize);
            foreach (Button buttonDisabled in chessButton) //Disables all buttons
            {
                buttonDisabled.Enabled = true;
            }
            imgGameOver.Visible = false;
            lblPoints.Text = "";
        }

        /// <summary>
        /// End game
        /// </summary>
        /// <param name="nbButtonClicked"></param>
        private void endTheGame(int nbButtonClicked)
        {
            lblRules.Text = ""; // Not show the rules
            disableButton();

            if (nbButtonClicked == 64)
            {
                lblPoints.Text = " Bravo !! Vous avez gagné !";
            }
            else
            {
                imgGameOver.Visible = true;
                lblPoints.Text = "Vous avez " + nbButtonClicked + " points";
            }

            /*
               ### HIGHSCORE ###
            */

            // Read scores file if exist
            if (File.Exists(gamePath + "\\scores.txt"))
            {
                // Find the position of the new score, if in top5
                isBest = false;
                for (int i = nbScores-1; i >= 0; i--)
                {
                    if (nbButtonClicked > Convert.ToInt32(highScores[i, 1]))
                    {
                        isBest = true;
                        position = i;
                    }
                }

                // Add new highscore
                if (isBest || nbScores < 5) // Score is in top5 -> ask for player's name
                {
                    askName();
                }
            }
            else // If scores file dosen't exist, ask for player's name
            {
                askName();
            }
        }

        /// <summary>
        /// To disable all buttons
        /// </summary>
        private void disableButton()
        {
            foreach (Button buttonDisabled in chessButton) //Disables all buttons
            {
                buttonDisabled.Enabled = false;
            }
        }

        /// <summary>
        /// To print highscores in a text file
        /// </summary>
        /// <param name="array"></param>
        private void printInFile(string[,] array)
        {
            StreamWriter file = new StreamWriter(Path.Combine(gamePath, "scores.txt")); // To save score in "scores.txt" file

            int index = (nbScores == 5) ? 5 : nbScores + 1;
            for (int i = 0; i < index; i++)
            {
                file.WriteLine(array[i, 0] + " " + array[i, 1]);
            }
            file.Close();
        }

        /// <summary>
        /// Ceate label and textBox to print highscores
        /// </summary>
        /// <param name="scoreArray"></param>
        private void printHscores(string[,] scoreArray)
        {
            createHscoreArray();
            int y = 0;
            // Ceate label in panel to print highscore
            for (int i = 0; i < highScores.Length/2; i++)
            {
                createLabel(25, y, highScores[i, 0], 70, 25, true);
                createLabel(105, y, highScores[i, 1], 40, 25, true);
                y += 30;
            }
        }

        /// <summary>
        /// Create an array with highScores from file
        /// </summary>
        private void createHscoreArray()
        {
            if (File.Exists(gamePath + "\\scores.txt")) // Create array only if file exist
            {
                // Read each line of the file into a string array. Each element of the array is one line of the file.
                scoresInFile = File.ReadAllLines(Path.Combine(gamePath, "scores.txt"));
                nbScores = scoresInFile.Count(s => s != null); // number of non null element in the array = number of scores

                // Put scores from file in a two dimention array highScores
                for (int i = nbScores - 1; i >= 0; i--)
                {
                    string line = scoresInFile[i];
                    string[] words = line.Split(' ');

                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0) // Player's name
                        {
                            highScores[i, 0] = words[0];
                        }
                        else if (j == 1) // Score
                        {
                            highScores[i, 1] = words[1];
                        }
                    }
                }
            }
            else
            {
                nbScores = 0;
            }
        }

        /// <summary>
        /// Ask for player's name
        /// </summary>
        private void askName()
        {
            lblAskName.Text = "Votre nom?";
            tbAskName.Text = "";
            tbAskName.Visible = true;
        }

        /// <summary>
        /// When enter pressed, store the user name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAskName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userName = tbAskName.Text;
                lblAskName.Text = "";
                tbAskName.Visible = false;
                afterKeyDown(); //method to continue the code after enter pressed
            }
        }

        /// <summary>
        /// Add new best score in top5
        /// </summary>
        private void afterKeyDown()
        {
            // Add new highscore
            if (File.Exists(gamePath + "\\scores.txt"))
            {
                if (isBest) // Score is in top5 -> add it inside the array
                {
                    // Clone the highScores array
                    cloneHScores = highScores.Clone() as string[,];

                    int index = (scoresInFile.Length == 5) ? 5 : scoresInFile.Length + 1;
                    for (int i = position + 1; i < index; i++)
                    {
                        highScores[i, 0] = cloneHScores[i - 1, 0];
                        highScores[i, 1] = cloneHScores[i - 1, 1];
                    }

                    highScores[position, 0] = userName;
                    highScores[position, 1] = Convert.ToString(nbButtonClicked);


                }
                else if (scoresInFile.Length < 5) // Score isn't in the actuals best score -> put in the end
                {
                    highScores[scoresInFile.Length, 0] = userName;
                    highScores[scoresInFile.Length, 1] = Convert.ToString(nbButtonClicked);

                }
                printInFile(highScores);
            }
            else if (!File.Exists(gamePath + "\\scores.txt")) // If scores file dosen't exist create one
            {
                highScores[0, 0] = userName;
                highScores[0, 1] = Convert.ToString(nbButtonClicked);
                printInFile(highScores);
            }
            pnlScores.Controls.Clear();
            printHscores(highScores);
        }

        /// <summary>
        /// Button to erase highscore table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearHS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous effacer le tableau des scores?", "Tableau des scores", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes) // Yes -> so erase HS table, and label
            {
                foreach (Label lbl in pnlScores.Controls) // Erase text in scores labels
                {
                    lbl.Text = "";
                }
                Array.Clear(highScores, 0, highScores.Length);// Clear highscore array
                if (File.Exists(gamePath + "\\scores.txt")) // Erase scores file
                {
                    File.Delete(gamePath + "\\scores.txt");
                }
                nbScores = 0; 
            }
        }
    }
}
/*TODO: 
 
     */
