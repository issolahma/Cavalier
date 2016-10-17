namespace cavalier_WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_game = new System.Windows.Forms.Panel();
            this.imgGameOver = new System.Windows.Forms.PictureBox();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.btn_play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.tbAskName = new System.Windows.Forms.TextBox();
            this.lblAskName = new System.Windows.Forms.Label();
            this.pnlScores = new System.Windows.Forms.Panel();
            this.btnClearHS = new System.Windows.Forms.Button();
            this.pnl_game.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_game
            // 
            this.pnl_game.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_game.Controls.Add(this.imgGameOver);
            this.pnl_game.Location = new System.Drawing.Point(31, 35);
            this.pnl_game.Name = "pnl_game";
            this.pnl_game.Size = new System.Drawing.Size(402, 402);
            this.pnl_game.TabIndex = 0;
            // 
            // imgGameOver
            // 
            this.imgGameOver.BackColor = System.Drawing.Color.Crimson;
            this.imgGameOver.Image = global::cavalier_WinForms.Properties.Resources.gameover;
            this.imgGameOver.Location = new System.Drawing.Point(83, 113);
            this.imgGameOver.Name = "imgGameOver";
            this.imgGameOver.Size = new System.Drawing.Size(234, 133);
            this.imgGameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgGameOver.TabIndex = 5;
            this.imgGameOver.TabStop = false;
            // 
            // lblScoreTitle
            // 
            this.lblScoreTitle.AutoSize = true;
            this.lblScoreTitle.BackColor = System.Drawing.Color.Ivory;
            this.lblScoreTitle.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTitle.ForeColor = System.Drawing.Color.Indigo;
            this.lblScoreTitle.Location = new System.Drawing.Point(536, -4);
            this.lblScoreTitle.Name = "lblScoreTitle";
            this.lblScoreTitle.Size = new System.Drawing.Size(73, 26);
            this.lblScoreTitle.TabIndex = 17;
            this.lblScoreTitle.Text = "Scores";
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.Ivory;
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_play.BackgroundImage")));
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_play.Location = new System.Drawing.Point(453, 377);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(65, 60);
            this.btn_play.TabIndex = 1;
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPoints.Location = new System.Drawing.Point(487, 241);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(180, 26);
            this.lblPoints.TabIndex = 4;
            this.lblPoints.Text = "vous avez 12 points";
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.BackColor = System.Drawing.Color.LightYellow;
            this.lblRules.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblRules.Location = new System.Drawing.Point(439, 189);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(51, 20);
            this.lblRules.TabIndex = 6;
            this.lblRules.Text = "label4";
            // 
            // tbAskName
            // 
            this.tbAskName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAskName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tbAskName.Location = new System.Drawing.Point(579, 281);
            this.tbAskName.MaxLength = 7;
            this.tbAskName.Name = "tbAskName";
            this.tbAskName.Size = new System.Drawing.Size(65, 26);
            this.tbAskName.TabIndex = 18;
            this.tbAskName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAskName_KeyDown);
            // 
            // lblAskName
            // 
            this.lblAskName.AutoSize = true;
            this.lblAskName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAskName.Location = new System.Drawing.Point(498, 283);
            this.lblAskName.Name = "lblAskName";
            this.lblAskName.Size = new System.Drawing.Size(75, 18);
            this.lblAskName.TabIndex = 19;
            this.lblAskName.Text = "Votre nom?";
            // 
            // pnlScores
            // 
            this.pnlScores.Location = new System.Drawing.Point(483, 25);
            this.pnlScores.Name = "pnlScores";
            this.pnlScores.Size = new System.Drawing.Size(200, 161);
            this.pnlScores.TabIndex = 20;
            // 
            // btnClearHS
            // 
            this.btnClearHS.BackColor = System.Drawing.Color.Red;
            this.btnClearHS.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearHS.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnClearHS.Location = new System.Drawing.Point(703, 411);
            this.btnClearHS.Name = "btnClearHS";
            this.btnClearHS.Size = new System.Drawing.Size(52, 26);
            this.btnClearHS.TabIndex = 21;
            this.btnClearHS.Text = "Clear";
            this.btnClearHS.UseVisualStyleBackColor = false;
            this.btnClearHS.Click += new System.EventHandler(this.btnClearHS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(767, 453);
            this.Controls.Add(this.btnClearHS);
            this.Controls.Add(this.pnlScores);
            this.Controls.Add(this.lblAskName);
            this.Controls.Add(this.tbAskName);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.lblScoreTitle);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.pnl_game);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Jeu du cavalier";
            this.pnl_game.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgGameOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_game;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.PictureBox imgGameOver;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.Label lblScoreTitle;
        private System.Windows.Forms.TextBox tbAskName;
        private System.Windows.Forms.Label lblAskName;
        private System.Windows.Forms.Panel pnlScores;
        private System.Windows.Forms.Button btnClearHS;
    }
}

