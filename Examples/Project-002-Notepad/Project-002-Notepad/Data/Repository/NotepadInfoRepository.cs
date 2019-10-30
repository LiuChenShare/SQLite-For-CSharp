using Project_002_Notepad.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_002_Notepad.Data.Repository
{
    /// <summary>
    /// 笔记本仓储服务
    /// </summary>
    public class NotepadInfoRepository
    {
        private NotepadContext notepadContext = ContextManager.Instance.GetNotepadContext();

        public List<NotepadInfo> GetInfos()
        {
            return notepadContext.NotepadInfo.OrderByDescending(x =>x.CreateTime).ToList();
        }

        public bool SetInfo(string txt)
        {
            notepadContext.NotepadInfo.Add(new NotepadInfo
            {
                Id = Guid.NewGuid().ToString(),
                NotepadContent = txt,
                CreateTime = DateTime.Now
            });
            notepadContext.SaveChanges();
            return true;
        }
    }
}
