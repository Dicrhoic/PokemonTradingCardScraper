using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardScraper.Classes
{
    internal class PanelHelper
    {
        public int twitterPanelH;
        public int twitterPanelW;

        public PanelHelper(int twitterPanelW, int twitterPanelH)
        {
            this.twitterPanelH = twitterPanelH;
            this.twitterPanelW = twitterPanelW;
        }

        public void AdjustPanel(Panel panel, int panelW, int panelH)
        {
            panel.Size = new Size(panelW, panelH);
        }

    }
}
