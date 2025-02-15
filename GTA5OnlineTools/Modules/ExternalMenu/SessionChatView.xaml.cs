﻿using GTA5OnlineTools.Common.Utils;
using GTA5OnlineTools.Common.Helper;
using GTA5OnlineTools.Features.SDK;
using GTA5OnlineTools.Features.Core;

using Chinese;
using RestSharp;
using Forms = System.Windows.Forms;

namespace GTA5OnlineTools.Modules.ExternalMenu;

/// <summary>
/// SessionChatView.xaml 的交互逻辑
/// </summary>
public partial class SessionChatView : UserControl
{
    private const string youdaoAPI = "http://fanyi.youdao.com/translate?&doctype=json&type=AUTO&i=";

    public SessionChatView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        TextBox_InputMessage.Text = "测试文本: 请把游戏中聊天输入法调成英文,否则会漏掉文字.Hello1234,漏掉文字了吗?";
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {
        
    }

    private void Button_Translate_Click(object sender, RoutedEventArgs e)
    {
        AudioUtil.PlayClickSound();

        try
        {
            var message = TextBox_InputMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                var btnContent = (e.OriginalSource as Button).Content.ToString();

                switch (btnContent)
                {
                    case "中英互译":
                        YouDaoTranslation(message);
                        break;
                    case "简转繁":
                        TextBox_InputMessage.Text = ChineseConverter.ToTraditional(message);
                        break;
                    case "繁转简":
                        TextBox_InputMessage.Text = ChineseConverter.ToSimplified(message);
                        break;
                    case "转拼音":
                        TextBox_InputMessage.Text = Pinyin.GetString(message, PinyinFormat.WithoutTone);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    private void Button_SendTextToGTA5_Click(object sender, RoutedEventArgs e)
    {
        AudioUtil.PlayClickSound();

        try
        {
            if (TextBox_InputMessage.Text != "")
            {
                TextBox_InputMessage.Text = ToDBC(TextBox_InputMessage.Text);

                Memory.SetForegroundWindow();
                SendMessageToGTA5(TextBox_InputMessage.Text);
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    /// <summary>
    /// 模拟键盘按键
    /// </summary>
    /// <param name="winVK"></param>
    private void KeyPress(WinVK winVK)
    {
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        Win32.Keybd_Event(winVK, Win32.MapVirtualKey(winVK, 0), 0, 0);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        Win32.Keybd_Event(winVK, Win32.MapVirtualKey(winVK, 0), 2, 0);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
    }

    /// <summary>
    /// 发送消息到GTA5游戏
    /// </summary>
    /// <param name="str"></param>
    private void SendMessageToGTA5(string str)
    {
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));

        KeyPress(WinVK.RETURN);

        if (RadioButton_PressKeyT.IsChecked == true)
            KeyPress(WinVK.T);
        else
            KeyPress(WinVK.Y);

        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));
        Forms.SendKeys.Flush();
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        Forms.SendKeys.SendWait(str);
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep2.Value));
        Forms.SendKeys.Flush();
        Thread.Sleep(Convert.ToInt32(Slider_SendKey_Sleep1.Value));

        KeyPress(WinVK.RETURN);
        KeyPress(WinVK.RETURN);
    }

    /// <summary>
    /// 调用有道翻译中英互译API
    /// </summary>
    /// <param name="message"></param>
    private async void YouDaoTranslation(string message)
    {
        try
        {
            var stringBuilder = new StringBuilder();

            var options = new RestClientOptions(youdaoAPI + message)
            {
                MaxTimeout = 5000,
                FollowRedirects = true
            };
            var client = new RestClient(options);

            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rb = JsonUtil.JsonDese<ReceiveObj>(response.Content);

                foreach (var item in rb.translateResult)
                {
                    foreach (var t in item)
                    {
                        stringBuilder.Append(t.tgt);
                    }
                }

                TextBox_InputMessage.Text = stringBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    private void TextBox_InputMessage_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            e.Handled = true;
            Button_SendTextToGTA5_Click(null, null);
        }
    }

    /// <summary>
    /// 全角字符转半角字符
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string ToDBC(string input)
    {
        char[] c = input.ToCharArray();

        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 12288)
            {
                c[i] = (char)32;
                continue;
            }

            if (c[i] > 65280 && c[i] < 65375)
            {
                c[i] = (char)(c[i] - 65248);
            }
        }

        return new string(c);
    }
}

public class ReceiveObj
{
    public string type { get; set; }
    public int errorCode { get; set; }
    public int elapsedTime { get; set; }
    public List<List<TranslateResultItemItem>> translateResult { get; set; }
    public class TranslateResultItemItem
    {
        public string src { get; set; }
        public string tgt { get; set; }
    }
}
