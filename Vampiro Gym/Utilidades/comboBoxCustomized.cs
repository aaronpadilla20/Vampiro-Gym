using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace Vampiro_Gym.Utilities
{
    [DefaultEvent("OnSelectedIndexChanged")]
    class comboBoxCustomized : UserControl
    {
        //Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;
        private ContentAlignment alignment;

        //Items
        private ComboBox cbList;
        private Label lblText;
        private Button btnIcon;

        //Properties
        //=>Apperance
        [Category ("comboBox Code - Apperance")]
        public new Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("comboBox Code - Apperance")]
        public Color IconColor
        {
            get
            {
                return iconColor;
            }
            set
            {
                iconColor = value;
                btnIcon.Invalidate(); // Redraw icon
            }
        }

        [Category("comboBox Code - Apperance")]
        public Color ListBackColor
        {
            get
            {
                return listBackColor;
            }
            set
            {
                listBackColor = value;
                cbList.BackColor = listBackColor;
            }
        }

        [Category("comboBox Code - Apperance")]
        public Color ListTextColor
        {
            get
            {
                return listTextColor;
            }
            set
            {
                listTextColor = value;
                cbList.ForeColor = listTextColor;
            }
        }

        [Category("comboBox Code - Apperance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }

        [Category("comboBox Code - Apperance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize); //Border Size
                AdjustComboBoxDimensions();
            }
        }

        [Category("comboBox Code - Apperance")]
        public ContentAlignment Alignment
        {
            get
            {
                return alignment;
            }
            set
            {
                alignment = value;
                lblText.TextAlign = value;
            }
        }

        [Category("comboBox Code - Apperance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        [Category("comboBox Code - Apperance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cbList.Font = value; //Optional
            }
        }

        [Category("comboBox Code - Apperance")]
        public string Texts
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        [Category("comboBox Code - Apperance")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cbList.DropDownStyle; }
            set 
            {
                if(cbList.DropDownStyle != ComboBoxStyle.Simple)
                    cbList.DropDownStyle = value;
            }
        }
        //<=Apperance

        //Data
        [Category ("comboBox Code - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return cbList.Items; }
        }

        [Category("comboBox Code - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get { return cbList.DataSource; }
            set { cbList.DataSource = value; }
        }

        [Category("comboBox Code - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return cbList.AutoCompleteCustomSource; }
            set { cbList.AutoCompleteCustomSource = value; }
        }

        [Category("comboBox Code - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return cbList.AutoCompleteSource; }
            set { cbList.AutoCompleteSource = value; }
        }

        [Category("comboBox Code - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return cbList.AutoCompleteMode; }
            set { cbList.AutoCompleteMode = value; }
        }

        [Category("comboBox Code - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return cbList.SelectedItem; }
            set { cbList.SelectedItem = value; }
        }

        [Category("comboBox Code - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return cbList.SelectedIndex; }
            set { cbList.SelectedIndex = value; }
        }

        //Events
        public event EventHandler OnSelectedIndexChanged;

        //Constructor
        public comboBoxCustomized()
        {
            cbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            //ComboBox: DropDown list
            cbList.BackColor = this.listBackColor;
            cbList.Font = new Font(this.Font.Name, 10f);
            cbList.ForeColor = this.listTextColor;
            cbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged); //Default event
            cbList.TextChanged += new EventHandler(ComboBox_TextChanged); //Refresh Text

            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = this.backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click); //Open drop down list 
            btnIcon.Paint += new PaintEventHandler(Icon_Paint); //Drawn Icon

            //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = this.backColor;
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10f);
            lblText.Click += new EventHandler(Surface_Click); //Select Combo box

            //User Control
            this.Controls.Add(lblText); //2
            this.Controls.Add(btnIcon); //1
            this.Controls.Add(cbList); //0
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(this.borderSize);
            base.BackColor = this.borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        //Private methods
        private void AdjustComboBoxDimensions()
        {
            cbList.Width = lblText.Width;
            cbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cbList.Width,
                Y = lblText.Bottom - cbList.Height
            };
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            //Select ComboBox
            lblText.Text = "";
            cbList.Select();
            if(cbList.DropDownStyle==ComboBoxStyle.DropDownList)
            {
                cbList.DroppedDown = true; //Open drop down list 
            }
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            //Fields
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            //Draw arrow down icon
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(this.iconColor,2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen,path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cbList.Select();
            cbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            //Refresh Text
            lblText.Text = cbList.Text;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged!=null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);
            }
            lblText.Text = cbList.Text;
        }
    }
}
