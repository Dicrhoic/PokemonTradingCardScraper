using PokemonCardScraper.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PokemonCardScraper.Classes
{

    internal class CardFetcher
    {
        static readonly HttpClient client = new HttpClient();
        public string responseBody = "";
        public string mainURL = "https://www.serebii.net";
        public string enURL = "https://www.serebii.net/card/english.shtml";
        public string jpURL = "https://www.serebii.net/card/japanese.shtml";
        public List<String> cardSetNames = new List<String>();  
        public List<CardFormat.CardSet> cardSet = new List<CardFormat.CardSet>();
        public List<CardFormat.Card> cardDetails = new List<CardFormat.Card>();
        public List<CardFormat.Card> allCardList = new List<CardFormat.Card>();
        public List<Tuple<string, CardFormat.Card>> SearchYield = new List<Tuple<string, CardFormat.Card>>();
        string currentCard = "";
        string currentMessage = "";
        public bool dataDownloaded = false;
        public List<string> movePaths = new List<string>();
        public List<string> moveEffectsPath = new List<string>();
        public List<string> moveList = new List<string>();
        public List<string> moveEffects = new List<string>();
        private List<Tuple<int, string>> moveNameMap = new List<Tuple<int, string>>();
        private List<Tuple<int, string>> moveEffectMap = new List<Tuple<int, string>>();
        string image = "";
        public Form origin = Application.OpenForms["Form1"];
        public async Task<bool> HtmlDataLoaded(string url)
        {
            try
            {
                Debug.Write("Hello\n");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                //Debug.WriteLine(responseBody);
                dataDownloaded = true;
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }

        public void CreateCardList(int amount, LoadingBar bar, BackgroundWorker worker, TextBox textBox, ComboBox cb)
        {
            LoadCardList(amount, bar, worker, textBox, cb);

        }

        public void LoadCardDB(ComboBox cb)
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(allCardList.Select(s => s.Name).ToList().ToArray());
            cb.DataSource = source;
            Debug.WriteLine("Data loaded to CB for search");
        }

        public async void LoadCardList(int amount, LoadingBar bar, BackgroundWorker worker, TextBox textBox, ComboBox cb)
        {
            amount++;
            Debug.WriteLine($"Amount is: {amount}");
            var task = await HtmlDataLoaded(jpURL);
            worker.ReportProgress(10);
            if (task)
            {
                //CardsCreated(amount, bar, worker);
                var task1 = await AllSetsGrabbed(amount, bar, worker);
                if (task1)
                {
                    //bar.Close();
                    //get link then add card
                    GetCardFromSets(amount, bar, worker, textBox, cb);


                }

            }
        }

        public async void GrabCards(int amount, LoadingBar bar, BackgroundWorker worker)
        {
            bar.progressBar1.Minimum = 1;
            bar.progressBar1.Maximum = 100;
            bar.Show();
            bar.progressBar1.Step = amount / 1;
            int step = 100 / amount;
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);

            var body = "//tr/td/a[1]";
            var data = "//tr/td[2]";
            var htmlNodes = doc.DocumentNode.SelectNodes(body);
            var cardNodes = doc.DocumentNode.SelectNodes(data);
            int count = 0;
            string text = "";
            int num = 0;
            List<int> cardNums = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                var node = cardNodes[i];
                text = node.InnerText;
                Int32.TryParse(text, out num);
                cardNums.Add(num);
            }
            for (int i = 0; i < amount; i++)
            {
                var task = await CardLoaded(htmlNodes, i, count, cardNums);
                if (task)
                {
                    bar.progressBar1.PerformStep();
                    count++;
                    Debug.WriteLine($"Progress in func: {step} x {i}");
                    int progress = step * (i + 1);
                    if (i + 1 == amount)
                    {
                        progress = 100;
                    }
                    worker.ReportProgress(progress);
                    bar.Caption.Text = currentMessage;
                    if (progress == 100)
                    {

                    }
                }
            }
        }

        public async Task<bool> AllSetsGrabbed(int amount, LoadingBar bar, BackgroundWorker worker)
        {
            bar.progressBar1.Minimum = 1;
            bar.progressBar1.Maximum = 100;
            bar.Show();
            bar.Text = "Loading card sets from JP TCG";
            bar.progressBar1.Step = amount / 1;
            int step = 100 / amount;
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);

            var body = "//tr/td/a[1]";
            var data = "//tr/td[2]";
            var htmlNodes = doc.DocumentNode.SelectNodes(body);
            var cardNodes = doc.DocumentNode.SelectNodes(data);
            int count = 0;
            string text = "";
            int num = 0;
            List<int> cardNums = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                var node = cardNodes[i];
                text = node.InnerText;
                Int32.TryParse(text, out num);
                cardNums.Add(num);
            }
            for (int i = 0; i < amount; i++)
            {
                var task = await CardLoaded(htmlNodes, i, count, cardNums);
                if (task)
                {
                    bar.progressBar1.PerformStep();
                    count++;
                    Debug.WriteLine($"Progress in func: {step} x {i}");
                    
                    int progress = step * (i + 1);
                    if (i + 1 == amount)
                    {
                        progress = 100;
                    }
                    worker.ReportProgress(progress);
                    bar.Caption.Text = currentMessage;
                    if (progress == 100)
                    {
                        await Task.Delay(1000);
                        return true;
                    }
                }
            }
            return false;
        }


        public async Task<bool> CardLoaded(HtmlAgilityPack.HtmlNodeCollection nodes,
            int index, int count, List<int> cardNums)
        {
            var node = nodes[index];
            string name = node.InnerText;
            string link = mainURL + node.Attributes["href"].Value;
            int id = count;
            int cardNumSum = cardNums[count];
            CardFormat.CardSet newCardSet = new(name, id, link, cardNumSum);
            currentCard = $"Adding {name} to card set";
            cardSet.Add(newCardSet);
            await Task.Delay(100);
            currentMessage = $"{name} added";
            Debug.WriteLine(currentMessage);
            return true;
        }

        public async Task<bool> GetCardSets()
        {
            //<td class="cen">
            var task = await HtmlDataLoaded(jpURL);
            if(task)
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseBody);
                var body = "//tr/td/a[1]";
                var htmlNodes = doc.DocumentNode.SelectNodes(body);
                foreach (var node in htmlNodes)
                {
                    Debug.WriteLine(node.InnerHtml);
                    cardSetNames.Add(node.InnerHtml);
                }
                return true;
            }
            return false;

        }

        public async void GetCardFromSets(int amount, LoadingBar bar, BackgroundWorker worker, TextBox textBox, ComboBox cb)
        {
            int sum = amount;
            for (int i = 0; i < amount; i++)
            {
                Stopwatch sw1 = Stopwatch.StartNew();
                var taskA = await HtmlDataLoaded(cardSet[i].setLink);
                if (taskA)
                {
                    //StoreCardDetials(cardSet[i]);
                    Stopwatch sw = Stopwatch.StartNew();
                    sw1.Stop();
                    Debug.WriteLine($"Elapsed time to load cards sets {sw1.Elapsed}");
                    var taskB = await CardsLoadedInSet(cardSet[i], amount, bar, worker);
                    if (taskB)
                    {

                        if ((i + 1) >= amount)
                        {
                            bar.Close();
                            sw.Stop();
                            Debug.WriteLine($"Elapsed time to load cards {sw.Elapsed}");
                            LoadSearchContents(textBox);
                            LoadCardDB(cb);
                        }
                    }
                }

            }
        }

        public void StoreCardDetials(CardFormat.CardSet cardSet)
        {

            string srcURL = cardSet.setLink;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);

            var body = "//tr/td[3]/a[1]";
            var htmlNodes = doc.DocumentNode.SelectNodes(body);
            int count = 1;
            List<CardFormat.Card> cardList = new List<CardFormat.Card>();
            string name = "";


            foreach (var node in htmlNodes)
            {
              
                if (node.NodeType == HtmlNodeType.Element)
                {
                    //Console.WriteLine("Adding {0}/{1} in {2}", count, htmlNodes.Count, cardSet.Name);
                    name = node.InnerText;
                    //Console.WriteLine(node.InnerText);                   

                    //string newName = name;
                    //Regex.Replace(name, @"^\s+", "");
                    string input = name;
                    string pattern = @"^\s+|^\t";
                    string replacement = "";
                    string newName = Regex.Replace(input, pattern, replacement);
                    Regex.Replace(newName, @"\s+", "");
                    Console.WriteLine("Replaced:{0}_to:{1}", name, newName);
                    string link = mainURL + node.Attributes["href"].Value;
                    string setName = cardSet.Name;
                    count++;
                    CardFormat.Card card = new CardFormat.Card(newName, setName, count, link);
                    cardList.Add(card);
                    allCardList.Add(card);
                    Debug.WriteLine($"Added {card.Name} to {card.cardPack}");

                }
            }
        }

        public void PrintList()
        {
            Debug.Write("Printing List");
            foreach(var set in cardSetNames)
            {
                //Debug.WriteLine($"Cardset: {set}");
                var c = allCardList.Where(x => x.cardPack == set);
                if(c.Count() > 0)
                {
                   foreach(var  card in c)
                    {
                        //Debug.WriteLine(card.Name);
                        CardFormat.PokemonCard pokemonCard = new(card.Name, set, card.cardLink);
                        GetCardDetails(pokemonCard);    
                    }

                }
            }
            foreach (var card in allCardList)
            {
                //.WriteLine(card.Name);
            }
        }

        private async void GetCardDetails(CardFormat.PokemonCard card)
        {
            Debug.WriteLine("Get Card Details");
            var task = await HtmlDataLoaded(card.link);
            if (task)
            {
                int moves = await MoveCount();
                var taskA = await MovesLoaded();
                if (taskA)
                {
                    Debug.WriteLine($"Adding {moves} moves");
                    if (moves != 0)
                    {
                        LoadMoves(card, moves);
                        Debug.WriteLine("Move effect");
                        LoadeMoveEffect(card);
                        UnlockButton();
                    }
                }

            }
        }

        private void LoadeMoveEffect(CardFormat.PokemonCard card)
        {
        
            foreach (var move in moveEffectMap.ToList())
            {
                int index = move.Item1;
                string path = move.Item2;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseBody);
                string effect = "";
                var node = doc.DocumentNode.SelectSingleNode(path);
                if(node != null)
                {
                    if (doc.DocumentNode.SelectSingleNode(path).InnerText != null)
                    {
                        effect = doc.DocumentNode.SelectSingleNode(path).InnerText;
                    }
                    Debug.WriteLine($"Effect length: {effect.Length}, index: {index}");
                    Debug.WriteLine($"Effect null: {string.IsNullOrEmpty(effect)}");
                    if (!string.IsNullOrEmpty(effect))
                    {
                        switch (index)
                        {
                            case 1:
                                Debug.WriteLine($"Loading move effect 1: {effect}");
                                card.me1 = RefineText(card.mn1, effect);
                                break;
                            case 2:
                                Debug.WriteLine($"Loading move effect 2: {effect}");
                                card.me2 = RefineText(card.mn1, effect);
                                break;
                            case 3:
                                Debug.WriteLine($"Loading move effect 3: {effect}");
                                card.me3 = RefineText(card.mn1, effect);
                                break;
                        }
                    }
                }
              
            }
        }

        private void LoadMoves(CardFormat.PokemonCard card, int moveCount)
        {
            Debug.WriteLine($"Moves: {moveCount}, MoveList: {moveList.Count}");
            switch (moveCount)
            {
                case 1:
                    card.mn1 = moveList[0];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    break;
                case 2:
                    card.mn1 = moveList[0];
                    card.mn2 = moveList[1];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    Debug.WriteLine($"Updating move {moveList[1]}");
                    break;
                case 3:
                    card.mn1 = moveList[0];
                    card.mn2 = moveList[1];
                    card.mn3 = moveList[2];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    Debug.WriteLine($"Updating move {moveList[1]}");
                    Debug.WriteLine($"Updating move {moveList[2]}");
                    break;
                default:
                    Debug.WriteLine("Default reached something went wrong");
                    break;
            }
        }

        public async Task<bool> CardsLoadedInSet(CardFormat.CardSet cardSet, int amount,
            LoadingBar bar, BackgroundWorker worker)
        {
            worker.ReportProgress(1);
            bar.Show();
            bar.Text = $"Adding cards from {cardSet.Name}";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);

            var body = "//tr/td[3]/a[1]";
            var htmlNodes = doc.DocumentNode.SelectNodes(body);
            int count = 1;
            List<CardFormat.Card> cardList = new List<CardFormat.Card>();
            string name = "";
            int max = htmlNodes.Count;
            int step = 1;
            Debug.WriteLine("Cards count: " + max);
            int increment = 1;
            if (amount > 100)
            {
                increment = 100 / amount;
            }

            foreach (var node in htmlNodes)
            {

                if (node.NodeType == HtmlNodeType.Element)
                {
                    //Console.WriteLine("Adding {0}/{1} in {2}", count, htmlNodes.Count, cardSet.Name);
                    name = node.InnerText;
                    //Console.WriteLine(node.InnerText);                   

                    //string newName = name;
                    //Regex.Replace(name, @"^\s+", "");
                    string input = name;
                    string pattern = @"^\s+|^\t";
                    string replacement = "";
                    string newName = Regex.Replace(input, pattern, replacement);
                    Regex.Replace(newName, @"\s+", "");
                    Console.WriteLine("Replaced:{0}_to:{1}", name, newName);
                    string link = mainURL + node.Attributes["href"].Value;
                    string setName = cardSet.Name;
                    count++;
                    CardFormat.Card card = new CardFormat.Card(newName, setName, count, link);
                    cardList.Add(card);
                    allCardList.Add(card);
                    string message = $"Added {card.Name} #{count} from {card.cardPack}";
                    bar.Caption.Text = message;
                    step = step + increment;
                    if (step + 1 >= max || step >= 100)
                    {
                        Debug.WriteLine("Overload of 100 reducing");
                        step = 100;
                    }
                    Debug.WriteLine($"Sending value {step} to worker");
                    worker.ReportProgress(step);
                    await Task.Delay(50);
                    Debug.WriteLine(message);
                }
            }
            await Task.Delay(500);
            //PrintList();
            return true;
        }

        public void LoadSearchContents(TextBox cardSearchBox)
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(allCardList.Select(s => s.Name).ToList().ToArray());
            cardSearchBox.AutoCompleteCustomSource = source;
            cardSearchBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cardSearchBox.AutoCompleteCustomSource = source;
            cardSearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Debug.WriteLine("Data added for searchbox");
        }

        public void FindCard(string searchWord, ComboBox results)
        {
            List<CardFormat.Card> searchReturns = new List<CardFormat.Card>();
            int index = 0;
            SearchYield.Clear();
            foreach (var card in allCardList)
            {
                if (card.Name == searchWord)
                {
                    Debug.WriteLine($"Found {card.Name} in set {card.cardPack} id{card.cardId}");
                    //Console.WriteLine(card.cardSet);
                    searchReturns.Add(card);
                    string title = $"{card.Name} {card.cardPack}/#{card.cardId}";
                    string name = title;
                    Tuple<string, CardFormat.Card> searchResults = new Tuple<string, CardFormat.Card>(name, card);
                    SearchYield.Add(searchResults);
                }

                index++;
            }

            results.DataSource = SearchYield.Select(sy => sy.Item1).ToList().ToArray();
        }

        public void LoadCardImage(string url, PictureBox picture)
        {
            picture.Load(url);
        }

        public void TestFormGrab()
        {
            origin = Application.OpenForms["Form1"];
            if (origin != null)
            {
                Debug.WriteLine($"Form1 contents: {origin.Controls} could be found");
                foreach (Control control in origin.Controls)
                {
                    var home = control.Controls;
                    Debug.WriteLine($"Inner 1 Control: {control.Name} could be found");
                    foreach (Control control1 in home)
                    {
                        Debug.WriteLine($"Inner 2 Control: {control1.Name} could be found");
                    }
                }

            }
        }

        public void UnlockButton()
        {
            origin = Application.OpenForms["Form1"];
            var panel1 = origin.Controls["panel1"];
            var mainPanel = panel1.Controls["mainPanel"];
            var buttonTarget = mainPanel.Controls["addToDBBtn"];
            buttonTarget.Enabled = true;
        }

        public async void GetCardDetails(string url, Label m1, Label m2, Label m3,
            PictureBox picture, RichTextBox me1, RichTextBox me2, RichTextBox me3)
        {
            Debug.WriteLine("Get Card Details");
            var task = await HtmlDataLoaded(url);
            if (task)
            {
                int moves = await MoveCount();
                var taskA = await MovesLoaded();
                if (taskA)
                {
                    var taskB = await CardImageLoaded();
                    if (taskB != null)
                    {
                        picture.Load(taskB);
                    }
                    Debug.WriteLine($"Adding {moves} moves");
                    if (moves != 0)
                    {
                        DisplayMoves(m1, m2, m3, moves);
                        Debug.WriteLine("Move effect");
                        DisplayMoveEffect(m1, m2, m3, me1, me2, me3);
                        UnlockButton();
                    }
                }

            }
        }

        public async void ExportCardData(string setName)
        {

        }

        private async void GetSaveCardDetails(string url, Label m1, Label m2, Label m3,
            PictureBox picture, RichTextBox me1, RichTextBox me2, RichTextBox me3)
        {
            Debug.WriteLine("Get Card Details");
            var task = await HtmlDataLoaded(url);
            if (task)
            {
                int moves = await MoveCount();
                var taskA = await MovesLoaded();
                if (taskA)
                {
                    var taskB = await CardImageLoaded();
                    if (taskB != null)
                    {
                        picture.Load(taskB);
                    }
                    Debug.WriteLine($"Adding {moves} moves");
                    if (moves != 0)
                    {
                        DisplayMoves(m1, m2, m3, moves);
                        Debug.WriteLine("Move effect");
                        DisplayMoveEffect(m1, m2, m3, me1, me2, me3);
                        UnlockButton();
                    }
                }

            }
        }


        public async Task<int> MoveCount()
        {
            await Task.Delay(1);
            moveEffectsPath.Clear();
            movePaths.Clear();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);
            var textField = "//span[@class='main']";
            var textTest = doc.DocumentNode.SelectNodes(textField);
            int count = 0;
            int index = 0;
            var effectField = "/html[1]/body[1]/div[1]/div[2]/main[1]/div[1]/table[3]/tr[1]/td[2]/table[3]/tr/td[2]";
            HtmlNodeCollection effectTest;
            try
            {
                effectTest = doc.DocumentNode.SelectNodes(effectField);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"No effect field error: {e.Message}");
                effectTest = null;
            }
          
            if (textTest != null)
            {
                Debug.WriteLine("TextTest");
                foreach (var node in textTest.ToList())
                {
                    count++;
                    Debug.WriteLine($"Run: {count} {node.InnerText} Path: {node.XPath}");
                    string path = node.XPath;
                    movePaths.Add(path);
                    var data = Tuple.Create(count, path);
                    moveNameMap.Add(data);
                    Debug.WriteLine($"TextText {textTest} passed on to effect test {effectTest}");
                }
            }
            if(effectTest == null)
            {   
                Debug.WriteLine("Skipping effect test");
                int movesT = count;
                Debug.WriteLine($"Moves {movesT} set from {count}");
                Debug.WriteLine("Returning moves");
                return movesT;
            }
            if (effectTest != null)
            {
                Debug.WriteLine($"Effect test");
                foreach (var node in effectTest.ToList())
                {
                    index++; 
                    string text = node.InnerText;
                    if (!string.IsNullOrEmpty(text) && text != "\n")
                    {
                        string path = node.XPath;
                        Debug.WriteLine($"Effect: {index} {node.InnerText} Path: {path}");
                        moveEffectsPath.Add(path);
                        Debug.WriteLine("Added path");
                        var data = Tuple.Create(index, path);
                        moveEffectMap.Add(data);
                        Debug.WriteLine("Mapped move");
                    }


                }
            }
            int moves = count;
      
            Debug.WriteLine("Returning moves");
            return moves;
        }

        public async Task<int> MoveEffectsPlaced()
        {
            int indexes = 0;
            await Task.Delay(10);
            return indexes;
        }

        public async Task<bool> MovesLoaded()
        {
            await Task.Delay(10);
            moveList.Clear();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);
            foreach (var move in movePaths.ToList())
            {
                var index = move;
                var node = doc.DocumentNode.SelectSingleNode(index);
                if(node != null)
                {
                    var skill = doc.DocumentNode.SelectSingleNode(index).InnerText;
                    Debug.WriteLine($"Skill: {skill}");
                    moveList.Add(skill);
                    Debug.WriteLine("#Moves: " + moveList.Count);
                }
           
             
            }
            return true;
        }

        public async Task<bool> MovesPaired()
        {
            for (int i = 0; i < moveNameMap.Count; i++)
            {
                for (int j = 0; j < moveEffectMap.Count; j++)
                {
                    var move = moveNameMap[i];
                    var pair = moveEffectMap[j];
                    if (move.Item1 == pair.Item1)
                    {
                        //this is the same move
                    }
                    else
                    {
                        //this move has no effect
                    }
                }
            }
            return true;
        }

        public void DisplayMoveEffect(Label m1, Label m2, Label m3,
            RichTextBox me1, RichTextBox me2, RichTextBox me3)
        {
            me1.Hide();
            me2.Hide();
            me3.Hide();
            me1.Text = "";
            me2.Text = "";
            me3.Text = "";
            foreach (var move in moveEffectMap)
            {
                int index = move.Item1;
                string path = move.Item2;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseBody);
                string effect = "";
                var node = doc.DocumentNode.SelectSingleNode(path);
                if (node != null)
                {
                    if (doc.DocumentNode.SelectSingleNode(path).InnerText != null)
                    {
                        effect = doc.DocumentNode.SelectSingleNode(path).InnerText;
                    }
                    Debug.WriteLine($"Effect length: {effect.Length}, index: {index}");
                    Debug.WriteLine($"Effect null: {string.IsNullOrEmpty(effect)}");
                    if (!string.IsNullOrEmpty(effect))
                    {
                        switch (index)
                        {
                            case 1:
                                Debug.WriteLine($"Loading move effect 1: {effect}");
                                me1.Text = RefineText(m1, effect);
                                me1.Show();
                                break;
                            case 2:
                                Debug.WriteLine($"Loading move effect 2: {effect}");
                                me2.Text = RefineText(m2, effect);
                                me2.Show();
                                break;
                            case 3:
                                Debug.WriteLine($"Loading move effect 3: {effect}");
                                me3.Text = RefineText(m3, effect);
                                me3.Show();
                                break;
                        }
                    }
                }
                
            
            }
        }

        private string RefineText(string move, string effect)
        {
            Debug.WriteLine($"Passed Effect: {effect} length: {effect.Length}");
            if (effect.Length == 4)
            {
                Debug.WriteLine("Length == 4");
                return "No translation";
            }
            if (move.Length == 0)
            {

            }
            string formatted = effect;
            bool containsSearchResult1 = effect.Contains("Pok&eacute;mon");
            if (containsSearchResult1)
            {
                formatted = formatted.Replace("Pok&eacute;mon", "Pokémon");
            }
            string name = move;
            if (move.Length > 0)
            {
                bool containsSearchResult2 = effect.Contains(name);
                if (containsSearchResult2)
                {
                    formatted = formatted.Replace(name, "");
                    formatted = formatted.Replace("\n", "");
                }

            }

            return formatted;
        }



        public string RefineText(Label move, string effect)
        {
            Debug.WriteLine($"Passed Effect: {effect} length: {effect.Length}");
            if (effect.Length == 4)
            {
                Debug.WriteLine("Length == 4");
                return "No translation";
            }
            if(move.Text.Length == 0)
            {
                
            }
            string formatted = effect;
            bool containsSearchResult1 = effect.Contains("Pok&eacute;mon");
            if (containsSearchResult1)
            {
                formatted = formatted.Replace("Pok&eacute;mon", "Pokémon");
            }
            string name = move.Text;
            if (move.Text.Length > 0)
            {
                bool containsSearchResult2 = effect.Contains(name);
                if (containsSearchResult2)
                {
                    formatted = formatted.Replace(name, "");
                    formatted = formatted.Replace("\n", "");
                }

            }

            return formatted;
        }


        public void DisplayMoves(Label m1, Label m2, Label m3, int moveCount)
        {
            m1.Text = "";
            m2.Text = "";
            m3.Text = "";
            switch (moveCount)
            {
                case 1:
                    m1.Text = moveList[0];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    break;
                case 2:
                    m1.Text = moveList[0];
                    m2.Text = moveList[1];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    Debug.WriteLine($"Updating move {moveList[1]}");
                    break;
                case 3:
                    m1.Text = moveList[0];
                    m2.Text = moveList[1];
                    m3.Text = moveList[2];
                    Debug.WriteLine($"Updating move {moveList[0]}");
                    Debug.WriteLine($"Updating move {moveList[1]}");
                    Debug.WriteLine($"Updating move {moveList[2]}");
                    break;
                default:
                    Debug.WriteLine("Default reached something went wrong");
                    break;
            }
        }

        public async Task<string> CardImageLoaded()
        {
            var image1 = "//table/tr/td/a";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(responseBody);
            var test = doc.DocumentNode.SelectNodes(image1);
            int count = 0;
            string imageLink = string.Empty;
            Console.WriteLine("Step 2 for image....");
            foreach (var node in test)
            {
                count++;
                Console.WriteLine(node.Attributes["href"].Value);
                if (count == 2)
                {
                    imageLink = mainURL + node.Attributes["href"].Value;
                    Console.WriteLine(imageLink);
                }
            }
            await Task.Delay(5);
            return imageLink;
        }
    }
}
