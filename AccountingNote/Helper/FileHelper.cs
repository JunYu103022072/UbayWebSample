using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AccountingNote.Helper
{
    public class FileHelper
    {
        private const int _mbs = 10;
        private const int _maxLength = _mbs * 1024 * 1024;
        private static string[] _allowFileExt = { ".bmp", ".jpg", ".png" };

        /// <summary> 換新檔名 </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public static string GetNewFileName(FileUpload fileUpload)
        {
            //重名 解一:
            System.Threading.Thread.Sleep(4);
            //重名 解二:
            string seqText = new Random((int)DateTime.Now.Ticks).Next(0, 1000).ToString().PadLeft(3, '0');

            string orgFileName = fileUpload.FileName;
            string ext = System.IO.Path.GetExtension(orgFileName);
            string newFIleName = DateTime.Now.ToString("yyMMddHHmmssFFFFFF") + seqText + ext;
            return newFIleName;
        }
        /// <summary> 驗證上傳的檔案 </summary>
        /// <param name="fileUpload"></param>
        /// <param name="msgList"></param>
        /// <returns></returns>
        public static bool ValidFileUpload(FileUpload fileUpload, out List<string> msgList)
        {
            msgList = new List<string>();
            if (!ValidFileExt(fileUpload.FileName))
            {
                msgList.Add("Only allow .jpg , .bmp , .png");
            }
            if (!ValidFileLength(fileUpload.FileBytes))
            {
                msgList.Add($"Only allow length : {_mbs} MB");
            }
            if (msgList.Any())
            {
                return false;
            }
            else
                return true;
        }
        /// <summary> 驗證檔案大小為 10mbs </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        public static bool ValidFileLength(byte[] fileContent)
        {
            if (fileContent.Length > _maxLength)
                return false;
            else
                return true;
        }
        /// <summary> 驗證副檔名 </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool ValidFileExt(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);

            if (!_allowFileExt.Contains(ext.ToLower()))
                return false;
            else
                return true;
        }
    }
}