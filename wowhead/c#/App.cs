using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Diagnostics;
using System.Text;

namespace WowheadParser
{
    public partial class App : Form
    {
        private string outputFile;
        private IWowHeadParser wowheadParser;
        private IParser parser;
        private bool autoClearDupes = true;
        private bool dirty;
        private string _noneFound = "None Found";

        private ParseType ParseType
        {
            get
            {
                if (Path.GetFileName(outputFile).ToLower() == "mounts.json")
                {
                    return ParseType.Mounts;
                }
                else if (Path.GetFileName(outputFile).ToLower() == "pets.json")
                {
                    return ParseType.Pets;
                }
                else if (Path.GetFileName(outputFile).ToLower() == "achievements.json")
                {
                    return ParseType.Achievements;
                }
                else if (Path.GetFileName(outputFile).ToLower() == "battlepets.json")
                {
                    return ParseType.BattlePets;
                }
                else
                {
                    throw new ApplicationException("Unknown parser for file '" + outputFile + "'");
                }
            }
        }

        public App()
        {
            // support both home and work
            outputFile = @"C:\Users\Kevin Clement\Dropbox\Development\Projects\SimpleArmory\SimpleArmory\app\data\battlepets.json";
            if (!File.Exists(outputFile))
            {
                outputFile = @"F:\Dropbox\Development\Projects\SimpleArmory\SimpleArmory\app\data\battlepets.json";
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ParseCategories(outputFile);
            this.ResetFetchedItems();
            FillInHelpJavascript();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            AddItems(false);
        }

        private void AddItems(bool legacyMode)
        {
            var toRemove = new List<object>();

            var selectedCategory = categoryList.SelectedItem;
            foreach (var item in fetchedItems.SelectedItems)
            {
                if (item.ToString() == _noneFound)
                {
                    continue;
                }

                this.dirty = true;

                if (legacyMode)
                {
                    ((AchievementParser)this.parser).Move(item, selectedCategory);
                }
                else
                {
                    this.parser.Add(item, selectedCategory);
                }

                toRemove.Add(item);
            }

            foreach (var o in toRemove)
            {
                this.fetchedItems.Items.Remove(o);
            }

            FormatTotalFound();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetFetchedItems();
        }

        private void ResetFetchedItems()
        {
            fetchedItems.Items.Clear();
            fetchedItems.BeginUpdate();

            if (!string.IsNullOrEmpty(urlBox.Text))
            {
                this.wowheadParser = WowHeadParser.Create(urlBox.Text, this.ParseType);

                foreach (var item in wowheadParser.Items)
                {
                    if (this.autoClearDupes)
                    {
                        if (!this.parser.Contains(item))
                        {
                            fetchedItems.Items.Add(item);
                        }
                    }
                    else
                    {
                        fetchedItems.Items.Add(item);
                    }
                }

                if (this.fetchedItems.Items.Count == 0)
                {
                    this.fetchedItems.Items.Add(_noneFound);
                }

                FormatTotalFound();
            }

            fetchedItems.EndUpdate();
        }

        private void FormatTotalFound()
        {
            this.totalFound.Text = "Found: " + this.fetchedItems.Items.Count;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                categoriesFile.Text = openFileDialog1.FileName;
                ParseCategories(categoriesFile.Text);

                // fill in javscript
                FillInHelpJavascript();
            }
        }

        private void FillInHelpJavascript()
        {
            if (this.ParseType == WowheadParser.ParseType.Achievements)
            {
                urlBox.Text = "for (var key in g_achievements) { if (typeof g_achievements[key] == \"object\") { console.log(key); } }";
            }
            else if (this.ParseType == WowheadParser.ParseType.Mounts)
            {
                urlBox.Text = "for (var key in g_items) { if (typeof g_items[key] == \"object\") { console.log(key); } }";
            }
            else if (this.ParseType == WowheadParser.ParseType.Pets)
            {
                urlBox.Text = "for (var key in g_items) { if (typeof g_items[key] == \"object\") { console.log(key); } }";
            }
            else if (this.ParseType == WowheadParser.ParseType.BattlePets)
            {
                urlBox.Text = "for (var item in g_listviews.gallery.data) { console.log(g_listviews.gallery.data[item].npc.id + \",\" + g_listviews.gallery.data[item].icon + \",\" + g_listviews.gallery.data[item].name); }";
            }
        }

        private void ParseCategories(string fileName)
        {
            this.outputFile = fileName;
            this.parser = Parser.Create(fileName, this.ParseType);
            this.ResetCategories();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // TODO: change to outputfile
            //var outFile = @"f:\tmp\sa\" + Path.GetFileName(this.outputFile);
            var outFile = this.outputFile;

            // Delete file if it exists
            if (File.Exists(outFile))
            {
                File.Delete(outFile);
            }

            File.AppendAllText(
                outFile,
                this.parser.ToJavascript());

            this.dirty = false;
        }

        private void RemoveDuplicates_Click(object sender, EventArgs e)
        {
            var toRemove = new List<object>();

            foreach (var item in this.fetchedItems.Items)
            {
                if (this.parser.Contains(item))
                {
                    toRemove.Add(item);    
                }                
            }

            foreach (var o in toRemove)
            {
                this.fetchedItems.Items.Remove(o);
            }
        }

        private void fetchedItems_DoubleClick(object sender, EventArgs e)
        {
            if (this.fetchedItems.SelectedItem == null || this.fetchedItems.SelectedItem.ToString() == _noneFound)
            {
                return;
            }

            if (this.fetchedItems.SelectedItem is IWowHeadItem)
            {
                Process.Start(((IWowHeadItem)this.fetchedItems.SelectedItem).URL);
            }
            else
            {
                Process.Start("http://www.wowhead.com/achievement=" + ((Ach)this.fetchedItems.SelectedItem).id);
            }
        }

        private void fetchedItems_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TryToEnableAddButton();
        }

        private void TryToEnableAddButton()
        {
            if (this.fetchedItems.SelectedItems.Count > 0 && this.categoryList.SelectedItems.Count > 0)
            {              
                if (this.fetchedItems.SelectedItems.Count == 1 && this.fetchedItems.SelectedItem.ToString() == _noneFound)
                {
                    this.moveButton.Enabled = false;
                }
                else
                {
                    this.moveButton.Enabled = true;
                }
            }
            else
            {
                this.moveButton.Enabled = false;
            }
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TryToEnableAddButton();

            this.reorderButton.Enabled = this.categoryList.SelectedItems.Count == 1;
            this.checkDupe.Enabled = this.categoryList.SelectedItems.Count == 1;
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            var addCatForm = AddCategory.Create(this.parser);
            if (addCatForm.ShowDialog() == DialogResult.OK)
            {
                this.parser = addCatForm.Parser;
                this.ResetCategories();
            }
        }

        private void ResetCategories()
        {
            categoryList.Items.Clear();
            categoryList.BeginUpdate();
            foreach (var category in this.parser.Categories)
            {
                categoryList.Items.Add(category);
            }

            categoryList.EndUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dirty)
            {
                e.Cancel = MessageBox.Show("You've made changes.  You sure you want to close without saving?", "Hold up!", MessageBoxButtons.YesNo) ==
                           DialogResult.No;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.autoClearDupes = this.checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TMP: doesn't do anything, not needed anymore
            AddItems(true);
        }

        private void reorder_Click(object sender, EventArgs e)
        {
            var ind = categoryList.SelectedIndex;
            var form = new Reorder(this.parser, (AchievementParser.VisualCategory)categoryList.SelectedItem);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.parser = form.Parser;
                this.ResetCategories();
            }

            categoryList.SelectedIndex = ind;
        }

        private void FixPoints()
        {
            var ap = (AchievementParser)this.parser;

            var sb = new StringBuilder("messed: (");
            var missing = new StringBuilder("missing:" + Environment.NewLine);
            var checkedCount = 0;
            foreach (var sc in ap.Achievements.supercats)
            {
                if (sc.name == "Legacy" || sc.name == "Feats of Strength")
                {
                    continue;
                }

                foreach (var c in sc.cats)
                {
                    foreach (var z in c.zones)
                    {
                        foreach (var a in z.achs)
                        {
                            // Query blizzard
                            try
                            {
                                checkedCount++;
                                var ba = BlizzardParser.Parse(a.id);
                                if (ba.points != a.points)
                                {
                                    sb.AppendLine(ba.id + " : " + ba.title);
                                    a.points = ba.points;
                                }
                            }
                            catch (Exception e)
                            {
                                missing.AppendLine(a.id);
                            }
                        }
                    }
                }
            }

            sb.Append(checkedCount + ")" + Environment.NewLine);
            MessageBox.Show(sb.ToString());
            MessageBox.Show(missing.ToString());
        }

        private void checkDupe_Click(object sender, EventArgs e)
        {
            var ap = (PetParser) this.parser;

            var hash = new HashSet<string>();
            var dupes = new List<string>();


            foreach(var pc in ap.PetCats)
            {
                foreach (var sc in pc.subcats)
                {
                    foreach (var item in sc.items)
                    {
                        if (hash.Contains(item.spellid))
                        {
                            dupes.Add(item.spellid);
                        }
                        else
                        {
                            hash.Add(item.spellid);
                        }
                    }
                }
            }

            var sb = new StringBuilder("Dupes: ");
            foreach (var dupe in dupes)
            {
                sb.AppendLine(dupe);
            }

            if (hash.Count > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            
        }
    }
}
