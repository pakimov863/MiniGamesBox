namespace MiniGamesBox.SeaBattle
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net.Sockets;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private byte[,] _field1;

        private byte[,] _field2;

        private Point _lastSect;

        private byte[] _ships;

        /// <remarks>
        /// 0 - меню, 1 - сингл выбор кораблей, 2 - сингл игра,
        /// 3 - сеть выбор кораблей, 4- сеть игра
        /// </remarks>
        private byte _gameState;

        private byte _rotate;

        private TcpListener _tcpListener;

        private TcpClient _tcpClient;

        private NetworkStream _readStream;

        private NetworkStream _writeStream;

        private StreamWriter _writer;

        private StreamReader _reader;

        private string _str;

        private string _ipMy;

        private string _ipBy;

        private int _portMy;

        private int _portBy;

        private bool _chatShown;

        private byte _formSize;

        private byte _lang;

        public Form1()
        {
            _field1 = new byte[9, 9];
            _field2 = new byte[9, 9];
            _ships = new byte[] {0, 4, 3, 2, 1};
            _formSize = 0;
            _lang = 0;

            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы. Сброс поля.
        /// gamestate = МЕНЮ, определение локального IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //AllowSet()
            //ResetField1()
            //gamestate = 0

            //TextIpFrom.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList(0).ToString()
        }

        /// <summary>
        /// Кнопка рандомного расположения кораблей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandom_Click(object sender, System.EventArgs e)
        {
            //ResetField1()
            //SetChips(field1)
            //ships = {0, 0, 0, 0, 0}
            //PictureBox1.Enabled = False
            //PictureBox1.Invalidate()
        }

        /// <summary>
        /// Показать и скрыть чат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, System.EventArgs e)
        {
            //If (chatshown) Then
            //Me.Width -= 200
            //Else
            //Me.Width += 200
            //End If
            //    chatshown = Not chatshown
        }

        /// <summary>
        /// Завершение программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Кнопка НОВАЯ ИГРА
        /// Стадия игры в СИНГЛ ВЫБОР КОРАБЛЕЙ
        /// Показ панели с игрой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, System.EventArgs e)
        {
            //gamestate = 1
            //PanelGame.Location = New Point(0, 0)
            //PanelGame.Visible = True
            //PanelMenu.Visible = False
        }

        /// <summary>
        /// Подтверждение настроек
        /// ТОЛЬКО РАЗМЕР ФОРМЫ!!!
        /// </summary>
        private void AllowSet()
        {
        //    Select Case formsize
        //    Case 0
        //        Me.Width = 477
        //        Me.Height = 338
        //    Case 1
        //        Me.Width = 687
        //        Me.Height = 487
        //    Case 2
        //        Me.Width = 900
        //        Me.Height = 638
        //End Select
        //chatshown = False
        //'MessageBox.Show(CStr(Me.Width) + "-" + CStr(Me.Height))
        //''''''''''''''''
        //'Панель игры
        //''''''''''''''''
        //PanelGame.Width = Me.Width - 37
        //PanelGame.Height = Me.Height - 38

        //PictureBox1.Width = PanelGame.Width / 2.2
        //PictureBox1.Height = PictureBox1.Width
        //PictureBox1.Invalidate()

        //PictureBox2.Location = New Point(24 + PictureBox1.Width, 31)
        //PictureBox2.Width = PanelGame.Width / 2.2
        //PictureBox2.Height = PictureBox2.Width
        //PictureBox2.Invalidate()

        //Label3.Location = New Point(PanelGame.Width - 158, PanelGame.Height - 15)
        //Label4.Location = New Point(PanelGame.Width - 88, PanelGame.Height - 15)
        //Label6.Location = New Point(PanelGame.Width - 69, PanelGame.Height - 15)
        //Label5.Location = New Point(CInt(PictureBox1.Width / 2) - 50, 42 + PictureBox1.Height)
        //Label2.Location = New Point(21 + PictureBox1.Width, 15)
        //ButtonRandom.Location = New Point(PictureBox1.Width - 58, 58 + PictureBox1.Height)
        //ButtonStart.Location = New Point(24 + PictureBox1.Width, 58 + PictureBox1.Height)
        //ButtonReset.Location = New Point(17, 58 + PictureBox1.Height)

        //LabelWait2.Location = New Point(ButtonStart.Location.X + 81, ButtonStart.Location.Y + 5)
        //''''''''''''''''
        //'Панель меню
        //''''''''''''''''
        //PanelMenu.Width = Me.Width - 37
        //PanelMenu.Height = Me.Height - 38
        //Label10.Location = New Point(PanelMenu.Width - 135, PanelMenu.Height - 29)
        //''''''''''''''''
        //'ЧАТ
        //''''''''''''''''
        //Button6.Location = New Point(Me.Width - 20, Me.Height - 72)
        //ListBox1.Location = New Point(Me.Width, 12)
        //ListBox1.Height = Me.Height * 0.7
        //TextBoxText.Location = New Point(Me.Width, ListBox1.Height + 18)
        //Button2.Location = New Point(Me.Width + 87, ListBox1.Height + 44)
        }

        /// <summary>
        /// Отправка системного сообщения в чат
        /// Только для передачи системных команд
        /// </summary>
        private void SendMsg(string str)
        {
            //Try
            //    TcpSender = New TcpClient()
            //TcpSender.Connect(IPAddress.Parse(ipby), prtby)
            //writestream = TcpSender.GetStream()
            //writer = New StreamWriter(writestream)
            //writer.Write(str)
            //writer.Close()
            //'Console.WriteLine("513:" + str)
            //Catch ex As Exception

            //End Try
        }

        /// <summary>
        /// Кнопка НАСТРОЙКИ
        /// Отображение и скрытие нужных элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7_Click(object sender, System.EventArgs e)
        {
            //Button3.Visible = Not Button3.Visible
            //Button4.Visible = Not Button4.Visible
            //Button5.Visible = Not Button5.Visible
            //GroupBox1.Visible = False
            //GroupBox2.Visible = Not GroupBox2.Visible
            //GroupBox3.Visible = Not GroupBox3.Visible
            //    If (Not GroupBox2.Visible) Then
            //If (RadioButton3.Checked) Then formsize = 0
            //If (RadioButton4.Checked) Then formsize = 1
            //If (RadioButton5.Checked) Then formsize = 2

            //If (RadioButton1.Checked) Then lang = 0
            //If (RadioButton2.Checked) Then lang = 1
            //AllowSet()
            //End If
        }

        /// <summary>
        /// Кнопка СЕТЬ
        /// Отображение и скрытие нужных элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, System.EventArgs e)
        {
            //Button3.Visible = Not Button3.Visible
            //Button5.Visible = Not Button5.Visible
            //Button7.Visible = Not Button7.Visible
            //GroupBox1.Visible = Not GroupBox1.Visible
            //GroupBox2.Visible = False
            //GroupBox3.Visible = False
        }

        /// <summary>
        /// Кнопка чата ОТПРАВИТЬ
        /// Отправка сообщения в чат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, System.EventArgs e)
        {
            //TcpSender = New TcpClient()
            //TcpSender.Connect(IPAddress.Parse(TextIpTo.Text), Convert.ToInt32(TextPortTo.Text))
            //writestream = TcpSender.GetStream()
            //writer = New StreamWriter(writestream)
            //writer.Write(TextBoxText.Text)
            //ListBox1.Items.Add("<" + TextBoxText.Text)
            //TextBoxText.Text = ""
            //writer.Close()
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        //    If (str = "ready") And (gamestate <> 3) Then
        //    Console.WriteLine("Rec readypoint!")
        //    gamestate = 3
        //    SendMsg("ready")
        //    LabelWait.Text = "Подключен! Ставьте корабли"
        //    PanelMenu.Visible = False
        //    PanelGame.Location = New Point(0, 0)
        //    PanelGame.Visible = True
        //    Button6.Visible = True
        //ElseIf (str = "readyplay") And (gamestate <> 4) Then
        //    gamestate = 4
        //    'SendMsg("readyplaystart")
        //    LabelWait2.Text = "Соперник готов, ждем вас"
        //    'PictureBox2.Enabled = False
        //    LabelWait2.Visible = True
        //ElseIf (str = "readyplay") And (gamestate = 4) Then
        //    SendMsg("readyplaystart")
        //    LabelWait2.Text = "Ход соперника"
        //    PictureBox2.Enabled = False
        //    LabelWait2.Visible = True
        //ElseIf (str = "readyplaystart") Then
        //    LabelWait2.Text = "Ваш ход"
        //    PictureBox2.Enabled = True
        //    LabelWait2.Visible = True
        //    gamestate = 4
        //ElseIf (str = "win") Then
        //    MessageBox.Show("Вы выиграли!")
        //    PictureBox2.Enabled = False
        //    LabelWait2.Visible = False
        //ElseIf (str.ToCharArray(1, 1) = "|") Then
        //    Dim words As String() = str.Split(New Char() {"|"c})
        //    Dim xx As Integer = CInt(words(0))
        //    Dim yy As Integer = CInt(words(1))
        //    If (str.Length > 3) Then

        //        If (words(2) = "1") Then
        //            field2(xx, yy) = 2
        //        Else
        //            field2(xx, yy) = 3
        //            PictureBox2.Enabled = False
        //            LabelWait2.Text = "Ход соперника"
        //        End If
        //    Else
        //        If (field1(xx, yy) = 1) Then
        //            field1(xx, yy) = 2
        //            SendMsg(str + "|1")
        //            If (CheckFieldWin(field1)) Then
        //                SendMsg("win")
        //                MessageBox.Show("Вы проиграли. Все ваши корабли унечтожены")
        //                PictureBox2.Enabled = False
        //                LabelWait2.Visible = False
        //            End If
        //        ElseIf (field1(xx, yy) = 0) Then
        //            field1(xx, yy) = 3
        //            SendMsg(str + "|0")
        //            LabelWait2.Text = "Ваш ход"
        //            PictureBox2.Enabled = True
        //        End If
        //    End If

        //    PictureBox1.Invalidate()
        //    PictureBox2.Invalidate()
        //Else
        //    ListBox1.Items.Add(">" + str)
        //End If
        //BackgroundWorker1.RunWorkerAsync()
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //TcpClient = TcpLictener.AcceptTcpClient()
            //readstream = TcpClient.GetStream()
            //reader = New StreamReader(readstream)
            //str = reader.ReadToEnd()
            //'Console.Write(str)
            //TcpClient.Close()
        }

        /// <summary>
        /// Кнопка начала сетевой игры
        /// Подключение к игроку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, System.EventArgs e)
        {
            //ipmy = TextIpFrom.Text
            //prtmy = Convert.ToInt32(TextPortFrom.Text)
            //ipby = TextIpTo.Text
            //prtby = Convert.ToInt32(TextPortTo.Text)
            //TcpLictener = New TcpListener(IPAddress.Parse(ipmy), prtmy)
            //TcpLictener.Start()
            //BackgroundWorker1.RunWorkerAsync()
            //TextIpTo.Enabled = False
            //TextPortTo.Enabled = False
            //TextIpFrom.Enabled = False
            //TextPortFrom.Enabled = False
            //LabelWait.Visible = True
            //Button1.Enabled = False

            //SendMsg("ready")
        }

        /// <summary>
        /// Вызывается при отрисовке картинки поля противника
        /// Рисование поля, кораблей на нем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            //Dim size As Single = PictureBox2.Width / 10 - 1
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //Select Case field2(i, j)
            //Case 0, 1
            //e.Graphics.FillRectangle(Brushes.Aqua, i * (size + 1), j * (size + 1), size, size)
            //Case 2
            //e.Graphics.FillRectangle(Brushes.Chocolate, i * (size + 1), j * (size + 1), size, size)
            //Case 3
            //e.Graphics.FillRectangle(Brushes.LightBlue, i * (size + 1), j * (size + 1), size, size)
            //Case Else
            //e.Graphics.FillEllipse(Brushes.Red, i * (size + 1), j * (size + 1), size, size)
            //End Select
            //Next
            //    Next
        }

        /// <summary>
        /// Проверка поля.
        /// true - если кораблей больше не осталось, false - если остались
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool CheckFieldWin(Array field)
        {
            throw new NotImplementedException();
            //Dim cou As Integer = 0
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //If (field(i, j) = 1) Then
            //    cou = cou + 1
            //End If
            //Next
            //    Next
            //If (cou <> 0) Then
            //    Return False
            //    Else
            //Return True
            //End If
        }

        /// <summary>
        /// Ход ПК
        /// Выстрел по рандомной клетке на поле
        /// </summary>
        private void CompMove()
        {
            //Dim x = Floor(Rnd() * 10)
            //Dim y = Floor(Rnd() * 10)
            //'MessageBox.Show(x.ToString)
            //Dim cou As Integer = 0
            //Dim boom As Boolean = False
            //If (field1(x, y) <> 2) And (field1(x, y) <> 3) Then
            //    For i As Integer = x - 1 To x + 1 Step 1
            //For j As Integer = y - 1 To y + 1 Step 1
            //If (i >= 0) And (i < 10) And (j >= 0) And (j < 10) Then
            //If (field1(i, j) = 2) Then
            //    cou = cou + 1
            //End If
            //End If
            //Next
            //    Next
            //If (cou = 0) Or (field1(x, y) = 1) Then
            //If (field1(x, y) = 1) Then
            //field1(x, y) = 2
            //boom = True
            //ElseIf (field1(x, y) = 0) Then
            //field1(x, y) = 3
            //End If
            //PictureBox1.Invalidate()
            //If (boom) Then CompMove()
            //Else
            //CompMove()
            //End If
            //Else
            //CompMove()
            //End If
        }

        /// <summary>
        /// Кнопка начала сингла
        /// Проверка, все ли корабли расставлены.
        /// Для сингла: запуск игры
        /// Для сети: запрос ко 2 игроку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //If (ships(0) = 0) And (ships(1) = 0) And (ships(2) = 0) And (ships(3) = 0) And (ships(4) = 0) Then
            //    For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //If (field1(i, j) = 2) Then field1(i, j) = 1
            //Next
            //    Next
            //lastsect.X = 0
            //lastsect.Y = 0

            //PictureBox1.Invalidate()
            //If (gamestate = 1) Then
            //    gamestate = 2
            //ButtonReset.Visible = False
            //ButtonRandom.Visible = False
            //ButtonStart.Visible = False
            //PictureBox1.Enabled = False
            //Startgame()
            //MessageBox.Show("Да начнется бой")
            //ElseIf (gamestate = 3) Then
            //'gamestate = 4
            //ButtonReset.Visible = False
            //ButtonRandom.Visible = False
            //ButtonStart.Visible = False
            //PictureBox1.Enabled = False
            //PictureBox2.Enabled = False
            //LabelWait2.Visible = True
            //SendMsg("readyplay")
            //ElseIf (gamestate = 4) Then
            //'gamestate = 4
            //ButtonReset.Visible = False
            //ButtonRandom.Visible = False
            //ButtonStart.Visible = False
            //PictureBox1.Enabled = False
            //PictureBox2.Enabled = False
            //LabelWait2.Text = "Ход соперника"
            //LabelWait2.Visible = True

            //SendMsg("readyplaystart")
            //End If
            //Else
            //MessageBox.Show("Не все корабли расставлены")
            //End If
        }

        /// <summary>
        /// Очистка поля от кораблей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            //PictureBox1.Enabled = True
            //ResetField1()
        }

        /// <summary>
        /// Проверка поля вокруг корабля
        /// Разобрать!!!
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool Freedom(int x, int y, byte[,] field)
        {
            throw new NotImplementedException();
            //Dim d(8) As Point
            //d(1).X = 0 : d(1).Y = 1
            //d(2).X = 1 : d(2).Y = 0
            //d(3).X = 0 : d(3).Y = -1
            //d(4).X = -1 : d(4).Y = 0
            //d(5).X = 1 : d(5).Y = 1
            //d(6).X = -1 : d(6).Y = 1
            //d(7).X = 1 : d(7).Y = -1
            //d(8).X = -1 : d(8).Y = -1
            //Dim i, dx, dy As Integer
            //If (x >= 0) And (x < 10) And (y >= 0) And (y < 10) Then
            //If (field(x, y) = 0) Then
            //For i = 1 To 8 Step 1
            //dx = x + CInt(d(i).X)
            //dy = y + CInt(d(i).Y)
            //If (dx >= 0) And (dx < 10) And (dy >= 0) And (dy < 10) Then
            //If (field(dx, dy) <> 0) Then
            //    Return False
            //    Exit Function
            //    End If
            //    End If
            //    Next
            //Return True
            //Else
            //    Return False
            //    End If
            //    Else
            //Return False
            //End If
        }

        /// <summary>
        /// Рандомная установка кораблей на поле
        /// </summary>
        /// <param name="field"></param>
        private void SetChips(byte[,] field)
        {
            //Dim N, M, i As Integer
            //Dim x, y, kx, ky As Integer
            //Dim b As Boolean
            //Dim rnd As New Random()
            //For N = 3 To 0 Step -1
            //For M = 0 To 3 - N Step 1
            //Do
            //    x = rnd.Next(0, 10)
            //y = rnd.Next(0, 10)
            //kx = rnd.Next(2)
            //If kx = 0 Then ky = 1 Else ky = 0
            //b = True
            //For i = 0 To N Step 1
            //If Not Freedom(x + kx * i, y + ky * i, field) Then b = False
            //Next
            //    If b Then
            //For i = 0 To N Step 1
            //field(x + kx * i, y + ky * i) = 1
            //Next
            //    End If
            //    Loop Until b
            //Next
            //    Next
        }

        /// <summary>
        /// Инициализация начала игры
        /// Очистка поля противника и расстановка кораблей
        /// </summary>
        private void StartGame()
        {
            //Label5.Visible = False
            //PictureBox2.Enabled = True
            //PictureBox2.Invalidate()
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //field2(i, j) = 0
            //Next
            //    Next
            //SetChips(field2)
        }

        /// <summary>
        /// Сброс установленных кораблей
        /// Перерисовка пустого поля
        /// </summary>
        private void ResetField()
        {
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //field1(i, j) = 0
            //Next
            //    Next
            //lastsect.X = 0
            //lastsect.Y = 0
            //ships = {0, 4, 3, 2, 1}

            //PictureBox1.Invalidate()
        }

        /// <summary>
        /// Используется для очистки поля от превью кораблей
        /// </summary>
        /// <param name="field"></param>
        private void ClearFieldExcept(byte[,] field)
        {
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //If (field(i, j) = 1) Then
            //field(i, j) = 0
            //End If
            //Next
            //    Next
        }

        /// <summary>
        /// Возврат длины корабля, который сейчас можно поставить
        /// </summary>
        /// <param name="ships"></param>
        /// <returns></returns>
        private byte SetShip(byte[] ships)
        {
            throw new NotImplementedException();
            //'MessageBox.Show(ships(4).ToString)
            //If (ships(4) > 0) Then
            //    Return 4
            //ElseIf (ships(3) > 0) Then
            //    Return 3
            //ElseIf (ships(2) > 0) Then
            //    Return 2
            //ElseIf (ships(1) > 0) Then
            //    Return 1
            //Else : Return 0
            //End If
        }

        /// <summary>
        /// Проверка возможности установки корабля
        /// </summary>
        /// <param name="field"></param>
        /// <param name="length"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        private bool Check(byte[,] field, int length, int x, int y, byte rotate)
        {
            throw new NotImplementedException();
        //    If (rotate = 0) Then
        //    For i As Integer = x - 1 To x + 1 Step 1
        //        For j As Integer = y - length To y + 1 Step 1
        //            'MessageBox.Show("(" + (x - 1).ToString + ":" + (y - 1).ToString + ") to (" + (x + length).ToString + ":" + (y + 1).ToString + ") CURR " + i.ToString + ":" + j.ToString)
        //            If (i >= 0) And (i < 10) And (j >= 0) And (j < 10) Then
        //                If (field1(i, j) = 2) Then

        //                    Return False
        //                End If
        //            End If
        //        Next
        //    Next
        //ElseIf (rotate = 1) Then
        //    For i As Integer = x - 1 To x + length Step 1
        //        For j As Integer = y - 1 To y + 1 Step 1
        //            'MessageBox.Show("(" + (x - 1).ToString + ":" + (y - 1).ToString + ") to (" + (x + length).ToString + ":" + (y + 1).ToString + ") CURR " + i.ToString + ":" + j.ToString)
        //            If (i >= 0) And (i < 10) And (j >= 0) And (j < 10) Then
        //                If (field1(i, j) = 2) Then

        //                    Return False
        //                End If
        //            End If
        //        Next
        //    Next
        //ElseIf (rotate = 2) Then
        //    For i As Integer = x - 1 To x + 1 Step 1
        //        For j As Integer = y - 1 To y + length Step 1
        //            'MessageBox.Show("(" + (x - 1).ToString + ":" + (y - 1).ToString + ") to (" + (x + length).ToString + ":" + (y + 1).ToString + ") CURR " + i.ToString + ":" + j.ToString)
        //            If (i >= 0) And (i < 10) And (j >= 0) And (j < 10) Then
        //                If (field1(i, j) = 2) Then

        //                    Return False
        //                End If
        //            End If
        //        Next
        //    Next
        //ElseIf (rotate = 3) Then
        //    For i As Integer = x - length To x + 1 Step 1
        //        For j As Integer = y - 1 To y + 1 Step 1
        //            'MessageBox.Show("(" + (x - 1).ToString + ":" + (y - 1).ToString + ") to (" + (x + length).ToString + ":" + (y + 1).ToString + ") CURR " + i.ToString + ":" + j.ToString)
        //            If (i >= 0) And (i < 10) And (j >= 0) And (j < 10) Then
        //                If (field1(i, j) = 2) Then
        //                    'MessageBox.Show("(" + (x - 1).ToString + ":" + (y - 1).ToString + ") to (" + (x + length).ToString + ":" + (y + 1).ToString + ")")
        //                    Return False
        //                End If
        //            End If
        //        Next
        //    Next
        //End If
        //Return True
        }

        /// <summary>
        /// Нажатие на поле противника
        /// Определение: поврежден или не поврежден
        /// Для сети: передача координаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            //Dim x As Integer = e.X
            //Dim y As Integer = e.Y
            //Dim boom As Boolean = False
            //Dim size As Integer = PictureBox2.Width / 10
            //x = Floor(x / size)
            //y = Floor(y / size)

            //If (gamestate = 1) Or (gamestate = 2) Then
            //If (field2(x, y) <> 2) And (field2(x, y) <> 3) Then
            //If (field2(x, y) = 1) Then 'Подбит корабль
            //field2(x, y) = 2
            //boom = True
            //ElseIf (field2(x, y) = 0) Then 'Мимо
            //field2(x, y) = 3
            //End If

            //PictureBox2.Invalidate()
            //If (Not boom) Then
            //If (CheckFieldWin(field2)) Then
            //MessageBox.Show("Вы победили. У противника не осталось кораблей")
            //PictureBox2.Enabled = False
            //Else
            //CompMove()
            //If (CheckFieldWin(field1)) Then
            //MessageBox.Show("Противник победил. У вас не осталось кораблей")
            //PictureBox2.Enabled = False
            //End If
            //End If
            //End If
            //End If
            //Else
            //SendMsg(x.ToString + "|" + y.ToString)
            //End If
        }

        /// <summary>
        /// Перемещение мыши по полю противника
        /// Вычисление квадрата, на который наведена мышь
        /// ТОЛЬКО ДЕБАГ!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            //Dim x As Integer = e.X
            //Dim y As Integer = e.Y
            //Dim size As Integer = PictureBox2.Width / 10
            //x = Floor(x / size)
            //y = Floor(y / size)

            //Label6.Text = e.X.ToString + "(" + x.ToString + ")+" + e.Y.ToString + "(" + y.ToString + ")"
        }

        /// <summary>
        /// Вызывается при отрисовке картинки.
        /// Рисование поля, кораблей на нем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Dim size As Single = PictureBox1.Width / 10 - 1
            //For i As Integer = 0 To 9 Step 1
            //For j As Integer = 0 To 9 Step 1
            //Select Case field1(i, j)
            //Case 0
            //e.Graphics.FillRectangle(Brushes.Aqua, i * (size + 1), j * (size + 1), size, size)
            //Case 1
            //e.Graphics.FillRectangle(Brushes.Brown, i * (size + 1), j * (size + 1), size, size)
            //Case 2
            //e.Graphics.FillRectangle(Brushes.DarkGray, i * (size + 1), j * (size + 1), size, size)
            //Case 3
            //e.Graphics.FillRectangle(Brushes.LightBlue, i * (size + 1), j * (size + 1), size, size)
            //Case Else
            //e.Graphics.FillEllipse(Brushes.Red, i * (size + 1), j * (size + 1), size, size)
            //End Select
            //Next
            //    Next
        }

        /// <summary>
        /// Отпускание мыши.
        /// Установка или не установка корабля на поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        //    If (e.Button = Windows.Forms.MouseButtons.Left) Then
        //    Dim length As Byte = SetShip(ships)
        //    'MessageBox.Show(length.ToString)
        //    If (length <> 0) Then
        //        If (rotate = 0) Then
        //            If (lastsect.Y - length + 1 >= 0) And (Check(field1, length, lastsect.X, lastsect.Y, rotate)) Then
        //                For i As Integer = 0 To length - 1 Step 1
        //                    field1(lastsect.X, lastsect.Y - i) = 2
        //                Next
        //                ships(length) = ships(length) - 1
        //            Else
        //                MessageBox.Show("Нельзя за пределы или рядом")
        //            End If
        //        ElseIf (rotate = 1) Then
        //            If (lastsect.X + length <= 10) And (Check(field1, length, lastsect.X, lastsect.Y, rotate)) Then
        //                For i As Integer = 0 To length - 1 Step 1
        //                    field1(lastsect.X + i, lastsect.Y) = 2
        //                Next
        //                ships(length) = ships(length) - 1
        //            Else
        //                MessageBox.Show("Нельзя за пределы или рядом")
        //            End If
        //        ElseIf (rotate = 2) Then
        //            If (lastsect.Y + length <= 10) And (Check(field1, length, lastsect.X, lastsect.Y, rotate)) Then
        //                For i As Integer = 0 To length - 1 Step 1
        //                    field1(lastsect.X, lastsect.Y + i) = 2
        //                Next
        //                ships(length) = ships(length) - 1
        //            Else
        //                MessageBox.Show("Нельзя за пределы или рядом")
        //            End If
        //        ElseIf (rotate = 3) Then
        //            If (lastsect.X - length + 1 >= 0) And (Check(field1, length, lastsect.X, lastsect.Y, rotate)) Then
        //                For i As Integer = 0 To length - 1 Step 1
        //                    field1(lastsect.X - i, lastsect.Y) = 2
        //                Next
        //                ships(length) = ships(length) - 1
        //            Else
        //                MessageBox.Show("Нельзя за пределы или рядом")
        //            End If
        //        End If
        //    Else
        //        MessageBox.Show("Все корабли расставлены")
        //    End If
        //Else
        //    ClearFieldExcept(field1)
        //    If (rotate = 3) Then
        //        rotate = 0
        //    Else
        //        rotate = rotate + 1
        //    End If
        //    'MessageBox.Show(rotate.ToString)
        //End If
        //'MessageBox.Show(e.X.ToString + "|" + e.Y.ToString)
        }

        /// <summary>
        /// Перемещение превью корабля по полю при расстановке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        //    Dim x As Integer = e.X
        //Dim y As Integer = e.Y
        //Dim size As Integer = PictureBox1.Width / 10
        //Dim length As Byte = SetShip(ships)
        //x = Floor(x / size)
        //y = Floor(y / size)
        //If (lastsect.X <> x) Or (lastsect.Y <> y) Then
        //    If (rotate = 0) Then
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.Y - i >= 0) Then
        //                If (field1(lastsect.X, lastsect.Y - i) = 1) Then field1(lastsect.X, lastsect.Y - i) = 0
        //            End If
        //        Next
        //        lastsect.X = x
        //        lastsect.Y = y
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.Y - i >= 0) Then
        //                If (field1(lastsect.X, lastsect.Y - i) = 0) Then field1(lastsect.X, lastsect.Y - i) = 1
        //            End If
        //        Next
        //    ElseIf (rotate = 1) Then
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.X + i < 10) Then
        //                If (field1(lastsect.X + i, lastsect.Y) = 1) Then field1(lastsect.X + i, lastsect.Y) = 0
        //            End If
        //        Next
        //        lastsect.X = x
        //        lastsect.Y = y
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.X + i < 10) Then
        //                If (field1(lastsect.X + i, lastsect.Y) = 0) Then field1(lastsect.X + i, lastsect.Y) = 1
        //            End If
        //        Next
        //    ElseIf (rotate = 2) Then
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.Y + i < 10) Then
        //                If (field1(lastsect.X, lastsect.Y + i) = 1) Then field1(lastsect.X, lastsect.Y + i) = 0
        //            End If
        //        Next
        //        lastsect.X = x
        //        lastsect.Y = y
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.Y + i < 10) Then
        //                If (field1(lastsect.X, lastsect.Y + i) = 0) Then field1(lastsect.X, lastsect.Y + i) = 1
        //            End If
        //        Next
        //    ElseIf (rotate = 3) Then
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.X - i >= 0) Then
        //                If (field1(lastsect.X - i, lastsect.Y) = 1) Then field1(lastsect.X - i, lastsect.Y) = 0
        //            End If
        //        Next
        //        lastsect.X = x
        //        lastsect.Y = y
        //        For i As Integer = 0 To length - 1 Step 1
        //            If (lastsect.X - i >= 0) Then
        //                If (field1(lastsect.X - i, lastsect.Y) = 0) Then field1(lastsect.X - i, lastsect.Y) = 1
        //            End If
        //        Next
        //    End If
        //    'MessageBox.Show(field1(lastsect.X, lastsect.Y).ToString)
        //    Refresh()
        //End If
        //Label3.Text = e.X.ToString + "(" + x.ToString + ")+" + e.Y.ToString + "(" + y.ToString + ")"
        //Label4.Text = rotate.ToString
        }
    }
}
