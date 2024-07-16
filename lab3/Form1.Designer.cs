namespace lab2;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        groupBox1 = new GroupBox();
        createButton = new Button();
        noRadioButton = new RadioButton();
        yesRadioButton = new RadioButton();
        label4 = new Label();
        sugarTextBox = new TextBox();
        label3 = new Label();
        nameTextBox = new TextBox();
        label2 = new Label();
        factoryComboBox = new ComboBox();
        label1 = new Label();
        listView = new ListView();
        imageList = new ImageList(components);
        logTextBox = new TextBox();
        timer1 = new System.Windows.Forms.Timer(components);
        menuStrip1 = new MenuStrip();
        файлToolStripMenuItem = new ToolStripMenuItem();
        импортироватьToolStripMenuItem = new ToolStripMenuItem();
        jsonImpToolStripMenuItem = new ToolStripMenuItem();
        binImpToolStripMenuItem = new ToolStripMenuItem();
        экспортироватьToolStripMenuItem = new ToolStripMenuItem();
        jsonExpToolStripMenuItem1 = new ToolStripMenuItem();
        binExpToolStripMenuItem1 = new ToolStripMenuItem();
        добавитьКлассToolStripMenuItem = new ToolStripMenuItem();
        добавитьПлагинToolStripMenuItem = new ToolStripMenuItem();
        PluginComboBox = new ToolStripComboBox();
        toolStripTextBox1 = new ToolStripTextBox();
        cacheComboBox = new ToolStripComboBox();
        saveFileDialog1 = new SaveFileDialog();
        openFileDialog1 = new OpenFileDialog();
        groupBox1.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(createButton);
        groupBox1.Controls.Add(noRadioButton);
        groupBox1.Controls.Add(yesRadioButton);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(sugarTextBox);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(nameTextBox);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(factoryComboBox);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new Point(5, 44);
        groupBox1.Margin = new Padding(4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(4);
        groupBox1.Size = new Size(438, 855);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Создание объекта";
        // 
        // createButton
        // 
        createButton.Location = new Point(16, 767);
        createButton.Name = "createButton";
        createButton.Size = new Size(400, 64);
        createButton.TabIndex = 9;
        createButton.Text = "Создать";
        createButton.UseVisualStyleBackColor = true;
        createButton.Click += createButton_Click;
        // 
        // noRadioButton
        // 
        noRadioButton.AutoSize = true;
        noRadioButton.Checked = true;
        noRadioButton.Location = new Point(143, 606);
        noRadioButton.Name = "noRadioButton";
        noRadioButton.Size = new Size(88, 42);
        noRadioButton.TabIndex = 8;
        noRadioButton.TabStop = true;
        noRadioButton.Text = "Нет";
        noRadioButton.UseVisualStyleBackColor = true;
        // 
        // yesRadioButton
        // 
        yesRadioButton.AutoSize = true;
        yesRadioButton.Location = new Point(27, 606);
        yesRadioButton.Name = "yesRadioButton";
        yesRadioButton.Size = new Size(75, 42);
        yesRadioButton.TabIndex = 7;
        yesRadioButton.TabStop = true;
        yesRadioButton.Text = "Да";
        yesRadioButton.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(7, 536);
        label4.Name = "label4";
        label4.Size = new Size(269, 38);
        label4.TabIndex = 6;
        label4.Text = "Добавлять молоко?";
        // 
        // sugarTextBox
        // 
        sugarTextBox.Location = new Point(7, 430);
        sugarTextBox.Name = "sugarTextBox";
        sugarTextBox.Size = new Size(147, 45);
        sugarTextBox.TabIndex = 5;
        sugarTextBox.Text = "0";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(7, 368);
        label3.Name = "label3";
        label3.Size = new Size(307, 38);
        label3.TabIndex = 4;
        label3.Text = "Введите кол-во сахара";
        // 
        // nameTextBox
        // 
        nameTextBox.Location = new Point(7, 266);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(370, 45);
        nameTextBox.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(7, 210);
        label2.Name = "label2";
        label2.Size = new Size(287, 38);
        label2.TabIndex = 2;
        label2.Text = "Введите имя напитка";
        // 
        // factoryComboBox
        // 
        factoryComboBox.FormattingEnabled = true;
        factoryComboBox.Location = new Point(7, 121);
        factoryComboBox.Name = "factoryComboBox";
        factoryComboBox.Size = new Size(259, 46);
        factoryComboBox.TabIndex = 1;
        factoryComboBox.SelectedIndexChanged += factoryComboBox_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(7, 68);
        label1.Name = "label1";
        label1.Size = new Size(259, 38);
        label1.TabIndex = 0;
        label1.Text = "Выберите фабрику";
        // 
        // listView
        // 
        listView.Location = new Point(466, 61);
        listView.MultiSelect = false;
        listView.Name = "listView";
        listView.Size = new Size(1272, 736);
        listView.SmallImageList = imageList;
        listView.TabIndex = 1;
        listView.UseCompatibleStateImageBehavior = false;
        listView.View = View.List;
        listView.SelectedIndexChanged += listView_SelectedIndexChanged;
        // 
        // imageList
        // 
        imageList.ColorDepth = ColorDepth.Depth32Bit;
        imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
        imageList.TransparentColor = Color.Transparent;
        imageList.Images.SetKeyName(0, "tea.png");
        imageList.Images.SetKeyName(1, "coffee.png");
        imageList.Images.SetKeyName(2, "chicory.png");
        imageList.Images.SetKeyName(3, "cola.png");
        // 
        // logTextBox
        // 
        logTextBox.Location = new Point(466, 854);
        logTextBox.Name = "logTextBox";
        logTextBox.Size = new Size(1272, 45);
        logTextBox.TabIndex = 2;
        // 
        // timer1
        // 
        timer1.Enabled = true;
        timer1.Tick += timer1_Tick;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(28, 28);
        menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, PluginComboBox, toolStripTextBox1, cacheComboBox });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1771, 42);
        menuStrip1.TabIndex = 3;
        menuStrip1.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { импортироватьToolStripMenuItem, экспортироватьToolStripMenuItem, добавитьКлассToolStripMenuItem, добавитьПлагинToolStripMenuItem });
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Size = new Size(80, 38);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // импортироватьToolStripMenuItem
        // 
        импортироватьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jsonImpToolStripMenuItem, binImpToolStripMenuItem });
        импортироватьToolStripMenuItem.Name = "импортироватьToolStripMenuItem";
        импортироватьToolStripMenuItem.Size = new Size(296, 40);
        импортироватьToolStripMenuItem.Text = "Импортировать";
        // 
        // jsonImpToolStripMenuItem
        // 
        jsonImpToolStripMenuItem.Name = "jsonImpToolStripMenuItem";
        jsonImpToolStripMenuItem.Size = new Size(169, 40);
        jsonImpToolStripMenuItem.Text = "json";
        jsonImpToolStripMenuItem.Click += jsonImpToolStripMenuItem_Click;
        // 
        // binImpToolStripMenuItem
        // 
        binImpToolStripMenuItem.Name = "binImpToolStripMenuItem";
        binImpToolStripMenuItem.Size = new Size(169, 40);
        binImpToolStripMenuItem.Text = "bin";
        binImpToolStripMenuItem.Click += binImpToolStripMenuItem_Click;
        // 
        // экспортироватьToolStripMenuItem
        // 
        экспортироватьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jsonExpToolStripMenuItem1, binExpToolStripMenuItem1 });
        экспортироватьToolStripMenuItem.Name = "экспортироватьToolStripMenuItem";
        экспортироватьToolStripMenuItem.Size = new Size(296, 40);
        экспортироватьToolStripMenuItem.Text = "Экспортировать";
        // 
        // jsonExpToolStripMenuItem1
        // 
        jsonExpToolStripMenuItem1.Name = "jsonExpToolStripMenuItem1";
        jsonExpToolStripMenuItem1.Size = new Size(169, 40);
        jsonExpToolStripMenuItem1.Text = "json";
        jsonExpToolStripMenuItem1.Click += jsonExpToolStripMenuItem_Click;
        // 
        // binExpToolStripMenuItem1
        // 
        binExpToolStripMenuItem1.Name = "binExpToolStripMenuItem1";
        binExpToolStripMenuItem1.Size = new Size(169, 40);
        binExpToolStripMenuItem1.Text = "bin";
        binExpToolStripMenuItem1.Click += binExpToolStripMenuItem_Click;
        // 
        // добавитьКлассToolStripMenuItem
        // 
        добавитьКлассToolStripMenuItem.Name = "добавитьКлассToolStripMenuItem";
        добавитьКлассToolStripMenuItem.Size = new Size(296, 40);
        добавитьКлассToolStripMenuItem.Text = "Добавить класс";
        добавитьКлассToolStripMenuItem.Click += addClassToolStripMenuItem_Click;
        // 
        // добавитьПлагинToolStripMenuItem
        // 
        добавитьПлагинToolStripMenuItem.Name = "добавитьПлагинToolStripMenuItem";
        добавитьПлагинToolStripMenuItem.Size = new Size(296, 40);
        добавитьПлагинToolStripMenuItem.Text = "Добавить плагин";
        добавитьПлагинToolStripMenuItem.Click += addPluginToolStripMenuItem_Click;
        // 
        // PluginComboBox
        // 
        PluginComboBox.Name = "PluginComboBox";
        PluginComboBox.Size = new Size(300, 38);
        PluginComboBox.SelectedIndexChanged += PluginComboBox_SelectedIndexChanged;
        // 
        // toolStripTextBox1
        // 
        toolStripTextBox1.Name = "toolStripTextBox1";
        toolStripTextBox1.Size = new Size(300, 38);
        // 
        // cacheComboBox
        // 
        cacheComboBox.Items.AddRange(new object[] { "Кэш выключен", "Кэш ВКЛЮЧЕН" });
        cacheComboBox.Name = "cacheComboBox";
        cacheComboBox.Size = new Size(250, 38);
        cacheComboBox.Tag = "";
        cacheComboBox.SelectedIndexChanged += cacheComboBox_SelectedIndexChanged;
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(15F, 38F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1771, 907);
        Controls.Add(logTextBox);
        Controls.Add(listView);
        Controls.Add(groupBox1);
        Controls.Add(menuStrip1);
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        Closed += Form1_Closed;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBox1;
    private TextBox nameTextBox;
    private Label label2;
    private ComboBox factoryComboBox;
    private Label label1;
    private RadioButton noRadioButton;
    private RadioButton yesRadioButton;
    private Label label4;
    private TextBox sugarTextBox;
    private Label label3;
    private Button createButton;
    private ListView listView;
    private TextBox logTextBox;
    private ImageList imageList;
    private System.Windows.Forms.Timer timer1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem импортироватьToolStripMenuItem;
    private ToolStripMenuItem jsonImpToolStripMenuItem;
    private ToolStripMenuItem binImpToolStripMenuItem;
    private ToolStripMenuItem экспортироватьToolStripMenuItem;
    private ToolStripMenuItem jsonExpToolStripMenuItem1;
    private ToolStripMenuItem binExpToolStripMenuItem1;
    private SaveFileDialog saveFileDialog1;
    private OpenFileDialog openFileDialog1;
    private ToolStripMenuItem добавитьКлассToolStripMenuItem;
    private ToolStripComboBox PluginComboBox;
    private ToolStripMenuItem добавитьПлагинToolStripMenuItem;
    private ToolStripTextBox toolStripTextBox1;
    private ToolStripComboBox cacheComboBox;
}