using GameLib;
using lab14;
using MyCollectionAVLTree;

namespace UnitTestProgram { }

/// <summary>
/// ����� ������ ������� ������ Program.
/// </summary>
[TestClass]
public class UnitTestProgramMethods

{
    #region ����� ������ �����
    #region ����� ������������ ���������
    /// <summary>
    /// ���� ����������� ���������� ��������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestCollection_CorrectCountFill()
    {
        SortedDictionary<string, List<Game>> gameStore = Program.FillStore(); // �������� � ���������� ��������� ���������
        Assert.AreEqual(4, gameStore.Count); // ��������, ��� ��������� ��������� ���������� ������ �������
        Assert.AreEqual(5, gameStore["����"].Count); // ��������, ��� ������ �������� ���������� ������ ���������
        Assert.AreEqual(3, gameStore["���������� ����"].Count); // ��������, ��� ������ �������� ���������� ������ ���������
        Assert.AreEqual(6, gameStore["�����-����"].Count); // ��������, ��� ������ �������� ���������� ������ ���������
        Assert.AreEqual(4, gameStore["VR-����"].Count); // ��������, ��� ������ �������� ���������� ������ ���������
    }

    /// <summary>
    /// ���� ����������� ���������� ��������� � ���������� ������.
    /// </summary>
    [TestMethod]
    public void TestCollection_CorrectKeyFill()
    {
        SortedDictionary<string, List<Game>> gameStore = Program.FillStore(); // �������� � ���������� ��������� ���������
        Assert.IsTrue(gameStore.ContainsKey("����")); // ��������, ��� ���������� ���������� ����
        Assert.IsTrue(gameStore.ContainsKey("���������� ����")); // ��������, ��� ���������� ���������� ����
        Assert.IsTrue(gameStore.ContainsKey("�����-����")); // ��������, ��� ���������� ���������� ����
        Assert.IsTrue(gameStore.ContainsKey("VR-����")); // ��������, ��� ���������� ���������� ����
    }
    #endregion

    #region ����� ������� �������
    /// <summary>
    /// ���� ������� ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }
    
    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ��������� ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new BoardGame("���� �", 6, 9, 5, false, "��������")
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("���� �", 1, 5, 1, true, "��������").ToString())); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ��������� ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new BoardGame("���� �", 6, 9, 5, false, "��������")
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(gameStore); // ������ ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("���� �", 1, 5, 1, true, "��������").ToString())); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� ������� �������
    /// <summary>
    /// ���� ������� ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ��������� ��� ����� ��������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ��������� ��� ����� ��������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� �������� �������
    /// <summary>
    /// ���� �������� ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("9")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("9")); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� ���������� �������
    /// <summary>
    /// ���� ���������� ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsFalse(consoleOutput.Contains("���� �")); // ��������, ��� �� �������� ������������ ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("���� �")); // ��������, ��� �������� ���������� ���������
        Assert.IsFalse(consoleOutput.Contains("���� �")); // ��������, ��� �� �������� ������������ ���������
    }
    #endregion

    #region ����� ������ �������
    /// <summary>
    /// ���� ������ ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request5_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������ ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request5_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 4")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 5")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 1")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 3")); // ��������, ��� �� �������� ������������ ���������
    }

    /// <summary>
    /// ���� ������ ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request5_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������ ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request5_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 4")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 5")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 1")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� � ���������� �������: 3")); // ��������, ��� �� �������� ������������ ���������
    }
    #endregion

    #region ����� ������� �������
    /// <summary>
    /// ���� ������� ������� � ������ ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� ������� ����.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("�������", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_LINQ(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("ID: 1, ����: �������, � �������: ���� ��� ������, ����")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������ ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, �� ���������� ���������� ���������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("��������� ������� ����.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ���������, ���������� ���������� ��������. ����� ����������.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // �������� ��������� ���������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("�������", 1, 5, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new VRGame("���� �", 6, 9, 5, "����", 6, true, true)
        };
        gameStore.Add("����", games); // ��������� ������ � ���������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request6_ExMethod(gameStore); // ������ � ���������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("ID: 1, ����: �������, � �������: ���� ��� ������, ����")); // ��������, ��� �������� ���������� ���������
    }
    #endregion
    #endregion

    #region ����� ������ �����
    #region ����� ������������ ������
    /// <summary>
    /// ���� ����������� ���������� ������
    /// </summary>
    [TestMethod]
    public void TestTree_CorrectFill()
    {
        MyAVLTree<Game> tree = Program.CreateTree(); // �������� � ���������� ������
        Assert.IsNotNull(tree.Root); // ��������, ��� ������ ������ �� ����
        Assert.AreEqual(15, tree.Count); // ��������, ��� ��������� ���������� ���������� ���������
    }
    #endregion

    #region ����� ������� �������
    /// <summary>
    /// ���� ������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ������ ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 50000, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("���� �", 1, 50000, 1, true, "��������").ToString())); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ������ ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 50000, 1, true, "��������"), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request1_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("���� �", 1, 50000, 1, true, "��������").ToString())); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� ������� �������
    /// <summary>
    /// ���� ������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ������ ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new VideoGame("���� �", 1, 50000, 1, "PlayStation", 5), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("1")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new Game("���� �", 1, 5, 1), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("� ������ ��� ����� ���.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new VideoGame("���� �", 1, 50000, 1, "PlayStation", 5), new Game("���� �", 2, 7, 2),
            new Game("���� �", 3, 4, 3), new Game("���� �", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request2_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("1")); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� �������� �������
    /// <summary>
    /// ���� �������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree =
        [
            new Game("����", 0, 0, 1),
        ]; // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 50000, 1, true, "��������"),
            new Game("���� �", 2, 7, 2),
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("1")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������, �� ����������� ���������� ���������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree =
        [
            new Game("����", 0, 0, 1),
        ]; // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� �������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        List<Game> games = new List<Game> // ������� ����� ������ � ����������
        {
            new BoardGame("���� �", 1, 50000, 1, true, "��������"),
            new Game("���� �", 2, 7, 2),
        };
        foreach (Game game in games)
            tree.Add(game); // ��������� �������� ������ � ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request3_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("1")); // ��������, ��� �������� ���������� ���������
    }
    #endregion

    #region ����� ���������� �������
    /// <summary>
    /// ���� ���������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree =
        [
            new Game("����", 0, 0, 1),
            new Game("����", 1, 2, 5),
            new Game("�������", 2, 4, 6)
        ]; // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_ExMethod(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� (���������� ���������: 2)")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� (���������� ���������: 1)")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ������� ������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("������ �� ��������� ����������.")); // ��������, ��� �������� ���������� ���������
    }

    /// <summary>
    /// ���� ���������� ������� � ������, ����������� ���������� ��������.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree =
        [
            new Game("����", 0, 0, 1),
            new Game("����", 1, 2, 5),
            new Game("�������", 2, 4, 6)
        ]; // �������� ������
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // �������������� ����������� ����� � StringWriter
        Program.Request4_LINQ(tree); // ������ � ������
        string consoleOutput = sw.ToString(); // ��������� ����� ������� � ������
        Console.SetOut(Console.Out); // ��������������� ����������� �����
        Assert.IsTrue(consoleOutput.Contains("���� (���������� ���������: 2)")); // ��������, ��� �������� ���������� ���������
        Assert.IsTrue(consoleOutput.Contains("������� (���������� ���������: 1)")); // ��������, ��� �������� ���������� ���������
    }
    #endregion
    #endregion
}