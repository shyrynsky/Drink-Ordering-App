using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using lab2.Factories;
using BaseClassLibrary;
using lab2.Plugins;

namespace lab2;

public partial class Form1 : Form
{
    public Form1(ILogger logger)
    {
        _logger = logger;
        InitializeComponent();
    }

    private readonly List<(string, IFactory)> _factoryArr =
    [
        ("чай", new TeaFactory()),
        ("кофе", new CoffeeFactory()),
        ("цикорий", new ChicoryFactory())
    ];

    public List<Drink> DrinkList = new();

    private IFactory _factory = null!;

    private readonly List<IFilePlugin> _pluginArr = [new DefaultPlugin()];

    private IFilePlugin _plugin = null!;

    private readonly ILogger _logger;

    private void factoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        _factory = _factoryArr[factoryComboBox.SelectedIndex].Item2;
    }

    public void Form1_Load(object sender, EventArgs e)
    {
        foreach (var factory in _factoryArr)
        {
            factoryComboBox.Items.Add(factory.Item1);
        }

        foreach (var filePlugin in _pluginArr)
        {
            PluginComboBox.Items.Add(filePlugin.PluginName);
        }

        factoryComboBox.SelectedIndex = 0;
        _factory = _factoryArr[0].Item2;

        PluginComboBox.SelectedIndex = 0;
        _plugin = _pluginArr[0];

        cacheComboBox.SelectedIndex = 0;
    }

    private void Form1_Closed(object sender, EventArgs e)
    {
        _logger.Close();
    }

    public void AddItem(Drink drink)
    {
        var text = $"{drink.Name} c кол-вом сахара: {drink.Sugars}{(drink.Milk ? " и с молоком" : "")}";
        var listItem = new ListViewItem(text, drink.Img)
        {
            BackColor = drink.IsHot ? Color.LightPink : Color.LightBlue
        };
        listView.Items.Add(listItem);
        _logger.Add("Был добавлен " + text);
    }

    public void createButton_Click(object sender, EventArgs e)
    {
        var drink = _factory.NewDrink(nameTextBox.Text);
        drink.Milk = yesRadioButton.Checked;
        drink.Sugars = int.Parse(sugarTextBox.Text);

        DrinkList.Add(drink);
        AddItem(drink);

        noRadioButton.Checked = true;
        sugarTextBox.Text = @"0";
        nameTextBox.Text = "";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        for (var i = 0; i < DrinkList.Count; i++)
        {
            if (!DrinkList[i].IsHot)
                listView.Items[i].BackColor = Color.LightBlue;
        }
    }

    private void listView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView.SelectedIndices.Count > 0)
        {
            var index = listView.SelectedIndices[0];
            _logger.Add("Был удален " + listView.Items[index].Text);
            listView.Items.RemoveAt(index);
            logTextBox.Text = DrinkList[index].HaveADrink();
            DrinkList.RemoveAt(index);
        }
    }

    private static readonly List<JsonDerivedType> JsonDerivedTypes =
    [
        Coffee.JsonDerivedData,
        Tea.JsonDerivedData,
        Chicory.JsonDerivedData
    ];

    private static JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        TypeInfoResolver = new PolymorphicTypeResolver(JsonDerivedTypes)
    };

    private void jsonImpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался импорт json файла");

        using var fileStream = _plugin.GetInputStream(File.OpenRead(openFileDialog1.FileName), toolStripTextBox1.Text);

        DrinkList = JsonSerializer.Deserialize<List<Drink>>(fileStream, _jsonOptions) ?? [];

        listView.Items.Clear();
        DrinkList.ForEach(AddItem);
        _logger.Add("Закончился импорт json файла");
    }

    private void jsonExpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался экспорт json файла");

        using var fileStream = _plugin.GetOutputStream(File.Create(saveFileDialog1.FileName), toolStripTextBox1.Text);

        JsonSerializer.Serialize(fileStream, DrinkList, _jsonOptions);
        _logger.Add("Закончился экспорт json файла");
    }

    [Obsolete("Obsolete")]
    private void binImpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался импорт bin файла");

        using var fileStream = _plugin.GetInputStream(File.OpenRead(openFileDialog1.FileName), toolStripTextBox1.Text);

        var binFormatter = new BinaryFormatter();
        DrinkList = binFormatter.Deserialize(fileStream) as List<Drink> ?? [];

        listView.Items.Clear();
        DrinkList.ForEach(AddItem);
        _logger.Add("Закончился импорт bin файла");
    }

    [Obsolete("Obsolete")]
    private void binExpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался экспорт bin файла");
        using var fileStream = _plugin.GetOutputStream(File.Create(saveFileDialog1.FileName), toolStripTextBox1.Text);

        var binFormatter = new BinaryFormatter();
        binFormatter.Serialize(fileStream, DrinkList);
        _logger.Add("Закончился экспорт bin файла");
    }

    private static int[] _libHashArr = new int[16] { 179, 35, 18, 137, 68, 120, 190, 31, 164, 38, 35, 15, 130, 213, 11, 196 };

    private void addClassToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался импорт библиотеки классов");

        byte[] fileHash;
        using (var libFile = File.OpenRead(openFileDialog1.FileName))
        {
            fileHash = MD5.HashData(libFile);
        }
        for (var i = 0; i < fileHash.Length; i++)
        {
            if (fileHash[i] != _libHashArr[i])
            {
                MessageBox.Show(@"Неизвестная библиотека");
                _logger.Add("Ошибка: Неизвестная библиотека");

                return;
            }
        }

        try
        {
            var assembly = Assembly.LoadFrom(openFileDialog1.FileName);

            var obj = assembly.GetType("ClassLibrary.Program")?.GetMethod("Load")?.Invoke(null, null);
            (string, IFactory)[] factoryInfo;
            JsonDerivedType[] jsonInfo;
            (factoryInfo, jsonInfo) = (((string, IFactory)[], JsonDerivedType[]))obj!;
            _factoryArr.AddRange(factoryInfo);
            JsonDerivedTypes.AddRange(jsonInfo);
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = new PolymorphicTypeResolver(JsonDerivedTypes)
            };
            foreach (var factory in factoryInfo)
            {
                factoryComboBox.Items.Add(factory.Item1);
            }
        }
        catch(Exception exception)
        {
            MessageBox.Show(@"Ошибка при загрузке");
            _logger.Add("Ошибка при загрузке библиотеки классов: " + exception);
        }
        _logger.Add("Закончился импорт библиотеки классов");
    }

    private void PluginComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        _plugin = _pluginArr[PluginComboBox.SelectedIndex];
        cacheComboBox.SelectedIndex = 0;
    }

    private void addPluginToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK)
            return;
        _logger.Add("Начался импорт плагина");

        try
        {
            var assembly = Assembly.LoadFrom(openFileDialog1.FileName);

            var obj = assembly.GetType("PluginLibrary.Program")?.GetMethod("Load")?.Invoke(null, null);
            obj ??= assembly.GetType("AdapterPluginLibrary.Program")?.GetMethod("Load")?.Invoke(null, null);
            var newPlugins = (IFilePlugin[])obj!;
            _pluginArr.AddRange(newPlugins);
            foreach (var plugin in newPlugins)
            {
                PluginComboBox.Items.Add(plugin.PluginName);
            }
        }
        catch(Exception exception)
        {
            MessageBox.Show(@"Ошибка при загрузке");
            _logger.Add("Ошибка при загрузке плагина: " + exception);

        }
        _logger.Add("Закончился импорт плагина");
    }

    private void cacheComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cacheComboBox.SelectedIndex == 1)
            _plugin = new CacheProxyPlugin(_plugin);
        else
            _plugin = _pluginArr[PluginComboBox.SelectedIndex];
    }
}