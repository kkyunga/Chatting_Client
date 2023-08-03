using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chatting_Client
{
    delegate void SetTextDelegate(string s);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tcpClient = null;
        NetworkStream ntwStream = null;

        ChatHandler chatHandler = new ChatHandler();  // 서버와 채팅 실행

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "입장")
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 2023);

                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, txtChatMsg);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    Message_Send("<" + txtName.Text + "> 님께서 접속 하였습니다.", true);
                    btnConnect.Text = "나가기";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chatting_Server 오류 발생 또는 Start 되지 않았거나\r\n" + ex.Message, "Client");
                }
            }
            else
            {
                Message_Send("<" + txtName.Text + "> 님께서 접속해제 하였습니다.", false);
                chatHandler.ChatClose();
                ntwStream.Close();
                tcpClient.Close();

                btnConnect.Text = "입장";
            }
        }

        public void Message_Send(string message, Boolean Msg)
        {
            try
            {
                string dataToSend = message + "\r\n";
                byte[] data = Encoding.Default.GetBytes(dataToSend);
                ntwStream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("서버가 Start 되지 않았거나 \r\n" + ex.Message, "Client");
                    btnConnect.Text = "입장";
                    chatHandler.ChatClose();
                    ntwStream.Close();
                    tcpClient.Close();
                }
            }
        }

        public void SetText(string text)
        {
            if (this.txtChatMsg.InvokeRequired)  // true
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else                                 // false
            {
                this.txtChatMsg.AppendText(text);
            }
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnConnect.Text == "나가기")
                {
                    Message_Send("<" + txtName.Text + ">" + txtMsg.Text, true);
                }

                txtMsg.Text = "";
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "나가기")
            {
                Message_Send("<" + txtName.Text + ">" + txtMsg.Text, true);
            }

            txtMsg.Text = "";
        }
    }

    public class ChatHandler
    {
        private TextBox txtChatMsg;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Form1 form1;

        public void Setup(Form1 form1, NetworkStream netStream, TextBox txtChatMsg)
        {
            this.txtChatMsg = txtChatMsg;
            this.form1 = form1;
            this.netStream = netStream;
            this.strReader = new StreamReader(netStream);
        }

        public void ChatClose()
        {
            netStream.Close();
            strReader.Close();
        }

        public void ChatProcess()
        {
            while (true)
            {
                try
                {
                    string msg = strReader.ReadLine();

                    if (msg != null && msg != "")
                    {
                        form1.SetText(msg + "\r\n");
                    }
                }
                catch (Exception ex)
                {
                    break;
                }
            }
        }
    }
}