using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WowheadParser
{
    public partial class Reorder : Form
    {
        public IParser Parser { get; private set; }

        private Zone zone;

        public Reorder(IParser parser, AchievementParser.VisualCategory vc)
        {
            InitializeComponent();

            Zone zoneToFind = vc.Zone;

            // Clone the parser buy using its json
            this.Parser = WowheadParser.Parser.Create(parser.JsonFile, parser.ParseType);

            // find the matching zone
            foreach (var supercat in ((AchievementParser) Parser).Achievements.supercats)
            {
                foreach (var cat in supercat.cats)
                {
                    foreach (var z in cat.zones)
                    {
                        var display = supercat.name + "\\" + cat.name + "\\" + z.name;

                        if (display == vc.ToString())
                        {
                            this.zone = z;
                        }
                    }
                }
            }

            // Fill out the item list
            foreach (var ach in this.zone.achs)
            {
                itemListBox.Items.Add(ach);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void itemListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.downItem.Enabled = this.itemListBox.SelectedItems.Count > 0 && this.itemListBox.SelectedIndex != (this.itemListBox.Items.Count - 1);
            this.upItem.Enabled = this.itemListBox.SelectedItems.Count > 0 && this.itemListBox.SelectedIndex != 0;
        }

        private void upItem_Click(object sender, EventArgs e)
        {
            // move selected item up        
            var removeIndex = this.itemListBox.SelectedIndex + 1;
            var addIndex = this.itemListBox.SelectedIndex - 1;
            var item = this.itemListBox.SelectedItem;
            this.itemListBox.Items.Insert(addIndex, item);
            this.itemListBox.Items.RemoveAt(removeIndex);
            this.itemListBox.SelectedIndex = addIndex;

            // move it up in mem too
            zone.achs.Insert(addIndex, (Ach)item);
            zone.achs.RemoveAt(removeIndex);
        }

        private void downItem_Click(object sender, EventArgs e)
        {
            var removeIndex = this.itemListBox.SelectedIndex;
            var addIndex = this.itemListBox.SelectedIndex + 2;
            var item = this.itemListBox.SelectedItem;
            this.itemListBox.Items.Insert(addIndex, item);
            this.itemListBox.Items.RemoveAt(removeIndex);
            this.itemListBox.SelectedIndex = addIndex - 1;

            // move it up in mem too
            zone.achs.Insert(addIndex, (Ach)item);
            zone.achs.RemoveAt(removeIndex);
        }
    }
}
