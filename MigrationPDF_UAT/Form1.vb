Imports System.Xml
Imports System.Xml.XPath
Imports System.Text
Imports System.IO
Imports System.Collections.Specialized

Imports pdftron
Imports pdftron.Common
Imports pdftron.Filters
Imports pdftron.SDF
Imports pdftron.PDF

Public Class Form1
    Dim logFileName As String = ""
    Dim osgPageXML, clientPageXML As XmlDocument
    Dim osgPDF, clientPDF As PDFDoc
    Dim boxes As List(Of TextBox)
    Dim tempTB As TextBox
    Dim globalErrorList As New List(Of String)
    Dim compareXML As New XmlDocument
    Dim rootElm As XmlElement

    Dim clipUniqueIdentifier, clipNewPage As Rect
    Dim uniqueIdentifierVal As String = "", newPageVal As String = "", newPageLiteral As String = ""

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadDefaults()
        boxes = New List(Of TextBox)() From {txtGSB_UI_X, txtGSB_UI_Y, txtGSB_UI_Height, txtGSB_UI_Width, txtGSB_NP_Height, txtGSB_NP_Width, _
                                             txtGSB_NP_Y, txtGSB_NP_X, txtGSB_NP_Literal, txtOSG_NP_Literal, txtOSG_NP_Height, txtOSG_NP_Width, _
                                             txtOSG_NP_Y, txtOSG_NP_X, txtOSG_UI_Height, txtOSG_UI_Width, txtOSG_UI_Y, txtOSG_UI_X}
    End Sub

#Region "Processing Buttons"

    Private Sub btnScan_Click(sender As Object, e As System.EventArgs) Handles btnScan.Click
        PDFNet.Initialize("OSG Billing Services(osgbilling.com):ENTCPU:1::W:AMS(20140622):8E4F78C23CAFD6B962824007400DD29C15AD420D33446C5017F1E6BEF5C7")

        'Check validity of Client PDF file path
        If txtGSB_PDFfilename.Text.Trim = "" Then
            MsgBox("Set Client PDF File", MsgBoxStyle.Critical, "Migration PDF UAT Review")
            txtGSB_PDFfilename.Focus()
            Exit Sub
        Else
            If Not File.Exists(txtGSB_PDFfilename.Text.Trim) Then
                MsgBox(txtGSB_PDFfilename.Text.Trim & " file does not exist! Check Client PDF File Path", MsgBoxStyle.Critical, "Migration PDF UAT Review")
                txtGSB_PDFfilename.Focus()
                Exit Sub
            Else
                clientPDF = New PDFDoc(txtGSB_PDFfilename.Text.Trim)
            End If
        End If

        'Check validity of OSG PDF file path
        If txtOSG_PDFfilename.Text.Trim = "" Then
            MsgBox("Set OSG PDF File", MsgBoxStyle.Critical, "Migration PDF UAT Review")
            txtOSG_PDFfilename.Focus()
            Exit Sub
        Else
            If Not File.Exists(txtOSG_PDFfilename.Text.Trim) Then
                MsgBox(txtOSG_PDFfilename.Text.Trim & " file does not exist! Check OSG PDF File Path", MsgBoxStyle.Critical, "Migration PDF UAT Review")
                txtOSG_PDFfilename.Focus()
                Exit Sub
            Else
                osgPDF = New PDFDoc(txtOSG_PDFfilename.Text.Trim)
            End If
        End If

        'logFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & _
        '              Path.GetFileNameWithoutExtension(txtClientPDFfilename.Text.Trim) & "_" & _
        '              Path.GetFileNameWithoutExtension(txtOSGPDFfilename.Text.Trim) & "_UATCompare.txt"

        logFileName = Path.GetDirectoryName(txtOSG_PDFfilename.Text) & "\UATCompare.txt"

        scanPDFfiles()

        PDFNet.Terminate()

    End Sub

#End Region

#Region "PDF Processing"

    Private Sub scanPDFfiles()

        If CheckBox1.Checked Then
            OneToOnePDFs()
            enableButtons()
            resetTextBoxesAndCheckBox()
        Else
            disableButtons()
            buildAndCompareXML()
            enableButtons()
            'If Not checkCoordinateAndLiteralTextBoxes() Then
            '    CoordinatesBasedPDFs()
            '    enableButtons()
            '    'resetTextBoxesAndCheckBox()
            'End If
        End If

    End Sub

    Private Sub OneToOnePDFs()

        Dim outputLog As New StreamWriter(logFileName)
        Dim pageCount As Integer

        'Read PDFs
        For pageCount = 1 To clientPDF.GetPageCount
            If pageCount Mod 50 = 0 Then
                Status("Processing PDF page (" & pageCount.ToString & ")")
            End If

            Dim clientPage As Page = clientPDF.GetPage(pageCount)
            Dim osgPage As Page = osgPDF.GetPage(pageCount)
            Dim currentPageDiClient As New Dictionary(Of String, Integer)
            Dim currentPageDiOSG As New Dictionary(Of String, Integer)

            'Get clientPage xml
            clientPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(clientPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                clientPageXML = New XmlDocument : clientPageXML.LoadXml(txtXML)
            End Using

            'Build client page dictionary
            For Each xe As XmlElement In clientPageXML.SelectNodes("//Line")
                If Not currentPageDiClient.ContainsKey(xe.InnerText.ToUpper.Trim) Then
                    currentPageDiClient.Add(xe.InnerText.ToUpper.Trim, 1)
                Else
                    Dim currentCount As Integer = currentPageDiClient(xe.InnerText.ToUpper.Trim)
                    currentCount += 1
                    currentPageDiClient(xe.InnerText.ToUpper.Trim) = currentCount
                End If
            Next



            'Get osgPage xml
            osgPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(osgPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                osgPageXML = New XmlDocument : osgPageXML.LoadXml(txtXML)
            End Using

            'Build osg page dictionary
            For Each xe As XmlElement In osgPageXML.SelectNodes("//Line")
                If Not currentPageDiOSG.ContainsKey(xe.InnerText.ToUpper.Trim) Then
                    currentPageDiOSG.Add(xe.InnerText.ToUpper.Trim, 1)
                Else
                    Dim currentCount As Integer = currentPageDiOSG(xe.InnerText.ToUpper.Trim)
                    currentCount += 1
                    currentPageDiOSG(xe.InnerText.ToUpper.Trim) = currentCount
                End If
            Next

            'Go through dictionaries
            If pageCount > 1 Then
                outputLog.WriteLine(vbCrLf)
            End If
            outputLog.WriteLine("PDF Page " & pageCount.ToString & vbCrLf & "--------------" & vbCrLf)

            For Each key As String In currentPageDiClient.Keys
                If currentPageDiOSG.ContainsKey(key) Then
                    If currentPageDiClient(key) = currentPageDiOSG(key) Then
                        outputLog.WriteLine("   PASS    - [" & currentPageDiClient(key).ToString & "] """ & key & """ found on Client and OSG page.")
                    Else
                        outputLog.WriteLine("###FAIL### - [" & currentPageDiClient(key).ToString & "] """ & key & """ found on Client page and [" & currentPageDiOSG(key).ToString & "] found on OSG page.")
                    End If
                Else
                    outputLog.WriteLine("###FAIL### - [" & currentPageDiClient(key).ToString & "] """ & key & """ found on Client page and [0] found on OSG page.")
                End If

            Next

        Next

        outputLog.Flush() : outputLog.Close()
        Status("Done")
        MsgBox("Logfile saved [" & logFileName.ToString & "]", MsgBoxStyle.Information, "Migration PDF UAT Review")

    End Sub

    Private Sub buildAndCompareXML()
        Dim outputLog As New StreamWriter(logFileName)
        Dim pageCount As Integer
        Dim pageSize As String = txtPageSize.Text

        compareXML.LoadXml("<DOCS/>")
        rootElm = compareXML.DocumentElement

        'Read GSB PDF
        For pageCount = 1 To clientPDF.GetPageCount
            If pageCount Mod 100 = 0 Then
                Status("Processing GSB PDF page (" & pageCount.ToString & ")")
            End If

            Dim clientPage As Page = clientPDF.GetPage(pageCount)
            Dim osgPage As Page = osgPDF.GetPage(pageCount)

            'Get clientPage xml
            clientPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(clientPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                clientPageXML = New XmlDocument : clientPageXML.LoadXml(txtXML)
            End Using

            'Build GSB XML
            If txtPageSize.Text = "" Then
                Dim acctElm As XmlElement = compareXML.CreateElement("GSB_DOC")

                clipUniqueIdentifier = New Rect()
                clipUniqueIdentifier.x1 = I2P(txtGSB_UI_X.Text)
                clipUniqueIdentifier.x2 = (clipUniqueIdentifier.x1 + I2P(txtGSB_UI_Width.Text))
                clipUniqueIdentifier.y1 = I2P(txtGSB_UI_Y.Text)
                clipUniqueIdentifier.y2 = (clipUniqueIdentifier.y1 + I2P(txtGSB_UI_Height.Text))

                If GetPDFpageValue(clipUniqueIdentifier, clientPage).ToUpper.Trim() <> "" Then
                    acctElm.SetAttribute("ID", GetPDFpageValue(clipUniqueIdentifier, clientPage).ToUpper.Trim())
                    For Each xe As XmlElement In clientPageXML.SelectNodes("//Line")
                        Dim docText As String = xe.InnerText.ToUpper.Trim
                        Dim textElm As XmlElement = compareXML.CreateElement("TEXT")
                        textElm.InnerText = docText
                        acctElm.AppendChild(textElm)
                    Next
                    rootElm.AppendChild(acctElm)
                End If

            Else

                For pagePart As Integer = 1 To 3 'Step through three documents on one page
                    Dim acctElm As XmlElement = compareXML.CreateElement("GSB_DOC")

                    clipUniqueIdentifier = New Rect()
                    clipUniqueIdentifier.x1 = I2P(txtGSB_UI_X.Text)
                    clipUniqueIdentifier.x2 = (clipUniqueIdentifier.x1 + I2P(txtGSB_UI_Width.Text))

                    Select Case pagePart
                        Case 1
                            clipUniqueIdentifier.y1 = I2P(txtGSB_UI_Y.Text) - (I2P(pageSize) * 2)
                        Case 2
                            clipUniqueIdentifier.y1 = I2P(txtGSB_UI_Y.Text) - I2P(pageSize)
                        Case 3
                            clipUniqueIdentifier.y1 = I2P(txtGSB_UI_Y.Text)
                    End Select
                    clipUniqueIdentifier.y2 = (clipUniqueIdentifier.y1 + I2P(txtGSB_UI_Height.Text))

                    If GetPDFpageValue(clipUniqueIdentifier, clientPage).ToUpper.Trim() <> "" Then
                        acctElm.SetAttribute("ID", GetPDFpageValue(clipUniqueIdentifier, clientPage).ToUpper.Trim())
                        For Each xe As XmlElement In clientPageXML.SelectNodes("//Line")
                            Dim coor() As String = xe.GetAttribute("box").Split(",")
                            Dim currY As Decimal = Decimal.Parse(coor(1))
                            If currY < I2P((pagePart * Double.Parse(pageSize))) And currY > I2P(((pagePart - 1) * Double.Parse(pageSize))) Then 'Read blocks up the page
                                Dim docText As String = xe.InnerText.ToUpper.Trim
                                Dim textElm As XmlElement = compareXML.CreateElement("TEXT")
                                textElm.InnerText = docText
                                acctElm.AppendChild(textElm)
                            End If
                        Next
                        rootElm.AppendChild(acctElm)
                    End If
                Next

            End If

        Next


        'Read OSG PDF
        For pageCount = 1 To osgPDF.GetPageCount
            If pageCount Mod 100 = 0 Then
                Status("Processing OSG PDF page (" & pageCount.ToString & ")")
            End If

            Dim osgPage As Page = osgPDF.GetPage(pageCount)
            Dim acctElm As XmlElement = compareXML.CreateElement("OSG_DOC")

            osgPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(osgPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                osgPageXML = New XmlDocument : osgPageXML.LoadXml(txtXML)
            End Using

            'Build OSG XML
            clipUniqueIdentifier = New Rect()
            clipUniqueIdentifier.x1 = I2P(txtOSG_UI_X.Text)
            clipUniqueIdentifier.y1 = I2P(txtOSG_UI_Y.Text)
            clipUniqueIdentifier.x2 = (clipUniqueIdentifier.x1 + I2P(txtOSG_UI_Width.Text))
            clipUniqueIdentifier.y2 = (clipUniqueIdentifier.y1 + I2P(txtOSG_UI_Height.Text))
            acctElm.SetAttribute("ID", GetPDFpageValue(clipUniqueIdentifier, osgPage).ToUpper.Trim())

            For Each xe As XmlElement In osgPageXML.SelectNodes("//Line")
                Dim docText As String = xe.InnerText.ToUpper.Trim
                Dim textElm As XmlElement = compareXML.CreateElement("TEXT")
                textElm.InnerText = docText
                acctElm.AppendChild(textElm)
            Next
            rootElm.AppendChild(acctElm)
        Next

        compareXML.Save(Path.GetDirectoryName(logFileName) & "\compare.xml")


        'Compare XML
        Status("Comparing XML")
        Dim docCount As Integer = 0
        For Each gsbElm As XmlElement In rootElm.SelectNodes("GSB_DOC")
            Dim currAcctNbr As String = gsbElm.GetAttribute("ID")
            Dim osgElm As XmlElement = rootElm.SelectSingleNode("OSG_DOC[@ID='" & currAcctNbr & "']")
            outputLog.WriteLine(currAcctNbr.PadLeft(8, "#").PadRight(8, "#"))
            If IsNothing(osgElm) Then
                outputLog.WriteLine("###FAIL### - [Account Number " & currAcctNbr & "] found in GSB PDF but not OSG PDF")
            Else

                'GSB --> OSG
                For Each gsbLineElm As XmlElement In gsbElm.SelectNodes("TEXT")
                    Dim osgLineElm As XmlElement = osgElm.SelectSingleNode("TEXT[. =" & Chr(34) & updateEncoding(gsbLineElm.InnerText) & Chr(34) & "]")
                    If IsNothing(osgLineElm) Then
                        Dim errorText As String = gsbLineElm.InnerText
                        If validError(errorText) Then
                            outputLog.WriteLine("###FAIL### - [" & gsbLineElm.InnerText & "] found on GSB page but not on OSG page.")
                            globalErrorList.Add(errorText)
                        End If
                    End If
                Next

                'OSG --> GSB
                For Each osgLineElm As XmlElement In osgElm.SelectNodes("TEXT")
                    Dim gsbLineElm As XmlElement = gsbElm.SelectSingleNode("TEXT[. =" & Chr(34) & updateEncoding(osgLineElm.InnerText) & Chr(34) & "]")
                    If IsNothing(gsbLineElm) Then
                        Dim errorText As String = osgLineElm.InnerText
                        If validError(errorText) Then
                            outputLog.WriteLine("###FAIL### - [" & osgLineElm.InnerText & "] found on OSG page but not on GSB page.")
                            globalErrorList.Add(errorText)
                        End If
                    End If
                Next
            End If

            docCount += 1
            If docCount Mod 100 = 0 Then
                Status("Comparing XML (" & docCount.ToString & ")")
            End If
        Next

        docCount = 0
        outputLog.WriteLine("-----MISSING ACCOUNTS IN GSB OUTPUT-----")
        For Each osgElm As XmlElement In rootElm.SelectNodes("OSG_DOC")
            Dim currAcctNbr As String = osgElm.GetAttribute("ID")
            Dim gsbElm As XmlElement = rootElm.SelectSingleNode("GSB_DOC[@ID='" & currAcctNbr & "']")
            If IsNothing(gsbElm) Then
                outputLog.WriteLine("###FAIL### - [Account Number " & currAcctNbr & "] found in OSG PDF but not GSB PDF")
            End If

            docCount += 1
            If docCount Mod 100 = 0 Then
                Status("Checking XML for missing accounts (" & docCount.ToString & ")")
            End If
        Next

        outputLog.Flush() : outputLog.Close()
        Status("Done")
        MsgBox("Logfile saved [" & logFileName.ToString & "]", MsgBoxStyle.Information, "Migration PDF UAT Review")

    End Sub

    Private Function validError(errorText As String) As Boolean

        If errorText.Replace("A", "").Replace("D", "").Replace("F", "").Replace("T", "") = "" Then 'Do not include IMB
            Return False
        End If

        Dim tempArray() As String = errorText.Split("-")
        If tempArray.Length = 5 Then 'Assume OSG GUID
            If tempArray(0).Length = 8 And tempArray(1).Length = 4 And tempArray(2).Length = 4 And tempArray(3).Length = 4 And tempArray(4).Length = 12 Then
                Return False
            End If
        End If

        If Not globalErrorList.Contains(errorText) Then
            globalErrorList.Add(errorText)
            Return True
        End If


        Return False

    End Function

    Private Function updateEncoding(input) As String
        Dim output As String
        output = System.Security.SecurityElement.Escape(input)
        Return (output)

    End Function

    Private Sub CoordinatesBasedPDFs()

        Dim outputLog As New StreamWriter(logFileName)
        Dim pageCount As Integer
        Dim clientPDFAccountsDi As New Dictionary(Of String, Dictionary(Of String, Integer))
        Dim osgPDFAccountsDi As New Dictionary(Of String, Dictionary(Of String, Integer))
        Dim currentAcctDiClient As New Dictionary(Of String, Integer)
        Dim clientPage, osgPage As Page

        'Assign client PDF parsing coordinates/values
        clipUniqueIdentifier = New Rect()
        clipUniqueIdentifier.x1 = I2P(txtGSB_UI_X.Text)
        clipUniqueIdentifier.y1 = I2P(txtGSB_UI_Y.Text)
        clipUniqueIdentifier.x2 = (clipUniqueIdentifier.x1 + I2P(txtGSB_UI_Width.Text))
        clipUniqueIdentifier.y2 = (clipUniqueIdentifier.y1 + I2P(txtGSB_UI_Height.Text))

        clipNewPage = New Rect()
        clipNewPage.x1 = I2P(txtGSB_NP_X.Text)
        clipNewPage.y1 = I2P(txtGSB_NP_Y.Text)
        clipNewPage.x2 = (clipNewPage.x1 + I2P(txtGSB_NP_Width.Text))
        clipNewPage.y2 = (clipNewPage.y1 + I2P(txtGSB_NP_Height.Text))

        newPageLiteral = txtGSB_NP_Literal.Text.ToUpper


        'Read Client PDF
        For pageCount = 1 To clientPDF.GetPageCount
            If pageCount Mod 50 = 0 Then
                Status("Processing Client PDF page (" & pageCount.ToString & ")")
            End If

            clientPage = clientPDF.GetPage(pageCount)
            newPageVal = ""
            newPageVal = GetPDFpageValue(clipNewPage, clientPage).ToUpper.Trim
            If newPageVal.Contains(newPageLiteral) Then
                'New Account
                If pageCount > 1 Then
                    clientPDFAccountsDi.Add(uniqueIdentifierVal, currentAcctDiClient)
                End If

                currentAcctDiClient = New Dictionary(Of String, Integer)
                uniqueIdentifierVal = ""
                uniqueIdentifierVal = GetPDFpageValue(clipUniqueIdentifier, clientPage).ToUpper.Trim
            Else
                'Same Account
                If pageCount = 1 And newPageVal = "" Then
                    MsgBox("Did not encounter page literal value on Page1 of Client PDF, check Client PDF New Page coordinates.", MsgBoxStyle.Critical, "Migration PDF UAT Review")
                    outputLog.Flush() : outputLog.Close() : File.Delete(logFileName)
                    GoTo EndOfSub
                End If
            End If

            'Get clientPage xml
            clientPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(clientPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                clientPageXML = New XmlDocument : clientPageXML.LoadXml(txtXML)
            End Using

            'Build client page dictionary
            For Each xe As XmlElement In clientPageXML.SelectNodes("//Line")
                If Not currentAcctDiClient.ContainsKey(xe.InnerText.ToUpper.Trim) Then
                    currentAcctDiClient.Add(xe.InnerText.ToUpper.Trim, 1)
                Else
                    Dim currentCount As Integer = currentAcctDiClient(xe.InnerText.ToUpper.Trim)
                    currentCount += 1
                    currentAcctDiClient(xe.InnerText.ToUpper.Trim) = currentCount
                End If
            Next
        Next

        'Last account on client PDF
        clientPDFAccountsDi.Add(uniqueIdentifierVal, currentAcctDiClient)



        Dim currentAcctDiOSG As New Dictionary(Of String, Integer)

        'Assign OSG PDF parsing coordinates/values
        clipUniqueIdentifier = New Rect()
        clipUniqueIdentifier.x1 = I2P(txtOSG_UI_X.Text)
        clipUniqueIdentifier.y1 = I2P(txtOSG_UI_Y.Text)
        clipUniqueIdentifier.x2 = (clipUniqueIdentifier.x1 + I2P(txtOSG_UI_Width.Text))
        clipUniqueIdentifier.y2 = (clipUniqueIdentifier.y1 + I2P(txtOSG_UI_Height.Text))

        clipNewPage = New Rect()
        clipNewPage.x1 = I2P(txtOSG_NP_X.Text)
        clipNewPage.y1 = I2P(txtOSG_NP_Y.Text)
        clipNewPage.x2 = (clipNewPage.x1 + I2P(txtOSG_NP_Width.Text))
        clipNewPage.y2 = (clipNewPage.y1 + I2P(txtOSG_NP_Height.Text))

        newPageLiteral = txtOSG_NP_Literal.Text.ToUpper


        'Read OSG PDF
        For pageCount = 1 To osgPDF.GetPageCount
            If pageCount Mod 50 = 0 Then
                Status("Processing OSG PDF page (" & pageCount.ToString & ")")
            End If

            osgPage = osgPDF.GetPage(pageCount)
            newPageVal = ""
            newPageVal = GetPDFpageValue(clipNewPage, osgPage).ToUpper.Trim
            If newPageVal.Contains(newPageLiteral) Then
                'New Account
                If pageCount > 1 Then
                    osgPDFAccountsDi.Add(uniqueIdentifierVal, currentAcctDiOSG)
                End If

                currentAcctDiOSG = New Dictionary(Of String, Integer)
                uniqueIdentifierVal = ""
                uniqueIdentifierVal = GetPDFpageValue(clipUniqueIdentifier, osgPage).ToUpper.Trim
            Else
                'Same Account
                If pageCount = 1 And newPageVal = "" Then
                    MsgBox("Did not encounter page literal value on Page1 of OSG PDF, check OSG PDF New Page coordinates.", MsgBoxStyle.Critical, "Migration PDF UAT Review")
                    outputLog.Flush() : outputLog.Close() : File.Delete(logFileName)
                    GoTo EndOfSub
                End If
            End If

            'Get osgPage xml
            osgPageXML = Nothing
            Using txt As TextExtractor = New TextExtractor
                Dim txtXML As String
                txt.Begin(osgPage)
                txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
                osgPageXML = New XmlDocument : osgPageXML.LoadXml(txtXML)
            End Using

            'Build osg page dictionary
            For Each xe As XmlElement In osgPageXML.SelectNodes("//Line")
                If Not currentAcctDiOSG.ContainsKey(xe.InnerText.ToUpper.Trim) Then
                    currentAcctDiOSG.Add(xe.InnerText.ToUpper.Trim, 1)
                Else
                    Dim currentCount As Integer = currentAcctDiOSG(xe.InnerText.ToUpper.Trim)
                    currentCount += 1
                    currentAcctDiOSG(xe.InnerText.ToUpper.Trim) = currentCount
                End If
            Next
        Next

        'Last account on OSG PDF
        osgPDFAccountsDi.Add(uniqueIdentifierVal, currentAcctDiOSG)


        'Go through dictionaries
        Dim keyCount As Integer = 0
        For Each key As String In clientPDFAccountsDi.Keys
            keyCount += 1

            If keyCount > 1 Then
                outputLog.WriteLine(vbCrLf)
            End If
            outputLog.WriteLine("PDF Acct# " & key & vbCrLf & "--------------" & vbCrLf)

            If osgPDFAccountsDi.ContainsKey(key) Then
                Dim tempClientDict As Dictionary(Of String, Integer) = clientPDFAccountsDi(key)
                Dim tempOSGDict As Dictionary(Of String, Integer) = osgPDFAccountsDi(key)
                For Each keyVal As String In tempClientDict.Keys
                    If tempOSGDict.ContainsKey(keyVal) Then
                        If tempClientDict(keyVal) = tempOSGDict(keyVal) Then
                            outputLog.WriteLine("   PASS    - [" & tempClientDict(keyVal).ToString & "] """ & keyVal & """ found on Client and OSG page.")
                        Else
                            outputLog.WriteLine("###FAIL### - [" & tempClientDict(keyVal).ToString & "] """ & keyVal & """ found on Client page and [" & tempOSGDict(keyVal).ToString & "] found on OSG page.")
                        End If
                    Else
                        outputLog.WriteLine("###FAIL### - [" & tempClientDict(keyVal).ToString & "] """ & keyVal & """ found on Client page and [0] found on OSG page.")
                    End If
                Next
            Else
                outputLog.WriteLine("###FAIL### - Account# """ & key & """ from Client PDF not found in the OSG PDF.")
            End If
        Next


        outputLog.Flush() : outputLog.Close()
        Status("Done")
        MsgBox("Logfile saved [" & logFileName.ToString & "]", MsgBoxStyle.Information, "Migration PDF UAT Review")

EndOfSub:
    End Sub

    Private Function GetPDFpageValue(clipRect As Rect, currentPage As Page) As String

        Dim docXML As New XmlDocument
        Dim X, Y, prevY As Double
        Dim x1Content As Double = clipRect.x1
        Dim y1Content As Double = clipRect.y1
        Dim x2Content As Double = clipRect.x2
        Dim y2Content As Double = clipRect.y2
        Dim contentValue As String = ""

        Using txt As TextExtractor = New TextExtractor
            Dim txtXML As String
            txt.Begin(currentPage, clipRect)
            txtXML = txt.GetAsXML(TextExtractor.XMLOutputFlags.e_output_bbox)
            docXML.LoadXml(txtXML)

            Dim tempRoot As XmlElement = docXML.DocumentElement
            Dim tempxnl1 As XmlNodeList
            tempxnl1 = Nothing
            tempxnl1 = tempRoot.SelectNodes("Flow/Para/Line")
            prevY = 0
            For Each elmC As XmlElement In tempxnl1
                Dim pos() As String = elmC.GetAttribute("box").Split(","c)
                X = CDbl(pos(0)) : Y = CDbl(pos(1))

                'Page(Content)
                If (X >= x1Content) And (Y >= y1Content) And (X <= x2Content) And (Y <= y2Content) Then
                    If contentValue = "" Then
                        If prevY <> Math.Round(Y, 3) Then
                            contentValue = elmC.InnerText.Replace(vbLf, "")
                        End If
                    Else
                        contentValue = contentValue & elmC.InnerText.Replace(vbLf, "")
                    End If
                End If

                prevY = Math.Round(Y, 3)
                elmC = Nothing
            Next
        End Using

        Return contentValue

    End Function

#End Region

#Region "File Browsing"

    Private Sub btnOSGPDF_Click(sender As Object, e As System.EventArgs) Handles btnOSGPDF.Click
        openFileDialog.Filter = "PDF Files|*.pdf"
        openFileDialog.FileName = ""
        openFileDialog.ShowDialog()
        txtOSG_PDFfilename.Text = openFileDialog.FileName
    End Sub

    Private Sub btnClientPDF_Click(sender As Object, e As System.EventArgs) Handles btnClientPDF.Click
        openFileDialog.Filter = "PDF Files|*.pdf"
        openFileDialog.FileName = ""
        openFileDialog.ShowDialog()
        txtGSB_PDFfilename.Text = openFileDialog.FileName
    End Sub

    Private Sub btnConfigFile_Click(sender As Object, e As System.EventArgs) Handles btnConfigFile.Click
        openFileDialog.Filter = "XML Files|*.xml"
        openFileDialog.FileName = ""
        openFileDialog.ShowDialog()
        txtConfigFile.Text = openFileDialog.FileName
        loadDefaults()
    End Sub

#End Region

#Region "Other Processes"

    Private Sub loadDefaults()
        Dim configFile As New XmlDocument

        If txtConfigFile.Text = "" Then Exit Sub

        If Not File.Exists(txtConfigFile.Text) Then
            MsgBox("Cannot find config file", MsgBoxStyle.Critical, "MigrationPDF_UAT")
            txtConfigFile.Focus()
            Exit Sub
        End If

        configFile.Load(txtConfigFile.Text)
        Dim rootElm As XmlElement = configFile.DocumentElement

        txtGSB_PDFfilename.Text = getConfigVal(rootElm, "GSB_PDFfile")
        txtGSB_UI_X.Text = getConfigVal(rootElm, "GSB_UI_X")
        txtGSB_UI_Y.Text = getConfigVal(rootElm, "GSB_UI_Y")
        txtGSB_UI_Width.Text = getConfigVal(rootElm, "GSB_UI_Width")
        txtGSB_UI_Height.Text = getConfigVal(rootElm, "GSB_UI_Height")
        txtGSB_NP_X.Text = getConfigVal(rootElm, "GSB_NP_X")
        txtGSB_NP_Y.Text = getConfigVal(rootElm, "GSB_NP_Y")
        txtGSB_NP_Width.Text = getConfigVal(rootElm, "GSB_NP_Width")
        txtGSB_NP_Height.Text = getConfigVal(rootElm, "GSB_NP_Height")
        txtGSB_NP_Literal.Text = getConfigVal(rootElm, "GSB_NP_Literal")
        txtPageSize.Text = getConfigVal(rootElm, "PageSize")

        txtOSG_PDFfilename.Text = getConfigVal(rootElm, "OSG_PDFfile")
        txtOSG_UI_X.Text = getConfigVal(rootElm, "OSG_UI_X")
        txtOSG_UI_Y.Text = getConfigVal(rootElm, "OSG_UI_Y")
        txtOSG_UI_Width.Text = getConfigVal(rootElm, "OSG_UI_Width")
        txtOSG_UI_Height.Text = getConfigVal(rootElm, "OSG_UI_Height")
        txtOSG_NP_X.Text = getConfigVal(rootElm, "OSG_NP_X")
        txtOSG_NP_Y.Text = getConfigVal(rootElm, "OSG_NP_Y")
        txtOSG_NP_Width.Text = getConfigVal(rootElm, "OSG_NP_Width")
        txtOSG_NP_Height.Text = getConfigVal(rootElm, "OSG_NP_Height")
        txtOSG_NP_Literal.Text = getConfigVal(rootElm, "OSG_NP_Literal")

    End Sub

    Private Function getConfigVal(rootElm As XmlElement, attName As String) As String
        Dim val As String
        Dim entry As XmlElement = rootElm.SelectSingleNode("ENTRY[@name='" & attName & "']")
        If IsNothing(entry) Then
            Return ""
        End If

        val = entry.GetAttribute("val")

        Return val

    End Function

    Private Function I2P(i As String) As Double
        Return (CDbl(i) * 72)
    End Function

    Private Sub disableButtons()
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is GroupBox Then
                For Each subCtl As Control In ctl.Controls
                    If TypeOf subCtl Is Button Then
                        subCtl.Enabled = False
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub enableButtons()
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is GroupBox Then
                For Each subCtl As Control In ctl.Controls
                    If TypeOf subCtl Is Button Then
                        subCtl.Enabled = True
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub resetTextBoxesAndCheckBox()

        For i As Integer = 0 To (boxes.Count - 1)
            boxes(i).Enabled = True : boxes(i).Text = ""
        Next

        CheckBox1.Enabled = True : CheckBox1.Checked = False

    End Sub

    Private Function checkCoordinateAndLiteralTextBoxes() As Boolean

        Dim blankTextBox As Boolean = False
        Dim errorTextBox As String = ""

        Select Case True
            Case txtGSB_UI_X.Text = ""
                blankTextBox = True : errorTextBox = "Client Unique Identifier X"

            Case txtGSB_UI_Y.Text = ""
                blankTextBox = True : errorTextBox = "Client Unique Identifier Y"

            Case txtGSB_UI_Height.Text = ""
                blankTextBox = True : errorTextBox = "Client Unique Identifier Height"

            Case txtGSB_UI_Width.Text = ""
                blankTextBox = True : errorTextBox = "Client Unique Identifier Width"

            Case txtGSB_NP_Height.Text = ""
                blankTextBox = True : errorTextBox = "Client New Page Height"

            Case txtGSB_NP_Width.Text = ""
                blankTextBox = True : errorTextBox = "Client New Page Width"

            Case txtGSB_NP_Y.Text = ""
                blankTextBox = True : errorTextBox = "Client New Page Y"

            Case txtGSB_NP_X.Text = ""
                blankTextBox = True : errorTextBox = "Client New Page X"

            Case txtGSB_NP_Literal.Text = ""
                blankTextBox = True : errorTextBox = "Client New Page Literal"

            Case txtOSG_UI_X.Text = ""
                blankTextBox = True : errorTextBox = "OSG Unique Identifier X"

            Case txtOSG_UI_Y.Text = ""
                blankTextBox = True : errorTextBox = "OSG Unique Identifier Y"

            Case txtOSG_UI_Height.Text = ""
                blankTextBox = True : errorTextBox = "OSG Unique Identifier Height"

            Case txtOSG_UI_Width.Text = ""
                blankTextBox = True : errorTextBox = "OSG Unique Identifier Width"

            Case txtOSG_NP_Height.Text = ""
                blankTextBox = True : errorTextBox = "OSG New Page Height"

            Case txtOSG_NP_Width.Text = ""
                blankTextBox = True : errorTextBox = "OSG New Page Width"

            Case txtOSG_NP_Y.Text = ""
                blankTextBox = True : errorTextBox = "OSG New Page Y"

            Case txtOSG_NP_X.Text = ""
                blankTextBox = True : errorTextBox = "OSG New Page X"

            Case txtOSG_NP_Literal.Text = ""
                blankTextBox = True : errorTextBox = "OSG New Page Literal"
        End Select

        If blankTextBox Then
            MsgBox("No value entered for " & errorTextBox, MsgBoxStyle.Critical, "Migration PDF UAT Review")
            enableButtons()
        End If

        Return blankTextBox

    End Function

    Private Sub textChangeCheck(currentTB As TextBox, tempIndex As Integer, Optional numericCheck As Boolean = True)

        If currentTB.Text = "" Then
            Dim textBoxBool As Boolean = True
            For i As Integer = 0 To (boxes.Count - 1)
                If i <> tempIndex Then
                    If boxes(i).Text <> "" Then textBoxBool = False
                End If
            Next
            CheckBox1.Enabled = textBoxBool
        Else
            CheckBox1.Enabled = False
        End If

        If numericCheck Then
            If currentTB.Text <> "" Then
                If Not IsNumeric(currentTB.Text) Then
                    MsgBox("Enter a numeric value", MsgBoxStyle.Critical, "Migration PDF UAT Review")
                    currentTB.Text = ""
                End If
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Dim enabledBool As Boolean = True
        If CheckBox1.Checked Then
            enabledBool = False
        End If

        For i As Integer = 0 To (boxes.Count - 1)
            boxes(i).Enabled = enabledBool
        Next

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_UI_X.TextChanged
        tempTB = txtGSB_UI_X
        textChangeCheck(tempTB, 0)
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_UI_Y.TextChanged
        tempTB = txtGSB_UI_Y
        textChangeCheck(tempTB, 1)
    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_UI_Height.TextChanged
        tempTB = txtGSB_UI_Height
        textChangeCheck(tempTB, 2)
    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_UI_Width.TextChanged
        tempTB = txtGSB_UI_Width
        textChangeCheck(tempTB, 3)
    End Sub

    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_NP_Height.TextChanged
        tempTB = txtGSB_NP_Height
        textChangeCheck(tempTB, 4)
    End Sub

    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_NP_Width.TextChanged
        tempTB = txtGSB_NP_Width
        textChangeCheck(tempTB, 5)
    End Sub

    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_NP_Y.TextChanged
        tempTB = txtGSB_NP_Y
        textChangeCheck(tempTB, 6)
    End Sub

    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_NP_X.TextChanged
        tempTB = txtGSB_NP_X
        textChangeCheck(tempTB, 7)
    End Sub

    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGSB_NP_Literal.TextChanged
        tempTB = txtGSB_NP_Literal
        textChangeCheck(tempTB, 8, False)
    End Sub

    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_NP_Literal.TextChanged
        tempTB = txtOSG_NP_Literal
        textChangeCheck(tempTB, 9, False)
    End Sub

    Private Sub TextBox11_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_NP_Height.TextChanged
        tempTB = txtOSG_NP_Height
        textChangeCheck(tempTB, 10)
    End Sub

    Private Sub TextBox12_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_NP_Width.TextChanged
        tempTB = txtOSG_NP_Width
        textChangeCheck(tempTB, 11)
    End Sub

    Private Sub TextBox13_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_NP_Y.TextChanged
        tempTB = txtOSG_NP_Y
        textChangeCheck(tempTB, 12)
    End Sub

    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_NP_X.TextChanged
        tempTB = txtOSG_NP_X
        textChangeCheck(tempTB, 13)
    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_UI_Height.TextChanged
        tempTB = txtOSG_UI_Height
        textChangeCheck(tempTB, 14)
    End Sub

    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_UI_Width.TextChanged
        tempTB = txtOSG_UI_Width
        textChangeCheck(tempTB, 15)
    End Sub

    Private Sub TextBox17_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_UI_Y.TextChanged
        tempTB = txtOSG_UI_Y
        textChangeCheck(tempTB, 16)
    End Sub

    Private Sub TextBox18_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOSG_UI_X.TextChanged
        tempTB = txtOSG_UI_X
        textChangeCheck(tempTB, 17)
    End Sub

    Private Sub Status(ByVal txt As String)
        StatusLabel.Text = txt
        StatusStrip1.Refresh()
        Application.DoEvents()
    End Sub

#End Region

End Class
