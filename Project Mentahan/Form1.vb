Imports ATSMS
Public Class Form1
    Private WithEvents oGsmModem As New GSMModem
    Dim TextTerima As String
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("https://www.instagram.com/mr._unknown_02/")

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        oGsmModem.Port = “Com” & TextBox1.Text
        oGsmModem.BaudRate = 115200
        oGsmModem.DataBits = 8
        oGsmModem.StopBits = Common.EnumStopBits.One
        oGsmModem.FlowControl = Common.EnumFlowControl.None
        Try
            oGsmModem.Connect()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Button1.Text = “CONNECT”
            Return
        End Try

        Try
            oGsmModem.NewMessageIndication = True
        Catch ex As Exception

        End Try
        MsgBox(“Modem Anda Sudah terkoneksi !”, MsgBoxStyle.Information)
        Button1.Text = “DISCONNECT”
    End Sub
    Private Sub oGsmModem_NewMessageReceived(ByVal e As ATSMS.NewMessageReceivedEventArgs) Handles oGsmModem.NewMessageReceived
        TextBox2.Text = e.MSISDN
        TextBox3.Text = e.TextMessage
    End Sub
End Class
