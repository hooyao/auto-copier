using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoCopier
{
    class Copier
    {
        private string _source = "";
        private string _target = "";
        private bool ifDel = true;

        public bool IfDel
        {
            get { return ifDel; }
            set { ifDel = value; }
        }

        public Copier(string source, string target)
        {
            this._source = source;
            this._target = target;
        }

        public void startCopy()
        {
            try
            {
                File.Copy(this._source, this._target,true);
                if (this.ifDel)
                    File.Delete(this._source);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
