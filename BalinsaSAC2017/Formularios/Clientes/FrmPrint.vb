Imports System.Drawing.Printing

Public Class FrmPrint
    Dim i As Integer = 0
    Dim rz() As String

    ' The DataGridView Control which will be printed.
    Dim MyDataGridViewprinter As DataGridViewPrinter

    ' The printing setup function
    Private Function SetupThePrinting() As Boolean
        Dim MyPrintDialog As New PrintDialog()
        MyPrintDialog.AllowCurrentPage = False
        MyPrintDialog.AllowPrintToFile = False
        MyPrintDialog.AllowSelection = False
        MyPrintDialog.AllowSomePages = False
        MyPrintDialog.PrintToFile = False
        MyPrintDialog.ShowHelp = False
        MyPrintDialog.ShowNetwork = False

        If MyPrintDialog.ShowDialog() <> DialogResult.OK Then
            Return False
        End If

        MyPrintDocument.DocumentName = "Reporte de Usuarios"
        MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
        MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
        MyPrintDocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)

        If MessageBox.Show("¿Quieres que el informe se centre en la página", "InvoiceManager - Centrar en Pagina", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            MyDataGridViewprinter = New DataGridViewPrinter(dgvClientes, MyPrintDocument, True, True, "Customers", New Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), _
                Color.Black, True)
        Else
            MyDataGridViewprinter = New DataGridViewPrinter(dgvClientes, MyPrintDocument, False, True, "Customers", New Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), _
                Color.Black, True)
        End If

        Return True
    End Function
    Private Sub FrmPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmCarteraClientes.Enabled = True
    End Sub

    Private Sub VistapreviadeimpresiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VistapreviadeimpresiónToolStripMenuItem.Click

        PrintPreviewDialog.Document = MyPrintDocument
        PrintPreviewDialog.ShowDialog()
        ''If SetupThePrinting() Then
        ''----Dim MyPrintPreviewDialog As New PrintPreviewDialog()
        ''PrintPreviewDialog.Document = MyPrintDocument
        ''PrintPreviewDialog.ShowDialog()
        ''End If
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles MyPrintDocument.PrintPage

        ' Definimos la fuente que vamos a usar para imprimir
        ' en este caso Arial de 10
        Dim printFont As System.Drawing.Font = New Font("Arial", 7)
        Dim printFont1 As System.Drawing.Font = New Font("Arial", 10)
        Dim topMargin As Double = e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim yPos1 As Double = 0
        Dim yPos2 As Double = 0
        Dim linesPerPage As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""
        Dim texup As String = "-----------------------------------------------------------------------------------------------------------------------------------------------"
        Dim row As System.Windows.Forms.DataGridViewRow
        Dim x, y, w, h, k As Integer
        ' Calculamos el número de líneas que caben en cada página
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)
        ' Imprimimos las cabeceras
        ''Dim header As DataGridViewHeaderCell
        ''For Each column As DataGridViewColumn In dgvClientes.Columns
        ''header = column.HeaderCell
        ''texto += vbTab + header.FormattedValue.ToString() ' 
        ''Next
        yPos = topMargin + (count * printFont.GetHeight(e.Graphics))
        x = 10
        y = yPos
        w = 800
        h = 20
        ' cramos un rectangulo para los emcabezados
        Dim rec As New Rectangle(x, y, w, h)
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec)
        e.Graphics.DrawRectangle(Pens.Black, rec)
        e.Graphics.DrawString("N°", printFont1, System.Drawing.Brushes.Black, 10, yPos)
        e.Graphics.DrawString("| Razon Social", printFont1, System.Drawing.Brushes.Black, 40, yPos)
        e.Graphics.DrawString("| Contactos", printFont1, System.Drawing.Brushes.Black, 330, yPos)
        e.Graphics.DrawString("| Cargo", printFont1, System.Drawing.Brushes.Black, 430, yPos)
        e.Graphics.DrawString("| Telefono", printFont1, System.Drawing.Brushes.Black, 530, yPos)
        e.Graphics.DrawString("| Correo", printFont1, System.Drawing.Brushes.Black, 630, yPos)
        ' Dejamos una línea de separación
        count += 3
        ' Recorremos las filas del DataGridView hasta que llegemos
        ' a las líneas que nos caben en cada página o al final del grid.
        While count < linesPerPage AndAlso i < dgvClientes.Rows.Count
            row = dgvClientes.Rows(i)
            texto = ""
            k += 1
            For Each celda As System.Windows.Forms.DataGridViewCell In row.Cells
                'Comprobamos que la celda tenga algún valor, en caso de 
                'permitir añadir filas esto es muy importante
                If celda.Value IsNot Nothing Then
                    texto += " | " + celda.Value.ToString()
                End If
            Next
            ' Calculamos la posición en la que se escribe la línea
            yPos1 = yPos - 10
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics))
            ' Escribimos la línea con el objeto Graphics
            e.Graphics.DrawString(texto, printFont, System.Drawing.Brushes.Black, 10, yPos)
            ' Incrementamos los contadores
            count += 1
            i += 1
        End While

        ' Una vez fuera del bucle comprobamos si nos quedan más filas
        ' por imprimir, si quedan saldrán en la siguente página
        If i < dgvClientes.Rows.Count Then
            e.HasMorePages = True
        Else
            ' si llegamos al final, se establece HasMorePages a
            ' false para que se acabe la impresión
            e.HasMorePages = False
            ' Es necesario poner el contador a 0 porque, por ejemplo si se hace
            ' una impresión desde PrintPreviewDialog, se vuelve disparar este
            ' evento como si fuese la primera vez, y si i está con el valor de la
            ' última fila del grid no se imprime nada
            i = 0
            ReDim rz(0)
        End If





        '|||----------->>>>>
        'Dim more As Boolean = MyDataGridViewprinter.DrawDataGridView(e.Graphics)
        'If more = True Then
        'e.HasMorePages = True
        'End If
        '<<<<<------------||||


        'Dim con As Integer
        'con = dgvClientes.RowCount

        'Dim rec As New Rectangle(10, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec)
        'e.Graphics.DrawRectangle(Pens.Black, rec)
        'e.Graphics.DrawString(Column6.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec)

        'Dim rec1 As New Rectangle(110, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec1)
        'e.Graphics.DrawRectangle(Pens.Black, rec1)
        'e.Graphics.DrawString(Column3.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec1)

        'Dim rec2 As New Rectangle(210, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec2)
        'e.Graphics.DrawRectangle(Pens.Black, rec2)
        'e.Graphics.DrawString(Column1.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec2)

        'Dim rec3 As New Rectangle(310, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec3)
        'e.Graphics.DrawRectangle(Pens.Black, rec3)
        'e.Graphics.DrawString(Column2.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec3)

        'Dim rec4 As New Rectangle(410, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec4)
        'e.Graphics.DrawRectangle(Pens.Black, rec4)
        'e.Graphics.DrawString(Column7.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec4)

        'Dim rec5 As New Rectangle(510, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec5)
        'e.Graphics.DrawRectangle(Pens.Black, rec5)
        'e.Graphics.DrawString(Column4.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec5)

        'Dim rec6 As New Rectangle(610, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec6)
        'e.Graphics.DrawRectangle(Pens.Black, rec6)
        'e.Graphics.DrawString(Column5.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec6)

        'Dim rec7 As New Rectangle(710, 10, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec7)
        'e.Graphics.DrawRectangle(Pens.Black, rec7)
        'e.Graphics.DrawString(Column8.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec7)

        'Dim rec8 As New Rectangle(10, 30, 100, 20)
        'e.Graphics.FillRectangle(Brushes.WhiteSmoke, rec8)
        'e.Graphics.DrawRectangle(Pens.Black, rec8)
        'e.Graphics.DrawString(Column8.HeaderText, SystemFonts.DefaultFont, Brushes.Black, rec8)


    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub FrmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click

        If SetupThePrinting() Then
            MyPrintDocument.Print()
        End If

    End Sub

    
End Class