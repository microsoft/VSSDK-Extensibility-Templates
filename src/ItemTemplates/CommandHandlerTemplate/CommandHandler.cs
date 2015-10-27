using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text.Editor;
using OLEConstants = Microsoft.VisualStudio.OLE.Interop.Constants;
using System;

namespace $rootnamespace$
{
    internal sealed class $rootSafeItemName$ : IOleCommandTarget
    {
        private readonly IWpfTextView textView;

        public $rootSafeItemName$(IWpfTextView textView)
        {
            this.textView = textView;
        }

        public IOleCommandTarget Next { get; internal set; }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            // todo: Insert command handling here

            if (this.Next != null)
            {
                return this.Next.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            }

            return (int)OLEConstants.OLECMDERR_E_UNKNOWNGROUP;
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            // todo: Insert command handling registration here

            if (this.Next != null)
            {
                return this.Next.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
            }

            return (int)OLEConstants.OLECMDERR_E_UNKNOWNGROUP;
        }
    }
}
