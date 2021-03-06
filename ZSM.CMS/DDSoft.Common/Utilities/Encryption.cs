﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DDSoft.Common.Utilities
{
    /// <summary>
    /// 文件加密类
    /// </summary>
    //public class FileEncrypt
    //{
    //    #region 变量
    //    /// <summary>
    //    /// 一次处理的明文字节数
    //    /// </summary>
    //    public static readonly int encryptSize = 10000000;
    //    /// <summary>
    //    /// 一次处理的密文字节数
    //    /// </summary>
    //    public static readonly int decryptSize = 10000016;
    //    #endregion
    //    #region 加密文件
    //    /// <summary>
    //    /// 加密文件
    //    /// </summary>
    //    public static void EncryptFile(string path, string pwd, RefreshFileProgress refreshFileProgress)
    //    {
    //        try
    //        {
    //            if (File.Exists(path + ".temp")) File.Delete(path + ".temp");
    //            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    //            {
    //                if (fs.Length > 0)
    //                {
    //                    using (FileStream fsnew = new FileStream(path + ".temp", FileMode.OpenOrCreate, FileAccess.Write))
    //                    {
    //                        if (File.Exists(path + ".temp")) File.SetAttributes(path + ".temp", FileAttributes.Hidden);
    //                        int blockCount = ((int)fs.Length - 1) / encryptSize + 1;
    //                        for (int i = 0; i < blockCount; i++)
    //                        {
    //                            int size = encryptSize;
    //                            if (i == blockCount - 1) size = (int)(fs.Length - i * encryptSize);
    //                            byte[] bArr = new byte[size];
    //                            fs.Read(bArr, 0, size);
    //                            byte[] result = AES.AESEncrypt(bArr, pwd);
    //                            fsnew.Write(result, 0, result.Length);
    //                            fsnew.Flush();
    //                            refreshFileProgress(blockCount, i + 1); //更新进度
    //                        }
    //                        fsnew.Close();
    //                        fsnew.Dispose();
    //                    }
    //                    fs.Close();
    //                    fs.Dispose();
    //                    FileAttributes fileAttr = File.GetAttributes(path);
    //                    File.SetAttributes(path, FileAttributes.Archive);
    //                    File.Delete(path);
    //                    File.Move(path + ".temp", path);
    //                    File.SetAttributes(path, fileAttr);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.Delete(path + ".temp");
    //            throw ex;
    //        }
    //    }
    //    #endregion
    //    #region 解密文件
    //    /// <summary>
    //    /// 解密文件
    //    /// </summary>
    //    public static void DecryptFile(string path, string pwd, RefreshFileProgress refreshFileProgress)
    //    {
    //        try
    //        {
    //            if (File.Exists(path + ".temp")) File.Delete(path + ".temp");
    //            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    //            {
    //                if (fs.Length > 0)
    //                {
    //                    using (FileStream fsnew = new FileStream(path + ".temp", FileMode.OpenOrCreate, FileAccess.Write))
    //                    {
    //                        if (File.Exists(path + ".temp")) File.SetAttributes(path + ".temp", FileAttributes.Hidden);
    //                        int blockCount = ((int)fs.Length - 1) / decryptSize + 1;
    //                        for (int i = 0; i < blockCount; i++)
    //                        {
    //                            int size = decryptSize;
    //                            if (i == blockCount - 1) size = (int)(fs.Length - i * decryptSize);
    //                            byte[] bArr = new byte[size];
    //                            fs.Read(bArr, 0, size);
    //                            byte[] result = AES.AESDecrypt(bArr, pwd);
    //                            fsnew.Write(result, 0, result.Length);
    //                            fsnew.Flush();
    //                            refreshFileProgress(blockCount, i + 1); //更新进度
    //                        }
    //                        fsnew.Close();
    //                        fsnew.Dispose();
    //                    }
    //                    fs.Close();
    //                    fs.Dispose();
    //                    FileAttributes fileAttr = File.GetAttributes(path);
    //                    File.SetAttributes(path, FileAttributes.Archive);
    //                    File.Delete(path);
    //                    File.Move(path + ".temp", path);
    //                    File.SetAttributes(path, fileAttr);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.Delete(path + ".temp");
    //            throw ex;
    //        }
    //    }
    //    #endregion
    //}

    //public delegate void RefreshFileProgress(int max, int value);
}
