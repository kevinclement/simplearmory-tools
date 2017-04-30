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
    public partial class AddAchievementCategory : Form, IAddCategory
    {
        public IParser Parser { get; private set; }
        private AchievementParser ap;

        //public List<Supercat> SuperCats { get; private set; }

        public AddAchievementCategory(IParser parser)
        {
            InitializeComponent();

            // Clone the parser buy using its json
            this.Parser = WowheadParser.Parser.Create(parser.JsonFile, parser.ParseType);
            this.ap = (AchievementParser)this.Parser;

            // Fill out the super cat list view
            foreach (var supercat in ap.Achievements.supercats)
            {
                this.superCatsListBox.Items.Add(supercat);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void superCatAdd_Click(object sender, EventArgs e)
        {
            var inform = new Prompt("Super Category");
            if (inform.ShowDialog() == DialogResult.OK)
            {
                var newSuperCat = new Supercat()
                    {
                        cats = new List<Cat>(),
                        name = inform.Value
                    };

                this.ap.Achievements.supercats.Add(newSuperCat);
                this.superCatsListBox.Items.Add(newSuperCat);
            }
        }

        private void superCatsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.categoryListBox.BeginUpdate();
            this.categoryListBox.Items.Clear();

            if (this.superCatsListBox.SelectedItems.Count > 0)
            {
                foreach (var category in ((Supercat) this.superCatsListBox.SelectedItem).cats)
                {
                    this.categoryListBox.Items.Add(category);
                }
            }

            this.categoryListBox.EndUpdate();
            this.categoryRemove.Enabled = false;
            
            this.superCatRemove.Enabled = this.superCatsListBox.SelectedItems.Count > 0;
            this.superCatDown.Enabled = this.superCatsListBox.SelectedItems.Count > 0 && this.superCatsListBox.SelectedIndex != (this.superCatsListBox.Items.Count - 1);
            this.superCatUp.Enabled = this.superCatsListBox.SelectedItems.Count > 0 && this.superCatsListBox.SelectedIndex != 0;
        }

        private void categoryListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.zoneListBox.BeginUpdate();
            this.zoneListBox.Items.Clear();

            if (this.categoryListBox.SelectedItems.Count > 0)
            {
                foreach (var zone in ((Cat) this.categoryListBox.SelectedItem).zones)
                {
                    this.zoneListBox.Items.Add(zone);
                }
            }

            this.zoneListBox.EndUpdate();
            this.zoneRemove.Enabled = false;

            this.categoryRemove.Enabled = this.categoryListBox.SelectedItems.Count > 0;
            this.downCat.Enabled = this.categoryListBox.SelectedItems.Count > 0 && this.categoryListBox.SelectedIndex != (this.categoryListBox.Items.Count - 1);
            this.upCat.Enabled = this.categoryListBox.SelectedItems.Count > 0 && this.categoryListBox.SelectedIndex != 0;
        }

        private void zoneListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.zoneRemove.Enabled = this.zoneListBox.SelectedItems.Count > 0;
            this.downZone.Enabled = this.zoneListBox.SelectedItems.Count > 0 && this.zoneListBox.SelectedIndex != (this.zoneListBox.Items.Count - 1);
            this.upZone.Enabled = this.zoneListBox.SelectedItems.Count > 0 && this.zoneListBox.SelectedIndex != 0;
        }

        private void zoneRemove_Click(object sender, EventArgs e)
        {
            ((Cat) this.categoryListBox.SelectedItem).zones.Remove((Zone) this.zoneListBox.SelectedItem);
            this.zoneListBox.Items.Remove(this.zoneListBox.SelectedItem);
        }

        private void categoryRemove_Click(object sender, EventArgs e)
        {
            ((Supercat)this.superCatsListBox.SelectedItem).cats.Remove((Cat)this.categoryListBox.SelectedItem);
            this.categoryListBox.Items.Remove(this.categoryListBox.SelectedItem);
            this.zoneListBox.Items.Clear();
        }

        private void superCatRemove_Click(object sender, EventArgs e)
        {
            this.ap.Achievements.supercats.Remove((Supercat)this.superCatsListBox.SelectedItem);
            this.superCatsListBox.Items.Remove(this.superCatsListBox.SelectedItem);
            this.categoryListBox.Items.Clear();
            this.zoneListBox.Items.Clear();
        }

        private void categoryAdd_Click(object sender, EventArgs e)
        {
            var inform = new Prompt("Category");
            if (inform.ShowDialog() == DialogResult.OK)
            {
                var newCategory = new Cat()
                {
                    zones = new List<Zone>(),
                    name = inform.Value
                };

                ((Supercat)this.superCatsListBox.SelectedItem).cats.Add(newCategory);
                this.categoryListBox.Items.Add(newCategory);
            }
        }

        private void zoneAdd_Click(object sender, EventArgs e)
        {
            var inform = new Prompt("Zone");
            if (inform.ShowDialog() == DialogResult.OK)
            {
                var newZone = new Zone()
                {
                    achs = new List<Ach>(),
                    name = inform.Value
                };

                ((Cat)this.categoryListBox.SelectedItem).zones.Add(newZone);
                this.zoneListBox.Items.Add(newZone);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // move selected item up        
            var removeIndex = this.superCatsListBox.SelectedIndex + 1;
            var addIndex = this.superCatsListBox.SelectedIndex - 1;
            var item = this.superCatsListBox.SelectedItem;
            this.superCatsListBox.Items.Insert(addIndex, item);
            this.superCatsListBox.Items.RemoveAt(removeIndex);
            this.superCatsListBox.SelectedIndex = addIndex;

            // move it up in mem too
            this.ap.Achievements.supercats.Insert(addIndex, (Supercat)item);
            this.ap.Achievements.supercats.RemoveAt(removeIndex);
        }

        private void superCatDown_Click(object sender, EventArgs e)
        {
            // move selected item down
            var removeIndex = this.superCatsListBox.SelectedIndex;
            var addIndex = this.superCatsListBox.SelectedIndex + 2;
            var item = this.superCatsListBox.SelectedItem;
            this.superCatsListBox.Items.Insert(addIndex, item);
            this.superCatsListBox.Items.RemoveAt(removeIndex);
            this.superCatsListBox.SelectedIndex = addIndex - 1;

            // move it up in mem too
            this.ap.Achievements.supercats.Insert(addIndex, (Supercat)item);
            this.ap.Achievements.supercats.RemoveAt(removeIndex);
        }

        private void upCat_Click(object sender, EventArgs e)
        {
            // move selected item up        
            var removeIndex = this.categoryListBox.SelectedIndex + 1;
            var addIndex = this.categoryListBox.SelectedIndex - 1;
            var item = this.categoryListBox.SelectedItem;
            this.categoryListBox.Items.Insert(addIndex, item);
            this.categoryListBox.Items.RemoveAt(removeIndex);
            this.categoryListBox.SelectedIndex = addIndex;

            // move it up in mem too
            ((Supercat)this.superCatsListBox.SelectedItem).cats.Insert(addIndex, (Cat)item);
            ((Supercat)this.superCatsListBox.SelectedItem).cats.RemoveAt(removeIndex);
        }

        private void downCat_Click(object sender, EventArgs e)
        {
            var removeIndex = this.categoryListBox.SelectedIndex;
            var addIndex = this.categoryListBox.SelectedIndex + 2;
            var item = this.categoryListBox.SelectedItem;
            this.categoryListBox.Items.Insert(addIndex, item);
            this.categoryListBox.Items.RemoveAt(removeIndex);
            this.categoryListBox.SelectedIndex = addIndex - 1;

            // move it up in mem too
            ((Supercat)this.superCatsListBox.SelectedItem).cats.Insert(addIndex, (Cat)item);
            ((Supercat)this.superCatsListBox.SelectedItem).cats.RemoveAt(removeIndex);
        }

        private void upZone_Click(object sender, EventArgs e)
        {
            // move selected item up        
            var removeIndex = this.zoneListBox.SelectedIndex + 1;
            var addIndex = this.zoneListBox.SelectedIndex - 1;
            var item = this.zoneListBox.SelectedItem;
            this.zoneListBox.Items.Insert(addIndex, item);
            this.zoneListBox.Items.RemoveAt(removeIndex);
            this.zoneListBox.SelectedIndex = addIndex;

            // move it up in mem too
            ((Cat)this.categoryListBox.SelectedItem).zones.Insert(addIndex, (Zone)item);
            ((Cat)this.categoryListBox.SelectedItem).zones.RemoveAt(removeIndex);
        }

        private void downZone_Click(object sender, EventArgs e)
        {
            var removeIndex = this.zoneListBox.SelectedIndex;
            var addIndex = this.zoneListBox.SelectedIndex + 2;
            var item = this.zoneListBox.SelectedItem;
            this.zoneListBox.Items.Insert(addIndex, item);
            this.zoneListBox.Items.RemoveAt(removeIndex);
            this.zoneListBox.SelectedIndex = addIndex - 1;

            // move it up in mem too
            ((Cat)this.categoryListBox.SelectedItem).zones.Insert(addIndex, (Zone)item);
            ((Cat)this.categoryListBox.SelectedItem).zones.RemoveAt(removeIndex);
        }        
    }
}
