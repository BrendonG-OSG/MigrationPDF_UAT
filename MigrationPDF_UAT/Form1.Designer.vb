<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.pdfCompare = New System.Windows.Forms.GroupBox()
        Me.btnConfigFile = New System.Windows.Forms.Button()
        Me.txtConfigFile = New System.Windows.Forms.TextBox()
        Me.lblUseConfigFile = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gb3Up = New System.Windows.Forms.GroupBox()
        Me.lblPageSize = New System.Windows.Forms.Label()
        Me.txtPageSize = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOSG_NP_Literal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOSG_NP_Height = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtOSG_NP_Width = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtOSG_NP_Y = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtOSG_NP_X = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtOSG_UI_Height = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtOSG_UI_Width = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtOSG_UI_Y = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtOSG_UI_X = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtGSB_NP_Literal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGSB_NP_Height = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGSB_NP_Width = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGSB_NP_Y = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGSB_NP_X = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGSB_UI_Height = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGSB_UI_Width = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGSB_UI_Y = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGSB_UI_X = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnClientPDF = New System.Windows.Forms.Button()
        Me.txtGSB_PDFfilename = New System.Windows.Forms.TextBox()
        Me.lblClientPDF = New System.Windows.Forms.Label()
        Me.btnOSGPDF = New System.Windows.Forms.Button()
        Me.txtOSG_PDFfilename = New System.Windows.Forms.TextBox()
        Me.lblOSGPDF = New System.Windows.Forms.Label()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.pdfCompare.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gb3Up.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 414)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(817, 24)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = False
        Me.StatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(815, 19)
        Me.StatusLabel.Text = "Ready"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "openFileDialog"
        '
        'pdfCompare
        '
        Me.pdfCompare.Controls.Add(Me.btnConfigFile)
        Me.pdfCompare.Controls.Add(Me.txtConfigFile)
        Me.pdfCompare.Controls.Add(Me.lblUseConfigFile)
        Me.pdfCompare.Controls.Add(Me.GroupBox1)
        Me.pdfCompare.Controls.Add(Me.btnClientPDF)
        Me.pdfCompare.Controls.Add(Me.txtGSB_PDFfilename)
        Me.pdfCompare.Controls.Add(Me.lblClientPDF)
        Me.pdfCompare.Controls.Add(Me.btnOSGPDF)
        Me.pdfCompare.Controls.Add(Me.txtOSG_PDFfilename)
        Me.pdfCompare.Controls.Add(Me.lblOSGPDF)
        Me.pdfCompare.Controls.Add(Me.btnScan)
        Me.pdfCompare.Location = New System.Drawing.Point(6, 5)
        Me.pdfCompare.Name = "pdfCompare"
        Me.pdfCompare.Size = New System.Drawing.Size(809, 406)
        Me.pdfCompare.TabIndex = 22
        Me.pdfCompare.TabStop = False
        Me.pdfCompare.Text = "Compare PDFs"
        '
        'btnConfigFile
        '
        Me.btnConfigFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfigFile.Location = New System.Drawing.Point(757, 24)
        Me.btnConfigFile.Name = "btnConfigFile"
        Me.btnConfigFile.Size = New System.Drawing.Size(37, 29)
        Me.btnConfigFile.TabIndex = 32
        Me.btnConfigFile.Text = "..."
        Me.btnConfigFile.UseVisualStyleBackColor = True
        '
        'txtConfigFile
        '
        Me.txtConfigFile.Location = New System.Drawing.Point(102, 28)
        Me.txtConfigFile.Name = "txtConfigFile"
        Me.txtConfigFile.Size = New System.Drawing.Size(649, 20)
        Me.txtConfigFile.TabIndex = 31
        '
        'lblUseConfigFile
        '
        Me.lblUseConfigFile.AutoSize = True
        Me.lblUseConfigFile.Location = New System.Drawing.Point(8, 32)
        Me.lblUseConfigFile.Name = "lblUseConfigFile"
        Me.lblUseConfigFile.Size = New System.Drawing.Size(81, 13)
        Me.lblUseConfigFile.TabIndex = 33
        Me.lblUseConfigFile.Text = "Use Config File:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gb3Up)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtOSG_NP_Literal)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtOSG_NP_Height)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtOSG_NP_Width)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtOSG_NP_Y)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtOSG_NP_X)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtOSG_UI_Height)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtOSG_UI_Width)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtOSG_UI_Y)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtOSG_UI_X)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtGSB_NP_Literal)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtGSB_NP_Height)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtGSB_NP_Width)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtGSB_NP_Y)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtGSB_NP_X)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtGSB_UI_Height)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtGSB_UI_Width)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtGSB_UI_Y)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGSB_UI_X)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox1.Location = New System.Drawing.Point(102, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(649, 238)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PDF Parsing Type (choose one)"
        '
        'gb3Up
        '
        Me.gb3Up.Controls.Add(Me.lblPageSize)
        Me.gb3Up.Controls.Add(Me.txtPageSize)
        Me.gb3Up.Location = New System.Drawing.Point(6, 144)
        Me.gb3Up.Name = "gb3Up"
        Me.gb3Up.Size = New System.Drawing.Size(103, 88)
        Me.gb3Up.TabIndex = 42
        Me.gb3Up.TabStop = False
        Me.gb3Up.Text = "GSB 3-Up"
        '
        'lblPageSize
        '
        Me.lblPageSize.AutoSize = True
        Me.lblPageSize.Location = New System.Drawing.Point(6, 28)
        Me.lblPageSize.Name = "lblPageSize"
        Me.lblPageSize.Size = New System.Drawing.Size(58, 13)
        Me.lblPageSize.TabIndex = 3
        Me.lblPageSize.Text = "Page Size:"
        '
        'txtPageSize
        '
        Me.txtPageSize.Location = New System.Drawing.Point(5, 50)
        Me.txtPageSize.Name = "txtPageSize"
        Me.txtPageSize.Size = New System.Drawing.Size(92, 20)
        Me.txtPageSize.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(507, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Literal (upper case)"
        '
        'txtOSG_NP_Literal
        '
        Me.txtOSG_NP_Literal.Location = New System.Drawing.Point(510, 198)
        Me.txtOSG_NP_Literal.Name = "txtOSG_NP_Literal"
        Me.txtOSG_NP_Literal.Size = New System.Drawing.Size(98, 20)
        Me.txtOSG_NP_Literal.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(406, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Width"
        '
        'txtOSG_NP_Height
        '
        Me.txtOSG_NP_Height.Location = New System.Drawing.Point(447, 202)
        Me.txtOSG_NP_Height.Name = "txtOSG_NP_Height"
        Me.txtOSG_NP_Height.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_NP_Height.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(406, 205)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Height"
        '
        'txtOSG_NP_Width
        '
        Me.txtOSG_NP_Width.Location = New System.Drawing.Point(447, 176)
        Me.txtOSG_NP_Width.Name = "txtOSG_NP_Width"
        Me.txtOSG_NP_Width.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_NP_Width.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(341, 205)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Y"
        '
        'txtOSG_NP_Y
        '
        Me.txtOSG_NP_Y.Location = New System.Drawing.Point(361, 202)
        Me.txtOSG_NP_Y.Name = "txtOSG_NP_Y"
        Me.txtOSG_NP_Y.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_NP_Y.TabIndex = 36
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(341, 179)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "X"
        '
        'txtOSG_NP_X
        '
        Me.txtOSG_NP_X.Location = New System.Drawing.Point(361, 176)
        Me.txtOSG_NP_X.Name = "txtOSG_NP_X"
        Me.txtOSG_NP_X.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_NP_X.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(341, 154)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(123, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "OSG PDF New Page"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(186, 179)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 13)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Width"
        '
        'txtOSG_UI_Height
        '
        Me.txtOSG_UI_Height.Location = New System.Drawing.Point(226, 202)
        Me.txtOSG_UI_Height.Name = "txtOSG_UI_Height"
        Me.txtOSG_UI_Height.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_UI_Height.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(186, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Height"
        '
        'txtOSG_UI_Width
        '
        Me.txtOSG_UI_Width.Location = New System.Drawing.Point(226, 176)
        Me.txtOSG_UI_Width.Name = "txtOSG_UI_Width"
        Me.txtOSG_UI_Width.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_UI_Width.TabIndex = 25
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(120, 205)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(14, 13)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Y"
        '
        'txtOSG_UI_Y
        '
        Me.txtOSG_UI_Y.Location = New System.Drawing.Point(140, 202)
        Me.txtOSG_UI_Y.Name = "txtOSG_UI_Y"
        Me.txtOSG_UI_Y.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_UI_Y.TabIndex = 27
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(120, 179)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(14, 13)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "X"
        '
        'txtOSG_UI_X
        '
        Me.txtOSG_UI_X.Location = New System.Drawing.Point(140, 176)
        Me.txtOSG_UI_X.Name = "txtOSG_UI_X"
        Me.txtOSG_UI_X.Size = New System.Drawing.Size(34, 20)
        Me.txtOSG_UI_X.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(120, 154)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(159, 13)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "OSG PDF Unique Identifier"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(507, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Literal (upper case)"
        '
        'txtGSB_NP_Literal
        '
        Me.txtGSB_NP_Literal.Location = New System.Drawing.Point(510, 64)
        Me.txtGSB_NP_Literal.Name = "txtGSB_NP_Literal"
        Me.txtGSB_NP_Literal.Size = New System.Drawing.Size(98, 20)
        Me.txtGSB_NP_Literal.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(406, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Width"
        '
        'txtGSB_NP_Height
        '
        Me.txtGSB_NP_Height.Location = New System.Drawing.Point(447, 68)
        Me.txtGSB_NP_Height.Name = "txtGSB_NP_Height"
        Me.txtGSB_NP_Height.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_NP_Height.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(406, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Height"
        '
        'txtGSB_NP_Width
        '
        Me.txtGSB_NP_Width.Location = New System.Drawing.Point(447, 42)
        Me.txtGSB_NP_Width.Name = "txtGSB_NP_Width"
        Me.txtGSB_NP_Width.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_NP_Width.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(341, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Y"
        '
        'txtGSB_NP_Y
        '
        Me.txtGSB_NP_Y.Location = New System.Drawing.Point(361, 68)
        Me.txtGSB_NP_Y.Name = "txtGSB_NP_Y"
        Me.txtGSB_NP_Y.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_NP_Y.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(341, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "X"
        '
        'txtGSB_NP_X
        '
        Me.txtGSB_NP_X.Location = New System.Drawing.Point(361, 42)
        Me.txtGSB_NP_X.Name = "txtGSB_NP_X"
        Me.txtGSB_NP_X.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_NP_X.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(341, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Client PDF New Page"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(186, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Width"
        '
        'txtGSB_UI_Height
        '
        Me.txtGSB_UI_Height.Location = New System.Drawing.Point(226, 68)
        Me.txtGSB_UI_Height.Name = "txtGSB_UI_Height"
        Me.txtGSB_UI_Height.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_UI_Height.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Height"
        '
        'txtGSB_UI_Width
        '
        Me.txtGSB_UI_Width.Location = New System.Drawing.Point(226, 42)
        Me.txtGSB_UI_Width.Name = "txtGSB_UI_Width"
        Me.txtGSB_UI_Width.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_UI_Width.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(120, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Y"
        '
        'txtGSB_UI_Y
        '
        Me.txtGSB_UI_Y.Location = New System.Drawing.Point(140, 68)
        Me.txtGSB_UI_Y.Name = "txtGSB_UI_Y"
        Me.txtGSB_UI_Y.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_UI_Y.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "X"
        '
        'txtGSB_UI_X
        '
        Me.txtGSB_UI_X.Location = New System.Drawing.Point(140, 42)
        Me.txtGSB_UI_X.Name = "txtGSB_UI_X"
        Me.txtGSB_UI_X.Size = New System.Drawing.Size(34, 20)
        Me.txtGSB_UI_X.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(120, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Client PDF Unique Identifier"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 71)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(82, 17)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "1 to 1 PDFs"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(643, 219)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 109
        Me.LineShape1.X2 = 109
        Me.LineShape1.Y1 = 0
        Me.LineShape1.Y2 = 212
        '
        'btnClientPDF
        '
        Me.btnClientPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientPDF.Location = New System.Drawing.Point(757, 56)
        Me.btnClientPDF.Name = "btnClientPDF"
        Me.btnClientPDF.Size = New System.Drawing.Size(37, 29)
        Me.btnClientPDF.TabIndex = 26
        Me.btnClientPDF.Text = "..."
        Me.btnClientPDF.UseVisualStyleBackColor = True
        '
        'txtGSB_PDFfilename
        '
        Me.txtGSB_PDFfilename.Location = New System.Drawing.Point(102, 60)
        Me.txtGSB_PDFfilename.Name = "txtGSB_PDFfilename"
        Me.txtGSB_PDFfilename.Size = New System.Drawing.Size(649, 20)
        Me.txtGSB_PDFfilename.TabIndex = 25
        '
        'lblClientPDF
        '
        Me.lblClientPDF.AutoSize = True
        Me.lblClientPDF.Location = New System.Drawing.Point(8, 64)
        Me.lblClientPDF.Name = "lblClientPDF"
        Me.lblClientPDF.Size = New System.Drawing.Size(79, 13)
        Me.lblClientPDF.TabIndex = 27
        Me.lblClientPDF.Text = "Client PDF File:"
        '
        'btnOSGPDF
        '
        Me.btnOSGPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOSGPDF.Location = New System.Drawing.Point(757, 91)
        Me.btnOSGPDF.Name = "btnOSGPDF"
        Me.btnOSGPDF.Size = New System.Drawing.Size(37, 29)
        Me.btnOSGPDF.TabIndex = 29
        Me.btnOSGPDF.Text = "..."
        Me.btnOSGPDF.UseVisualStyleBackColor = True
        '
        'txtOSG_PDFfilename
        '
        Me.txtOSG_PDFfilename.Location = New System.Drawing.Point(102, 95)
        Me.txtOSG_PDFfilename.Name = "txtOSG_PDFfilename"
        Me.txtOSG_PDFfilename.Size = New System.Drawing.Size(649, 20)
        Me.txtOSG_PDFfilename.TabIndex = 28
        '
        'lblOSGPDF
        '
        Me.lblOSGPDF.AutoSize = True
        Me.lblOSGPDF.Location = New System.Drawing.Point(8, 99)
        Me.lblOSGPDF.Name = "lblOSGPDF"
        Me.lblOSGPDF.Size = New System.Drawing.Size(76, 13)
        Me.lblOSGPDF.TabIndex = 24
        Me.lblOSGPDF.Text = "OSG PDF File:"
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(698, 376)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(96, 24)
        Me.btnScan.TabIndex = 0
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 438)
        Me.Controls.Add(Me.pdfCompare)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDF UAT Review"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pdfCompare.ResumeLayout(False)
        Me.pdfCompare.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb3Up.ResumeLayout(False)
        Me.gb3Up.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pdfCompare As System.Windows.Forms.GroupBox
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents btnOSGPDF As System.Windows.Forms.Button
    Friend WithEvents txtOSG_PDFfilename As System.Windows.Forms.TextBox
    Friend WithEvents lblOSGPDF As System.Windows.Forms.Label
    Friend WithEvents btnClientPDF As System.Windows.Forms.Button
    Friend WithEvents txtGSB_PDFfilename As System.Windows.Forms.TextBox
    Friend WithEvents lblClientPDF As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_NP_Literal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_NP_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_NP_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_NP_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_NP_X As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_UI_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_UI_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_UI_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGSB_UI_X As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_NP_Literal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_NP_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_NP_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_NP_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_NP_X As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_UI_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_UI_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_UI_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtOSG_UI_X As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents gb3Up As System.Windows.Forms.GroupBox
    Friend WithEvents lblPageSize As System.Windows.Forms.Label
    Friend WithEvents txtPageSize As System.Windows.Forms.TextBox
    Friend WithEvents btnConfigFile As System.Windows.Forms.Button
    Friend WithEvents txtConfigFile As System.Windows.Forms.TextBox
    Friend WithEvents lblUseConfigFile As System.Windows.Forms.Label

End Class
