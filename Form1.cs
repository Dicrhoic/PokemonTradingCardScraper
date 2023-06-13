using PokemonCardScraper.Classes;
using PokemonCardScraper.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PokemonCardScraper
{
    public partial class Form1 : Form
    {
        LoadingBar loadingBar;
        CardFetcher fetcher;
        PanelHelper panelHelper;
        int index = 0;
        bool numberChose = true;
        bool indexChanged = false;
        bool dataLoaded = false;
        int call = 0;
        public Form1()
        {
            InitializeComponent();
            loadingBar = new LoadingBar();
            fetcher = new CardFetcher();
            List<int> indexes = new List<int>();
            for (int i = 1; i < 129; i++)
            {
                indexes.Add(i);
            }
            LoadCardSets();
            InitializeLayout();
        }

        private async void LoadCardSets()
        {
            var a = await fetcher.GetCardSets();
            if(a)
            {
                CardSetLoaderCB.DataSource = fetcher.cardSetNames;
            }
            dataLoaded = true;
        }

        private void InitializeLayout()
        {
            addToDBBtn.Enabled = false;
            numberChose = false;

            move1Label.Text = "";
            move2label.Text = "";
            move3label.Text = "";
            moveEffectLabel1.Hide();
            moveEffectLabel2.Hide();
            moveEffectLabel3.Hide();
            moveEffectLabel1.Text = "";
            moveEffectLabel2.Text = "";
            moveEffectLabel3.Text = "";

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Debug.WriteLine($"Progress changed: {e.ProgressPercentage}");
            loadingBar.ProgressLabel.Text = (e.ProgressPercentage.ToString() + "%");
            loadingBar.progressBar1.Value = e.ProgressPercentage;
        }

        private void CardSetLoaderCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!numberChose && dataLoaded)
            {
                index = CardSetLoaderCB.SelectedIndex;
                fetcher.CreateCardList(index, loadingBar, backgroundWorker1, cardSearchBox, allCardsCB);
                CardSetLoaderCB.Enabled = false;
                cardSearchBox.Enabled = true;
        
           
            }

        }


        private void QueryCardName(object sender, KeyEventArgs e)
        {
            bool searched = false;
            if ((e.KeyCode == Keys.Enter))
            {
                fetcher.FindCard(cardSearchBox.Text, searchResultsBox);
                searched = true;
            }
        }

        private void ExportCardsJSON(object sender, EventArgs e)
        {
            
        }

        private void searchResultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchResultsBox.Items.Count > 0)
            {
                int index = searchResultsBox.SelectedIndex;
                var card = fetcher.SearchYield[index];
                try
                {
                    //fetcher.LoadCardImage(card.Item2.cardLink, pictureBox1);
                    fetcher.GetCardDetails(card.Item2.cardLink, move1Label, move2label, move3label,
                        cardImageHolder, moveEffectLabel1, moveEffectLabel2, moveEffectLabel3);
                }
                catch
                {

                }

            }
        }

        private void LoadItemIntoQuery(string name)
        {
            cardSearchBox.Text = name;
            fetcher.FindCard(name, searchResultsBox);
        }
        private void allCardsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!indexChanged)
            {
                indexChanged = true;
                call = 1;
                return;
            }
            if (call == 1)
            {
                LoadItemIntoQuery(allCardsCB.Text);
            }

        }


    }
}