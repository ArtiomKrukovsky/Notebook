using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reader_Text_DB
{
    public interface IModelFileManager
    {
        string GetContent(string filepath);
        void SaveContent(string content, string filepath);
        bool IsExist(string filepath);
        int GetSymbolCount(string content);
    }
    public class FileManager: IModelFileManager
    {
        private readonly Encoding _defaultencoding = Encoding.GetEncoding(1251);

        public string GetContent(string filepath)
        {
            string content = File.ReadAllText(filepath, _defaultencoding);
            return content;
        }

        public void SaveContent(string content, string filepath)
        {
            File.WriteAllText(filepath, content, _defaultencoding);
        }

        public bool IsExist(string filepath)
        {
            bool isexist = File.Exists(filepath);
            return isexist;
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

    }
}
