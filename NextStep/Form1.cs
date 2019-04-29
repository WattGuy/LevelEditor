using NextStep.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace NextStep
{

    public partial class Form1 : Form
    {

        public static Dictionary<string, Dot> dots = new Dictionary<string, Dot>();
        public static Form1 instance;
        public static Dot selected = null;
        public static List<string> dlcItems = null;
        public static List<string> onItems = null;
        public static Dictionary<string, HeroType> hts = null;
        public static Dictionary<KeyValuePair<HeroType, DLCType>, Bitmap> imgs = null;
        public static Dictionary<Dot, On> ons = new Dictionary<Dot, On>();
        public static Dictionary<string, OnType> ots = null;

        public Form1()
        {

            instance = this;
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e) {

            ResourceManager rm = Resources.ResourceManager;

            imgs = new Dictionary<KeyValuePair<HeroType, DLCType>, Bitmap>();
            foreach (HeroType ht in Enum.GetValues(typeof(HeroType)).Cast<HeroType>())
            {

                foreach (DLCType dt in Enum.GetValues(typeof(DLCType)).Cast<DLCType>())
                {
                    string s;
                    if (dt == DLCType.NONE)
                    {

                        s = getName(ht);

                    }
                    else s = getName(ht) + "_" + getName(dt);

                    try
                    {
                        Bitmap b = (Bitmap) rm.GetObject(s);

                        if (b != null) {

                            KeyValuePair<HeroType, DLCType> p = new KeyValuePair<HeroType, DLCType>(ht, dt);
                            imgs.Add(p, b);

                        }
                        
                    }
                    catch (Exception ex) {}

                }

            }

            for (int x = 1; x <= 7; x++)
            {

                for (int y = 1; y <= 8; y++)
                {

                    dots.Add(x + ":" + y, new Dot(x, y));

                }

            }

            dlcItems = new List<string>();
            for (int i = 0; i < dlcBox.Items.Count; i++)
            {

                dlcItems.Add((string)dlcBox.Items[i]);

            }

            onItems = new List<string>();
            for (int i = 0; i < onBox.Items.Count; i++)
            {

                onItems.Add((string)onBox.Items[i]);

            }

            hts = new Dictionary<string, HeroType>();
            for (int i = 0; i < typeBox.Items.Count; i++)
            {
                string s = (string)typeBox.Items[i];
                HeroType? ht = getHTypeByInt(i);
                if (ht == null) continue;

                hts.Add(s, (HeroType)ht);
                if (!notColor((HeroType) ht)) {

                    addTypeBox.Items.Add(s);

                }

            }

             ots = new Dictionary<string, OnType>();
            for (int i = 0; i < onBox.Items.Count; i++)
            {
                string s = (string)onBox.Items[i];
                OnType? ot = getOTypeByInt(i);
                if (ot == null) continue;

                ots.Add(s, (OnType)ot);

            }

            addTypeBox.Items.Add("ЛЁД");
            addTypeBox.Items.Add("ЦЕПИ");
            addTypeBox.SelectedIndex = 0;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ТИП";
            column1.Name = "type";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.Width = 154;

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "КОЛИЧЕСТВО";
            column2.Name = "number";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            column2.Width = 155;

            targetsData.Columns.Add(column1);
            targetsData.Columns.Add(column2);

            typeBox.SelectedIndex = 0;
            onBox.SelectedIndex = 0;
            updateDLCBox();
            selected = dots["1:8"];
            updateOnBox();
            //select(dots["1:8"]);
            // DotData[] datas = { new DotData(HeroType.CONCRETE, "5:5") };
            //TargetData[] targets = { new TargetData(HeroType.BLUE, 50) };
            //saveLevel(new LevelData(datas, targets, 30), "D:/hi.json");

        }

        private void select(Dot d) {

            if (selected != null) {

                selected.getBox().BorderStyle = BorderStyle.None;

            }

            d.getBox().BorderStyle = BorderStyle.FixedSingle;
            selected = d;

        }

        public static Bitmap getImage(OnType ot)
        {
            ResourceManager rm = Resources.ResourceManager;

            try
            {
                Bitmap b = (Bitmap)rm.GetObject(getName(ot.ToString()));

                if (b != null) return b;

            }
            catch (Exception e) { }

            return null;

        }

        public static Bitmap getImage(HeroType ht, DLCType dt) {

            try
            {
                return imgs[new KeyValuePair<HeroType, DLCType>(ht, dt)];

            }
            catch (Exception e) { }

            return null;

        }

        public static string getName(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s[0]);
            s = s.ToLower();

            for (int i = 1; i < s.Length; i++)
            {

                sb.Append(s[i]);

            }

            return sb.ToString();

        }

        public string getName(HeroType ht) {

            return getName(ht.ToString());

        }

        public string getName(DLCType dt)
        {

            return getName(dt.ToString());

        }

        public void updateDLCBox() {

            if (notColor(hts[(string) typeBox.Items[typeBox.SelectedIndex]]))
            {

                dlcBox.Items.Clear();
                dlcBox.Items.Add(dlcItems[0]);
                dlcBox.SelectedIndex = 0;

            }
            else
            {

                dlcBox.Items.Clear();

                foreach (string s in dlcItems)
                {

                    dlcBox.Items.Add(s);

                }

                dlcBox.SelectedIndex = (int) selected.getDType();

            }

        }

        public void updateOnBox()
        {

            if (hts[(string)typeBox.Items[typeBox.SelectedIndex]] == HeroType.CONCRETE)
            {

                onBox.Items.Clear();
                onBox.Items.Add(onItems[0]);
                onBox.SelectedIndex = 0;

            }
            else
            {

                onBox.Items.Clear();

                foreach (string s in onItems)
                {

                    onBox.Items.Add(s);

                }

                onBox.SelectedIndex = 0;

            }

        }

        public static Point getLocation(int x, int y) {

            return new Point(12 + (65 * (x - 1)), 465 - (65 * (y - 1)));

        }

        public static bool notColor(HeroType ht) {

            if (ht == HeroType.CONCRETE || ht == HeroType.RANDOM)
            {

                return true;

            }
            else return false;

        }

        public enum HeroType {
            RANDOM = 0, BLUE = 1, GREEN = 2, PINK = 3, ORANGE = 4, LIGHTGREEN = 5, CONCRETE = 6
        }

        public enum DLCType {
            NONE = 0, ADJACENT = 1, HORIZONTAL = 2, VERTICAL = 3, BOMB = 4
        }

        public enum OnType {
            NONE = 0, ICE = 1, CHAINS = 2
        }

        public static HeroType? getHTypeByInt(int i)
        {

            foreach (HeroType ht in Enum.GetValues(typeof(HeroType)).Cast<HeroType>())
            {

                if ((int) ht == i)
                {

                    return ht;

                }

            }

            return null;
        }

        public static OnType? getOTypeByInt(int i)
        {

            foreach (OnType ot in Enum.GetValues(typeof(OnType)).Cast<OnType>())
            {

                if ((int)ot == i)
                {

                    return ot;

                }

            }

            return null;
        }

        public static OnType? getOTypeByString(string s)
        {

            foreach (OnType ot in Enum.GetValues(typeof(OnType)).Cast<OnType>())
            {

                if (ot.ToString() == s)
                {

                    return ot;

                }

            }

            return null;
        }

        public static HeroType? getHTypeByString(string s) {

            foreach (HeroType ht in Enum.GetValues(typeof(HeroType)).Cast<HeroType>()) {

                if (ht.ToString() == s) {

                    return ht;

                }

            }

            return null;
        }

        public static DLCType? getDTypeByString(string s)
        {

            foreach (DLCType dt in Enum.GetValues(typeof(DLCType)).Cast<DLCType>())
            {

                if (dt.ToString() == s)
                {

                    return dt;

                }

            }

            return null;
        }

        public static DLCType? getDTypeByInt(int i)
        {

            foreach (DLCType dt in Enum.GetValues(typeof(DLCType)).Cast<DLCType>())
            {

                if ((int) dt == i)
                {

                    return dt;

                }

            }

            return null;
        }

        public class On {

            private Dot d;
            private OnType ot;
            private PictureBox box;

            public On(Dot d, OnType ot) {

                this.d = d;
                this.ot = ot;

                box = new PictureBox();
                box.BackgroundImageLayout = ImageLayout.Zoom;
                updateImage();
                box.Name = "x" + d.getX() + "y" + d.getY();
                box.Size = new Size(60, 60);
                box.MouseMove += new MouseEventHandler(Form1.instance.dot_MouseMove);
                box.MouseDown += new MouseEventHandler(Form1.instance.dot_MouseDown);
                box.MouseUp += new MouseEventHandler(Form1.instance.dot_MouseUp);
                Form1.instance.Controls.Add(box);
                box.BringToFront();
                box.Parent = d.getBox();
                box.BackColor = Color.Transparent;

            }

            private void updateImage()
            {
                Bitmap img = getImage(ot);

                if (img != null)
                {

                    box.BackgroundImage = img;

                }
                else box.BackgroundImage = Resources.Random;

            }

            public OnType getOType() {
                return ot;
            }

            public void setOType(OnType ot)
            {
                this.ot = ot;
            }

            public void destroy() {
                d.getBox().Controls.Remove(box);
            }

        }

        public class Dot
        {

            private int x;
            private int y;
            private PictureBox box;
            private HeroType ht = HeroType.RANDOM;
            private DLCType dt = DLCType.NONE;

            public Dot(int x, int y)
            {

                this.x = x;
                this.y = y;
                box = new PictureBox();
                box.Location = getLocation(x, y);
                box.Size = new Size(60, 60);
                box.BackgroundImageLayout = ImageLayout.Zoom;
                box.Name = "x" + x + "y" + y;
                box.MouseMove += new MouseEventHandler(Form1.instance.dot_MouseMove);
                box.MouseDown += new MouseEventHandler(Form1.instance.dot_MouseDown);
                box.MouseUp += new MouseEventHandler(Form1.instance.dot_MouseUp);
                updateImage();
                Form1.instance.Controls.Add(box);
                box.BackColor = Color.Transparent;
                box.SendToBack();

            }

            public int getX()
            {
                return x;
            }

            public int getY()
            {
                return y;
            }

            public PictureBox getBox()
            {
                return box;
            }

            public HeroType getHType() {
                return ht;
            }

            public void setHType(HeroType n) {
                this.ht = n;
                updateImage();
            }

            public DLCType getDType()
            {
                return dt;
            }

            public void setDType(DLCType n)
            {
                this.dt = n;
                updateImage();
            }

            private void updateImage() {
                Bitmap img = getImage(ht, dt);

                if (img != null) {

                    box.BackgroundImage = img;

                }
                else box.BackgroundImage = Resources.Random;

            }

        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e) {
            updateDLCBox();
            updateOnBox();
        }

        private void addTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeButton_MouseClick(object sender, MouseEventArgs e)
        {
            removeSelectedRow();
        }

        public void removeSelectedRow() {

            foreach (DataGridViewCell oneCell in targetsData.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    targetsData.Rows.RemoveAt(oneCell.RowIndex);
                }
            }

        }

        private void targetsData_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete) {

                removeSelectedRow();

            }

        }

        private void addButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (targetsData.RowCount <= 8) {

                targetsData.Rows.Add(addTypeBox.Text, addNumberBox.Value);

            }
        }

        [System.Serializable]
        public class TargetData
        {

            public string type = "";
            public string otype = "";
            public int target = 0;

            public TargetData(string type, string otype, int i)
            {

                this.type = type;
                this.otype = otype;
                target = i;

            }

            public HeroType? getType()
            {

                return getHTypeByString(type);

            }

            public OnType? getOType()
            {

                return getOTypeByString(type);

            }

        }

        [System.Serializable]
        public class DotData
        {

            public string position = "";
            public string type = "";
            public string dtype = "";
            public string otype = "";

            public DotData(string ht, DLCType dt, OnType ot, string position)
            {

                this.position = position;
                type = ht;
                dtype = dt.ToString();
                otype = ot.ToString();

            }

        }

        [System.Serializable]
        public class LevelData
        {

            public List<DotData> dots;
            public List<TargetData> targets;
            public int steps;
            public int energy;

            public LevelData(List<DotData> dots, List<TargetData> targets, int steps, int energy)
            {

                this.dots = dots;
                this.targets = targets;
                this.steps = steps;
                this.energy = energy;

            }

        }

        public static void saveLevel(LevelData d, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);

            byte[] contentBytes = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(d));
            stream.Write(contentBytes, 0, contentBytes.Length);
            stream.Close();
        }

        public static LevelData loadLevel(string path)
        {
            LevelData d = null;

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string s = r.ReadToEnd();
                    d = JsonConvert.DeserializeObject<LevelData>(s);
                }
            }
            catch (Exception e) { }

            return d;
        }

        public LevelData getLevel() {
            List<DotData> dots = new List<DotData>();

            foreach (Dot d in Form1.dots.Values) {
                if (d.getHType() == HeroType.RANDOM && ((!Form1.ons.ContainsKey(d)) || (ons[d].getOType() == OnType.NONE))) continue;

                OnType ot;
                if (Form1.ons.ContainsKey(d))
                {

                    ot = Form1.ons[d].getOType();

                }
                else ot = OnType.NONE;

                if (d.getHType() == HeroType.RANDOM)
                {

                    dots.Add(new DotData("NONE", d.getDType(), ot, d.getX() + ":" + d.getY()));

                }
                else {

                    dots.Add(new DotData(d.getHType().ToString(), d.getDType(), ot, d.getX() + ":" + d.getY()));

                }
                

            }

            Dictionary<HeroType, TargetData> targets = new Dictionary<HeroType, TargetData>();
            Dictionary<OnType, TargetData> targets2 = new Dictionary<OnType, TargetData>();
            foreach (DataGridViewRow row in instance.targetsData.Rows)
            {
                if (hts.ContainsKey(((string)row.Cells["type"].Value)))
                {
                    HeroType ht = hts[((string)row.Cells["type"].Value)];

                    targets.Add((HeroType)ht, new TargetData(ht.ToString(), "", Decimal.ToInt32((decimal)row.Cells["number"].Value)));
                } else if (ots.ContainsKey(((string)row.Cells["type"].Value))) {

                    OnType ot = ots[((string)row.Cells["type"].Value)];

                    targets2.Add((OnType)ot, new TargetData("", ot.ToString(), Decimal.ToInt32((decimal)row.Cells["number"].Value)));

                }

            }

            List<TargetData> list = new List<TargetData>();
            list.AddRange(targets.Values);
            list.AddRange(targets2.Values);

            return new LevelData(dots, list.ToList(), (int) stepsBox.Value, (int) energyBox.Value);
        }

        public void setLevel(LevelData d) {
            List<Dot> dots = Form1.dots.Values.ToList();

            foreach (On o in ons.Values) {

                o.destroy();

            }

            ons.Clear();

            if (d.dots != null) {

                foreach (DotData data in d.dots)
                {
                    if (!Form1.dots.ContainsKey(data.position)) continue;
                    Dot dot = Form1.dots[data.position];

                    OnType? ot = getOTypeByString(data.otype);
                    if (ot != null && ot != OnType.NONE)
                    {
                        ons.Add(dot, new On(dot, (OnType)ot));
                        dots.Remove(dot);
                    }

                    HeroType? ht = getHTypeByString(data.type);
                    if (ht == null) continue;

                    dot.setHType((HeroType)ht);

                    DLCType? dt = getDTypeByString(data.dtype);
                    if (dt != null) {

                        dot.setDType((DLCType)dt);

                    }
                    dots.Remove(dot);

                }

            }

            foreach (Dot dot in dots) {

                dot.setHType(HeroType.RANDOM);
                dot.setDType(DLCType.NONE);

            }

            targetsData.Rows.Clear();
            foreach (TargetData data in d.targets) {
                HeroType? ht = getHTypeByString(data.type);
                if (ht != null)
                {
                    targetsData.Rows.Add((string)typeBox.Items[(int) ht], data.target);
                    continue;
                }

                OnType? ot = getOTypeByString(data.otype);
                if (ot != null)
                {
                    targetsData.Rows.Add((string)onItems[(int) ot], data.target);
                }

            }

            stepsBox.Value = d.steps;
            energyBox.Value = d.energy;

        }

        private void saveButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (targetsData.Rows.Count < 1) {
                MessageBox.Show("Должна быть как минимум 1 цель!");
                return;
            }
            saveFileDialog.Filter = "|*.json";
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            saveLevel(getLevel(), saveFileDialog.FileName);
            MessageBox.Show("Уровень успешно сохранён!");

        }

        public static bool selecting = false;

        private void dot_MouseDown(object sender, MouseEventArgs e)
        {
            selecting = true; 
            dot_MouseMove(sender, e);
        }

        private void dot_MouseUp(object sender, MouseEventArgs e)
        {
            selecting = false;
        }

        public static Control getControl(Point p) {

            foreach (Dot d in dots.Values) {

                if (d.getBox().DisplayRectangle.Contains(p.X, p.Y)) return d.getBox();
                else continue;

            }

            return null;

        }

        private void dot_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point p = PointToClient(Cursor.Position);
                Control c = GetChildAtPoint(p);
                if (c == null || !(c is PictureBox)) return;
                string[] s = ((PictureBox) c).Name.Split('y');
                s[0] = s[0].Replace("x", "");
                Dot d = dots[s[0] + ":" + s[1]];
                if (d.getBox().BorderStyle != BorderStyle.FixedSingle) select(d);
                if (!selecting) return;

                HeroType ht = hts[(string) typeBox.Items[typeBox.SelectedIndex]];
                DLCType dt = (DLCType)getDTypeByInt(dlcBox.SelectedIndex);
                OnType ot = (OnType)getOTypeByInt(onBox.SelectedIndex);
                if (d.getHType() != ht) d.setHType(ht);
                if (d.getDType() != dt) d.setDType(dt);
                if (ons.ContainsKey(d) && ot == OnType.NONE)
                {

                    ons[d].destroy();
                    ons.Remove(d);

                }
                else if (!ons.ContainsKey(d) && ot != OnType.NONE) {

                    ons.Add(d, new On(d, ot));


                }
                else if (ons.ContainsKey(d) && ons[d].getOType() != ot)
                {

                    ons[d].setOType(ot);

                }


            }
            catch (Exception ex) { }

        }

        private void openButton_MouseClick(object sender, MouseEventArgs e)
        {
            openFileDialog.Filter = "|*.json";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            setLevel(loadLevel(openFileDialog.FileName));
            MessageBox.Show("Уровень успешно открыт!");
        }

    }
}
