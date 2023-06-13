namespace PokemonCardScraper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            windowToolStripMenuItem = new ToolStripMenuItem();
            twitterPanelToolStripMenuItem = new ToolStripMenuItem();
            newsToolStripMenuItem = new ToolStripMenuItem();
            deckBuilderToolStripMenuItem = new ToolStripMenuItem();
            myDecksToolStripMenuItem = new ToolStripMenuItem();
            addToDBBtn = new Button();
            cardImageHolder = new PictureBox();
            panel3 = new Panel();
            moveEffectLabel3 = new RichTextBox();
            moveEffectLabel2 = new RichTextBox();
            moveEffectLabel1 = new RichTextBox();
            move2label = new Label();
            move3label = new Label();
            move1Label = new Label();
            deckToolStripMenuItem = new ToolStripMenuItem();
            cardSearcherToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            cardSetCBLabel = new Label();
            LoadPanel = new Panel();
            CardSetLoaderCB = new ComboBox();
            allCardsCB = new ComboBox();
            cardSearchBox = new TextBox();
            panel2 = new Panel();
            searchResultsBox = new ComboBox();
            searchPanel = new Panel();
            mainPanel = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)cardImageHolder).BeginInit();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            LoadPanel.SuspendLayout();
            panel2.SuspendLayout();
            searchPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { twitterPanelToolStripMenuItem });
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(63, 20);
            windowToolStripMenuItem.Text = "Window";
            // 
            // twitterPanelToolStripMenuItem
            // 
            twitterPanelToolStripMenuItem.Name = "twitterPanelToolStripMenuItem";
            twitterPanelToolStripMenuItem.Size = new Size(141, 22);
            twitterPanelToolStripMenuItem.Text = "Twitter Panel";
            // 
            // newsToolStripMenuItem
            // 
            newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            newsToolStripMenuItem.Size = new Size(48, 20);
            newsToolStripMenuItem.Text = "News";
            // 
            // deckBuilderToolStripMenuItem
            // 
            deckBuilderToolStripMenuItem.Name = "deckBuilderToolStripMenuItem";
            deckBuilderToolStripMenuItem.Size = new Size(140, 22);
            deckBuilderToolStripMenuItem.Text = "Deck Builder";
            // 
            // myDecksToolStripMenuItem
            // 
            myDecksToolStripMenuItem.Name = "myDecksToolStripMenuItem";
            myDecksToolStripMenuItem.Size = new Size(140, 22);
            myDecksToolStripMenuItem.Text = "My Decks";
            // 
            // addToDBBtn
            // 
            addToDBBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            addToDBBtn.Location = new Point(346, 121);
            addToDBBtn.Name = "addToDBBtn";
            addToDBBtn.Size = new Size(147, 31);
            addToDBBtn.TabIndex = 8;
            addToDBBtn.Text = "Add to Collection";
            addToDBBtn.UseVisualStyleBackColor = true;
            // 
            // cardImageHolder
            // 
            cardImageHolder.Location = new Point(12, 107);
            cardImageHolder.Name = "cardImageHolder";
            cardImageHolder.Size = new Size(300, 417);
            cardImageHolder.SizeMode = PictureBoxSizeMode.StretchImage;
            cardImageHolder.TabIndex = 7;
            cardImageHolder.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(moveEffectLabel3);
            panel3.Controls.Add(moveEffectLabel2);
            panel3.Controls.Add(moveEffectLabel1);
            panel3.Controls.Add(move2label);
            panel3.Controls.Add(move3label);
            panel3.Controls.Add(move1Label);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(512, 101);
            panel3.Name = "panel3";
            panel3.Size = new Size(586, 407);
            panel3.TabIndex = 6;
            // 
            // moveEffectLabel3
            // 
            moveEffectLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            moveEffectLabel3.Location = new Point(0, 305);
            moveEffectLabel3.Name = "moveEffectLabel3";
            moveEffectLabel3.ReadOnly = true;
            moveEffectLabel3.Size = new Size(534, 50);
            moveEffectLabel3.TabIndex = 11;
            moveEffectLabel3.Text = "";
            // 
            // moveEffectLabel2
            // 
            moveEffectLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            moveEffectLabel2.Location = new Point(3, 170);
            moveEffectLabel2.Name = "moveEffectLabel2";
            moveEffectLabel2.ReadOnly = true;
            moveEffectLabel2.Size = new Size(534, 50);
            moveEffectLabel2.TabIndex = 10;
            moveEffectLabel2.Text = "";
            // 
            // moveEffectLabel1
            // 
            moveEffectLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            moveEffectLabel1.Location = new Point(3, 54);
            moveEffectLabel1.Name = "moveEffectLabel1";
            moveEffectLabel1.ReadOnly = true;
            moveEffectLabel1.Size = new Size(534, 50);
            moveEffectLabel1.TabIndex = 9;
            moveEffectLabel1.Text = "";
            // 
            // move2label
            // 
            move2label.AutoSize = true;
            move2label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            move2label.Location = new Point(0, 122);
            move2label.Name = "move2label";
            move2label.Size = new Size(129, 25);
            move2label.TabIndex = 4;
            move2label.Text = "Move Name 2";
            // 
            // move3label
            // 
            move3label.AutoSize = true;
            move3label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            move3label.Location = new Point(0, 257);
            move3label.Name = "move3label";
            move3label.Size = new Size(129, 25);
            move3label.TabIndex = 5;
            move3label.Text = "Move Name 3";
            // 
            // move1Label
            // 
            move1Label.AutoSize = true;
            move1Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            move1Label.Location = new Point(0, 26);
            move1Label.Name = "move1Label";
            move1Label.Size = new Size(129, 25);
            move1Label.TabIndex = 3;
            move1Label.Text = "Move Name 1";
            // 
            // deckToolStripMenuItem
            // 
            deckToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myDecksToolStripMenuItem, deckBuilderToolStripMenuItem });
            deckToolStripMenuItem.Name = "deckToolStripMenuItem";
            deckToolStripMenuItem.Size = new Size(45, 20);
            deckToolStripMenuItem.Text = "Deck";
            // 
            // cardSearcherToolStripMenuItem
            // 
            cardSearcherToolStripMenuItem.Name = "cardSearcherToolStripMenuItem";
            cardSearcherToolStripMenuItem.Size = new Size(92, 20);
            cardSearcherToolStripMenuItem.Text = "Card Searcher";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cardSearcherToolStripMenuItem, deckToolStripMenuItem, newsToolStripMenuItem, windowToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1098, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cardSetCBLabel
            // 
            cardSetCBLabel.AutoSize = true;
            cardSetCBLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cardSetCBLabel.Location = new Point(193, 12);
            cardSetCBLabel.Name = "cardSetCBLabel";
            cardSetCBLabel.Size = new Size(187, 21);
            cardSetCBLabel.TabIndex = 1;
            cardSetCBLabel.Text = "Number of Packs to Load:";
            // 
            // LoadPanel
            // 
            LoadPanel.Controls.Add(cardSetCBLabel);
            LoadPanel.Controls.Add(CardSetLoaderCB);
            LoadPanel.Dock = DockStyle.Top;
            LoadPanel.Location = new Point(0, 24);
            LoadPanel.Name = "LoadPanel";
            LoadPanel.Size = new Size(1098, 43);
            LoadPanel.TabIndex = 0;
            // 
            // CardSetLoaderCB
            // 
            CardSetLoaderCB.DropDownStyle = ComboBoxStyle.DropDownList;
            CardSetLoaderCB.FormattingEnabled = true;
            CardSetLoaderCB.Location = new Point(386, 12);
            CardSetLoaderCB.MaxDropDownItems = 3;
            CardSetLoaderCB.Name = "CardSetLoaderCB";
            CardSetLoaderCB.Size = new Size(410, 23);
            CardSetLoaderCB.TabIndex = 0;
            CardSetLoaderCB.SelectedIndexChanged += CardSetLoaderCB_SelectedIndexChanged;
            // 
            // allCardsCB
            // 
            allCardsCB.DropDownStyle = ComboBoxStyle.DropDownList;
            allCardsCB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allCardsCB.FormattingEnabled = true;
            allCardsCB.Location = new Point(539, 6);
            allCardsCB.Name = "allCardsCB";
            allCardsCB.Size = new Size(417, 29);
            allCardsCB.TabIndex = 1;
            allCardsCB.SelectedIndexChanged += allCardsCB_SelectedIndexChanged;
            // 
            // cardSearchBox
            // 
            cardSearchBox.Enabled = false;
            cardSearchBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cardSearchBox.Location = new Point(12, 6);
            cardSearchBox.Name = "cardSearchBox";
            cardSearchBox.PlaceholderText = "Search for a Pokemon Card here";
            cardSearchBox.Size = new Size(481, 29);
            cardSearchBox.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(searchResultsBox);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(1098, 58);
            panel2.TabIndex = 2;
            // 
            // searchResultsBox
            // 
            searchResultsBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchResultsBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchResultsBox.FormattingEnabled = true;
            searchResultsBox.Location = new Point(12, 16);
            searchResultsBox.Name = "searchResultsBox";
            searchResultsBox.Size = new Size(481, 29);
            searchResultsBox.TabIndex = 0;
            searchResultsBox.SelectedIndexChanged += searchResultsBox_SelectedIndexChanged;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(allCardsCB);
            searchPanel.Controls.Add(cardSearchBox);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(1098, 43);
            searchPanel.TabIndex = 1;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(addToDBBtn);
            mainPanel.Controls.Add(cardImageHolder);
            mainPanel.Controls.Add(panel3);
            mainPanel.Controls.Add(panel2);
            mainPanel.Controls.Add(searchPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 67);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1098, 508);
            mainPanel.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(mainPanel);
            panel1.Controls.Add(LoadPanel);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 575);
            panel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 575);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)cardImageHolder).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            LoadPanel.ResumeLayout(false);
            LoadPanel.PerformLayout();
            panel2.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem twitterPanelToolStripMenuItem;
        private ToolStripMenuItem newsToolStripMenuItem;
        private ToolStripMenuItem deckBuilderToolStripMenuItem;
        private ToolStripMenuItem myDecksToolStripMenuItem;
        public Button addToDBBtn;
        private PictureBox cardImageHolder;
        private Panel panel3;
        private RichTextBox moveEffectLabel3;
        private RichTextBox moveEffectLabel2;
        private RichTextBox moveEffectLabel1;
        private Label move2label;
        private Label move3label;
        private Label move1Label;
        private ToolStripMenuItem deckToolStripMenuItem;
        private ToolStripMenuItem cardSearcherToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Label cardSetCBLabel;
        private Panel LoadPanel;
        private ComboBox CardSetLoaderCB;
        private ComboBox allCardsCB;
        private TextBox cardSearchBox;
        private Panel panel2;
        private ComboBox searchResultsBox;
        private Panel searchPanel;
        private Panel mainPanel;
        private Panel panel1;
    }
}