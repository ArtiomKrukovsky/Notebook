using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader_Text_DB;

namespace Reader_Text
{
    class Presentor
    {
        private readonly IMainView _view;
        private readonly IModelFileManager _model;
        string _currantfilePath = null;

        public Presentor(IMainView view, IModelFileManager model)
        {
            _view = view;
            _model = model;
            _view.SetCount(0);
            _view.ContentChanget += _view_ContentChanget;
            _view.Btn_Open += _view_Btn_Open;
            _view.Btn_Save += _view_Btn_Save;
        }

        private void _view_Btn_Save(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;
                _model.SaveContent(content, _currantfilePath);
            }
            catch { }
        }

        private void _view_Btn_Open(object sender, EventArgs e)
        {
            try
            {
                string filepath = _view.FilePath;
                if (!_model.IsExist(filepath))
                    return;
                _currantfilePath = filepath;
                string content = _model.GetContent(filepath);
                int count = _model.GetSymbolCount(content);
                _view.Content = content;
                _view.SetCount(count);
            }
            catch
            {
            }
        }

        private void _view_ContentChanget(object sender, EventArgs e)
        {
            string content = _view.Content;
            int count = _model.GetSymbolCount(content);
            _view.SetCount(count);
        }
    }
}
