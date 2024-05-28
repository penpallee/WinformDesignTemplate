using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Net.Sockets;
using System.Management;

namespace MIL_MODULE.Utilities
{
    public static class WinformHelper
    {
        static WinformHelper() { }

        #region [기타]
        /// <summary>
        /// 이름에 'SSD'가 들어간 저장매체를 찾아 시리얼번호를 반환하는 함수
        /// </summary>
        /// <returns>
        ///     첫번째 SSD의 시리얼번호
        /// </returns>
        public static string GetFirstSSDSerialNumber()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            string ssdSerial = String.Empty;

            foreach (ManagementObject managementObject in managementObjectSearcher.Get())
            {
                TreeNode node = new TreeNode(managementObject.ToString());

                node.Nodes.Add("모델 : " + managementObject["Model"].ToString());
                node.Nodes.Add("인터페이스 : " + managementObject["InterfaceType"].ToString());
                node.Nodes.Add("시리얼 번호 : " + managementObject["SerialNumber"].ToString().Trim());

                if (managementObject["Model"].ToString().Contains("SSD"))
                {
                    ssdSerial = managementObject["SerialNumber"].ToString();
                    break;
                }
            }

            return ssdSerial;
        }

        public static string GetRealTimeForLog2()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }

        public static string GetRealTimeForSave()
        {
            return DateTime.Now.ToString("HH_mm_ss_fff");
        }

        public static string GetRealTime()
        {
            DateTime now = DateTime.Now;

            string formattedTime = now.ToString("yyyy - MM - dd(dddd) HH : mm : ss");

            return formattedTime;
        }

        public static string GetRealTimeForLog()
        {
            DateTime now = DateTime.Now;

            string formattedTime = now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            return formattedTime;
        }

        public static long GetUnixTimeMilliseconds(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        }

        public static DateTime UnixTimeToDateTime(double unixTime, double addHours)
        {
            DateTime temp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddHours(addHours);
            return temp.AddMilliseconds(unixTime).ToLocalTime();
        }

        /// <summary>
        /// 로컬 IP 가져오기
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string localIP = string.Empty;
            using (System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }

        /// <summary>
        /// IP 핑 테스트
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>성공시 주소, 응답시간, 데이터의 유효 기간, 손실데이터 유무, 버퍼사이즈 반환 / 실패시 "" 반환</returns>
        public static string PingTest(string ip)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(IPAddress.Parse(ip), timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                string str = string.Empty;
                str += "Address: " + reply.Address.ToString() + "\n";   // 주소
                str += "RoundTrip time: " + reply.RoundtripTime + "ms\n";   // 응답시간
                str += "Time to live: " + reply.Options.Ttl + "\n";   // TTL : 데이터의 유효 기간
                str += "Don't fragment: " + reply.Options.DontFragment + "\n";   // 손실데이터 유무
                str += "Buffer size: " + reply.Buffer.Length + "\n\n";   // 버퍼사이즈

                return str;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 해당 IP의 장치이름 가져오기
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetIPDeviceName(string ip)
        {
            string result = "";

            try
            {
                result = Dns.GetHostEntry(IPAddress.Parse(ip)).HostName.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        // 10진수를 2진수로 변환해서 반환
        public static string DecimalToBinary(int decimalNum)
        {
            return Convert.ToString(decimalNum, 2);
        }

        // 2진수를 10진수로 변환해서 반환
        public static int BinaryToDecimal(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }
        #endregion

        #region [ Windows Folder ]
        /// <summary>
        ///     새로운 모델 폴더 생성
        /// </summary>
        /// <param name="newModelName"></param>
        public static void CreateNewModelFolder(string path)
        {
            if (!ExistFolder(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// sourceFolderPath의 모든 파일을 ModelFolderPath + name폴더에 복사
        /// </summary>
        /// <param name="sourceFolderPath"></param>
        /// <param name="ModelFolderPath"></param>
        /// <param name="name"></param>
        public static void CopyFileFromFolder(string sourceFolderPath, string ModelFolderPath, string name)
        {
            //@ 파일명 중복체크 로직 넣기

            string targetFolderPath = ModelFolderPath + name;
            foreach (string file in Directory.GetFiles(sourceFolderPath, "*.*", SearchOption.AllDirectories))
            {
                string destinationFilePath = file.Replace(sourceFolderPath, targetFolderPath);

                File.Copy(file, destinationFilePath);
            }
        }

        public static void DeleteFolder(string path)
        {
            if (ExistFolder(path))
                Directory.Delete(path, true);
        }

        public static bool ExistFolder(string path)
        {
            return Directory.Exists(path);
        }
        #endregion

        #region [문자열]

        /// <summary>
        /// 입력한 문자열에 있는 정수를 분리해서 반환한다.
        /// </summary>
        /// <param name="inputString"> 정수를 포함하는 문자열 </param>
        /// <returns> 문자열에 포함된 정수 리스트 </returns>
        public static List<int> ExtractNumbersFromString(string inputString)
        {
            List<int> numbers = new List<int>();

            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    int number = int.Parse(c.ToString());
                    numbers.Add(number);
                }
            }

            return numbers;
        }
        #endregion

        #region [체크]
        public static string StringFormat(string format, object value)
        {
            return String.Format(format, value);
        }

        /// <summary>
        /// 문자열이 정수값인지 아닌지 검사하고 해당 숫자를 반환, 정수가 아니면 0을 반환
        /// </summary>
        /// <param name="input"> 검증 대상인 문자열 </param>
        /// <returns>
        ///     정수면 - 숫자
        ///     정수가 아니면 - 0
        /// </returns>
        public static int IsInteger(string input)
        {
            int number;

            if (int.TryParse(input, out number))
            {
                return number;
            }

            return 0;
        }

        /// <summary>
        /// 문자열이 숫자인지 아닌지 검사하고 해당 숫자를 반환, 숫자가 아니면 0을 반환
        /// </summary>
        /// <param name="value"> 검증 대상인 문자열 </param>
        /// <returns>
        ///     숫자라면 - 숫자
        ///     숫자가 아니면 - 0
        /// </returns>
        public static double IsNumeric(string value)
        {
            double result;

            if (!double.TryParse(value, out result))
            {
                return 0;
            }
            return result;
        }
        #endregion

        #region [ Textbox ]
        public static string GetText_TextBox(System.Windows.Forms.TextBox tb)
        {
            string result = "";
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (tb.InvokeRequired)
            {
                tb.Invoke(new MethodInvoker(delegate ()
                {
                    result = tb.Text;
                }));
            }
            else
            {
                result = tb.Text;
            }
            return result;
        }

        public static void SetText_TextBox(System.Windows.Forms.TextBox tb, string data)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new MethodInvoker(delegate ()
                {
                    tb.Text = data;
                }));
            }
            else
            {
                tb.Text = data;
            }
        }

        public static void SetAppend_TextBox(System.Windows.Forms.TextBox tb, string data)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new MethodInvoker(delegate ()
                {
                    tb.AppendText($"{data}\r\n");
                }));
            }
            else
            {
                tb.AppendText($"{data}\r\n");
            }
        }

        public static void ClearText_TextBox(System.Windows.Forms.TextBox tb)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new MethodInvoker(delegate ()
                {
                    tb.Clear();
                }));
            }
            else
            {
                tb.Clear();
            }
        }
        #endregion

        #region [ Combobox ]
        public static string GetText_ComboBox(System.Windows.Forms.ComboBox cb)
        {
            string result = "";
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (cb.InvokeRequired)
            {
                cb.Invoke(new MethodInvoker(delegate ()
                {
                    result = cb.Text;
                }));
            }
            else
            {
                result = cb.Text;
            }
            return result;
        }


        public static void SetText_ComboBox(System.Windows.Forms.ComboBox cb, string data)
        {
            if (cb.InvokeRequired)
            {
                cb.Invoke(new MethodInvoker(delegate ()
                {
                    cb.Text = data;
                }));
            }
            else
            {
                cb.Text = data;
            }
        }

        public static void ClearText_ComboBox(System.Windows.Forms.ComboBox cb)
        {
            if (cb.InvokeRequired)
            {
                cb.Invoke(new MethodInvoker(delegate ()
                {
                    cb.Text = "";
                }));
            }
            else
            {
                cb.Text = "";
            }
        }

        public static string GetSelectItem_ComboBox(System.Windows.Forms.ComboBox cb)
        {
            string result = "";
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (cb.InvokeRequired)
            {
                cb.Invoke(new MethodInvoker(delegate ()
                {
                    result = cb.SelectedItem == null ? "" : cb.SelectedItem.ToString();
                }));
            }
            else
            {
                result = cb.SelectedItem == null ? "" : cb.SelectedItem.ToString();
            }
            return result;
        }
        #endregion

        #region [ Checkbox ]
        public static void SetChecked_CheckBox(System.Windows.Forms.CheckBox chk, bool data)
        {
            if (chk.InvokeRequired)
            {
                chk.Invoke(new MethodInvoker(delegate ()
                {
                    chk.Checked = data;
                }));
            }
            else
            {
                chk.Checked = data;
            }
        }

        public static bool GetChecked_CheckBox(System.Windows.Forms.CheckBox chk)
        {
            bool result = false;
            if (chk.InvokeRequired)
            {
                chk.Invoke(new MethodInvoker(delegate ()
                {
                    result = chk.Checked;
                }));
            }
            else
            {
                result = chk.Checked;
            }

            return result;
        }
        #endregion

        #region [ ListBox ]
        public static void SetItem_ListBox(ListBox lb, string[] datas)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    foreach (string s in datas)
                    {
                        lb.Items.Add(s);
                    }
                }));
            }
            else
            {
                foreach (string s in datas)
                {
                    lb.Items.Add(s);
                }
            }
        }

        public static string GetSelectedItem_ListBox(ListBox lb)
        {
            string result = "";

            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    if (lb.SelectedItem != null)
                        result = lb.SelectedItem.ToString();
                }));
            }
            else
            {
                if (lb.SelectedItem != null)
                    result = lb.SelectedItem.ToString();
            }

            return result;
        }

        public static string[] GetItems_ListBox(ListBox lb)
        {
            string[] result = new string[lb.Items.Count];

            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    if (lb.Items.Count > 0)
                    {
                        for (int i = 0; i < lb.Items.Count; i++)
                            result[i] = lb.Items[i].ToString();
                    }
                }));
            }
            else
            {
                if (lb.Items.Count > 0)
                {
                    for (int i = 0; i < lb.Items.Count; i++)
                        result[i] = lb.Items[i].ToString();
                }
            }

            return result;
        }

        public static void ClearItems_ListBox(ListBox lb)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    lb.Items.Clear();
                }));
            }
            else
            {
                lb.Items.Clear();
            }
        }

        public static void SetSelectedItem_ListBox(ListBox lb, string itemName)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    lb.SelectedItem = itemName;
                }));
            }
            else
            {
                lb.SelectedItem = itemName;
            }
        }
        #endregion

        #region [ Label ]
        public static string GetText_Label(Label lb)
        {
            string result = "";

            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    result = lb.Text;
                }));
            }
            else
            {
                result = lb.Text;
            }
            return result;
        }
        public static void SetText_TEXT(TextBox lb, string data)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    lb.Text = data;
                }));
            }
            else
            {
                lb.Text = data;
            }
        }
        public static void SetText_Label(Label lb, string data)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    lb.Text = data;
                }));
            }
            else
            {
                lb.Text = data;
            }
        }

        public static void SetBackColor_Label(Label lb, Color color)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    lb.BackColor = color;
                }));
            }
            else
            {
                lb.BackColor = color;
            }
        }

        public static Color GetBackColor_Label(Label lb)
        {
            Color result = Color.Empty;
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    result = lb.BackColor;
                }));
            }
            else
            {
                result = lb.BackColor;
            }

            return result;
        }

        public static void SetForeColor_Label(Label lb, Color color)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    lb.ForeColor = color;
                }));
            }
            else
            {
                lb.ForeColor = color;
            }
        }

        public static Color GetForeColor_Label(Label lb)
        {
            Color result = Color.Empty;
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    result = lb.ForeColor;
                }));
            }
            else
            {
                result = lb.ForeColor;
            }

            return result;
        }

        public static void ClearText_Label(Label lb)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate ()
                {
                    lb.Text = "";
                }));
            }
            else
            {
                lb.Text = "";
            }
        }
        #endregion

        #region [ Button ]
        public static string GetText_Button(System.Windows.Forms.Button btn)
        {
            string result = "";
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (btn.InvokeRequired)
            {
                btn.Invoke(new MethodInvoker(delegate ()
                {
                    result = btn.Text;
                }));
            }
            else
            {
                result = btn.Text;
            }
            return result;
        }


        public static void SetText_Button(System.Windows.Forms.Button btn, string data)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke(new MethodInvoker(delegate ()
                {
                    btn.Text = data;
                }));
            }
            else
            {
                btn.Text = data;
            }
        }

        public static void SetBackColor_Button(System.Windows.Forms.Button btn, Color color)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke(new MethodInvoker(delegate ()
                {
                    btn.BackColor = color;
                }));
            }
            else
            {
                btn.BackColor = color;
            }
        }

        public static void ClearText_Button(System.Windows.Forms.Button btn)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke(new MethodInvoker(delegate ()
                {
                    btn.Text = "";
                }));
            }
            else
            {
                btn.Text = "";
            }
        }
        #endregion

        #region [ DataGridView ]
        public static void Clear_DataGridView(DataGridView dgv)
        {
            if (dgv.InvokeRequired)
            {
                dgv.Invoke(new MethodInvoker(delegate
                {
                    dgv.Rows.Clear();
                }));
            }
            else
            {
                dgv.Rows.Clear();
            }
        }
        #endregion

        #region [Tracbar]
        public static int GetValue_Tracbar(System.Windows.Forms.TrackBar trb)
        {
            int result = 0;
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (trb.InvokeRequired)
            {
                trb.Invoke(new MethodInvoker(delegate ()
                {
                    result = trb.Value;
                }));
            }
            else
            {
                result = trb.Value;
            }
            return result;
        }

        public static void SetValue_TrackBar(System.Windows.Forms.TrackBar trb, int value)
        {
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (trb.InvokeRequired)
            {
                trb.Invoke(new MethodInvoker(delegate ()
                {
                    trb.Value = value;
                }));
            }
            else
            {
                trb.Value = value;
            }
        }
        #endregion

        #region [Panel]
        public static IntPtr GetIntPtr_Panel(System.Windows.Forms.Panel panel)
        {
            IntPtr handle = IntPtr.Zero;
            // 생성된 스레드가 아닌 다른 스레드에서 호출될 경우 true
            if (panel.InvokeRequired)
            {
                panel.Invoke(new MethodInvoker(delegate ()
                {
                    handle = panel.Handle;
                }));
            }
            else
            {
                handle = panel.Handle;
            }
            return handle;
        }


        #endregion

        #region [HScrollBar]
        public static int GetValue_HScrollBar(HScrollBar hScrollBar)
        {
            int value = 0;

            if (hScrollBar.InvokeRequired)
            {
                hScrollBar.Invoke(new MethodInvoker(delegate
                {
                    value = hScrollBar.Value;
                }));
            }
            else
            {
                value = hScrollBar.Value;
            }

            return value;
        }

        public static void SetValue_HScrollBar(HScrollBar hScrollBar, int value)
        {
            if (hScrollBar.InvokeRequired)
            {
                hScrollBar.Invoke(new MethodInvoker(delegate
                {
                    hScrollBar.Value = value;
                }));
            }
            else
            {
                hScrollBar.Value = value;
            }
        }
        #endregion

        /*#region [GlassButton]
        public static void PerformClick_GlassButton(EnhancedGlassButton.GlassButton button)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new MethodInvoker(delegate
                {
                    button.PerformClick();
                }));
            }
            else
            {
                button.PerformClick();
            }
        }

        public static void SetBackColor_GlassButton(EnhancedGlassButton.GlassButton button, Color color)
        {
            try
            {
                if (button.InvokeRequired)
                {
                    button.Invoke(new MethodInvoker(delegate
                    {
                        button.BackColor = color;
                    }));
                }
                else
                {
                    button.BackColor = color;
                }
            }
            catch
            {

            }
        }
        #endregion*/
    }
}
