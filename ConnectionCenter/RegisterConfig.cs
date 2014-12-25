﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//custom
using Microsoft.Win32;  //注册表操作

namespace ConnectionCenter
{
    public class RegisterConfig
    {
        private static string APPNAMEREG = "CityPlanning";  //在注册表中，本程序的名称为“LandResouces”
        private static string CONFIGFILEREG = "AppConfig";  //本软件初试配置路径


        //读取指定名称的注册表的值
        //读取的注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下的XXX目录中名称为name的注册表值；
        public static string GetConfigReg()
        {
            string registData = "";
            try
            {
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey(APPNAMEREG, true);
                registData = aimdir.GetValue(CONFIGFILEREG).ToString();
            }
            catch
            {
            }
            return registData;
        }


        //写入本软件的注册表项        
        public static void WriteAppReg()
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey(APPNAMEREG);
                //aimdir.SetValue(CONFIGFILEREG, tovalue);
            }
            catch
            {
            }
        }

        //写入配置文件注册表项        
        public static void WriteConfigReg(string configFilePath)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey(APPNAMEREG);
                aimdir.SetValue(CONFIGFILEREG, configFilePath);
            }
            catch
            {
            }
        }

        //删除注册表中指定的注册表项
        //在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中删除名称为name注册表项；
        public static void DeleteRegist()
        {
            try
            {
                string[] aimnames;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey(APPNAMEREG, true);
                aimnames = aimdir.GetSubKeyNames();
                foreach (string aimKey in aimnames)
                {
                    if (aimKey == CONFIGFILEREG)
                        aimdir.DeleteSubKeyTree(CONFIGFILEREG);
                }
            }
            catch
            {
            }
        }


        //判断指定注册表项是否存在
        public static bool IsRegeditExit()
        {
            bool _exit = false;
            string[] subkeyNames;
            try
            {
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey(APPNAMEREG, true);
                subkeyNames = aimdir.GetValueNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == CONFIGFILEREG)
                    {
                        _exit = true;
                        return _exit;
                    }
                }
            }
            catch
            {
            }
            return _exit;
        }

        //判断本软件的注册表项是否存在
        public static bool IsAppRegeditExit()
        {
            bool _exit = false;
            string[] subkeyNames;
            try
            {

                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                subkeyNames = software.GetSubKeyNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == APPNAMEREG)
                    {
                        _exit = true;
                        return _exit;
                    }
                }
            }
            catch
            {
            }
            return _exit;
        }
    }
}
