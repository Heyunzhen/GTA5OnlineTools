﻿using GTA5OnlineTools.Models;
using GTA5OnlineTools.Views.Cheats;
using GTA5OnlineTools.Common.Utils;
using GTA5OnlineTools.Common.Helper;
using GTA5OnlineTools.Features.Core;

using CommunityToolkit.Mvvm.Input;

namespace GTA5OnlineTools.Views;

/// <summary>
/// CheatsView.xaml 的交互逻辑
/// </summary>
public partial class CheatsView : UserControl
{
    /// <summary>
    /// Third数据模型
    /// </summary>
    public CheatsModel CheatsModel { get; set; } = new();

    /// <summary>
    /// 第三方辅助功能开关点击命令
    /// </summary>
    public RelayCommand<string> CheatsClickCommand { get; private set; }
    /// <summary>
    /// 第三方辅助使用说明点击命令
    /// </summary>
    public RelayCommand<string> ReadMeClickCommand { get; private set; }
    /// <summary>
    /// 第三方辅助额外功能点击命令
    /// </summary>
    public RelayCommand<string> ExtraClickCommand { get; private set; }

    public RelayCommand FrameHideClickCommand { get; private set; }

    private readonly KiddionPage KiddionPage = new();
    private readonly GTAHaxPage GTAHaxPage = new();
    private readonly BincoHaxPage BincoHaxPage = new();
    private readonly LSCHaxPage LSCHaxPage = new();
    private readonly YimMenuPage YimMenuPage = new();

    public CheatsView()
    {
        InitializeComponent();
        this.DataContext = this;

        CheatsClickCommand = new(CheatsClick);
        ReadMeClickCommand = new(ReadMeClick);
        ExtraClickCommand = new(ExtraClick);

        FrameHideClickCommand = new(FrameHideClick);

        new Thread(CheckCheatsIsRun)
        {
            Name = "CheckCheatsIsRun",
            IsBackground = true
        }.Start();
    }

    /// <summary>
    /// 检查第三方辅助是否正在运行线程
    /// </summary>
    private void CheckCheatsIsRun()
    {
        while (MainWindow.IsAppRunning)
        {
            // 判断 Kiddion 是否运行
            CheatsModel.KiddionIsRun = ProcessUtil.IsAppRun("Kiddion");
            // 判断 GTAHax 是否运行
            CheatsModel.GTAHaxIsRun = ProcessUtil.IsAppRun("GTAHax");
            // 判断 BincoHax 是否运行
            CheatsModel.BincoHaxIsRun = ProcessUtil.IsAppRun("BincoHax");
            // 判断 LSCHax 是否运行
            CheatsModel.LSCHaxIsRun = ProcessUtil.IsAppRun("LSCHax");

            Thread.Sleep(1000);
        }
    }

    /// <summary>
    /// 点击第三方辅助开关按钮
    /// </summary>
    /// <param name="hackName"></param>
    private void CheatsClick(string hackName)
    {
        AudioUtil.PlayClickSound();

        if (ProcessUtil.IsGTA5Run())
        {
            switch (hackName)
            {
                case "Kiddion":
                    KiddionClick();
                    break;
                case "GTAHax":
                    GTAHaxClick();
                    break;
                case "BincoHax":
                    BincoHaxClick();
                    break;
                case "LSCHax":
                    LSCHaxClick();
                    break;
                case "YimMenu":
                    YimMenuClick();
                    break;
            }
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "未发现《GTA5》进程，请先运行《GTA5》游戏");
        }
    }

    /// <summary>
    /// 点击第三方辅助使用说明
    /// </summary>
    /// <param name="pageName"></param>
    private void ReadMeClick(string pageName)
    {
        switch (pageName)
        {
            case "KiddionPage":
                CheatsModel.FrameState = Visibility.Visible;
                CheatsModel.FrameContent = KiddionPage;
                break;
            case "GTAHaxPage":
                CheatsModel.FrameState = Visibility.Visible;
                CheatsModel.FrameContent = GTAHaxPage;
                break;
            case "BincoHaxPage":
                CheatsModel.FrameState = Visibility.Visible;
                CheatsModel.FrameContent = BincoHaxPage;
                break;
            case "LSCHaxPage":
                CheatsModel.FrameState = Visibility.Visible;
                CheatsModel.FrameContent = LSCHaxPage;
                break;
            case "YimMenuPage":
                CheatsModel.FrameState = Visibility.Visible;
                CheatsModel.FrameContent = YimMenuPage;
                break;
        }
    }

    /// <summary>
    /// 点击第三方辅助配置文件路径
    /// </summary>
    /// <param name="funcName"></param>
    private void ExtraClick(string funcName)
    {
        AudioUtil.PlayClickSound();

        switch (funcName)
        {
            #region Kiddion增强功能
            case "KiddionKey104":
                KiddionKey104Click();
                break;
            case "KiddionKey87":
                KiddionKey87Click();
                break;
            case "KiddionChsON":
                KiddionChsONClick();
                break;
            case "KiddionChsOFF":
                KiddionChsOFFClick();
                break;
            case "KiddionConfigDirectory":
                KiddionConfigDirectoryClick();
                break;
            case "KiddionScriptsDirectory":
                KiddionScriptsDirectoryClick();
                break;
            case "EditKiddionConfig":
                EditKiddionConfigClick();
                break;
            case "EditKiddionTheme":
                EditKiddionThemeClick();
                break;
            case "EditKiddionTP":
                EditKiddionTPClick();
                break;
            case "EditKiddionVC":
                EditKiddionVCClick();
                break;
            #endregion
            ////////////////////////////////////
            #region 其他增强功能
            case "EditGTAHaxStat":
                EditGTAHaxStatClick();
                break;
            case "BigBaseV2Directory":
                BigBaseV2DirectoryClick();
                break;
            #endregion
            ////////////////////////////////////
            default:
                break;
        }
    }

    /// <summary>
    /// 使用说明隐藏按钮点击事件
    /// </summary>
    private void FrameHideClick()
    {
        CheatsModel.FrameState = Visibility.Collapsed;
        CheatsModel.FrameContent = null;
    }

    #region 第三方辅助功能开关事件
    /// <summary>
    /// Kiddion点击事件
    /// </summary>
    private void KiddionClick()
    {
        bool isRun = false;

        Task.Run(() =>
        {
            if (CheatsModel.KiddionIsRun)
            {
                // 先关闭Kiddion汉化程序
                ProcessUtil.CloseProcess("Kiddion_Chs");
                // 如果Kiddion没有运行则打开Kiddion
                if (!ProcessUtil.IsAppRun("Kiddion"))
                    ProcessUtil.OpenProcess("Kiddion", true);

                do
                {
                    // 等待Kiddion启动
                    if (ProcessUtil.IsAppRun("Kiddion"))
                    {
                        // Kiddion进程启动标志
                        isRun = true;
                        // Kiddion菜单界面显示标志
                        bool isShow = false;
                        do
                        {
                            // 拿到Kiddion进程
                            var pKiddion = Process.GetProcessesByName("Kiddion").ToList()[0];
                            // 获取Kiddion窗口句柄
                            var caption_handle = Win32.FindWindowEx(pKiddion.MainWindowHandle, IntPtr.Zero, "Static", null);

                            var length = Win32.GetWindowTextLength(caption_handle);
                            var windowName = new StringBuilder(length + 1);
                            Win32.GetWindowText(caption_handle, windowName, windowName.Capacity);

                            if (windowName.ToString() == "Kiddion's Modest Menu v0.9.6")
                            {
                                isShow = true;
                                ProcessUtil.OpenProcess("Kiddion_Chs", true);
                            }
                            else
                            {
                                isShow = false;
                            }

                            Task.Delay(100).Wait();
                        } while (!isShow);
                    }
                    else
                    {
                        isRun = false;
                    }

                    Task.Delay(250).Wait();
                } while (!isRun);
            }
            else
            {
                ProcessUtil.CloseProcess("Kiddion");
                ProcessUtil.CloseProcess("Kiddion_Chs");
            }
        });

        Task.Run(() =>
        {
            // 模拟任务超时
            Task.Delay(5000);
            isRun = true;
        });
    }

    /// <summary>
    /// GTAHax点击事件
    /// </summary>
    private void GTAHaxClick()
    {
        if (CheatsModel.GTAHaxIsRun)
            ProcessUtil.OpenProcess("GTAHax", false);
        else
            ProcessUtil.CloseProcess("GTAHax");
    }

    /// <summary>
    /// BincoHax点击事件
    /// </summary>
    private void BincoHaxClick()
    {
        if (CheatsModel.BincoHaxIsRun)
            ProcessUtil.OpenProcess("BincoHax", false);
        else
            ProcessUtil.CloseProcess("BincoHax");
    }

    /// <summary>
    /// LSCHax点击事件
    /// </summary>
    private void LSCHaxClick()
    {
        if (CheatsModel.LSCHaxIsRun)
            ProcessUtil.OpenProcess("LSCHax", false);
        else
            ProcessUtil.CloseProcess("LSCHax");
    }

    /// <summary>
    /// YimMenu点击事件
    /// </summary>
    private void YimMenuClick()
    {
        var _DLLPath = FileUtil.D_Inject_Path + "YimMenu.dll";

        if (!File.Exists(_DLLPath))
        {
            NotifierHelper.Show(NotifierType.Error, "发生异常，YimMenu菜单DLL文件不存在");
            return;
        }

        foreach (ProcessModule module in Process.GetProcessById(Memory.GTA5ProId).Modules)
        {
            if (module.FileName == _DLLPath)
            {
                NotifierHelper.Show(NotifierType.Warning, "该DLL已经被注入过了，请勿重复注入");
                return;
            }
        }

        try
        {
            BaseInjector.DLLInjector(Memory.GTA5ProId, _DLLPath);
            Memory.SetForegroundWindow();
            NotifierHelper.Show(NotifierType.Success, "YimMenu注入成功，请前往游戏查看");
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }
    #endregion

    #region Kiddion增强功能
    /// <summary>
    /// 启用Kiddion[104键]
    /// </summary>
    private void KiddionKey104Click()
    {
        ProcessUtil.CloseProcess("Kiddion");
        ProcessUtil.CloseProcess("Kiddion_Chs");
        FileUtil.ExtractResFile(FileUtil.Resource_Kiddion_Path + "config.json", FileUtil.D_Kiddion_Path + "config.json");
        NotifierHelper.Show(NotifierType.Success, "切换到《Kiddion [104键]》成功");
    }

    /// <summary>
    /// 启用Kiddion[87键]
    /// </summary>
    private void KiddionKey87Click()
    {
        ProcessUtil.CloseProcess("Kiddion");
        ProcessUtil.CloseProcess("Kiddion_Chs");
        FileUtil.ExtractResFile(FileUtil.Resource_Kiddion_Path + "key87.config.json", FileUtil.D_Kiddion_Path + "config.json");
        NotifierHelper.Show(NotifierType.Success, "切换到《Kiddion [87键]》成功");
    }

    /// <summary>
    /// 启用Kiddion汉化
    /// </summary>
    private void KiddionChsONClick()
    {
        if (ProcessUtil.IsAppRun("Kiddion"))
        {
            ProcessUtil.CloseProcess("Kiddion_Chs");
            ProcessUtil.OpenProcess("Kiddion_Chs", true);
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请先启动《Kiddion》程序");
        }
    }

    /// <summary>
    /// 关闭Kiddion汉化
    /// </summary>
    private void KiddionChsOFFClick()
    {
        if (ProcessUtil.IsAppRun("Kiddion_Chs"))
        {
            ProcessUtil.CloseProcess("Kiddion_Chs");
            NotifierHelper.Show(NotifierType.Success, "关闭《Kiddion汉化》成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Notification, "未发现《Kiddion汉化》进程");
        }
    }

    /// <summary>
    /// Kiddion配置目录
    /// </summary>
    private void KiddionConfigDirectoryClick()
    {
        ProcessUtil.OpenPath(FileUtil.D_Kiddion_Path);
    }

    /// <summary>
    /// Kiddion脚本目录
    /// </summary>
    private void KiddionScriptsDirectoryClick()
    {
        ProcessUtil.OpenPath(FileUtil.D_KiddionScripts_Path);
    }

    /// <summary>
    /// 编辑Kiddion配置文件
    /// </summary>
    private void EditKiddionConfigClick()
    {
        ProcessUtil.Notepad2EditTextFile(FileUtil.D_Kiddion_Path + "config.json");
    }

    /// <summary>
    /// 编辑Kiddion主题文件
    /// </summary>
    private void EditKiddionThemeClick()
    {
        ProcessUtil.Notepad2EditTextFile(FileUtil.D_Kiddion_Path + "themes.json");
    }

    /// <summary>
    /// 编辑Kiddion自定义传送
    /// </summary>
    private void EditKiddionTPClick()
    {
        ProcessUtil.Notepad2EditTextFile(FileUtil.D_Kiddion_Path + "teleports.json");
    }

    /// <summary>
    /// 编辑Kiddion自定义载具
    /// </summary>
    private void EditKiddionVCClick()
    {
        ProcessUtil.Notepad2EditTextFile(FileUtil.D_Kiddion_Path + "vehicles.json");
    }
    #endregion

    #region 其他增强功能
    /// <summary>
    /// 编辑GTAHax导入文件
    /// </summary>
    private void EditGTAHaxStatClick()
    {
        ProcessUtil.Notepad2EditTextFile(FileUtil.F_GTAHaxStat_Path);
    }

    /// <summary>
    /// BigBaseV2配置目录
    /// </summary>
    private void BigBaseV2DirectoryClick()
    {
        ProcessUtil.OpenPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/BigBaseV2/");
    }
    #endregion
}
